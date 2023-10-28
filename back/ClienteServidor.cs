using System;
using System.Net;
using System.Net.Sockets;

namespace back {
    public class Servidor {

        public Servidor() {
            
        }
    }
    public class Cliente {
        private IPAddress ipv4;
        private int porta;
        private IPEndPoint ipEndPoint;
        public Cliente() {

            this.Ipv4 = IPAddress.Parse("192.168.1.10");
            this.ipEndPoint = new IPEndPoint(Ipv4, 8000);
        }

        public Cliente(IPAddress ipv4, int porta) {
            
            this.Ipv4 = ipv4;
            this.Porta = porta;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        // Setters e Getters
        public IPAddress Ipv4 {get; set;}
        public int Porta {get; set;}

        public void conectar() {

            Socket socket = new Socket(ipv4.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                socket.Connect(ipEndPoint);
                
                socket.Close();

            } catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}

