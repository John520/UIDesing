using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UIDesing

{
   abstract class  baseClient
    {
        protected  bool isRun;
        public string IP{get;set;}
        private short port;//端口
        public byte[] senddata;
        public byte[] rcvdata;
        public int rcvBufferSize{get;set;}
        public int sendBufferSize { get; set; }
        private int rcvLength;
        public const int DEFAULTBUFFERSIZE = 4096;
        public short Port
        {
            get { return this.port;}
            set { this.port=value;}
        }
        protected bool IsRun {
            get { return this.isRun; }
            set { this.isRun = value; }
        }


        private Socket cliSocket;
        protected Socket CliSocket {
            get { return this.cliSocket; }
        }
        public baseClient( string IP,short port,int sendsize,int rcvsize)
        {
            this.IP=IP;
            this.port = port;
            this.sendBufferSize = sendsize;
            this.rcvBufferSize = rcvsize;
            if (sendsize < 1 || rcvsize<1)
            {
                this.sendBufferSize = DEFAULTBUFFERSIZE;
                this.rcvBufferSize = DEFAULTBUFFERSIZE;
            }
            this.senddata = new byte[sendBufferSize];
            this.rcvdata = new byte[rcvBufferSize];
            this.cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public baseClient(string IP, short port)
        {
            this.IP = IP;
            this.port = port;
            this.sendBufferSize = DEFAULTBUFFERSIZE;
            this.rcvBufferSize = DEFAULTBUFFERSIZE;

            this.senddata = new byte[sendBufferSize];
            this.rcvdata = new byte[rcvBufferSize];
            this.cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public baseClient() {
            this.sendBufferSize = DEFAULTBUFFERSIZE;
            this.rcvBufferSize = DEFAULTBUFFERSIZE;

            this.senddata = new byte[sendBufferSize];
            this.rcvdata = new byte[rcvBufferSize];
            this.cliSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public virtual bool start()
        {
            try
            {
                if (isRun)
                {
                    throw (new ApplicationException("client is running..."));
                    //return true;
                }
                    cliSocket.Connect(IP, port);
                    cliSocket.BeginReceive(rcvdata, 0, rcvdata.Length, SocketFlags.None, rcvData, rcvdata);
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
                if (cliSocket.Connected)
                {
                    cliSocket.Shutdown(SocketShutdown.Both);
                }
                cliSocket.Close();

            }
            catch
            {
                isRun = true;
            }
            return true;
        }
         //关闭连接
      
      

         //处理接受到的数据
        protected virtual void rcvData(IAsyncResult iar) {
            
            try
            {
                rcvLength = cliSocket.EndReceive(iar);
                if (rcvLength == 0) //关闭连接
                {
                    //正常的关闭 
                    cliSocket.Close();
                    return;
                }
                dataRcv(rcvdata);
            }
            catch
            {
            }
            try
            {
                //继续接收来自来客户端的数据 
                cliSocket.BeginReceive(rcvdata, 0, rcvdata.Length, SocketFlags.None, rcvData, rcvdata);
            }
            catch
            {
            }
        }
         //处理接收到的数据包，比如加入队列然后新建一个线程处理
         public abstract void dataRcv(byte[] rcvdata);
         public bool Send(byte[] data)
         {
             try
             {
                cliSocket.BeginSend(data,0,data.Length,SocketFlags.None,null,null);
                 return true;
             }
             catch
             {
                 return false;
             }

         }
        
    }

    
}
