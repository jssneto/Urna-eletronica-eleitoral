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

            this.Ipv4 = IPAddress.Parse("192.168.15.9");
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

        public void conectar(ref Servidor servidor) {
            
            int op = menu();
            Socket socket = new Socket(Ipv4.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            while(true){
                try {
                    socket.Connect(ipEndPoint);

                    byte[] buffer = new byte[5024];
                    buffer = BitConverter.GetBytes(op);
                    socket.Send(buffer);

                    Array.Clear(buffer, 0, buffer.Length);
                    Console.WriteLine("CHEGOU AQUI!");
                    if(op == 1){
                        Console.WriteLine("AGORA AQUI!");
                        Console.Write("Partido: ");
                        int partido = int.Parse(Console.ReadLine());
                        socket.Send(BitConverter.GetBytes(partido));                        

                        Array.Clear(buffer, 0, buffer.Length);
                        socket.Receive(buffer);
                        Console.WriteLine(Encoding.ASCII.GetString(buffer));
                    }
                    else if(op == 2)
                            servidor.listarCandidatos();
                    else{
                        socket.Close();
                        break;                            
                    }

                    socket.Receive(buffer);
                    Console.WriteLine(Encoding.ASCII.GetString(buffer));                    
 
                    socket.Close();
                }
                catch(Exception ex){
                    Console.WriteLine($"Erro! {ex.Message}");
                    break;
                }
            }
        }
        public int menu(){
            int op = 0;

            while (true){
                Console.WriteLine("\n[1]. Escolher candidato.");
                Console.WriteLine("[2]. Listar resultados.");
                Console.WriteLine("[3]. Sair.");
                Console.Write("Opcão: ");

                try{
                    op = int.Parse(Console.ReadLine());

                    if (op < 1 || op > 3){
                        throw new ExcecaoOpcaoInvalida("Entre com uma opção válida: ");
                    }

                    if (op == 3){
                        break; // saia do loop quando o eleitor escolher "3" (Sair)
                    }
                }
                catch (FormatException){
                    Console.WriteLine("\nErro! Insira a opção no formato correto.");
                }
                catch (ExcecaoOpcaoInvalida ex){
                    // Tratamento de exceção caso o usuário escolha uma opção diferente das opções disponíveis
                    Console.WriteLine($"\nErro! {ex.Message}");
                }
                catch (Exception ex){
                    Console.WriteLine($"\nErro! {ex.Message}");
                }
            }

            return op;
        }
    }