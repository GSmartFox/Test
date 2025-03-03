using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerTcp {
    // 这个代码应挪到另一个进程执行
    class ServerStart {
        private const int port = 3336;

        static void Main(string[] args) {
            CreateTCPServer();

            // Console.ReadKey();
        }
        
        static void CreateTCPServer() {
            // 使用TcpListener
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            // 开始监听
            listener.Start();

            // Console.WriteLine("Waiting for  connection...");
            while(true) {
                // 接受客户端链接
                TcpClient client = listener.AcceptTcpClient();
                // 获取网络流
                // Console.WriteLine("Connection accepted.");
                NetworkStream ns = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes("Hello World");
                try {
                    // 写入数据
                    ns.Write(data, 0, data.Length);
                    ns.Close();
                }
                catch(Exception e) {
                    // Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
