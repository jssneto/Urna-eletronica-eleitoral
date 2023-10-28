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
                            throw new ExcecaoOpcaoInvalida("\nEntre com uma opção válida:");
                        }
                        break;
                    }
                    catch(FormatException){
                        Console.WriteLine("\nErro! Insira a opção no formato correto.");
                    }
                    catch(ExcecaoOpcaoInvalida ex){
                        Console.WriteLine($"\nErro! {ex.Message}");
                    }
                    catch(Exception ex){
                        Console.WriteLine($"nErro! {ex.Message}");
                }

                while(true){
                    string partido="", nome="", grauInstrucao="", cidade="", profissao="", genero="", estadoCivil="", raca="";
                    int numero=0, idade=0, opGenero=0, opEstadoCivil=0, opRaca=0;

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
                    else{
                        Console.Write("\nA qual partido o candidato pertence: ");
                        partido = Console.ReadLine();

                        Console.Write("\nInsira o número do partido: ");
                        numero = int.Parse(Console.ReadLine());

                        Console.Write("\nInsira o nome do candidato: ");
                        nome = Console.ReadLine();

                        Console.Write("\nQual o seu grau de instrução: ");
                        grauInstrucao = Console.ReadLine();

                        Console.Write("Qual a sua cidade de nascimento: ");
                        cidade = Console.ReadLine();

                        Console.Write("Qual o seu gênero:\n1) Masculino\n2) Feminino\n3) Outro");
                        while(true){    
                            try{
                                opGenero = int.Parse(Console.ReadLine());

                                if (opGenero == 1){
                                    genero = "Masculino";
                                    break;
                                }
                                else if (opGenero == 2){
                                    genero = "Feminino";
                                    break;
                                }
                                else if (opGenero == 3){
                                    genero = "Outro";
                                    break;
                                }
                                else
                                    throw new ExcecaoOpcaoInvalida("Entre com uma opção válida:");
                            }
                            catch(FormatException){
                                Console.WriteLine("\nErro! Insira a opção no formato correto.");
                            }
                            catch(ExcecaoOpcaoInvalida ex){
                                Console.WriteLine($"\nErro! {ex.Message}");
                            }
                            catch(Exception ex){
                                Console.WriteLine($"\nErro! {ex.Message}");
                            }
                        }

                        Console.Write("Qual o seu estado cívil:\n1) Solteiro(a)\n2) Casado\n3) Divorciado\n4) Viúvo");
                        while(true){
                            try{
                                opEstadoCivil = int.Parse(Console.ReadLine());

                                if (opEstadoCivil == 1){
                                    estadoCivil = "Solteiro";
                                    break;
                                }
                                else if (opEstadoCivil == 2){
                                    estadoCivil = "Casado";
                                    break;
                                }
                                else if (opEstadoCivil == 3){
                                    estadoCivil = "Divorciado";
                                    break;
                                }
                                else if (opEstadoCivil == 4){
                                    estadoCivil = "Viúvo";
                                    break;
                                }
                                else
                                    throw new ExcecaoOpcaoInvalida("Entre com uma opção válida:");
                            }
                            catch(FormatException){
                                Console.WriteLine("\nErro! Insira a opção no formato correto.");
                            }
                            catch(ExcecaoOpcaoInvalida ex){
                                Console.WriteLine($"\nErro! {ex.Message}");
                            }
                            catch(Exception ex){
                                Console.WriteLine($"\nErro! {ex.Message}");
                            }
                        }

                        Console.Write("Qual a sua raça:\n1) Branco\n2) Preto\n3) Pardo\n4) Amarelo\n5) Indígena");

                        while(true){
                            try{
                                opRaca = int.Parse(Console.ReadLine());
                                if (opRaca == 1){
                                    raca = "Branco";
                                    break;
                                }
                                else if (opRaca == 2){
                                    raca = "Preto";
                                    break;
                                }
                                else if (opRaca == 3){
                                    raca = "Pardo";
                                    break;
                                }
                                else if (opRaca == 4){
                                    raca = "Amarelo";
                                    break;
                                }
                                else if (opRaca == 5){
                                    raca = "Indígena";
                                    break;
                                }
                                else
                                    throw new ExcecaoOpcaoInvalida("Entre com uma opção válida:");
                            }
                            catch(FormatException){
                                Console.WriteLine("\nErro! Insira a opção no formato correto.");
                            }
                            catch(ExcecaoOpcaoInvalida ex){
                                Console.WriteLine($"\nErro! {ex.Message}");
                            }
                            catch(Exception ex){
                                Console.WriteLine($"\nErro! {ex.Message}");
                            }
                        }

                        Console.Write("Qual a sua profissão: ");
                        profissao = Console.ReadLine();

                        Console.Write("Qual a sua idade: ");
                        idade = int.Parse(Console.ReadLine());

                        // chamando método para cadastrar o candidato
                        servidor.cadastrarCandidatos(new Candidato(partido, numero, nome, grauInstrucao, cidade, genero, estadoCivil, raca, profissao, idade));
                    }
                }
            }
        }
    }
}