using System;
using System.Text;
using System.Text.Json;
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
                
                Thread servidorThread = new Thread(() =>
                {
                
                try{
                    socket.Bind(ipEndPoint);
                    socket.Listen(10);

                    Socket clienteSocket;
                    while(true) {
                        Console.WriteLine($"[{this.Ipv4}] Executando . . .");
                        clienteSocket = socket.Accept();

                        byte[] buffer = new byte[8192];
                        clienteSocket.Receive(buffer);

                        int op = BitConverter.ToInt32(buffer, 0);                            

                        switch(op){                                
                                case 1:                                        
                                    clienteSocket.Receive(buffer);                                        
                                    selecionarCandidato(BitConverter.ToInt32(buffer, 0));
                                    Array.Clear(buffer, 0, buffer.Length);
                                    clienteSocket.Send(Encoding.ASCII.GetBytes("Voto Confirmado!"));
                                break;
                                default:
                                    Array.Clear(buffer, 0, buffer.Length);
                                    clienteSocket.Send(Encoding.ASCII.GetBytes(listarVotos()));
                                break;         
                        }

                        Console.WriteLine($"[{this.Ipv4} Desconectado . . .]");
                        clienteSocket.Close();
                    }
                }
                catch(Exception ex) {
                    Console.WriteLine(ex);
                }
                });

                servidorThread.Start();
        }

        public void selecionarCandidato(int x) {
            
            if (x<0)
                votos.QtdVotosNulos++;
            else if (x==0)
                votos.QtdVotosBrancos++;
            else {
                foreach(Candidato candidato in candidatos) {
                    if (x==candidato.NumPartido) {                                        
                        candidato.QtdVotos++;
                        votos.QtdVotosValidos++;
                        votos.QtdVotosTotal++;
                    }
                }
            }
        }
        public void listarCandidatos() {
                        
            if (candidatos.Count==0)
                Console.WriteLine("Lista vazia! Nao candidatos cadastrados.");
            else {
                foreach(Candidato x in candidatos) {
                    Console.WriteLine(x.NomeCompleto+"|"+x.NomePartido+"|"+x.NumPartido);
                }
            }
        }
        public void cadastrarCandidatos(Candidato obj) {

            candidatos.Add(obj);            
        }

        public string listarVotos() {

            string x = "Quant. total de votos (Total): "+votos.QtdVotosTotal+"Quant. total de votos (validos): "+votos.QtdVotosValidos+"Quant. total de votos (brancos): "+votos.QtdVotosBrancos+"Quant. total de votos (nulos): "+votos.QtdVotosNulos;
            return x;
        }        
    }
}

