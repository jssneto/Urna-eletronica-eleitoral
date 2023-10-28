using System;

namespace back {
    class Program {
        static void Main(string[] args) {
            Candidato candidato = new Candidato();
            candidato.NomeCompleto = "Luis Inacio Da Silva";

            candidato.apresentaCandidato();
        }
    }
}