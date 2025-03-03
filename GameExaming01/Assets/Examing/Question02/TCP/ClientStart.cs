using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTcp {
    class ClientStart {
        private const int port = 3336;

        static void Main(string[] args) {
            CreateTCPClient();
        }

        static void CreateTCPClient() {
            try {
                var client = new TcpClient("127.0.0.1", port);
                // 同样是获取网络流
                NetworkStream ns = client.GetStream();
                byte[] data = new byte[1024];
                int len = ns.Read(data, 0, data.Length);
                // 打印服务端的消息
                // Console.WriteLine(Encoding.ASCII.GetString(data, 0, len));
            }
            catch(Exception e) {
                // Console.WriteLine(e.ToString());
            }
        }
    }
}