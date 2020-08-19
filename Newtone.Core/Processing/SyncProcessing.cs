using Nejman.NSEC2;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
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
        #region Fields
        private static readonly int port = 9050; //transfer}
        private static MemoryStream currentBuffer;
        private static Task task;
        private static Task receiverTask;
        private const int BufferSize = 65536;
        private const int MessSize = 1024;
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        #endregion
        #region Properties
        public static List<string> Audios { get; private set; } = new List<string>();
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
        public static Action ReceivingAction { get; set; }
        public static string PlaylistName { get; set; }
        public static List<string> ReceivedTracks { get; private set; }

        private static IPAddress IpAddress
        {
            get
            {
                IPAddress tempAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                foreach (var item in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (item.AddressFamily == AddressFamily.InterNetwork)
                    {
                        tempAddress = item;
                        break;
                    }
                }
                return tempAddress;
            }
        }

        public static string Code
        {
            get
            {
                return ToHex(IpAddress);
            }
        }
        #endregion
        #region Public Methods
        public static void Connect(string code)
        {
            if(Verify(code))
            {
                try
                {
                    CurrentConnectionIp = FromHex(code);
                    CurrentConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                    {
                        SendTimeout = 100
                    };
                    CurrentConnection.Connect(CurrentConnectionIp, port);
                }
                catch(Exception e)
                {
                    ConsoleDebug.WriteLine("[SYNC ERROR] "+e);
                    Disconnect();
                }
            }
        }

        public static void Disconnect()
        {
            CurrentConnectionIp = null;
            if(CurrentConnection != null)
            {
                CurrentConnection.Close();
                CurrentConnection.Dispose();
                CurrentConnection = null;
            }
            SocketMode = 0;
            State = 0;
            Started = false;
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
                        ConsoleDebug.WriteLine("SYNC Binding "+IpAddress);
                        socket.Bind(new IPEndPoint(IpAddress, port));
                        socket.Listen(10);
                        //socket.Connect(FromHex(code), port);
                        //socket.Send(Encoding.ASCII.GetBytes(GlobalData.Current.SYNC_CODE));
                        //socket.Disconnect(true);

                        byte[] buffer = new byte[BufferSize];
                        ConsoleDebug.WriteLine("SYNC Waiting");
                        Socket client = socket.Accept();

                        ConsoleDebug.WriteLine("SYNC Accepted");
                        CurrentConnectionIp = (client.RemoteEndPoint as IPEndPoint).Address;
                        CurrentConnection = client;
                    }
                    catch(Exception e)
                    {
                        ConsoleDebug.WriteLine("[SYNC ERROR] " + e);
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
                    ConsoleDebug.WriteLine("SYNC Start");
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
                                    //ConsoleDebug.WriteLine("SYNC dataLength = " + dataLength);
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

                                //ConsoleDebug.WriteLine("SYNC "+currentBuffer.Length+" "+dataLength);

                                if (currentBuffer.Length >= dataLength)
                                {
                                    ConsoleDebug.WriteLine("Buffer: " + currentBuffer.Length + " data: " + dataLength);
                                    ConsoleDebug.WriteLine("SYNC Close");
                                    CurrentConnection.Send(Encoding.ASCII.GetBytes(GlobalData.SYNC_COMPLETED));
                                    CurrentConnection.Close();
                                    ConsoleDebug.WriteLine("SYNC Closed");
                                    break;
                                }
                            }
                        }
                        //File.WriteAllBytes(GlobalData.Current.MusicPath + "/mobile.nsec2", currentBuffer.ToArray());
                        State = 1;
                        PlaylistName = "";
                        
                        Unpack(currentBuffer);
                        State = 2;

                        Audios.Clear();
                        ReceivingAction?.Invoke();
                    }
                    catch(Exception e)
                    {
                        ConsoleDebug.WriteLine("[SYNC ERROR] " + e);
                        Disconnect();
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
                ConsoleDebug.WriteLine("SYNC Verified");
                byte[] bufferData = PrepareFilesToSend(Audios);
                Size = bufferData.Length / 1024 / 1024;
                //File.WriteAllBytes(GlobalData.Current.MusicPath + "/desktop.nsec2", bufferData);
                byte[] bufferLength = Encoding.ASCII.GetBytes(bufferData.Length.ToString());
                byte[] receiveBuffer = new byte[MessSize];

                try
                {
                    int bytesSent1 = CurrentConnection.Send(bufferLength);

                    byte[] buffer = new byte[BufferSize];
                    int bytesR = CurrentConnection.Receive(receiveBuffer);
                    ConsoleDebug.WriteLine("SYNC bytesR = " + bytesR);

                    string message = Encoding.ASCII.GetString(receiveBuffer, 0, bytesR);
                    ConsoleDebug.WriteLine(message);

                    if (message.Contains(GlobalData.RECEIVED_MESSAGE))
                    {
                        MemoryStream memoryStream = new MemoryStream(bufferData);
                        int read;
                        int progress = 0;
                        while ((read = memoryStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            //ConsoleDebug.WriteLine("SYNC read = " + read);
                            CurrentConnection.Send(buffer);
                            progress += read;
                            Progress = progress / 1024 / 1024;

                            //ConsoleDebug.WriteLine("Sync Receive");
                            bytesR = CurrentConnection.Receive(receiveBuffer);
                        }
                    }
                    else
                        throw new Exception("invalid message");
                }
                catch(Exception e)
                {
                    ConsoleDebug.WriteLine("[SYNC ERROR] "+e);
                    GlobalData.Current.MediaPlayer.Error(GlobalData.ERROR_CONNECTION);
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
                ConsoleDebug.WriteLine("Sync Add");
                AddFile(file);
            }
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
        #endregion
        #region Private Methods
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
                if (GlobalData.Current.AudioTags.ContainsKey(file))
                {
                    MediaSourceTag mediaSource = GlobalData.Current.AudioTags[file];

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
            ConsoleDebug.WriteLine("Unpack");
            NSEC2 nsec = new NSEC2(GlobalData.PASSWORD);
            ConsoleDebug.WriteLine("Unpack load");
            nsec.SetDebug(true);
            nsec.Load(stream);
            ConsoleDebug.WriteLine("Unpack loaded");
            

            string tagsBuffer = Encoding.UTF8.GetString(nsec.Get("tags"));
            string filesBuffer = Encoding.UTF8.GetString(nsec.Get("list"));

            //ConsoleDebug.WriteLine("Unpack " + tagsBuffer + " " + filesBuffer);
            foreach(string bufferItem in tagsBuffer.Split("\n",StringSplitOptions.RemoveEmptyEntries))
            {
                //ConsoleDebug.WriteLine("Unpack " + bufferItem);
                string[] elems = bufferItem.Split(GlobalData.SEPARATOR);
                string name = new FileInfo(GlobalData.Current.MusicPath + "/" + elems[0]).FullName;
                ConsoleDebug.WriteLine(name);
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

                if (GlobalData.Current.AudioTags.ContainsKey(name))
                    GlobalData.Current.AudioTags[name] = newTag;
                else
                    GlobalData.Current.AudioTags.Add(name, newTag);
            }
            string[] files = filesBuffer.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            FilesReceived = files.Length;

            ReceivedTracks = new List<string>();
            for(int a = 0; a < files.Length; a++)
            {
                string file = files[a];

                FileInfo info = new FileInfo(GlobalData.Current.MusicPath + "/" + file);
                CurrentFileName = file;
                CurrentFileReceived = a;
                //ConsoleDebug.WriteLine("Unpack " + info.FullName);
                File.WriteAllBytes(info.FullName, nsec.Get(file));
                GlobalLoader.AddTrack(MediaProcessing.GetSource(info.FullName));

                ReceivedTracks.Add(info.FullName);
            }

            GlobalData.Current.SaveTags();
            GlobalData.Current.SaveConfig();
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
        #endregion
    }
}
