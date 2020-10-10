using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace mysql
{
    public class udp
    {
        //设置服务端IP与端口
        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.1.129"), 8000);
        Socket Udpsocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public byte[] recBuff = new byte[1024];

        public  udp()
        {

        }

        public void SendtoSever(byte[] buff)
        {
            SocketAsyncEventArgs saea = new SocketAsyncEventArgs();
            saea.SetBuffer(buff, 0, buff.Length);
            saea.UserToken = Udpsocket;
            saea.Completed += Saea_Completed;
            saea.RemoteEndPoint = ip;
            if (!Udpsocket.SendToAsync(saea))
            {
                Saea_Completed(null, saea);
            }
            
        }

        private void Saea_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.None:
                    break;
                case SocketAsyncOperation.Accept:
                    break;
                case SocketAsyncOperation.Connect:
                    break;
                case SocketAsyncOperation.Disconnect:
                    break;
                case SocketAsyncOperation.Receive:
                    break;
                case SocketAsyncOperation.ReceiveFrom:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.ReceiveMessageFrom:
                    break;
                case SocketAsyncOperation.Send:
                    break;
                case SocketAsyncOperation.SendPackets:
                    break;
                case SocketAsyncOperation.SendTo:
                    ProcessSend(e);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 处理udp客户端发送的结果
        /// </summary>
        /// <param name="e"></param>
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // 发送成功就可以准备接收
                if (!Udpsocket.ReceiveFromAsync(e))
                {
                    Saea_Completed(null, e);
                }   
            }
            else
            {
                // 发送失败
            }
        }
        /// <summary>
        /// 处理接受到的udp服务器数据
        /// </summary>
        /// <param name="e"></param>
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 /*&& e.SocketError == SocketError.MessageSize*/)
            {
                //处理接收到的数据(e.Buffer);
                Array.Copy(e.Buffer, 0, recBuff, 0, e.BytesTransferred);

               
            }
            else
            {
                //没有接收到数据
            }
        }
    }
}
