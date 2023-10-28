using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using backend;
public class Cliente {
        private IPAddress ipv4;
        private int porta;
        private IPEndPoint ipEndPoint;
        public Cliente() {

            this.Ipv4 = IPAddress.Parse("192.168.1.10");
            this.Porta = 8000;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        public Cliente(string ipv4, int porta) {
            
            this.Ipv4 = IPAddress.Parse(ipv4);
            this.Porta = porta;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        // Setters e Getters
        public IPAddress Ipv4 {get; set;}
        public int Porta {get; set;}

        public void conectar() {

            Socket socket = new Socket(Ipv4.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

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

        public void votar(Servidor servidor){
            while(true) {
                int op=0; 

                Console.WriteLine("[1]. Cadastrar candidato.");
                Console.WriteLine("[2]. Listar Candidatos.");
                Console.WriteLine("[3]. Listar resultados.");
                Console.WriteLine("[4]. Escolher candidato.");
                Console.WriteLine("[5]. Sair.");

                while(true){
                    Console.Write("Opcão: ");
                    try{
                        op = int.Parse(Console.ReadLine());

                        if(op < 1 || op > 5){
                            throw new ExcecaoOpcaoInvalida("Entre com uma opção válida!");
                        }
                        break;
                    }
                    catch(FormatException){
                        Console.WriteLine("\nErro! Insira a opção no formato correto.");
                    }
                    catch(ExcecaoOpcaoInvalida ex){
                        Console.WriteLine($"\nErro! {ex.Message}");
                    }
                }

                while(true){
                    if(op == 5){
                        Console.WriteLine("\nSaindo...");
                        break;
                    }
                    else if(op == 4)
                        servidor.selecionarCandidato(13);
                    else if(op == 3)
                        servidor.listarVotos();
                    else if(op == 2)
                        servidor.listarCandidatos();
                    else
                        servidor.cadastrarCandidatos(new Candidato("PT", "Lula", 13, "Nicolas M. Ferreira", "Superior", "Contagem", "Masculino", "Solteiro", "Pardo", "Programador", 22, 20.000));
                }

            }
        }
    }