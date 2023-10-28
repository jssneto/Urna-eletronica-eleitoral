using System;

namespace backend {
    public class Votos {

        private int qtdVotosTotal;
        private int qtdVotosValidos;
        private int qtdVotosBrancos;
        private int qtdVotosNulos;
        
        public Votos() {

            qtdVotosTotal = 0;
            qtdVotosBrancos = 0;
            qtdVotosNulos = 0;
            qtdVotosValidos = 0;            
        }

        public int QtdVotosTotal {get; set;}
        public int QtdVotosValidos {get; set;}
        public int QtdVotosNulos {get; set;}
        public int QtdVotosBrancos {get; set;}
               
    }
}