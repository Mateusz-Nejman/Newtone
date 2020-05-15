using Nejman.NSEC2;
using Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Newtone.Core.Sync
{
    public class SyncController
    {
        /*
         * Pomysł
         * Wysyłający wpisuje kod odbiorcy(8 znaków)
         * Paczka z rozmiarem zostaje wysłana
         * Paczka właściwa zostaje wysłana
         * po odebraniu paczki dane są przetwarzane do poprawnego działania na urządzeniu odbiorcy
         */
        private readonly int port = 8888; //transfer}
        private MemoryStream currentBuffer;

        public double Progress { get; private set; } = 0;

        private List<string> Audios { get; set; }

        public SyncController()
        {
            currentBuffer = new MemoryStream();
        }

        public void Receive()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Bind(new IPEndPoint(SyncHelper.IpAddress, port));
                socket.Listen(10);

                byte[] buffer = new byte[1024];
                while(true)
                {
                    Socket client = socket.Accept();

                    int packetType = 0;
                    int dataLength = 0;

                    currentBuffer = new MemoryStream();
                    Progress = 0;
                    while(true)
                    {
                        int numByte = client.Receive(buffer);

                        if(packetType == 0)
                        {
                            dataLength = int.Parse(GetStringFromPacket(buffer));
                            client.Send(Encoding.ASCII.GetBytes(GlobalData.RECEIVED_MESSAGE));
                            packetType = 1;
                        }
                        else if(packetType == 1)
                        {
                            currentBuffer.Write(buffer, 0, numByte);
                            Progress = dataLength == 0 ? 0 : ((currentBuffer.Length / dataLength) * 100.0d);
                            client.Send(Encoding.ASCII.GetBytes(GlobalData.RECEIVED_MESSAGE));
                        }

                        if (currentBuffer.Length == dataLength)
                        {
                            client.Send(Encoding.ASCII.GetBytes(GlobalData.SYNC_COMPLETED));
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                            break;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public void SendTo(string code)
        {
            if(Verify(code))
            {
                byte[] bufferData = PrepareFilesToSend(Audios);
                byte[] bufferLength = GetPacketFromString(bufferData.Length.ToString());

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    socket.Connect(new IPEndPoint(FromHex(code),port));

                    int bytesSent1 = socket.Send(bufferLength);

                    byte[] buffer = new byte[1024];
                    int bytesR = socket.Receive(buffer);

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesR);

                    if (message == GlobalData.RECEIVED_MESSAGE)
                    {
                        MemoryStream memoryStream = new MemoryStream(bufferData);
                        int read;
                        while ((read = memoryStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            socket.Send(buffer);

                            bytesR = socket.Receive(buffer);

                            message = Encoding.ASCII.GetString(buffer, 0, bytesR);

                            if (message != GlobalData.RECEIVED_MESSAGE)
                            {
                                GlobalData.MediaPlayer.Error(GlobalData.ERROR_CONNECTION);
                                break;
                            }
                        }
                    }
                    else
                        GlobalData.MediaPlayer.Error(GlobalData.ERROR_CONNECTION);
                }
                catch
                {

                }
            }
        }

        public void AddFile(string filepath)
        {
            if (!Audios.Contains(filepath))
                Audios.Add(filepath);
        }

        public void AddFiles(IEnumerable<string> files)
        {
            foreach(string file in files)
            {
                AddFile(file);
            }
        }

        public byte[] PrepareFilesToSend(List<string> files)
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
                    MediaSourceTag tag = GlobalData.AudioTags[file];
                    string imageName = "image" + counter;
                    nsec.AddFile(imageName, tag.Image ?? (new byte[0]));

                    string bufferItem = fileInfo.Name + GlobalData.SEPARATOR + tag.Author + GlobalData.SEPARATOR + tag.Title + GlobalData.SEPARATOR + imageName + "\n";
                    audioTagsBuffer += bufferItem;
                    counter += 1;
                }

                nsec.AddFile(fileInfo.Name, File.ReadAllBytes(file));
            }

            nsec.AddFile("list", Encoding.UTF8.GetBytes(audiosListBuffer));
            nsec.AddFile("tags", Encoding.UTF8.GetBytes(audioTagsBuffer));

            return nsec.Save();

            

        }
        public byte[] GetNamePacket()
        {
            return GetPacketFromString(Dns.GetHostName());
        }

        public string GetNameFromPacket(byte[] packet)
        {
            return GetStringFromPacket(packet);
        }

        public byte[] GetPacketFromString(string text)
        {
            byte[] nameArray = Encoding.ASCII.GetBytes(text);
            int length = nameArray.Length;
            byte[] lengthArray = Encoding.ASCII.GetBytes(length.ToString());


            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(new byte[1] { (byte)lengthArray.Length }, 0, 1);
            memoryStream.Write(lengthArray, 0, lengthArray.Length);
            memoryStream.Write(nameArray, 0, nameArray.Length);
            byte[] buffer = memoryStream.ToArray();
            memoryStream.Dispose();
            return buffer;
        }

        public string GetStringFromPacket(byte[] packet)
        {
            MemoryStream memoryStream = new MemoryStream(packet);
            byte[] lengthArrayLengthArray = new byte[1];
            memoryStream.Read(lengthArrayLengthArray, 0, 1);
            int lengthArrayLength = int.Parse(Encoding.ASCII.GetString(lengthArrayLengthArray));
            byte[] lengthArray = new byte[lengthArrayLength];
            memoryStream.Position = 1;
            memoryStream.Read(lengthArray, 0, lengthArrayLength);
            memoryStream.Position = 1 + lengthArrayLength;
            int length = int.Parse(Encoding.ASCII.GetString(lengthArray));
            byte[] data = new byte[length];
            memoryStream.Read(data, 0, length);
            memoryStream.Dispose();

            return Encoding.ASCII.GetString(data);
        }

        public string GetCode()
        {
            return ToHex(SyncHelper.IpAddress);
        }

        private string ToHex(IPAddress addr)
        {
            string c1 = ((int)addr.GetAddressBytes()[0]).ToString("X").PadLeft(2, '0');
            string c2 = ((int)addr.GetAddressBytes()[1]).ToString("X").PadLeft(2, '0');
            string c3 = ((int)addr.GetAddressBytes()[2]).ToString("X").PadLeft(2, '0');
            string c4 = ((int)addr.GetAddressBytes()[3]).ToString("X").PadLeft(2, '0');

            return $"{c1}{c2}{c3}{c4}";
        }

        private IPAddress FromHex(string hex)
        {
            string h1 = hex[0].ToString() + hex[1].ToString();
            string h2 = hex[2].ToString() + hex[3].ToString();
            string h3 = hex[4].ToString() + hex[5].ToString();
            string h4 = hex[6].ToString() + hex[7].ToString();

            return new IPAddress(new byte[] { (byte)int.Parse(h1, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h2, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h3, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h4, System.Globalization.NumberStyles.HexNumber) });
        }

        private bool Verify(string hex)
        {
            if (hex.Length != 8)
                return false;
            string availableChars = "abcdef1234567890";

            foreach(char c in hex)
            {
                if (!availableChars.Contains(c))
                    return false;
            }

            return true;
        }
    }
}
