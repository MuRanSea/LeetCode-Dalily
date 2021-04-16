using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    internal class Client
    {
        TcpClient client;
        IPAddress remoteAddress;
        int localPort;
        int remotePort;
        byte[] buffer = new byte[1024 * 1024 * 10];
        bool isActive = true;
        bool isConnecting = false;
        bool isConnected
        {
            get
            {
                return client.Connected;
            }
        }

        #region 事件
        public Action OnConnectSuccess;
        public Action<string> OnConnectError;
        public Action<byte[]> OnSendMessage;
        public Action<byte[], int> OnReceieveMessage;
        public Action OnDisConnected;
        public Action OnReConnected;
        public Action<string> OnError;
        #endregion

        public Client(int port)
        {
            localPort = port;
            client = new TcpClient(new IPEndPoint(IPAddress.Any, localPort));
        }

        public void Connect(string ip,int port)
        {
            remoteAddress = IPAddress.Parse(ip);
            remotePort = port;
            BeginConnect();
        }

        public void SendMessage(byte[] message)
        {
            BeginSend(message);
        }

        public void Close()
        {
            isActive = false;
            while (isConnecting)
            {

            }
            Disconnect();
        }

        public void Disconnect()
        {
            client.Close();
            client.Dispose();
            OnDisConnected?.Invoke();
        }

        private void BeginConnect()
        {
            if (!isActive ||isConnecting || isConnected)
            {
                return;
            } 
            isConnecting = true;
            client.BeginConnect(remoteAddress, remotePort, EndConnect, client);
        }

        private void EndConnect(IAsyncResult ar)
        {
            isConnecting = false;
            var c = ar.AsyncState as TcpClient;
            try
            {
                client.EndConnect(ar);
                ConnectSuccess();
            }
            catch (Exception ex)
            {
                ReConnect();
                ConnectError(ex.Message);
            }
        }

        private void BeginReceieve()
        {
            NetworkStream stream = client.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, EndReceieve, stream);
        }

        private void EndReceieve(IAsyncResult ar)
        {
            try
            {
                NetworkStream stream = ar.AsyncState as NetworkStream;
                var len = stream.EndRead(ar);
                if (len > 0)
                {
                    ReceieveMessage(buffer, len);
                    BeginReceieve();
                }
                else
                {
                    OnError?.Invoke("接收消息失败 ...初始化重新连接 ");
                    Disconnect();
                    client = new TcpClient(new IPEndPoint(IPAddress.Any, localPort));
                    ReConnect();
                }
            }
            catch(Exception ex)
            {
                OnError?.Invoke($"{ex.Message} ...初始化重新连接 ");
                Disconnect();
                client = new TcpClient(new IPEndPoint(IPAddress.Any, localPort));
                ReConnect();
            }
        }

        private void BeginSend(byte[] data)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                stream.BeginWrite(data, 0, data.Length, EndSend, stream);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message);
            }
        }

        private void EndSend(IAsyncResult ar)
        {
            try
            {
                var stream = ar.AsyncState as NetworkStream;
                stream.EndWrite(ar);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message);
            }
        }

        private void ConnectSuccess()
        {
            OnConnectSuccess?.Invoke();
            BeginReceieve();
        }

        private void ConnectError(string message)
        {
            OnConnectError?.Invoke(message);
        }

        private void ReceieveMessage(byte[] message, int len)
        {
            OnReceieveMessage?.Invoke(message, len);
        }

        private void ReConnect()
        {
            BeginConnect();
            OnReConnected?.Invoke();
        }
    }
}
