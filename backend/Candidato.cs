using System;

namespace backend {
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

        public Candidato(string nomePartido, string coligacao, int numPartido, string nomeCompleto, string grauInstrucao, string cidadeNasc, string genero, string estadoCivil, string raca, string ocupacao, int idade, double bensDeclarados) : base(nomeCompleto, grauInstrucao, cidadeNasc, genero, estadoCivil, raca, ocupacao, idade, bensDeclarados) {

            this.NomePartido = nomePartido;
            this.Coligacao = coligacao;
            this.NumPartido = numPartido;
        }

        // Proprieades setters e getters
        public string NomePartido {get; set;}
        public string Coligacao {get; set;}
        public int NumPartido {get; set;}
        public int QtdVotos {get; set;}

        // Métodos
        public void apresentarCandidato() {

            Console.WriteLine($"{this.NomeCompleto} - {this.NumPartido} - {this.NomePartido} - {this.Coligacao}");
            Console.WriteLine($"{this.GrauInstrucao} - {this.Ocupacao} - {this.Idade} - {this.CidadeNasc}");
            Console.WriteLine($"{this.EstadoCivil} - {this.Genero} - {this.Raca} - {this.BensDeclarados}");
            Console.WriteLine("Quant. Votos obtidos: {0}", qtdVotos);
        }

    }
}