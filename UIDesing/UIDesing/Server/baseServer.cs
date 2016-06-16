using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIDesing
{
     abstract class baseServer
    {
        protected  bool isRun;
        private short port;//端口
        public short Port
        {
            get { return this.port;}
            set { this.port=value;}
        }
        protected bool IsRun {
            get { return this.isRun; }
            set { this.isRun = value; }
        }


        private Socket serverSocket;
        protected Socket ServerSocket {
            get { return this.serverSocket; }
        }


        private  Hashtable linkTable = new Hashtable(200);
        public Hashtable LinkTable
        {
            get { return this.linkTable; }
            set { this.linkTable = value; }
         }

        public baseServer(short port)
        {
            this.port = port;
        }
        public baseServer() { }
        public virtual bool start()
        {
            try
            {
                if (isRun)
                {
                    throw (new ApplicationException("server is running..."));
                    //return true;
                }
                this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress hostIP = IPAddress.Any;
                IPEndPoint ipEnd = new IPEndPoint(hostIP, port);
                serverSocket.Bind(ipEnd);

                serverSocket.Listen(200);
                serverSocket.BeginAccept(new AsyncCallback(acceptConn), serverSocket);
                isRun = true;
            }
            catch (ApplicationException)
            {
                //已经正在运行。。。

            }
            catch {
                isRun = false;
            }
            return isRun;
        }
        public virtual bool stop()
        {
            try
            {
                if (!isRun)
                {
                    return true;
                }
                isRun = false;
                if (serverSocket.Connected)
                {
                    serverSocket.Shutdown(SocketShutdown.Both);
                }
                serverSocket.Close();
                closeAllClient();
            }
            catch
            {
                isRun = true;
            }
            return true;
        }
         //关闭连接
        protected virtual void closeClient(Socket client) {
            try
            {
                if (client == null)
                {
                    return;
                }
                if (linkTable.ContainsKey(client.Handle.ToString() + "@" + client.RemoteEndPoint.ToString().Trim()) == true)
                {
                    linkTable.Remove(client.Handle.ToString() + "@" + client.RemoteEndPoint.ToString().Trim());
                    showlink();
                }
                //关闭数据的接受和发送 
                client.Shutdown(SocketShutdown.Both);

                //清理资源 
                client.Close();
                client = null;
            }
            catch { }
        
        }
        protected virtual void closeAllClient()
        {
            foreach (DictionaryEntry link in linkTable)
            {
                TCPPacketBuffer buffer = (TCPPacketBuffer)link.Value;
                if (buffer.clientSocket == null) continue;
                //注意捕获异常，比如考虑客户端断开连接
                buffer.clientSocket.Shutdown(SocketShutdown.Both);
                buffer.clientSocket.Close();
            }
            linkTable.Clear();
            showlink();
        }
        protected void acceptConn(IAsyncResult iar) {
            if (!isRun)
            {
                return;
            }
            try
            {
                Socket server = (Socket)iar.AsyncState;//服务器socket
                Socket client = server.EndAccept(iar);

                //构造TCPPacketBuffer
                TCPPacketBuffer clientPacket = new TCPPacketBuffer(client, TCPPacketBuffer.BUFFER_SIZE);

               //另开线程接受数据
                clientPacket.clientSocket.BeginReceive(clientPacket.data, 0, TCPPacketBuffer.BUFFER_SIZE, SocketFlags.None, new AsyncCallback(rcvData), clientPacket);
                //往HashTable中添加一条连接信息
                if (!linkTable.ContainsKey(clientPacket.bufferName))
                {
                    linkTable.Add(clientPacket.bufferName, clientPacket);
                    //显示linkTable
                    showlink();
                }
                else
                {
                    //连接存在！！！
                }
            }
            catch { 
             //
              
            }
            finally {
                try
                {
                    //继续接受连接
                    serverSocket.BeginAccept(new AsyncCallback(acceptConn), serverSocket);
                }
                catch { }
            
            }

        
        }

        //显示linkTable
        public abstract void  showlink();
         //处理接受到的数据
        protected virtual void rcvData(IAsyncResult iar) {
            TCPPacketBuffer tcpBuf = (TCPPacketBuffer)iar.AsyncState;
            try
            {
                int rcvCout = tcpBuf.clientSocket.EndReceive(iar);
                if (rcvCout == 0) //关闭连接
                {
                    //正常的关闭 
                    closeClient(tcpBuf.clientSocket);
                    return;
                }
                tcpBuf.dataLength = rcvCout;

                try
                {
                    ICloneable copySession = (ICloneable)tcpBuf;
                    TCPPacketBuffer newTcpBuf = (TCPPacketBuffer)copySession.Clone();
                    //如何处理该数据
                    dataRcv(newTcpBuf);
                    tcpBuf.clientSocket.Receive(tcpBuf.data, 0, TCPPacketBuffer.BUFFER_SIZE,SocketFlags.None);
                }
                catch { }
            }
            catch
            {
                //当远程进程被杀死会tcpBuf.clientSocket.EndReceive(iar)抛出异常“”
                closeClient(tcpBuf.clientSocket);
            }
            try
            {
                //继续接收来自来客户端的数据 

                tcpBuf.clientSocket.BeginReceive(tcpBuf.data, 0, TCPPacketBuffer.BUFFER_SIZE, SocketFlags.None,
                        new AsyncCallback(rcvData), tcpBuf);

            }
            catch
            {
               
            }
        }
         //处理接收到的数据包，比如加入队列然后新建一个线程处理
         public abstract void dataRcv(TCPPacketBuffer buffer);
         public bool Send(TCPPacketBuffer tcpBuf)
         {
             try
             {
                 tcpBuf.clientSocket.BeginSend(tcpBuf.data, 0, tcpBuf.dataLength, SocketFlags.None,
                                                 null, tcpBuf);
                 return true;
             }
             catch
             {
                 return false;
             }

         }
         public bool Send(Socket ClientSocket, byte[] sendBuf)
         {
             try
             {
                 ClientSocket.BeginSend(sendBuf, 0, sendBuf.Length, SocketFlags.None,
               null, ClientSocket);
                 return true;
             }
             catch { return false; }
             //ClientSocket.Send(sendBuf);
         }
    }

}
