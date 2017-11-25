using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
namespace Cajero_tcp.Clases
{// ip del servidor // ip del cliente // puerto // datos
    class Enviar
    {
        private TcpClient _client;
        private StreamReader _sReader;
        private StreamWriter _sWriter;
        private Boolean _isConnected;
        public  string InformacionRecibida {
            get;
            set;
        }
     public Enviar(String ipAddress, string ipCliente, int portNum,string OpcionDeEnvio, string Metadatos)
        {
            try
            {
                bool ok = true;
                while (ok)
                {
                    _client = new TcpClient();
                    Ping Pings = new Ping();//objeto ping para ver si hay conexion con el servidor
                    int timeout = 10;
                    if (Pings.Send(ipAddress, timeout).Status == IPStatus.Success)// si hay ping me inicia el meotod de hilo para establecer una conexion
                    {
                        _client.Connect(ipAddress, 4563);//se establece conexion y ya esta establecido un puerto unico
                        EnvioTcp(ipCliente, portNum, OpcionDeEnvio, Metadatos);// inicia el envio tcp
                        ok = false;//se cierra el ciclo 
                    }
                    else
                    {
                        //Console.Clear();
                        //Console.WriteLine("                  NO hay conexcion a al servidor verifie ip o conexion");
                        //Console.WriteLine("                                 Ingrese otra ip");
                        //Console.WriteLine("                      Prbablemente se perdio la conexion");
                        //Console.ReadKey();
                        //Program miPrograma = new Program();                  
                        //Console.Clear();
                    }
                }
            }
            catch (Exception)
            {

                Pantallas ConfigurarPantalla = new Pantallas();
            }
        }

    private void EnvioTcp(string cliente, int puerto, string OpcionDeEnvio,string MetaDatos)
        {
            _sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);
            _isConnected = true;
            String sData = string.Empty;
            sData = cliente + "|" + puerto + "|" +OpcionDeEnvio+"|"+ MetaDatos;
            _sWriter.WriteLine(sData);
            _sWriter.Flush();
            _sWriter.Close();
            _sReader.Close();
            _client.Close();
            RecibirDatos(puerto);
        }
       private void RecibirDatos(int puerto)
        {
            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Any, Convert.ToInt32(puerto));
            byte[] ByRec;
            try
            {
                miPrimerSocket.Bind(miDireccion);
                miPrimerSocket.Listen(1);
                Socket Escuchar = miPrimerSocket.Accept();
                ByRec = new byte[255];
                int a = Escuchar.Receive(ByRec, 0, ByRec.Length, 0);
                Array.Resize(ref ByRec, a);
                //Console.WriteLine("El servidor responde:" + Encoding.Default.GetString(ByRec)); //mostramos lo recibido
                InformacionRecibida =   Encoding.Default.GetString(ByRec);
                miPrimerSocket.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.ToString());
            }
        }
    }
}
