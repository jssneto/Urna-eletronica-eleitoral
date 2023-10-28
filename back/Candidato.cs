using System;

namespace back {
    public sealed class Candidato : Pessoa {
        private string nomePartido;
        private string coligacao;
        private int numPartido;
        private int qtdVotos;   
        public Candidato() {

            this.NomePartido = "N/D";
            this.Coligacao = "N/D";
            this.NumPartido = 0;
        }

        // Proprieades setters e getters
        public string NomePartido {get; set;}
        public string Coligacao {get; set;}
        public int NumPartido {get; set;}
        public int QtdVotos {get; set;}

        // Métodos
        public void apresentaCandidato() {

            Console.WriteLine($"{this.NomeCompleto} - {this.NumPartido} - {this.NomePartido} - {this.Coligacao}");
            Console.WriteLine($"{this.GrauInstrucao} - {this.Ocupacao} - {this.Idade} - {this.CidadeNasc}");
            Console.WriteLine($"{this.EstadoCivil} - {this.Genero} - {this.Raca} - {this.BensDeclarados}\n");
            Console.WriteLine("Quant. Votos obtidos: {0}", qtdVotos);
        }

    }
}