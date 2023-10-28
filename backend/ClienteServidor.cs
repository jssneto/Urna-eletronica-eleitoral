using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace backend {
    public class Servidor {
        private IPAddress ipv4;
        private IPEndPoint ipEndPoint;
        private int porta;

        public Servidor() {
            
            this.Ipv4 = getIP();
            this.Porta = 8000;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        public Servidor(IPAddress ipv4, int porta) {
            
            this.Ipv4 = ipv4;
            this.Porta = porta;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        // Métodos setters e getters
        public IPAddress Ipv4 {get; set;}
        public int Porta {get; set;}

        public IPAddress getIP() {

            string nomeHost = Dns.GetHostName();
            IPAddress[] enderecos = Dns.GetHostAddresses(nomeHost);
            IPAddress ip = null;

            foreach(IPAddress x in enderecos) {
                if (x.AddressFamily==AddressFamily.InterNetwork)
                    ip = x;
            }
            return ip;
        }
        public void executar() {

                Socket socket = new Socket(Ipv4.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try {
                        socket.Bind(ipEndPoint);
                        socket.Listen(10);

                        Socket clienteSocket;
                        while(true) {
                            Console.WriteLine($"[{this.Ipv4}] Executando . . .");
                            clienteSocket = socket.Accept();

                            byte[] buffer = new byte[1024];
                            clienteSocket.Receive(buffer);

                            Console.WriteLine(Encoding.ASCII.GetString(buffer));
                        }

                        Console.WriteLine($"[{this.Ipv4} Desconectado . . .]");
                        clienteSocket.Close();
                } catch(Exception ex) {
                    Console.WriteLine(ex);
                }
        }
    }
    public class Cliente {
        private IPAddress ipv4;
        private int porta;
        private IPEndPoint ipEndPoint;
        public Cliente() {

            this.Ipv4 = IPAddress.Parse("192.168.1.10");
            this.Porta = 8000;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        public Cliente(IPAddress ipv4, int porta) {
            
            this.Ipv4 = ipv4;
            this.Porta = porta;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        // Setters e Getters
        public IPAddress Ipv4 {get; set;}
        public int Porta {get; set;}

        public void conectar() {

            Socket socket = new Socket(ipv4.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                socket.Connect(ipEndPoint);

                byte[] buffer = new byte[1024];
                buffer = Encoding.ASCII.GetBytes("Ola mundo!");

                socket.Send(buffer);
                socket.Close();

            } catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}

