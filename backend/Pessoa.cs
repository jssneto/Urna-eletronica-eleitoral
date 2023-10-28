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
        private double bensDeclarados;

        public Pessoa() {

            this.NomeCompleto = "N/D";
            this.GrauInstrucao = "N/D";
            this.CidadeNasc = "N/D";
            this.Genero = "N/D";
            this.EstadoCivil = "N/D";
            this.Raca = "N/D";
            this.ocupacao = "N/D";
            this.Idade = 0;
            this.BensDeclarados = 0.0;
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
        public double BensDeclarados {get; set;}
    }
}