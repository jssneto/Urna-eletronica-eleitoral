using System;

namespace backend
{
    class Program {
        static void Main(string[] args) {

            Servidor servidor = new Servidor();
            Cliente cliente = new Cliente();

            cliente.votar(servidor);
            
        }
    }
}