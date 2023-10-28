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
        private List<Candidato> candidatos;

        public Servidor() {
            
            this.Ipv4 = getIP();
            this.Porta = 8000;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        public Servidor(string ipv4, int porta) {
            
            this.Ipv4 = IPAddress.Parse(ipv4);
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

                            int numCandidato = BitConverter.ToInt32(buffer, 0);

                        }

                        Console.WriteLine($"[{this.Ipv4} Desconectado . . .]");
                        clienteSocket.Close();
                } catch(Exception ex) {
                    Console.WriteLine(ex);
                }
        }
        public bool cadastrarCandidatos(Candidato obj) {

        }
    }
}

