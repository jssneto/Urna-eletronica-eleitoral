using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
public class Cliente {
        private IPAddress ipv4;
        private int porta;
        private IPEndPoint ipEndPoint;
        public Cliente() {

            this.Ipv4 = IPAddress.Parse("192.168.1.10");
            this.Porta = 8000;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        public Cliente(string ipv4, int porta) {
            
            this.Ipv4 = IPAddress.Parse(ipv4);
            this.Porta = porta;
            this.ipEndPoint = new IPEndPoint(Ipv4, Porta);
        }

        // Setters e Getters
        public IPAddress Ipv4 {get; set;}
        public int Porta {get; set;}

        public void conectar() {

            Socket socket = new Socket(Ipv4.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                socket.Connect(ipEndPoint);

                byte[] buffer = new byte[1024];
                buffer = BitConverter.GetBytes(4);

                socket.Send(buffer);

                socket.Send(BitConverter.GetBytes(13));
                socket.Close();

            } catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }