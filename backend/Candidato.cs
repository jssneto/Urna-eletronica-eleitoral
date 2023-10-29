using System;

namespace backend {
    public sealed class Candidato : Pessoa {

        private string nomePartido;
        private int numPartido;
        private int qtdVotos;  
        public Candidato() {

            this.NomePartido = "N/D";            
            this.NumPartido = 0;
        }

        public Candidato(string nomePartido, int numPartido, string nomeCompleto, string genero):base(nomeCompleto, genero) {
            
            this.NomePartido = nomePartido;            
            this.NumPartido = numPartido;
        }

        // Proprieades setters e getters
        public string NomePartido {get; set;}
        public int NumPartido {get; set;}
        public int QtdVotos {get; set;}

        // Métodos
        public void apresentarCandidato() {

            Console.WriteLine($"{this.NomeCompleto} - {this.NumPartido} - {this.NomePartido}");
            Console.WriteLine($"{this.GrauInstrucao} - {this.Ocupacao} - {this.Idade} - {this.CidadeNasc}");
            Console.WriteLine($"{this.EstadoCivil} - {this.Genero} - {this.Raca}");
            Console.WriteLine("Quant. Votos obtidos: {0}", qtdVotos);
        }

    }
}