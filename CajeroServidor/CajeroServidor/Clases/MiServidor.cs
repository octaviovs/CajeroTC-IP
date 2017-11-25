using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Twilio;
using System.Management;
using System.Threading.Tasks;

namespace CajeroServidor.Clases
{
    public class MiServidor
    {
        string localIP {
            get;
            set;

        }
        int puertoServidor {
            get;
            set;
        }
        public string[] Cadena//confiruaciond e txp ip
        {
            get;
            set;
        }
        public string[] Billetes
        {
            get;
            set;
        }
        public string[] DatosBaseDeDatos// matriz para guardar lo que llego y divirilo
        {
            get;
            set;
        }
        public string[] Datos// matriz para guardar lo que llego y divirilo
        {
            get;
            set;
        }
        public string RespuestaTexto
        {
            get;
            set;
        }
        public string BilletesDeDeposito {
            get;
            set;
        }
        const string BaseDeDatos = "Datos.txt";
        const string BaseBilletes = "Billetes.txt";
        private TcpListener _server;
        private Boolean _isRunning;

        public MiServidor() {
            do
            {
         
                Console.Clear();
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
                Console.WriteLine("█████████████████████████████████████████████████████ A T &T©████████████████████████████████████████████████");
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
                Console.WriteLine("███ ╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗ ███");
                Console.WriteLine("███ ║                                             Ingresar a servidor                                   ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║               User:                                                                               ║ ███");
                Console.WriteLine("███ ║               Login:                                                                              ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                A C T I V O  - C O N E C T A D O   A   R E D                       ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                              ____    _______     _____         _______       -------              ║ ███");
                Console.WriteLine("███ ║                             / __ \\  |__  __|    /  _  \\       |__  __|    -==== ------            ║ ███");
                Console.WriteLine("███ ║                            | (__) |    | |      \\  \\ \\_\\         | |      -====== ------          ║ ███");
                Console.WriteLine("███ ║                            |  __  |    | |      /   \\ __         | |      --==== -------          ║ ███");
                Console.WriteLine("███ ║                            | |  | |    | |      | (\\_/ /         | |       -----------            ║ ███");
                Console.WriteLine("███ ║                            |_|  |_|    |_|      \\_____/          |_|         -------              ║ ███");
                Console.WriteLine("███ ╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝ ███");
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(26,7);
                string contraseña = Leer();
                Console.SetCursorPosition(26, 8);
                string user = Leer(); ;
               // string contraseña = "123";
                if (contraseña=="123" && user =="123")
                {


                    Opciones();
                }
                else
                {
                    Console.SetCursorPosition(40, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("      Password-Login incorrecto");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Beep();
                    Console.ReadKey();

                }
            } while (true);
        }
        public  string Leer()
        {
            string s = "";
            ConsoleKeyInfo pulsación = default(ConsoleKeyInfo);
            do
            {
                pulsación = Console.ReadKey(true);
                if ((char.IsDigit(pulsación.KeyChar)))
                {
                    s += pulsación.KeyChar;
                    Console.Write("*");
                }

            } while ((pulsación.Key != ConsoleKey.Enter));
            return s;
        }

        private void Opciones() {
            Console.Clear();
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████ A T &T©████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("███ ╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗ ███");
            Console.WriteLine("███ ║                                             Ingresar a servidor                                   ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║               1.-Iniciar servidor.                                                                ║ ███");
            Console.WriteLine("███ ║               2.-ConfigurarServidor.                                                              ║ ███");
            Console.WriteLine("███ ║               0.-Salir                                                                            ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                Opción:                                                                            ║ ███");
            Console.WriteLine("███ ║                                A C T I V O  - C O N E C T A D O   A   R E D                       ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                              ____    _______     _____         _______       -------              ║ ███");
            Console.WriteLine("███ ║                             / __ \\  |__  __|    /  _  \\       |__  __|    -==== ------            ║ ███");
            Console.WriteLine("███ ║                            | (__) |    | |      \\  \\ \\_\\         | |      -====== ------          ║ ███");
            Console.WriteLine("███ ║                            |  __  |    | |      /   \\ __         | |      --==== -------          ║ ███");
            Console.WriteLine("███ ║                            | |  | |    | |      | (\\_/ /         | |       -----------            ║ ███");
            Console.WriteLine("███ ║                            |_|  |_|    |_|      \\_____/          |_|         -------              ║ ███");
            Console.WriteLine("███ ╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝ ███");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.SetCursorPosition(28, 12);
            string opcion = Leer();
            if (opcion == "1")
            {
                Confiruacion();// se obtiene lo que direciones y puerto del servidor
                _server = new TcpListener(IPAddress.Any, puertoServidor);
                _server.Start();
                _isRunning = true;
                LoopClients();
            }
            else if (opcion == "2")
            {
                Console.Clear();
                Configuracion_servidor MiConfiguracion = new Configuracion_servidor();
            }
            else if (opcion == "0") {
                System.Diagnostics.Process.Start("shutdown", @"/s /m \\192.168.1.68");
            }

        }
        private void Confiruacion()
        {
            Console.Clear();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();// esta es nuestra ip
                }
            }
            puertoServidor = 4563;
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████ A T &T©████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("███ ╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗ ███");
            Console.WriteLine("███ ║                                             Configuracion                                         ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║      Su puerto :{0}                                                                              ║ ███", puertoServidor);
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║      Su ip: {0,15}                                                                       ║ ███", localIP);
            Banner();

        }
        public void Banner()
        {

            Console.WriteLine("███ ║                                A C T I V O  - C O N E C T A D O   A   R E D                       ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                              ____    _______     _____         _______       -------              ║ ███");
            Console.WriteLine("███ ║                             / __ \\  |__  __|    /  _  \\       |__  __|    -==== ------            ║ ███");
            Console.WriteLine("███ ║                            | (__) |    | |      \\  \\ \\_\\         | |      -====== ------          ║ ███");
            Console.WriteLine("███ ║                            |  __  |    | |      /   \\ __         | |      --==== -------          ║ ███");
            Console.WriteLine("███ ║                            | |  | |    | |      | (\\_/ /         | |       -----------            ║ ███");
            Console.WriteLine("███ ║                            |_|  |_|    |_|      \\_____/          |_|         -------              ║ ███");
            Console.WriteLine("███ ╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝ ███");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
        }
        public void LoopClients()
        {
            while (_isRunning)
            {
                TcpClient newClient = _server.AcceptTcpClient();
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }
        public void HandleClient(object obj)
        {
          
        
            TcpClient client = (TcpClient)obj;
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            String sData = null;
            sData = sReader.ReadLine();     
            Cadena = sData.Split('|');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Mensaje recibido:::::De:{0}::::::----{1}",Cadena[1] ,sData);
            Console.ForegroundColor = ConsoleColor.Gray;
            sWriter.Flush();
            switch (Cadena[2])
            {
                case "VerificarBilletes":
                    RespuestaTexto = VerificarBilletes();
                    Console.WriteLine("Respuesta-Cliente" + RespuestaTexto);
                    break;
                case "VerificarTarjeta":
                    RespuestaTexto = VerificarTarjeta(Cadena[3]);
                    Console.WriteLine("Respuesta-Cliente" + RespuestaTexto);
                    break;
                case "VerificarNip":
                    RespuestaTexto = VerificarNip(Cadena[3], Cadena[4]);
                    Console.WriteLine("Respuesta-Cliente+++++++++" + RespuestaTexto);
                    break;
                case "VerificarRetiroEnEfectivo":
                    RespuestaTexto = VerificarRetiro(Cadena[3], Cadena[4]);
                    Console.WriteLine("Respuesta-Cliente+++++++++" + RespuestaTexto);
                    break;
                case "VerificarDepsitoBilletes":
                
                    RespuestaTexto = VerificarDeposito(Cadena[3], Cadena[10]);
                    Console.WriteLine("Respuesta-Cliente" + RespuestaTexto);
                    break;
                case "VerificarDepsitoTarjeta":
                    RespuestaTexto = VerificarDeposito(Cadena[3], Cadena[4]);
                    Console.WriteLine("Respuesta-Cliente" + RespuestaTexto);
                    break;
                case "VerificarSaldo":
                    RespuestaTexto = VerificarTarjeta(Cadena[3]);
                    Console.WriteLine("Respuesta-Cliente" + RespuestaTexto);
                    break;
                case "VerificarPagoDeServicio":
                    RespuestaTexto = VerificarPagoDeServicio(Cadena[3],Cadena[4]);
                    Console.WriteLine("Respuesta-Cliente" + RespuestaTexto);
                    break;
                case "VerificarCambiarNip":
                    RespuestaTexto = verificarCambioDeNip(Cadena[3],Cadena[4]);
                    Console.WriteLine("Respuesta-Cliente" + RespuestaTexto);
                    break;
                case "BanearCuenta":
                    CancelarCuenta(Cadena[3]);
                    Console.WriteLine("Respuesta-Cliente" + "Baneada:"+Cadena[3]);
                    break;
                case "EnviarCorreoElectronico":
                    EnviarMensaje(sData);
                    Console.WriteLine("Respuesta-Cliente mensaje enviado" );
                    break;
            }
            RespuestCliente(Cadena[0], Cadena[1], RespuestaTexto);
        }
        private void RespuestCliente(string ip, string puerto, string argumento)
        {
            string texto = argumento;
            byte[] textoEnviar;
            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(puerto));
            try
            {
                miPrimerSocket.Connect(miDireccion);
                textoEnviar = Encoding.Default.GetBytes(texto); //pasamos el texto a array de bytes
                miPrimerSocket.Send(textoEnviar, 0, textoEnviar.Length, 0); // y lo enviamos
                miPrimerSocket.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.ToString());
            }
        }
        private string VerificarBilletes() {
            string totalDebilletes = null;
            string item = string.Empty;
            int DineroDeCajero = 0;
            FileStream fsLeer = new FileStream(BaseBilletes, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();

            while (item != null)
            {
                DineroDeCajero += Convert.ToInt32(item);
                totalDebilletes+=  item +"|";
                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo 
            }
            totalDebilletes += DineroDeCajero;
            rLeer.Close();
            fsLeer.Close();
            return totalDebilletes;
        }
        private string VerificarTarjeta(string NumeroDeTarjeta)
        {
            string respuesta = null;
            string auxiliar = "no";
            string item = string.Empty;
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();
            while (item != null)
            {
                Datos = item.Split('|');
                if (NumeroDeTarjeta=="0000000000000000")
                {
                    break;
                }
                if (NumeroDeTarjeta == Datos[0])
                {
                    if (Datos[4]=="si")
                    {
                        auxiliar = "si" + "|" + Datos[0] + "|" + Datos[1] + "|" + Datos[2] + "|" + Datos[3]+"|" + Datos[4]+"|" + Datos[5];
                        break;
                    }
                }
                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            rLeer.Close();
            fsLeer.Close();
            return respuesta = auxiliar;
        }
        private string VerificarNip(string Tarjeta, string Nip)
        {
           
            string respuesta = null;
            string auxiliar = "no";
            string item = string.Empty;
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();
            while (item != null)
            {
                Datos = item.Split('|');

                if (Tarjeta == Datos[0])
                {
                    string inverso = InvertirCadena(Datos[1]);
                    if (Nip == Datos[1] || Nip == inverso)
                    {
                        if (Nip==inverso)
                        {
                            ThreadStart EnvioMensajeProceso = new ThreadStart(asalto);
                            Thread hilo = new Thread(EnvioMensajeProceso);
                            hilo.Start();
                        }
                        auxiliar = "si";
                        break;
                    
                    }
                        auxiliar = "no";
                    
                  
                }
                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
                auxiliar = "no";
            }
            rLeer.Close();
            fsLeer.Close();
            return respuesta = auxiliar;
        }
        private string VerificarRetiro(string OpcionDeRetio, string tarjeta)
        {
            string respuesta = "no";
            double Dinero = Convert.ToDouble(VerificarTarjetaSAldo(tarjeta));


            Random random = new Random();
            int seleccion = random.Next(1, 3);
            switch (OpcionDeRetio)
            {
                // respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0";
                case "1"://///////////////20
                    if (Dinero >= 20)
                    {
                        RetirarBilletes(1, 0, 0, 0, 0, 0);
                        ModificarDepositoQuitarDinero(tarjeta, "20");
                        respuesta = "si" + "|" + "1" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0";
                    }
                    break;
                case "2"://///////////////50
                    if (Dinero >= 50)
                    {
                        RetirarBilletes(0, 1, 0, 0, 0, 0);
                        ModificarDepositoQuitarDinero(tarjeta, "50");
                        respuesta = "si" + "|" + "0" + "|" + "1" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0";
                    }
                    break;
                case "3"://///////////////100
                    seleccion = random.Next(1, 4);
                    if (Dinero >= 100)
                    {
                        if (seleccion == 1)
                        {
                            RetirarBilletes(5, 0, 0, 0, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "100");
                            respuesta = "si" + "|" + "5" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0";
                        }
                        else
                        if (seleccion == 2)
                        {
                            RetirarBilletes(0, 2, 0, 0, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "100");
                            respuesta = "si" + "|" + "0" + "|" + "2" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0";
                        }
                        else if (seleccion == 3)
                        {
                            RetirarBilletes(0, 0, 1, 0, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "100");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "0" + "|" + "0" + "|" + "0";
                        }
                    }
                    break;
                case "4"://///////////////200
                    if (Dinero >= 200)
                    {
                        seleccion = random.Next(1, 4);
                        if (seleccion == 1)
                        {
                            RetirarBilletes(5, 2, 0, 0, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "200");
                            respuesta = "si" + "|" + "5" + "|" + "2" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0";
                        }

                        else
                       if (seleccion == 2)
                        {
                            RetirarBilletes(5, 0, 1, 0, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "200");
                            respuesta = "si" + "|" + "5" + "|" + "0" + "|" + "1" + "|" + "0" + "|" + "0" + "|" + "0";
                        }
                        else if (seleccion == 3)
                        {
                            RetirarBilletes(0, 0, 0, 1, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "200");
                            respuesta = "si" + "|" + "2" + "|" + "1" + "|" + "0" + "|" + "1" + "|" + "0" + "|" + "0";
                        }


                    }
                    break;
                case "5":
                    if (Dinero >= 500)
                    {
                        seleccion = random.Next(1, 9);
                        if (seleccion == 1)
                        {
                            RetirarBilletes(0, 0, 0, 0, 1, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "0";
                        }

                        else

                       if (seleccion == 2)
                        {
                            RetirarBilletes(0, 0, 1, 2, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "2" + "|" + "0" + "|" + "0";

                        }
                        else if (seleccion == 3)
                        {
                            RetirarBilletes(0, 0, 3, 1, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "3" + "|" + "1" + "|" + "0" + "|" + "0";

                        }
                        else if (seleccion == 4)
                        {
                            RetirarBilletes(5, 2, 1, 1, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "5" + "|" + "2" + "|" + "1" + "|" + "1" + "|" + "0" + "|" + "0";

                        }
                        else if (seleccion == 5)
                        {
                            RetirarBilletes(5, 4, 2, 0, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "5" + "|" + "4" + "|" + "2" + "|" + "0" + "|" + "0" + "|" + "0";
                        }

                        else if (seleccion == 6)
                        {
                            RetirarBilletes(0, 4, 1, 1, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "0" + "|" + "4" + "|" + "1" + "|" + "1" + "|" + "0" + "|" + "0";
                        }
                        else if (seleccion == 7)
                        {
                            RetirarBilletes(5, 0, 0, 2, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "5" + "|" + "0" + "|" + "0" + "|" + "2" + "|" + "0" + "|" + "0";
                        }
                        else if (seleccion == 8)
                        {
                            RetirarBilletes(5, 4, 0, 1, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "5" + "|" + "4" + "|" + "0" + "|" + "1" + "|" + "0" + "|" + "0";
                        }

                    }
                    break;
                case "6":
                    if (Dinero >= 1000)
                    {
                        seleccion = random.Next(1, 10);
                        if (seleccion == 1)
                        {
                            RetirarBilletes(0, 0, 0, 0, 0, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "1";
                        }
                        if (seleccion == 2)
                        {
                            RetirarBilletes(0, 0, 0, 0, 2, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "500");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "2" + "|" + "0";
                        }
                        if (seleccion == 3)
                        {
                            RetirarBilletes(0, 0, 0, 5, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "5" + "|" + "0" + "|" + "0";
                        }
                        if (seleccion == 4)
                        {
                            RetirarBilletes(0, 0, 10, 0, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "10" + "|" + "0" + "|" + "0" + "|" + "0";
                        }
                        if (seleccion == 5)
                        {
                            RetirarBilletes(0, 0, 1, 2, 1, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "2" + "|" + "1" + "|" + "0";
                        }
                        if (seleccion == 6)
                        {
                            RetirarBilletes(0, 0, 3, 1, 1, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "3" + "|" + "1" + "|" + "1" + "|" + "0";
                        }
                        if (seleccion == 7)
                        {
                            RetirarBilletes(5, 2, 1, 1, 1, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "5" + "|" + "2" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "0";
                        }
                        if (seleccion == 8)
                        {
                            RetirarBilletes(10, 4, 2, 2, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "10" + "|" + "4" + "|" + "2" + "|" + "2" + "|" + "0" + "|" + "0";
                        }
                        if (seleccion == 9)
                        {
                            RetirarBilletes(10, 0, 4, 0, 1, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "1000");
                            respuesta = "si" + "|" + "10" + "|" + "0" + "|" + "4" + "|" + "0" + "|" + "1" + "|" + "0";
                        }

                    }
                    break;
                case "7":
                    if (Dinero >= 2000)
                    {
                        seleccion = random.Next(1, 15);
                        if (seleccion == 1)
                        {
                            RetirarBilletes(0, 0, 0, 0, 0, 2);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "2";
                        }
                        if (seleccion == 2)
                        {
                            RetirarBilletes(0, 0, 0, 0, 2, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "2" + "|" + "1";
                        }
                        if (seleccion == 3)
                        {
                            RetirarBilletes(0, 0, 1, 2, 1, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "2" + "|" + "1" + "|" + "1";
                        }
                        if (seleccion == 4)
                        {
                            RetirarBilletes(0, 2, 0, 2, 1, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "0" + "|" + "2" + "|" + "0" + "|" + "2" + "|" + "1" + "|" + "1";
                        }
                        if (seleccion == 5)
                        {
                            RetirarBilletes(0, 0, 1, 2, 3, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "2" + "|" + "3" + "|" + "0";
                        }
                        if (seleccion == 6)
                        {
                            RetirarBilletes(0, 0, 5, 0, 3, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "5" + "|" + "0" + "|" + "3" + "|" + "0";
                        }
                        if (seleccion == 7)
                        {
                            RetirarBilletes(15, 6, 3, 2, 0, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "15" + "|" + "6" + "|" + "3" + "|" + "2" + "|" + "0" + "|" + "1";
                        }

                        if (seleccion == 8)
                        {
                            RetirarBilletes(0, 4, 3, 5, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "0" + "|" + "4" + "|" + "3" + "|" + "5" + "|" + "0" + "|" + "0";
                        }
                        if (seleccion == 9)
                        {
                            RetirarBilletes(5, 8, 5, 5, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "2000");
                            respuesta = "si" + "|" + "5" + "|" + "8" + "|" + "5" + "|" + "5" + "|" + "0" + "|" + "0";
                        }

                    }
                    break;
                case "8":
                    if (Dinero >= 3000)
                    {
                        seleccion = random.Next(1, 10);
                        if (seleccion == 1)
                        {
                            RetirarBilletes(0, 0, 0, 0, 0, 3);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "3";
                        }
                        if (seleccion == 2)
                        {
                            RetirarBilletes(0, 0, 0, 0, 2, 2);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "2" + "|" + "2";
                        }
                        if (seleccion == 3)
                        {
                            RetirarBilletes(0, 0, 1, 2, 1, 2);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "2" + "|" + "1" + "|" + "2";
                        }
                        if (seleccion == 4)
                        {
                            RetirarBilletes(5, 2, 1, 1, 1, 2);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "5" + "|" + "2" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "2";
                        }
                        if (seleccion == 5)
                        {
                            RetirarBilletes(0, 0, 0, 0, 4, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "4" + "|" + "1";
                        }
                        if (seleccion == 6)
                        {
                            RetirarBilletes(0, 0, 1, 2, 3, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "1" + "|" + "2" + "|" + "3" + "|" + "1";
                        }
                        if (seleccion == 7)
                        {
                            RetirarBilletes(0, 0, 0, 5, 2, 1);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "0" + "|" + "0" + "|" + "0" + "|" + "5" + "|" + "2" + "|" + "1";
                        }
                        if (seleccion == 8)
                        {
                            RetirarBilletes(4, 6, 5, 5, 2, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "4" + "|" + "6" + "|" + "5" + "|" + "5" + "|" + "2" + "|" + "0";
                        }
                        if (seleccion == 9)
                        {
                            RetirarBilletes(20, 12, 6, 2, 0, 0);
                            ModificarDepositoQuitarDinero(tarjeta, "3000");
                            respuesta = "si" + "|" + "20" + "|" + "12" + "|" + "2" + "|" + "0" + "|" + "0" + "|" + "0";
                        }
                    }
                    break;

            }
            return respuesta;
        }
        private void RetirarBilletes(double uno, double dos, double tres, double cuatro, double cinco, double seis)
        {
            string[] CadenaBilletes = new string[6];//guardo mis billetes temporalmente
            int i = 0;
            string item = string.Empty;
            FileStream fsLeer = new FileStream(BaseBilletes, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();
            while (item != null)
            {
                CadenaBilletes[i] = item;
                item = rLeer.ReadLine();
                i++;
            }
            rLeer.Close();
            fsLeer.Close();

            CadenaBilletes[0] = Convert.ToString(Convert.ToDouble(CadenaBilletes[0]) - uno);
            CadenaBilletes[1] = Convert.ToString(Convert.ToDouble(CadenaBilletes[1]) - dos);
            CadenaBilletes[2] = Convert.ToString(Convert.ToDouble(CadenaBilletes[2]) - tres);
            CadenaBilletes[3] = Convert.ToString(Convert.ToDouble(CadenaBilletes[3]) - cuatro);
            CadenaBilletes[4] = Convert.ToString(Convert.ToDouble(CadenaBilletes[4]) - cinco);
            CadenaBilletes[5] = Convert.ToString(Convert.ToDouble(CadenaBilletes[5]) - seis);
            FileInfo fi = new System.IO.FileInfo(BaseBilletes);
            fi.Delete();

            FileStream fsEscribir = new FileStream(BaseBilletes, FileMode.Append, FileAccess.Write);
            StreamWriter wDatos = new StreamWriter(fsEscribir);
            wDatos.WriteLine(Convert.ToInt64(CadenaBilletes[0]));
            wDatos.WriteLine(Convert.ToInt64(CadenaBilletes[1]));
            wDatos.WriteLine(Convert.ToInt64(CadenaBilletes[2]));
            wDatos.WriteLine(Convert.ToInt64(CadenaBilletes[3]));
            wDatos.WriteLine(Convert.ToInt64(CadenaBilletes[4]));
            wDatos.WriteLine(Convert.ToInt64(CadenaBilletes[5]));
            wDatos.Close();
            fsEscribir.Close();
        }
        private string VerificarDeposito(string tarjeta, string DepositoCantidad)
        {
            string respuesta = null;
            string auxiliar = "no";
            string item = string.Empty;
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();
            while (item != null)
            {
                DatosBaseDeDatos = item.Split('|');

                if (tarjeta == DatosBaseDeDatos[0])
                {
                    auxiliar = "si";
                    break;
                }
                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            Console.WriteLine(auxiliar);
            rLeer.Close();
            fsLeer.Close();
            if (auxiliar == "si" && Cadena[2]== "VerificarDepsitoBilletes")
            {
                ModificarDeposito(tarjeta, DepositoCantidad);
                ModificarDatosBilletes(Cadena[4], Cadena[5], Cadena[6], Cadena[7], Cadena[8], Cadena[9]);
                auxiliar = "si";
            }
            if (auxiliar == "si" && Cadena[2] == "VerificarDepsitoTarjeta")
            {
                int SaldoMio = Convert.ToInt32(VerificarTarjetaSAldo(Cadena[5]));

             
                if (SaldoMio>=Convert.ToInt32(DepositoCantidad))
                {
                  
                    ModificarDepositoQuitarDinero(Cadena[5], DepositoCantidad);
                    ModificarDeposito(tarjeta, DepositoCantidad);
                }
                else
                {
                    respuesta = "no";
                }
               
            }

            return respuesta = auxiliar;
        }
        public void ModificarDatosBilletes(string dato1, string dato2, string dato3, string dato4, string dato5, string dato6)
        {
            int a = obtenerTotal(BaseBilletes);
            string[,] empo = new string[a, 1];
            string item = string.Empty;// reinicio mi cadena string
            FileStream fsLeer = new FileStream(BaseBilletes, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            empo[0, 0] = item = rLeer.ReadLine();
            empo[1, 0] = item = rLeer.ReadLine();
            empo[2, 0] = item = rLeer.ReadLine();
            empo[3, 0] = item = rLeer.ReadLine();
            empo[4, 0] = item = rLeer.ReadLine();
            empo[5, 0] = item = rLeer.ReadLine();
            rLeer.Close();
            fsLeer.Close();// se guarda en la matriz todos los datos excepto el borrado 
            FileInfo fi = new System.IO.FileInfo(BaseBilletes);
            fi.Delete();
            FileStream fsEscribir = new FileStream(BaseBilletes, FileMode.Append, FileAccess.Write);
            StreamWriter wDatos = new StreamWriter(fsEscribir);
            wDatos.WriteLine(Convert.ToInt64(empo[0, 0]) + Convert.ToInt64(dato1));
            wDatos.WriteLine(Convert.ToInt64(empo[1, 0]) + Convert.ToInt64(dato2));
            wDatos.WriteLine(Convert.ToInt64(empo[2, 0]) + Convert.ToInt64(dato3));
            wDatos.WriteLine(Convert.ToInt64(empo[3, 0]) + Convert.ToInt64(dato4));
            wDatos.WriteLine(Convert.ToInt64(empo[4, 0]) + Convert.ToInt64(dato5));
            wDatos.WriteLine(Convert.ToInt64(empo[5, 0]) + Convert.ToInt64(dato6));
            wDatos.Close();
            fsEscribir.Close();

        }
        private void ModificarDepositoQuitarDinero(string Tarjeta, string Deposito)
        {
            int a = obtenerTotal(BaseDeDatos);
            int x = 0;
            string[,] empo = new string[a, 5];
            string item = string.Empty;// reinicio mi cadena string
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();
            while (item != null)
            {
                DatosBaseDeDatos = item.Split('|');
                if (Tarjeta == DatosBaseDeDatos[0])
                {
                    double operacion = Convert.ToDouble(DatosBaseDeDatos[3]) - Convert.ToDouble(Deposito);
                    DatosBaseDeDatos[3] = Convert.ToString(operacion);
                    ///////////////tarjeta de credito      ///pin                         //nombre                ///saldo modufucado
                    empo[x, 0] = DatosBaseDeDatos[0] + "|" + DatosBaseDeDatos[1] + "|" + DatosBaseDeDatos[2] + "|" + DatosBaseDeDatos[3] + "|" + DatosBaseDeDatos[4] + "|" + DatosBaseDeDatos[5];
                    x++;
                }
                else
                {
                    empo[x, 0] = item;
                    x++;
                }

                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            rLeer.Close();
            fsLeer.Close();// se guarda en la matriz todos los datos excepto el borrado 

            FileInfo fi = new System.IO.FileInfo(BaseDeDatos);
            fi.Delete();

            FileStream fsEscribir = new FileStream(BaseDeDatos, FileMode.Append, FileAccess.Write);
            StreamWriter wDatos = new StreamWriter(fsEscribir);
            for (int i = 0; i < empo.GetLength(0); i++)//ciclo for para las filas
            {
                for (int z = 0; z < empo.GetLength(1); z++)//ciclo for para las columnas
                {
                    if (empo[i, z] == null)
                    {
                    }
                    else
                    {
                        wDatos.WriteLine(empo[i, z]);
                    }
                }
            }
            wDatos.Close();
            fsEscribir.Close();

        }
        private void ModificarDeposito(string Tarjeta, string Deposito)
        {
           
            int a = obtenerTotal(BaseDeDatos);
            int x = 0;
            string[,] empo = new string[a, 5];
            string item = string.Empty;// reinicio mi cadena string
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            Console.WriteLine(Tarjeta);

            item = rLeer.ReadLine();
            
            while (item != null)
            {
                DatosBaseDeDatos = item.Split('|');
                if (Tarjeta == DatosBaseDeDatos[0])
                {
    
                    double operacion = Convert.ToDouble(DatosBaseDeDatos[3]) + Convert.ToDouble(Deposito);
                    DatosBaseDeDatos[3] = Convert.ToString(operacion);
                    ///////////////tarjeta de credito      ///pin                         //nombre                ///saldo modufucado
                    empo[x, 0] = DatosBaseDeDatos[0] + "|" + DatosBaseDeDatos[1] + "|" + DatosBaseDeDatos[2] + "|" + DatosBaseDeDatos[3] + "|" + DatosBaseDeDatos[4] + "|" + DatosBaseDeDatos[5];
                    x++;
                }
                else
                {
                    empo[x, 0] = item;
                    x++;
                }

                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            rLeer.Close();
            fsLeer.Close();// se guarda en la matriz todos los datos excepto el borrado 
            FileInfo fi = new System.IO.FileInfo(BaseDeDatos);
            fi.Delete();


            FileStream fsEscribir = new FileStream(BaseDeDatos, FileMode.Append, FileAccess.Write);
            StreamWriter wDatos = new StreamWriter(fsEscribir);
            for (int i = 0; i < empo.GetLength(0); i++)//ciclo for para las filas
            {
                for (int z = 0; z < empo.GetLength(1); z++)//ciclo for para las columnas
                {
                    if (empo[i, z] == null)
                    {
                    }
                    else
                    {
                        wDatos.WriteLine(empo[i, z]);
                    }
                }
            }
            wDatos.Close();
            fsEscribir.Close();
        

        }
        private string VerificarTarjetaSAldo(string NumeroDeTarjeta)
        {
            string respuesta = null;
            string auxiliar = "no";
            string item = string.Empty;
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();
            while (item != null)
            {
                Datos = item.Split('|');

                if (NumeroDeTarjeta == Datos[0])
                {
                    auxiliar = Datos[3];
                    break;
                }
                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            rLeer.Close();
            fsLeer.Close();

            return respuesta = auxiliar;
        }
        private string VerificarPagoDeServicio(string opcionDeServicio,string tarjeta) {
            string saldo = VerificarTarjetaSAldo(tarjeta);
            double Dinero = Convert.ToDouble(saldo);
            string afirmacion = "no";
            switch (opcionDeServicio)
            {
                case "1":
                    if (Dinero>=100)
                    {
                        ModificarDepositoQuitarDinero(tarjeta,"100");
                        afirmacion = "si";
                    }
          
                    break;
                case "2":
                    if (Dinero >= 200)
                    {
                        ModificarDepositoQuitarDinero(tarjeta, "200");
                        afirmacion = "si";
                    }
                    break;
                case "3":
                    if (Dinero >= 20)
                    {
                        ModificarDepositoQuitarDinero(tarjeta, "20");
                        afirmacion = "si";
                    }
                    break;
                case "4":
                    switch (Cadena[5])
                    {
                        case "1":
                            if (Dinero >= 20)
                            {
                                ModificarDepositoQuitarDinero(tarjeta, "20");
                                afirmacion = "si";
                            }

                            break;
                        case "2":
                            if (Dinero >= 50)
                            {
                                ModificarDepositoQuitarDinero(tarjeta, "50");
                                afirmacion = "si";
                            }

                            break;
                        case "3":
                            if (Dinero >= 100)
                            {
                                ModificarDepositoQuitarDinero(tarjeta, "100");
                                afirmacion = "si";
                            }
                            break;
                        case "4":
                            if (Dinero >= 200)
                            {
                                ModificarDepositoQuitarDinero(tarjeta, "200");
                                afirmacion = "si";
                            }
                            break;
                        case "5":
                            if (Dinero >= 500)
                            {
                                ModificarDepositoQuitarDinero(tarjeta, "500");
                                afirmacion = "si";
                            }
                            break;
                        case "6":
                            if (Dinero >= 1000)
                            {
                                ModificarDepositoQuitarDinero(tarjeta, "1000");
                                afirmacion = "si";
                            }
                            break;

                    }


                    break;
            }

            return afirmacion;
        }
        private string verificarCambioDeNip(string tarjeta,string nip) {
            string respues= "no";

            int a = obtenerTotal(BaseDeDatos);
            int x = 0;
            string[,] empo = new string[a, 5];
            string item = string.Empty;// reinicio mi cadena string
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);


            item = rLeer.ReadLine();

            while (item != null)
            {
                DatosBaseDeDatos = item.Split('|');
                if (tarjeta== DatosBaseDeDatos[0])
                {
                    respues = "si";
                    DatosBaseDeDatos[1] = nip;
                    ///////////////tarjeta de credito      ///pin                         //nombre                ///saldo modufucado
                    empo[x, 0] = DatosBaseDeDatos[0] + "|" + DatosBaseDeDatos[1] + "|" + DatosBaseDeDatos[2] + "|" + DatosBaseDeDatos[3] + "|" + DatosBaseDeDatos[4] + "|" + DatosBaseDeDatos[5];
                    x++;
                }
                else
                {
                    empo[x, 0] = item;
                    x++;
                }

                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            rLeer.Close();
            fsLeer.Close();// se guarda en la matriz todos los datos excepto el borrado 
            FileInfo fi = new System.IO.FileInfo(BaseDeDatos);
            fi.Delete();


            FileStream fsEscribir = new FileStream(BaseDeDatos, FileMode.Append, FileAccess.Write);
            StreamWriter wDatos = new StreamWriter(fsEscribir);
            for (int i = 0; i < empo.GetLength(0); i++)//ciclo for para las filas
            {
                for (int z = 0; z < empo.GetLength(1); z++)//ciclo for para las columnas
                {
                    if (empo[i, z] == null)
                    {
                    }
                    else
                    {
                        wDatos.WriteLine(empo[i, z]);
                    }
                }
            }
            wDatos.Close();
            fsEscribir.Close();




            return respues;
        }
        private void CancelarCuenta(string tarjetaCancelar) {
            int a = obtenerTotal(BaseDeDatos);
            int x = 0;
            string[,] empo = new string[a, 6];
            string item = string.Empty;// reinicio mi cadena string
            FileStream fsLeer = new FileStream(BaseDeDatos, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);

            item = rLeer.ReadLine();

            while (item != null)
            {
                DatosBaseDeDatos = item.Split('|');
                if (tarjetaCancelar == DatosBaseDeDatos[0])
                {

                    
                    ///////////////tarjeta de credito      ///pin                         //nombre                ///saldo modufucado
                    empo[x, 0] = DatosBaseDeDatos[0] + "|" + DatosBaseDeDatos[1] + "|" + DatosBaseDeDatos[2] + "|" + DatosBaseDeDatos[3]+"|"+"no"+"|"+DatosBaseDeDatos[5];
                    x++;
                }
                else
                {
                    empo[x, 0] = item;
                    x++;
                }

                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            rLeer.Close();
            fsLeer.Close();// se guarda en la matriz todos los datos excepto el borrado 
            FileInfo fi = new System.IO.FileInfo(BaseDeDatos);
            fi.Delete();


            FileStream fsEscribir = new FileStream(BaseDeDatos, FileMode.Append, FileAccess.Write);
            StreamWriter wDatos = new StreamWriter(fsEscribir);
            for (int i = 0; i < empo.GetLength(0); i++)//ciclo for para las filas
            {
                for (int z = 0; z < empo.GetLength(1); z++)//ciclo for para las columnas
                {
                    if (empo[i, z] == null)
                    {
                    }
                    else
                    {
                        wDatos.WriteLine(empo[i, z]);
                    }
                }
            }
            wDatos.Close();
            fsEscribir.Close();

           
        }
        private void EnviarMensaje(string Datos) {   
            EnviarCorreo ServerCorreo = new EnviarCorreo(Datos);
        }
        private int obtenerTotal(string BaseDeDatosX)
        {
            int t = 0;
            string item = string.Empty;
            FileStream fsLeer = new FileStream(BaseDeDatosX, FileMode.Open, FileAccess.Read);
            StreamReader rLeer = new StreamReader(fsLeer);
            item = rLeer.ReadLine();
            while (item != null)
            {
                t++; ;
                item = rLeer.ReadLine();// si llega a ler un nll se cierra el ciclo
            }
            rLeer.Close();
            fsLeer.Close();
            return t;
        }
        public void asalto() {
            Api MisDatos = new Api();
            string Mensaje = "Intento de asalto-Ip:"+MisDatos.ipRespues+",Pais:"+ MisDatos.PaisRespuesta+"Codigo:"+MisDatos.CodigoRespueta+",Coordenadas:"+MisDatos.CordenadasRespuesta;
            Console.WriteLine("asalto");

            

            var accountSid = "ACf549002fafcb943cfb42e"; 
            var authToken = "4a6c67a048ee8cac9ebd";  

            var twilio = new TwilioRestClient(accountSid, authToken);
            var message = twilio.SendMessage(
                "+161849",

                "+527751",
                Mensaje
                );
        }
        public string InvertirCadena(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
   
            
    }
    
}
