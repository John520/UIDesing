using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing
{
    public class TCPPacketBuffer : ICloneable
    {
        public const int BUFFER_SIZE = 4096;
        public byte[] data;
        public int dataLength;
        public string bufferId;
        public string bufferName = "";
        public Socket clientSocket;

        public TCPPacketBuffer(Socket clientSocket, int bufferSize)
        {
            if (bufferSize <= 0) 
                bufferSize = BUFFER_SIZE;
            
            this.data = new byte[bufferSize];
            this.clientSocket = clientSocket;
            this.dataLength = 0;
            this.bufferId = clientSocket.Handle.ToString().Trim();
            this.bufferName = this.bufferId + "@" + this.clientSocket.RemoteEndPoint.ToString().Trim();
            this.bufferId = this.bufferName;

        }
        public TCPPacketBuffer(Socket clientSocket)
        {
            this.data = new byte[BUFFER_SIZE];
            this.clientSocket = clientSocket;
            this.dataLength = 0;
            this.bufferId = clientSocket.Handle.ToString().Trim();
            this.bufferName = this.bufferId + "@" + this.clientSocket.RemoteEndPoint.ToString().Trim();
            this.bufferId = this.bufferName;

        }



        public object Clone()
        {
            TCPPacketBuffer newBuf = new TCPPacketBuffer(this.clientSocket);
            Array.Copy(this.data, 0, newBuf.data, 0, this.dataLength);
            newBuf.dataLength = this.dataLength;
            newBuf.bufferId = bufferId;
            newBuf.bufferName = bufferName;
            return newBuf;
        }
    }
}
