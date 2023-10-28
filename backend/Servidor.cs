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
        private List<Candidato> candidatos = new List<Candidato>();
        private Votos votos = new Votos();

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

                            if (numCandidato<0)
                                votos.QtdVotosNulos++;
                            else if (numCandidato==0)
                                votos.QtdVotosBrancos++;
                            else {
                                foreach(Candidato x in candidatos) {
                                    if (numCandidato==x.NumPartido) {                                        
                                        x.QtdVotos++;
                                        votos.QtdVotosTotal++;
                                    }
                                }
                            }
                        }

                        Console.WriteLine($"[{this.Ipv4} Desconectado . . .]");
                        clienteSocket.Close();
                } catch(Exception ex) {
                    Console.WriteLine(ex);
                }
        }

        public void listarCandidatos() {
            
            foreach(Candidato x in candidatos) {
                x.apresentarCandidato();
            }
        }
        public void cadastrarCandidatos(Candidato obj) {

            candidatos.Add(obj);            
        }

        public void listarVotos() {

            Console.WriteLine("Quant. total de votos (Total): {0}", votos.QtdVotosTotal);
            Console.WriteLine("Quant. total de votos (validos): {0}", votos.QtdVotosValidos);
            Console.WriteLine("Quant. total de votos (brancos): {0}", votos.QtdVotosBrancos);
            Console.WriteLine("Quant. total de votos (nulos): {0}", votos.QtdVotosNulos);
        }
    }
}

