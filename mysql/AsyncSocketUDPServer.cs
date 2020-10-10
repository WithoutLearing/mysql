using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace mysql
{
    /// <summary>
    /// SOCKET实现异步UDP服务器
    /// </summary>
    public class UdpServiceSocket
    {
        private readonly string broadCastHost = "255.255.255.255";

        //接收数据事件
        public Action<string> recvMessageEvent = null;
        //发送结果事件
        public Action<int> sendResultEvent = null;

        //接收缓存数组
        public byte[] recvBuff = null;
        //发送缓存数组
        public byte[] sendBuff = null;
        //用于发送数据的SocketAsyncEventArgs
        private SocketAsyncEventArgs sendEventArg = null;
        //用于接收数据的SocketAsyncEventArgs
        private SocketAsyncEventArgs recvEventArg = null;
        //监听socket
        private Socket socket = null;
        //用于socket发送和接收的缓存区大小
        private int bufferSize = 1024;
        //udp服务器绑定地址
        private IPAddress localHost = null;
        //udp服务器监听端口
        private int localPort = 0;
        //udp广播组地址
        private string MultiCastHost = "";
        //udp广播组端口
        private int MultiCastPort = 0;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bufferSize">用于socket发送和接受的缓存区大小</param>
        public UdpServiceSocket()
        {
            //设置用于发送数据的SocketAsyncEventArgs
            sendBuff = new byte[bufferSize];
            sendEventArg = new SocketAsyncEventArgs();
            sendEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            sendEventArg.SetBuffer(sendBuff, 0, bufferSize);
            //设置用于接受数据的SocketAsyncEventArgs
            recvBuff = new byte[bufferSize];
            recvEventArg = new SocketAsyncEventArgs();
            recvEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            recvEventArg.SetBuffer(recvBuff, 0, bufferSize);
        }

        /// <summary>
        ///  开启udp服务器，等待udp客户端数据(设置广播)
        /// </summary>
        public void Start(int localPort)
        {
            if (localPort < 1 || localPort > 65535)
                throw new ArgumentOutOfRangeException("localPort is out of range");

            this.localHost = IPAddress.Any;
            this.localPort = localPort;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //设置广播
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, localPort);
                socket.Bind(endpoint);//设置监听地址和端口
                StartRecvFrom();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  开启udp服务器，等待udp客户端数据(设置多播，广播)
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Start(int localPort, string MultiCastHost, int MultiCastPort)
        {
            if (localPort < 1 || localPort > 65535)
                throw new ArgumentOutOfRangeException("localPort is out of range");

            if (string.IsNullOrEmpty(MultiCastHost))
                throw new ArgumentNullException("MultiCastHost cannot be null");
            if (MultiCastPort < 1 || MultiCastPort > 65535)
                throw new ArgumentOutOfRangeException("MultiCastPort is out of range");

            this.localHost = IPAddress.Any;
            this.localPort = localPort;
            this.MultiCastHost = MultiCastHost;
            this.MultiCastPort = MultiCastPort;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //设置广播
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

                //设置多播
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastLoopback, true);
                MulticastOption mcastOption = new MulticastOption(IPAddress.Parse(MultiCastHost), IPAddress.Any);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, mcastOption);

                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, localPort);
                socket.Bind(endpoint);//设置监听地址和端口
                StartRecvFrom();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 开始接受udp客户端发送的数据
        /// </summary>
        private void StartRecvFrom()
        {
            recvEventArg.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            bool willRaiseEvent = socket.ReceiveFromAsync(recvEventArg);
            if (!willRaiseEvent)
            {
                ProcessReceive(recvEventArg);
            }
        }

        /// <summary>
        /// socket.sendAsync和socket.recvAsync的完成回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.ReceiveFrom:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.SendTo:
                    ProcessSend(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }
        }

        /// <summary>
        /// 处理接收到的udp客户端数据
        /// </summary>
        /// <param name="e"></param>
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                if (recvMessageEvent != null)
                    //一定要指定GetString的长度
                    recvMessageEvent(Encoding.UTF8.GetString(e.Buffer, e.Offset, e.BytesTransferred));

                StartRecvFrom();
            }
            else
            {
                Restart();
            }
        }

        /// <summary>
        /// 处理udp服务器发送的结果
        /// </summary>
        /// <param name="e"></param>
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            //AsyncUserToken token = (AsyncUserToken)e.UserToken;
            if (e.SocketError == SocketError.Success)
            {
                if (sendResultEvent != null)
                    sendResultEvent(e.BytesTransferred);
            }
            else
            {
                if (sendResultEvent != null)
                    sendResultEvent(e.BytesTransferred);
                Restart();
            }
        }

        /// <summary>
        /// 关闭udp服务器
        /// </summary>
        public void CloseSocket()
        {
            if (socket == null)
                return;

            try
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            catch { }

            try
            {
                socket.Close();
            }
            catch { }
        }

        /// <summary>
        /// 重新启动udp服务器
        /// </summary>
        public void Restart()
        {
            CloseSocket();
            if (string.IsNullOrEmpty(MultiCastHost))
                Start(localPort, MultiCastHost, MultiCastPort);
            else
                Start(localPort);
        }

        /// <summary>
        /// 发送广播
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageByBroadcast(string message)
        {
            if (socket == null)
                throw new ArgumentNullException("socket cannot be null");
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message cannot be null");

            byte[] buff = Encoding.UTF8.GetBytes(message);
            if (buff.Length > bufferSize)
                throw new ArgumentOutOfRangeException("message is out off range");

            sendEventArg.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(broadCastHost), localPort);
            buff.CopyTo(sendEventArg.Buffer, 0);
            sendEventArg.SetBuffer(0, buff.Length);
            bool willRaiseEvent = socket.SendToAsync(sendEventArg);
            if (!willRaiseEvent)
            {
                ProcessSend(sendEventArg);
            }
        }

        /// <summary>
        /// 发送单播
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageByUnicast(string message, string destHost, int destPort)
        {
            if (socket == null)
                throw new ArgumentNullException("socket cannot be null");
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message cannot be null");
            if (string.IsNullOrEmpty(destHost))
                throw new ArgumentNullException("destHost cannot be null");
            if (destPort < 1 || destPort > 65535)
                throw new ArgumentOutOfRangeException("destPort is out of range");

            byte[] buff = Encoding.UTF8.GetBytes(message);
            if (buff.Length > bufferSize)
                throw new ArgumentOutOfRangeException("message is out off range");

            sendEventArg.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(destHost), destPort);
            buff.CopyTo(sendEventArg.Buffer, 0);
            sendEventArg.SetBuffer(0, buff.Length);
            bool willRaiseEvent = socket.SendToAsync(sendEventArg);
            if (!willRaiseEvent)
            {
                ProcessSend(sendEventArg);
            }
        }

        /// <summary>
        /// 发送组播(多播)
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageByMulticast(string message)
        {
            if (socket == null)
                throw new ArgumentNullException("socket cannot be null");
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message cannot be null");
            if (string.IsNullOrEmpty(MultiCastHost))
                throw new ArgumentNullException("MultiCastHost cannot be null");
            if (MultiCastPort < 1 || MultiCastPort > 65535)
                throw new ArgumentOutOfRangeException("MultiCastPort is out of range");

            byte[] buff = Encoding.UTF8.GetBytes(message);
            if (buff.Length > bufferSize)
                throw new ArgumentOutOfRangeException("message is out off range");

            sendEventArg.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(MultiCastHost), MultiCastPort);
            buff.CopyTo(sendEventArg.Buffer, 0);
            sendEventArg.SetBuffer(0, buff.Length);
            bool willRaiseEvent = socket.SendToAsync(sendEventArg);
            if (!willRaiseEvent)
            {
                ProcessSend(sendEventArg);
            }
        }







    }
}
