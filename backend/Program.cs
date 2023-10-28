using System;

namespace backend
{
    class Program {
        static void Main(string[] args) {

            Servidor servidor = new Servidor();
            
            while(true) {
                Console.WriteLine("[1]. Cadastrar candidato.");
                Console.WriteLine("[2]. Listar Candidatos.");
                Console.WriteLine("[3]. Listar resultados.");

                Console.Write("Opcao: ");
                int op = int.Parse(Console.ReadLine());

                switch(op) {
                    case 1:
                        servidor.cadastrarCandidatos(new Candidato("PT", "Lula", 13, "Nicolas M. Ferreira", "Superior", "Contagem", "Masculino", "Solteiro", "Pardo", "Programador", 22, 20.000));
                    break;

                    case 2:
                        servidor.listarCandidatos();
                    break;

                    case 3:
                        servidor.listarVotos();
                    break;
                }
            }
        }
    }
}