using System;

namespace backend {
    public abstract class Pessoa {

        private string nomeCompleto;
        private string grauInstrucao;
        private string cidadeNasc;
        private string genero;
        private string estadoCivil;
        private string ocupacao;
        private string raca;
        private int idade;

        public Pessoa() {

            this.NomeCompleto = "N/D";
            this.GrauInstrucao = "N/D";
            this.CidadeNasc = "N/D";
            this.Genero = "N/D";
            this.EstadoCivil = "N/D";
            this.Raca = "N/D";
            this.Ocupacao = "N/D";
            this.Idade = 0;
        }

        public Pessoa(string nomeCompleto, string genero){
            this.NomeCompleto = nomeCompleto;            
            this.Genero = genero;
        }

        public Pessoa(string nomeCompleto, string grauInstrucao, string cidadeNasc, string genero, string estadoCivil, string raca, string ocupacao, int idade) {
            this.NomeCompleto = nomeCompleto;
            this.GrauInstrucao = grauInstrucao;
            this.CidadeNasc = cidadeNasc;
            this.Genero = genero;
            this.EstadoCivil = estadoCivil;
            this.Raca = raca;
            this.Ocupacao = ocupacao;
            this.Idade = idade;
        }

        // Proprieades setters e getters
        public string NomeCompleto {get; set;}
        public string GrauInstrucao {get; set;}
        public string CidadeNasc {get; set;}
        public string Genero {get; set;}
        public string EstadoCivil {get; set;}
        public string Raca {get; set;}
        public string Ocupacao {get; set;}
        public int Idade {get; set;}
    }
}