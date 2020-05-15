using Nejman.NSEC2;
using Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newtone.Core.Processing
{
    public static class SyncProcessing
    {
        public static List<string> Audios { get; private set; } = new List<string>();
        private static readonly int port = 9050; //transfer}
        private static MemoryStream currentBuffer;
        private static Task task;
        private static Task receiverTask;
        public static double Progress { get; private set; } = 0;
        public static double Size { get; private set; } = 0;
        public static int FilesReceived { get; private set; } = 0;
        public static int CurrentFileReceived { get; private set; } = 0;
        public static string CurrentFileName { get; private set; } = "";
        public static IPAddress CurrentConnectionIp { get; private set; }
        public static int SocketMode { get; private set; } = 0;
        public static Socket CurrentConnection { get; private set; }
        public static int State { get; private set; } = 0;
        public static bool Started { get; private set; } = false;
        private const int BufferSize = 65536;
        private const int MessSize = 1024;
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private static IPAddress IpAddress
        {
            get
            {
                return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            }
        }

        public static string Code
        {
            get
            {
                return ToHex(IpAddress);
            }
        }

        public static void Connect(string code)
        {
            if(Verify(code))
            {
                CurrentConnectionIp = FromHex(code);
                CurrentConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    SendTimeout = 100
                };
                CurrentConnection.Connect(CurrentConnectionIp, port);
            }
        }

        public static void ListenReceiver()
        {
            if(receiverTask == null)
            {
                receiverTask = new Task(() =>
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    State = 0;
                    try
                    {
                        Console.WriteLine("SYNC Binding");
                        socket.Bind(new IPEndPoint(IpAddress, port));
                        socket.Listen(10);
                        //socket.Connect(FromHex(code), port);
                        //socket.Send(Encoding.ASCII.GetBytes(GlobalData.SYNC_CODE));
                        //socket.Disconnect(true);

                        byte[] buffer = new byte[BufferSize];
                        Console.WriteLine("SYNC Waiting");
                        Socket client = socket.Accept();

                        Console.WriteLine("SYNC Accepted");
                        CurrentConnectionIp = (client.RemoteEndPoint as IPEndPoint).Address;
                        CurrentConnection = client;
                    }
                    catch
                    {

                    }

                    receiverTask = null;
                });
                receiverTask.Start();
            }
        }

        public static void Receive()
        {
            if(task == null)
            {
                task = new Task(() =>
                {
                    Console.WriteLine("SYNC Start");
                    Started = true;
                    SocketMode = 1;
                    //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    State = 0;
                    try
                    {
                        byte[] buffer = new byte[BufferSize];

                        int packetType = 0;
                        int dataLength = 0;

                        currentBuffer = new MemoryStream();
                        Progress = 0;
                        CurrentFileName = "";
                        CurrentFileReceived = 0;
                        FilesReceived = 0;

                        while (true)
                        {
                            int numByte = CurrentConnection.Receive(buffer);
                            if (numByte > 0)
                            {
                                if (packetType == 0)
                                {
                                    dataLength = int.Parse(Encoding.ASCII.GetString(buffer, 0, numByte));
                                    Size = dataLength / 1024 / 1024;
                                    //Console.WriteLine("SYNC dataLength = " + dataLength);
                                    CurrentConnection.Send(Encoding.ASCII.GetBytes(GlobalData.RECEIVED_MESSAGE));
                                    packetType = 1;
                                }
                                else if (packetType == 1)
                                {
                                    long numByte1 = numByte;
                                    if (currentBuffer.Length + numByte > dataLength)
                                        numByte1 = dataLength - currentBuffer.Length;
                                    currentBuffer.Write(buffer, 0, (int)numByte1);
                                    Progress = currentBuffer.Length / 1024 / 1024;
                                    CurrentConnection.Send(Encoding.ASCII.GetBytes(GlobalData.RECEIVED_MESSAGE));
                                }

                                //Console.WriteLine("SYNC "+currentBuffer.Length+" "+dataLength);

                                if (currentBuffer.Length >= dataLength)
                                {
                                    Console.WriteLine("Buffer: " + currentBuffer.Length + " data: " + dataLength);
                                    Console.WriteLine("SYNC Close");
                                    CurrentConnection.Send(Encoding.ASCII.GetBytes(GlobalData.SYNC_COMPLETED));
                                    CurrentConnection.Close();
                                    Console.WriteLine("SYNC Closed");
                                    break;
                                }
                            }
                        }
                        //File.WriteAllBytes(GlobalData.MusicPath + "/mobile.nsec2", currentBuffer.ToArray());
                        State = 1;
                        Unpack(currentBuffer);
                        State = 2;

                        Audios.Clear();
                    }
                    catch
                    {
                        if (CurrentConnection.Connected)
                            CurrentConnection.Disconnect(false);
                        CurrentConnection.Close();
                    }
                    currentBuffer.Close();
                    SocketMode = 0;
                    Started = false;
                    task = null;
                });
                task.Start();
            }
            
            
        }

        public static void Send()
        {
            if (task != null)
                task = null;

            task = new Task(() =>
            {
                Started = true;
                SocketMode = 2;
                Console.WriteLine("SYNC Verified");
                byte[] bufferData = PrepareFilesToSend(Audios);
                //File.WriteAllBytes(GlobalData.MusicPath + "/desktop.nsec2", bufferData);
                byte[] bufferLength = Encoding.ASCII.GetBytes(bufferData.Length.ToString());
                byte[] receiveBuffer = new byte[MessSize];

                try
                {
                    int bytesSent1 = CurrentConnection.Send(bufferLength);

                    byte[] buffer = new byte[BufferSize];
                    int bytesR = CurrentConnection.Receive(receiveBuffer);
                    Console.WriteLine("SYNC bytesR = " + bytesR);

                    string message = Encoding.ASCII.GetString(receiveBuffer, 0, bytesR);
                    Console.WriteLine(message);

                    if (message.Contains(GlobalData.RECEIVED_MESSAGE))
                    {
                        MemoryStream memoryStream = new MemoryStream(bufferData);
                        int read;
                        int progress = 0;
                        while ((read = memoryStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            //Console.WriteLine("SYNC read = " + read);
                            CurrentConnection.Send(buffer);
                            progress += read;
                            Progress = bufferData.Length == 0 ? 0.0d : ((((double)progress) / ((double)bufferData.Length)) * 100.0d);

                            //Console.WriteLine("Sync Receive");
                            bytesR = CurrentConnection.Receive(receiveBuffer);
                        }
                    }
                    else
                        throw new Exception("invalid message");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    GlobalData.MediaPlayer.Error(GlobalData.ERROR_CONNECTION);
                    if (CurrentConnection.Connected)
                        CurrentConnection.Disconnect(false);
                    CurrentConnection.Close();
                }
                SocketMode = 0;
                Started = false;
            });
            task.Start();
        }

        public static void AddFile(string filepath)
        {
            if (!Audios.Contains(filepath))
                Audios.Add(filepath);
        }

        public static void AddFiles(IEnumerable<string> files)
        {
            foreach (string file in files)
            {
                AddFile(file);
            }
        }

        private static byte[] PrepareFilesToSend(List<string> files)
        {
            NSEC2 nsec = new NSEC2(GlobalData.PASSWORD);
            nsec.SetDebug(false);
            string audiosListBuffer = "";
            string audioTagsBuffer = "";
            int counter = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                audiosListBuffer += fileInfo.Name + "\n";
                if (GlobalData.AudioTags.ContainsKey(file))
                {
                    MediaSourceTag mediaSource = GlobalData.AudioTags[file];

                    string name = "image" + counter;
                    nsec.AddFile(name, mediaSource.Image ?? (new byte[0]));

                    string bufferItem = fileInfo.Name + GlobalData.SEPARATOR + mediaSource.Author + GlobalData.SEPARATOR + mediaSource.Title + GlobalData.SEPARATOR + name;

                    if (!string.IsNullOrWhiteSpace(mediaSource.Id))
                        bufferItem += GlobalData.SEPARATOR + mediaSource.Id;

                    bufferItem += "\n";
                    audioTagsBuffer += bufferItem;
                    counter += 1;
                }

                nsec.AddFile(fileInfo.Name, File.ReadAllBytes(file));
            }

            nsec.AddFile("list", Encoding.UTF8.GetBytes(audiosListBuffer));
            nsec.AddFile("tags", Encoding.UTF8.GetBytes(audioTagsBuffer));

            return nsec.Save();
        }

        private static void Unpack(MemoryStream stream)
        {
            Console.WriteLine("Unpack");
            NSEC2 nsec = new NSEC2(GlobalData.PASSWORD);
            Console.WriteLine("Unpack load");
            nsec.SetDebug(true);
            nsec.Load(stream);
            Console.WriteLine("Unpack loaded");
            

            string tagsBuffer = Encoding.UTF8.GetString(nsec.Get("tags"));
            string filesBuffer = Encoding.UTF8.GetString(nsec.Get("list"));

            //Console.WriteLine("Unpack " + tagsBuffer + " " + filesBuffer);
            foreach(string bufferItem in tagsBuffer.Split("\n",StringSplitOptions.RemoveEmptyEntries))
            {
                //Console.WriteLine("Unpack " + bufferItem);
                string[] elems = bufferItem.Split(GlobalData.SEPARATOR);
                string name = new FileInfo(GlobalData.MusicPath + "/" + elems[0]).FullName;
                Console.WriteLine(name);
                string author = elems[1];
                string title = elems[2];
                string imageName = elems[3];
                MediaSourceTag newTag = new MediaSourceTag
                {
                    Author = author,
                    Id = elems.Length > 4 ? elems[4] : "",
                    Image = nsec.Get(imageName).Length > 0 ? nsec.Get(imageName) : null,
                    Title = title
                };

                if (GlobalData.AudioTags.ContainsKey(name))
                    GlobalData.AudioTags[name] = newTag;
                else
                    GlobalData.AudioTags.Add(name, newTag);
            }
            string[] files = filesBuffer.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            FilesReceived = files.Length;

            for(int a = 0; a < files.Length; a++)
            {
                string file = files[a];

                FileInfo info = new FileInfo(GlobalData.MusicPath + "/" + file);
                CurrentFileName = file;
                CurrentFileReceived = a;
                //Console.WriteLine("Unpack " + info.FullName);
                File.WriteAllBytes(info.FullName, nsec.Get(file));
            }

            GlobalData.SaveTags();
        }

        private static string ToHex(IPAddress addr)
        {
            string c1 = ((int)addr.GetAddressBytes()[0]).ToString("X").PadLeft(2, '0');
            string c2 = ((int)addr.GetAddressBytes()[1]).ToString("X").PadLeft(2, '0');
            string c3 = ((int)addr.GetAddressBytes()[2]).ToString("X").PadLeft(2, '0');
            string c4 = ((int)addr.GetAddressBytes()[3]).ToString("X").PadLeft(2, '0');
            return $"{c1}{c2}{c3}{c4}";
        }

        private static IPAddress FromHex(string hex)
        {
            string h1 = hex[0].ToString() + hex[1].ToString();
            string h2 = hex[2].ToString() + hex[3].ToString();
            string h3 = hex[4].ToString() + hex[5].ToString();
            string h4 = hex[6].ToString() + hex[7].ToString();

            return new IPAddress(new byte[] { (byte)int.Parse(h1, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h2, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h3, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h4, System.Globalization.NumberStyles.HexNumber) });
        }

        public static bool Verify(string hex)
        {
            if (hex.Length != 8)
                return false;
            string availableChars = "abcdefABCDEF1234567890";

            foreach (char c in hex)
            {
                if (!availableChars.Contains(c))
                    return false;
            }

            return true;
        }

        public static bool ChceckEnabled(bool started, int mode, bool connection)
        {
            return Started == started && SocketMode == mode && (CurrentConnection != null) == connection;
        }
    }
}
