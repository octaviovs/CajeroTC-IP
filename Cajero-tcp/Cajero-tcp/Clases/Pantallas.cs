using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cajero_tcp.Clases
{
  public  class Pantallas
    {

        //propiedaes de configuracion de serviro
        string ipServidor {
            get;
            set;
        }
        int puertoCliente {
            get;
            set;
        }
        string localIP
        {
            set;
            get;
        }
        // propiedes de configuracion de cajero
        string[] Billetes {
            get;
            set;
        }
        string user
       {
            get;
            set;
        }
        string[] InformacionRecibida
        {
            get;
            set;
        }
        string NumeroDeTarjeta {
            get;
            set;
        }
        string nip {
            get;
            set;
        }
        string opcionMenu {
            get;
            set;
        }
        string[] CantidadBilletes {
            get;    
            set;
        }
        string [] aux
        {
            get;
            set;

        }
        string correo
        {
            get;

            set;
        }
        string nombe {
            get;
            set;
        }
        public  Pantallas() {

            Confiruacion();
            while (true)
            {
                Enviar EnvioServidor = new Enviar(ipServidor, localIP, puertoCliente, "VerificarBilletes", "billetes");
                Pantallainicio(EnvioServidor.InformacionRecibida);
            }
         
        }
        private void Confiruacion() {
            Console.Clear();
            try
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();// esta es nuestra ip
                    }
                }
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
                Console.WriteLine("█████████████████████████████████████████████████████ A T &T©████████████████████████████████████████████████");
                Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
                Console.WriteLine("███ ╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗ ███");
                Console.WriteLine("███ ║                                             Configuracion                                         ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║      Ingrese la ip del Servidor  :                                                                ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║      Ingrese puerto:                                                                              ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║      Su ip: {0,15}                                                                       ║ ███", localIP);
                Banner();
                Console.SetCursorPosition(40, 7);
                ipServidor = LeerNumero();// se ingresa la ip del sevidor
                Console.SetCursorPosition(30, 9);
                puertoCliente = Convert.ToInt32(LeerNumero());// puerto por el cual nos conectaremos

            }
            catch (Exception)
            {

                Confiruacion();
            }
        }
        public void Encabezado()
        {

            string fechaActual = DateTime.Now.ToLongDateString();
            string horaActual = DateTime.Now.ToLongTimeString();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████ A T &T©████████████████████████████████████████████████");
            Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("███ ╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗ ███");
            Console.WriteLine("███ ║                                            Cajero Automatico                                      ║ ███");
            Console.WriteLine("███ ║No. Cajero:{0}.Fecha y lugar:Tulancingo,Hgo,{1,32},Hora: {2,3} ║ ███ ", puertoCliente, fechaActual, horaActual);
            Console.WriteLine("███ ║                                                                                                   ║ ███");

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
        private void Pantallainicio(string NumeroDebilletes) {
            Console.Clear();
            Billetes = NumeroDebilletes.Split('|');
            if (Convert.ToInt32(Billetes[6])!=0)
            {
                Encabezado();
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                    B i e n v e n i d o     a    s u    c a j e ro    A T & T ( )                  ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════╦═══════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                                   ║                                               ║ ███");
                Console.WriteLine("███ ║                                                   ║    Denominación de billetes disponibles $     ║ ███");
                Console.WriteLine("███ ║                                                   ║                20  :{0,5}                     ║ ███", Billetes[0]);
                Console.WriteLine("███ ║             De enter para seguir                  ║                50  :{0,5}                     ║ ███", Billetes[1]);
                Console.WriteLine("███ ║                                                   ║                100 :{0,5}                     ║ ███", Billetes[2]);
                Console.WriteLine("███ ║                                                   ║                200 :{0,5}                     ║ ███", Billetes[3]);
                Console.WriteLine("███ ║                                                   ║                500 :{0,5}                     ║ ███", Billetes[4]);
                Console.WriteLine("███ ║                                                   ║                1000:{0,5}                     ║ ███", Billetes[5]);
                Console.WriteLine("███ ║                                                   ║                                               ║ ███");
                Console.WriteLine("███ ║                                                   ║                              (*) Ayuda.       ║ ███");
                Console.WriteLine("███ ║                                                   ║                              (.) Reportar Bug.║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════╩═══════════════════════════════════════════════╣ ███");
                Banner();
                Console.ReadKey();
                Console.Clear();
                PantallaDeTarjeta();
            }
            else
            {
                CajeroInactivo();
            }
      
        }
        private void CajeroInactivo() {

            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   F U E R A    D E   S E R V I C I O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════╦═══════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                                   ║                                               ║ ███");
            Console.WriteLine("███ ║                                                   ║    Denominación de billetes disponibles $     ║ ███");
            Console.WriteLine("███ ║                                                   ║                20  :{0,5}                     ║ ███", Billetes[1]);
            Console.WriteLine("███ ║             De enter para seguir                  ║                50  :{0,5}                     ║ ███", Billetes[2]);
            Console.WriteLine("███ ║                                                   ║                100 :{0,5}                     ║ ███", Billetes[3]);
            Console.WriteLine("███ ║                                                   ║                200 :{0,5}                     ║ ███", Billetes[4]);
            Console.WriteLine("███ ║                                                   ║                500 :{0,5}                     ║ ███", Billetes[5]);
            Console.WriteLine("███ ║                                                   ║                1000:{0,5}                     ║ ███", Billetes[6]);
            Console.WriteLine("███ ║                                                   ║                                               ║ ███");
            Console.WriteLine("███ ║                                                   ║                              (*) Ayuda.       ║ ███");
            Console.WriteLine("███ ║                                                   ║                              (.) Reportar Bug.║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════╩═══════════════════════════════════════════════╣ ███");
            Banner();
            Console.ReadKey();
             

        }
        private void PantallaDeTarjeta()
        {  
            string[] Dijitos = new string[16];
            for (int i = 0; i < Dijitos.Length; i++)
            {
                NumeroDeTarjeta =string.Empty;
            }
            Console.Clear();
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                      I n g r e s e   t a r j e t a                                ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                      [    ] [    ] [    ] [    ]                                  ║ ███");
            Console.WriteLine("███ ║                              _______________________________________________                      ║ ███");
            Console.WriteLine("███ ║                                    Ingrese el numero de su tarjeta.                               ║ ███");
            Console.WriteLine("███ ║                                        (16 dijitos numericos)                                     ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                     (0.) Cancelar.║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
            Console.SetCursorPosition(44, 16);
            Dijitos[0] = Leer();
            if (Dijitos[0] == "0")
            {
                Enviar EnviarMenu = new Enviar(ipServidor, localIP, puertoCliente, "VerificarBilletes", "billetes");
                Pantallainicio(EnviarMenu.InformacionRecibida);
            }
            Console.SetCursorPosition(45, 16);
            Dijitos[1] = Lee();
            Console.SetCursorPosition(46, 16);
            Dijitos[2] = Lee();
            Console.SetCursorPosition(47, 16);
            Dijitos[3] = Lee();
            Console.SetCursorPosition(51, 16);
            Dijitos[4] = Lee();
            Console.SetCursorPosition(52, 16);
            Dijitos[5] = Lee();
            Console.SetCursorPosition(53, 16);
            Dijitos[6] = Lee();
            Console.SetCursorPosition(54, 16);
            Dijitos[7] = Lee(); 
            Console.SetCursorPosition(58, 16);
            Dijitos[8] = Lee();
            Console.SetCursorPosition(59, 16);
            Dijitos[9] = Lee();
            Console.SetCursorPosition(60, 16);
            Dijitos[10] = Lee(); ;
            Console.SetCursorPosition(61, 16);
            Dijitos[11] = Lee();
            Console.SetCursorPosition(65, 16);
            Dijitos[12] = Lee();
            Console.SetCursorPosition(66, 16);
            Dijitos[13] = Lee();
            Console.SetCursorPosition(67, 16);
            Dijitos[14] = Lee();
            Console.SetCursorPosition(68, 16);
            Dijitos[15] = Lee();
         
            for (int i = 0; i < Dijitos.Length; i++)
            {
                NumeroDeTarjeta = NumeroDeTarjeta + Dijitos[i];      
            }
            Enviar EnviarTarjeta = new Enviar(ipServidor, localIP, puertoCliente, "VerificarTarjeta", NumeroDeTarjeta);
            InformacionRecibida = EnviarTarjeta.InformacionRecibida.Split('|');

            if (InformacionRecibida[0]=="no")
            {
                Console.SetCursorPosition(5, 21);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                            Tarjeta incorrecta.");
                Console.SetCursorPosition(5, 22);
                Console.WriteLine("                                                    o");
                Console.SetCursorPosition(5, 23);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                         Puede estar desactivada.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                PantallaDeTarjeta();
            }else 
            if (InformacionRecibida[0] == "si")
            {
              
                correo = InformacionRecibida[6];
                nombe = InformacionRecibida[3];
                user = InformacionRecibida[3];
                PantallaNip();

            }
            else {
                PantallaDeTarjeta();
            }

        }
        private void PantallaNip()  {
            int intentos = 4;
            while (true)
            {
                
                nip = null;
                string[] Digitos = new string[4];
                Console.Clear();
                Encabezado();
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                       I n g r e s e   n i p                                       ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                         ________[____]_______                                     ║ ███");
                Console.WriteLine("███ ║                                          Ingrese nip tarjeta.                                     ║ ███");
                Console.WriteLine("███ ║                                         (4 digitos numericos )                                    ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Banner();
                Console.SetCursorPosition(55, 17);
                Digitos[0] = LeerNip();
                Digitos[1] = LeerNip();
                Digitos[2] = LeerNip();
                Digitos[3] = LeerNip();
                for (int i = 0; i < Digitos.Length; i++)
                {
                    nip += Digitos[i];
                }
                string argumento = NumeroDeTarjeta + "|" + nip;
                Enviar EnviarNip = new Enviar(ipServidor, localIP, puertoCliente, "VerificarNip", argumento);


                if (EnviarNip.InformacionRecibida == "si")
                {
                    Console.Clear();
                    PantallaMenuCajero();
                }
                else
                if (EnviarNip.InformacionRecibida == "no")
                {
                    intentos--;
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("███ ║ ");
                    Console.SetCursorPosition(8, 21);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                          Nip incorrecto.");
                    Console.SetCursorPosition(8, 22);
                    Console.WriteLine("                                         Le quedan:{0} intentos",intentos);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Beep();
                    Console.ReadKey();
                }
                if (intentos==0)
                {
                    Enviar CancelarCuenta = new Enviar(ipServidor, localIP, puertoCliente, "BanearCuenta", NumeroDeTarjeta);

                    string datosCorreo = 3 + "|" + NumeroDeTarjeta + "|" + nombe + "|" +"desactivada"+ "|" + correo;
                    Enviar EnviarCorreoElectronico = new Enviar(ipServidor, localIP, puertoCliente, "EnviarCorreoElectronico", datosCorreo);

                    Enviar EnviarMenu = new Enviar(ipServidor, localIP, puertoCliente, "VerificarBilletes", "billetes");
                    Pantallainicio(EnviarMenu.InformacionRecibida);
                    break;
                }
               
            }
        }
        public void PantallaMenuCajero()
        {
            bool ciclo = true;
            do
            {
                Console.Clear();
                Encabezado();
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                               M e n u                                             ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                Usuario:{0,10}                                              ║ ███",nombe);
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                 ┌──────────────┐          ┌──────────────┐      ┌────────────────┐                ║ ███");
                Console.WriteLine("███ ║                 │  1.- Retiro  │          │  3.- Saldo   │      │ 5.-Cambiar Nip │                ║ ███");
                Console.WriteLine("███ ║                 └──────────────┘          └──────────────┘      └────────────────┘                ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                 ┌──────────────┐          ┌──────────────┐      ┌──────────────┐                  ║ ███");
                Console.WriteLine("███ ║                 │  2.- Deposito│          │  4.- Pago de │      │ 0.-Salir     │                  ║ ███");
                Console.WriteLine("███ ║                 └──────────────┘          │   servicios  │      └──────────────┘                  ║ ███");
                Console.WriteLine("███ ║                                           └──────────────┘                                        ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                  Opcion:__________                                                                ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Banner();
                Console.SetCursorPosition(34, 23);
                opcionMenu = Leer();
                switch (opcionMenu)
                {
                    case "1":
                        PantallaRetiro();
                        break;
                    case "2":
                        opcionDeposito();
                        break;
                    case "3":
                        PantallaSaldo();
                        break;
                    case "4":
                        PantallaServcios();
                        break;
                    case "5":
                        PantallaCambiarNip();
                        break;
                    case "0":
                        Enviar  MenuDecajero = new Enviar(ipServidor, localIP, puertoCliente, "VerificarBilletes", "billetes");
                        Pantallainicio(MenuDecajero.InformacionRecibida);
                        break;
                    default:
                        Console.SetCursorPosition(72, 23);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion incorrecta");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Beep();
                        break;
                }
                opcionMenu = Console.ReadLine();
            } while (ciclo);
        }
        private void PantallaRetiro() {
            Console.Clear();
            string retiro = null;
            int OpcionRetiro = 0;
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                      R e t i r o   e n   e f e c t i v o                          ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║┌──────────────┐   ┌──────────────┐   ┌─────────────┐  ┌───────────┐                               ║ ███");
            Console.WriteLine("███ ║│   1.-20      │   │  3.-100      │   │  5.-500     │  │  7.-2000  │     ┌─────────────────┐       ║ ███");
            Console.WriteLine("███ ║└──────────────┘   └──────────────┘   └─────────────┘  └───────────┘     │  Banco At&t     │       ║ ███");
            Console.WriteLine("███ ║┌──────────────┐   ┌──────────────┐   ┌─────────────┐  ┌───────────┐     │ |||| < $ >||||  │       ║ ███");
            Console.WriteLine("███ ║│   2.-50      │   │  4.-200      │   │  6.-1000    │  │  8.-3000  │     └─────────────────┘       ║ ███");
            Console.WriteLine("███ ║└──────────────┘   └──────────────┘   └─────────────┘  └───────────┘                               ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                          Opcion:__________                                                        ║ ███");
            Console.WriteLine("███ ║                                                                                       (0)Cancelar ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                            A C T I V O                                            ║ ███");
            Console.WriteLine("███ ╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝ ███");
            Banner();
            Console.SetCursorPosition(42, 21);
            OpcionRetiro= int.Parse(LeerNumero());
            if (OpcionRetiro == 0)
            {
                PantallaMenuCajero();
            }else 
            if (OpcionRetiro==11)
            {
             //   PantallaRetiro2();
            }
            else
            if (OpcionRetiro>=1 && OpcionRetiro<=8)
            {
                string argumento = OpcionRetiro + "|" + NumeroDeTarjeta;
                Enviar EnviarDeposito = new Enviar(ipServidor, localIP, puertoCliente, "VerificarRetiroEnEfectivo", argumento );

                if (EnviarDeposito.InformacionRecibida == "no")
                {
                    Console.SetCursorPosition(72, 19);
                    Console.WriteLine("Saldo insuficiente");
                }
                else
                {
                    switch (OpcionRetiro)
                    {
                        case 1:
                            retiro = "20";
                            break;
                        case 2:
                            retiro = "50";
                            break;
                        case 3:
                            retiro = "100";
                            break;
                        case 4:
                            retiro = "200";
                            break;
                        case 5:
                            retiro = "500";
                            break;
                        case 6:
                            retiro = "1000";
                            break;
                        case 7:
                            retiro = "2000";
                            break;
                        case 8:
                            retiro = "3000";
                            break;
                    }

                    aux = EnviarDeposito.InformacionRecibida.Split('|');
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(57, 19);
                    Console.WriteLine("Impirmir Ticktec 1/si enter/no:");
                    Console.SetCursorPosition(88, 19);
                    string tick = Leer();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string datosCorreo =1+"|"+NumeroDeTarjeta+"|"+nombe+"|"+retiro+"|"+correo;
                    Enviar EnviarCorreoElectronico = new Enviar(ipServidor, localIP, puertoCliente, "EnviarCorreoElectronico", datosCorreo);
                    if (tick=="1")
                    {
                        ImprimirTickect(retiro,aux[1], aux[2], aux[3], aux[4], aux[5], aux[6]);
                    }
                    else
                    {
                        VerTickect(retiro,aux[1], aux[2], aux[3], aux[4], aux[5], aux[6]);
                    }
                }

            }
            if (OpcionRetiro>8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(76, 19);
                Console.WriteLine("Opcion incorrecta");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                PantallaRetiro();
            }  
        }
        private void ImprimirTickect(string depo,string uno,string dos,string tres,string cuatro,string cinco,string seis) {
            Console.Clear();
            string tik="ticktec.txt";

            string fechaActual = DateTime.Now.ToLongDateString();
            string horaActual = DateTime.Now.ToLongTimeString();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("████████████████████████████████████████ A T &T©██████████████████████████████████████");
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("███ ╔════════════════════════════════════════════════════════════════════════════╗ ███");
            Console.WriteLine("███ ║                                    Cajero Automatico                       ║ ███");
            Console.WriteLine("███ ║No. Cajero:{0}.Fecha:{1,32},Hora: {2,3}║ ███ ", puertoCliente, fechaActual, horaActual);
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                       C A J E R O    A U T O M A T I C O                   ║ ███");
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                 T i c k e t                                ║ ███");
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                   Sucursal  AT&T Tulancingo de Bravo-Mexico                ║ ███");
            Console.WriteLine("███ ║       21 de marzo, colonia Centro de Tulancingo, # 8045 CPP:43650          ║ ███");
            Console.WriteLine("███ ║   Telefonos 775753545 Celulares:468468 Email: soporte@bnaquico.com.mx      ║ ███");
            Console.WriteLine("███ ║                             Matriz en Mexico                               ║ ███");
            Console.WriteLine("███ ║       Estado de Mexico- Lomas Verdes Calle Av. Politecnica CPP;546         ║ ███");
            Console.WriteLine("███ ║                                at&t.com                                    ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════╦════════════════╣ ███");
            Console.WriteLine("███ ║   Tipo de tramite:Retiro   Hora de retiro:{0,14}  ║    Cambio      ║ ███", horaActual);
            Console.WriteLine("███ ║                                                           ║   20$:{0,5}    ║ ███", uno);
            Console.WriteLine("███ ║   No. Cajero:{0,4}      Titular:{1,18}        ║   50$:{2,5}    ║ ███", puertoCliente, user, dos);
            Console.WriteLine("███ ║                                                           ║  100$:{0,5}    ║ ███", tres);
            Console.WriteLine("███ ║                                                           ║  200$:{0,5}    ║ ███", cuatro);
            Console.WriteLine("███ ║   No. Cuenta:{0,16}    Retiro:{1,5}             ║  500$:{2,5}    ║ ███", NumeroDeTarjeta, depo, cinco);
            Console.WriteLine("███ ║                                                           ║ 1000$:{0,5}    ║ ███", seis);
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════╩════════════════╣ ███");
            Console.WriteLine("███ ║                G R A C I A S   P O R   S U  P R E F E R E N C I A          ║ ███");
            Console.WriteLine("███ ║                              Codigo de barras                              ║ ███");
            Console.WriteLine("███ ║                    ||| | | ||| | ||||||| ||| | ||||  |||||    |            ║ ███");
            Console.WriteLine("███ ║                    ||| | | ||| | ||||||| ||| | ||||  |||||    |            ║ ███");
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║           ____    _______     _____         _______       -------          ║ ███");
            Console.WriteLine("███ ║          / __ \\  |__  __|    /  _  \\       |__  __|   -==== ------         ║ ███");
            Console.WriteLine("███ ║         | (__) |    | |      \\  \\ \\_\\         | |     -====== ------       ║ ███");
            Console.WriteLine("███ ║         |  __  |    | |      /   \\ __         | |     --==== -------       ║ ███");
            Console.WriteLine("███ ║         | |  | |    | |      | (\\_/ /         | |       -----------        ║ ███");
            Console.WriteLine("███ ║         |_|  |_|    |_|      \\_____/          |_|         -------          ║ ███");
            Console.WriteLine("███ ╚════════════════════════════════════════════════════════════════════════════╝ ███");
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.ReadKey();
            Console.Clear();

            FileStream fsEscribir = new FileStream(tik, FileMode.Append, FileAccess.Write);
            StreamWriter wDatos = new StreamWriter(fsEscribir);
             wDatos.WriteLine("                                    Cajero Automatico                       ");
            wDatos.WriteLine("No. Cajero:{0}.Fecha:{1,32},Hora: {2,3} ", puertoCliente, fechaActual, horaActual);
            wDatos.WriteLine("                       C A J E R O    A U T O M A T I C O                   ");
            wDatos.WriteLine("                                 T i c k e t                                ");
            wDatos.WriteLine("                   Sucursal  AT&T Tulancingo de Bravo-Mexico                ");
            wDatos.WriteLine("       21 de marzo, colonia Centro de Tulancingo, # 8045 CPP:43650          ");
            wDatos.WriteLine("   Telefonos 775753545 Celulares:468468 Email: soporte@bnaquico.com.mx      ");
            wDatos.WriteLine("                             Matriz en Mexico                               ");
            wDatos.WriteLine("       Estado de Mexico- Lomas Verdes Calle Av. Politecnica CPP;546         ");
            wDatos.WriteLine("                                at&t.com                                    ");
            wDatos.WriteLine("   Tipo de tramite:Retiro   Hora de retiro:{0,14}      Cambio      ", horaActual);
            wDatos.WriteLine("                                                              20$:{0,5}    ", uno);
            wDatos.WriteLine("   No. Cajero:{0,4}      Titular:{1,18}            50$:{2,5}    ", puertoCliente, user, dos);
            wDatos.WriteLine("                                                             100$:{0,5}    ", tres);
            wDatos.WriteLine("                                                             200$:{0,5}    ", cuatro);
            wDatos.WriteLine("   No. Cuenta:{0,16}    Retiro:{1,5}               500$:{2,5}    ", NumeroDeTarjeta, depo, cinco);
            wDatos.WriteLine("                                                            1000$:{0,5}    ", seis);
;
            wDatos.WriteLine("                G R A C I A S   P O R   S U  P R E F E R E N C I A          ");
            wDatos.WriteLine("                              Codigo de barras                              ");
            wDatos.WriteLine("                    ||| | | ||| | ||||||| ||| | ||||  |||||    |            ");
            wDatos.WriteLine("                    ||| | | ||| | ||||||| ||| | ||||  |||||    |            ");
            wDatos.WriteLine("           ____    _______     _____         _______       -------          ");
            wDatos.WriteLine("          / __ \\  |__  __|    /  _  \\       |__  __|   -==== ------         ");
            wDatos.WriteLine("         | (__) |    | |      \\  \\ \\_\\         | |     -====== ------       ");
            wDatos.WriteLine("         |  __  |    | |      /   \\ __         | |     --==== -------       ");
            wDatos.WriteLine("         | |  | |    | |      | (\\_/ /         | |       -----------        ");
            wDatos.WriteLine("          |_|  |_|    |_|      \\_____/          |_|         -------          ");
  


            wDatos.Close();
            fsEscribir.Close();
            impirmir ImpirmirDoucmento = new impirmir();
            ImpirmirDoucmento.ImprimirDocumento(tik);
            FileInfo fi = new System.IO.FileInfo(tik);
            fi.Delete();
        }
        private void VerTickect(string depo,string uno, string dos, string tres, string cuatro, string cinco, string seis)
        {
            Console.Clear();
        
            string fechaActual = DateTime.Now.ToLongDateString();
            string horaActual = DateTime.Now.ToLongTimeString();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("████████████████████████████████████████ A T &T©██████████████████████████████████████");
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("███ ╔════════════════════════════════════════════════════════════════════════════╗ ███");
            Console.WriteLine("███ ║                                    Cajero Automatico                       ║ ███");
            Console.WriteLine("███ ║No. Cajero:{0}.Fecha:{1,32},Hora: {2,3}║ ███ ", puertoCliente, fechaActual, horaActual);
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                       C A J E R O    A U T O M A T I C O                   ║ ███");
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                 T i c k e t                                ║ ███");
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                   Sucursal  AT&T Tulancingo de Bravo-Mexico                ║ ███");
            Console.WriteLine("███ ║       21 de marzo, colonia Centro de Tulancingo, # 8045 CPP:43650          ║ ███");
            Console.WriteLine("███ ║   Telefonos 775753545 Celulares:468468 Email: soporte@bnaquico.com.mx      ║ ███");
            Console.WriteLine("███ ║                             Matriz en Mexico                               ║ ███");
            Console.WriteLine("███ ║       Estado de Mexico- Lomas Verdes Calle Av. Politecnica CPP;546         ║ ███");
            Console.WriteLine("███ ║                                at&t.com                                    ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════╦════════════════╣ ███");
            Console.WriteLine("███ ║   Tipo de tramite:Retiro   Hora de retiro:{0,14}  ║    Cambio      ║ ███",horaActual);
            Console.WriteLine("███ ║                                                           ║   20$:{0,5}    ║ ███", uno);
            Console.WriteLine("███ ║   No. Cajero:{0,4}      Titular:{1,18}         ║   50$:{2,5}    ║ ███", puertoCliente, user, dos);
            Console.WriteLine("███ ║                                                           ║  100$:{0,5}    ║ ███", tres);
            Console.WriteLine("███ ║                                                           ║  200$:{0,5}    ║ ███", cuatro);
            Console.WriteLine("███ ║   No. Cuenta:{0,16}    Retiro:{1,5}             ║  500$:{2,5}    ║ ███", NumeroDeTarjeta, depo, cinco);
            Console.WriteLine("███ ║                                                           ║ 1000$:{0,5}    ║ ███", seis);
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════╩════════════════╣ ███");
            Console.WriteLine("███ ║                G R A C I A S   P O R   S U  P R E F E R E N C I A          ║ ███");
            Console.WriteLine("███ ║                              Codigo de barras                              ║ ███");
            Console.WriteLine("███ ║                    ||| | | ||| | ||||||| ||| | ||||  |||||    |            ║ ███");
            Console.WriteLine("███ ║                    ||| | | ||| | ||||||| ||| | ||||  |||||    |            ║ ███");
            Console.WriteLine("███ ╠════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║           ____    _______     _____         _______       -------          ║ ███");
            Console.WriteLine("███ ║          / __ \\  |__  __|    /  _  \\       |__  __|   -==== ------         ║ ███");
            Console.WriteLine("███ ║         | (__) |    | |      \\  \\ \\_\\         | |     -====== ------       ║ ███");
            Console.WriteLine("███ ║         |  __  |    | |      /   \\ __         | |     --==== -------       ║ ███");
            Console.WriteLine("███ ║         | |  | |    | |      | (\\_/ /         | |       -----------        ║ ███");
            Console.WriteLine("███ ║         |_|  |_|    |_|      \\_____/          |_|         -------          ║ ███");
            Console.WriteLine("███ ╚════════════════════════════════════════════════════════════════════════════╝ ███");
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.WriteLine("██████████████████████████████████████████████████████████████████████████████████████");
            Console.ReadKey();
            Console.Clear();
        }
        private void opcionDeposito()
        {
            Console.Clear();
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                        D e p o s i t o                                            ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                         Tipo de deposito                                          ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║      1.-Billetes.                                                                                 ║ ███");
            Console.WriteLine("███ ║      2.-Tarjeta                                                                                   ║ ███");
            Console.WriteLine("███ ║                           Ppcion:                                                                 ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
            Console.SetCursorPosition(40, 16);
            string op = Leer();
            if (op == "1")
            {
                PantallaDepositoBilletes();
            }
            else if(op=="2")
            {
                PantallaDepositoTarjeta();
            }
            else if(op=="0")
            {
                PantallaMenuCajero();
            }
        }
        private void PantallaDepositoBilletes()
        {
            Console.Clear();
            int z = 20;
            double[] cantidadADepositar = new double[6];
            double guardar = 0;//cantidad total
            string NumeroDeCuentaDeposito = null;//numero de cuenta a depositar
            string CantidadIngresada = null;
            string MontoDeDoposito = null;
            double uno = 0;
            double dos = 0;
            double tres = 0;
            double cuatro = 0;
            double cinco = 0;
            double sesis = 0;
            Console.Clear();
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                        D e p o s i t o                                            ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                             Monto maximo de deposito es de 5,000$                                 ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║       Ingrese el numero de cuenta :________________                                               ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║       Ingrese el monto a depositar:_______________                                                ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║          Billetes:                                                                                ║ ███");
            Console.WriteLine("███ ║              20:_____                                                                             ║ ███");
            Console.WriteLine("███ ║              50:_____                                                                             ║ ███");
            Console.WriteLine("███ ║             100:_____                                                                             ║ ███");
            Console.WriteLine("███ ║             200:_____                                                                             ║ ███");
            Console.WriteLine("███ ║             500:_____                                                                             ║ ███");
            Console.WriteLine("███ ║            1000:_____                                                                             ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
            Console.SetCursorPosition(41, 15);
            NumeroDeCuentaDeposito = Console.ReadLine();
            Console.SetCursorPosition(41, 17);
            CantidadIngresada = Console.ReadLine();

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(24, z);
                cantidadADepositar[i] = Convert.ToDouble(Console.ReadLine());
                MontoDeDoposito += Convert.ToString(cantidadADepositar[i]) + "|";
                z++;
            }
            uno = cantidadADepositar[0] * 20;
            dos = cantidadADepositar[1] * 50;
            tres = cantidadADepositar[2] * 100;
            cuatro = cantidadADepositar[3] * 200;
            cinco = cantidadADepositar[4] * 500;
            sesis = cantidadADepositar[5] * 1000;
            guardar = uno + dos + tres + cuatro + cinco + sesis;

      
            if (guardar > 5000)
            {
                Console.Clear();
                Encabezado();
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                        D e p o s i t o                                            ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                             Monto maximo de deposito es de 5,000$                                 ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                               Monto muy grande intente de nuevo.                                  ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Banner();
                Console.Beep();
                Console.ReadKey();
                opcionDeposito();
            }
            else if (guardar < 5000)
            {
                if (guardar==Convert.ToDouble(CantidadIngresada))
                {
                                          //tarejde a depositoar// vector de billetes// lo que se va a depositar
                    string argumento = NumeroDeCuentaDeposito + "|" + MontoDeDoposito  + guardar;
                    Enviar EnviarDeposito = new Enviar(ipServidor, localIP, puertoCliente, "VerificarDepsitoBilletes", argumento);
                    InformacionRecibida = EnviarDeposito.InformacionRecibida.Split('|');

                    if (InformacionRecibida[0] == "si")
                    {
                        Console.SetCursorPosition(0, 26);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("                                             Deposito exitoso");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("███ ║                                                                                                ║ ███");
                        Console.SetCursorPosition(0, 27);
                        Console.WriteLine("███ ║                                            De enter                                            ║ ███");             
                        Console.ReadKey();
                        PantallaMenuCajero();

                    }
                    if (InformacionRecibida[0] == "no")
                    {
                        Console.SetCursorPosition(0, 27);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("                                         No existe la tarjeta!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(0, 27);
                        Console.WriteLine("███ ║                                                                                                ║ ███");
                        Console.ReadKey();
                        opcionDeposito();
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("███ ║                                     No coincide su monto intente de nuevo    ");
                }
            }
        }
        private void PantallaDepositoTarjeta()
        {
            Console.Clear();

            double guardar = 0;//cantidad total
            string NumeroDeCuentaDeposito = null;
            string CantidadIngresada = null;
            Console.Clear();
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                        D e p o s i t o                                            ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                             Monto maximo de deposito es de 5,000$                                 ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║       Ingrese el numero de cuenta :________________                                               ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║       Ingrese el monto a depositar:_______________                                                ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                        (0)Cancelar║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
            Console.SetCursorPosition(41, 15);
            NumeroDeCuentaDeposito = Console.ReadLine();
            if (NumeroDeCuentaDeposito=="0")
            {
                PantallaMenuCajero();
            }
            Console.SetCursorPosition(41, 17);
            CantidadIngresada = Console.ReadLine();
       
            Console.ReadKey();
          

            if (Convert.ToInt32(CantidadIngresada) > 5000)
            {
                Console.Clear();
                Encabezado();
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                        D e p o s i t o                                            ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                             Monto maximo de deposito es de 5,000$                                 ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║                               Monto muy grande intente de nuevo.                                  ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Banner();
                Console.Beep();
                Console.ReadKey();
            }
            else if (Convert.ToInt32(CantidadIngresada) < 5000)
            {
                string argumento = NumeroDeCuentaDeposito + "|" + CantidadIngresada+"|"+NumeroDeTarjeta;
                Enviar EnviarDeposito = new Enviar(ipServidor, localIP, puertoCliente, "VerificarDepsitoTarjeta", argumento);
                InformacionRecibida = EnviarDeposito.InformacionRecibida.Split('|');

                if (InformacionRecibida[0] == "si")
                {
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("███ ║                                   Su monto a depositar es de:{0,5}                                ║ ███", CantidadIngresada);
                    Console.SetCursorPosition(0, 26);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("                                             Deposito exitoso");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(0, 26);
                    Console.WriteLine("███ ║                                                                                                ║ ███");
                    Console.SetCursorPosition(0, 27);
                    Console.WriteLine("███ ║                                            De enter                                            ║ ███");
                    argumento = NumeroDeTarjeta + "|" + guardar;
                    Enviar QuitarDinero = new Enviar(ipServidor, localIP, puertoCliente, "QuitarDinero", argumento);
                    Console.ReadKey();
                    PantallaMenuCajero();

                }
                if (InformacionRecibida[0] == "no")
                {
                    Console.SetCursorPosition(0, 27);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                         No existe la tarjeta!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(0, 27);
                    Console.WriteLine("███ ║                                                                                                ║ ███");
                    Console.ReadKey();
                    ///     PantallaDeposito();
                }


            }


        }
        private void PantallaSaldo() {
            Console.Clear();
            Enviar EnviarDeposito = new Enviar(ipServidor, localIP, puertoCliente, "VerificarSaldo", NumeroDeTarjeta);
            InformacionRecibida = EnviarDeposito.InformacionRecibida.Split('|');
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                          S a l d o                                                ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                          No de cuenta:{0,20}                                        ║ ███",InformacionRecibida[1]);
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                          Saldo:${0,20}                                              ║ ███",InformacionRecibida[4]);
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
        }
        private void PantallaServcios() {
            Console.Clear();
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                S e r v i c i o s   d i s p o n i b l e s                          ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                     ┌────────────────┐             ┌─────────────────┐                            ║ ███");
            Console.WriteLine("███ ║                     │  1.- Luz-100$  │             │  3.- spotify-20$│                            ║ ███");
            Console.WriteLine("███ ║                     └────────────────┘             └─────────────────┘                            ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                     ┌──────────────┐               ┌────────────────┐                             ║ ███");
            Console.WriteLine("███ ║                     │  2.-Agua-200$│               │  4.- Tiempo    │                             ║ ███");
            Console.WriteLine("███ ║                     └──────────────┘               │       aire     │                             ║ ███");
            Console.WriteLine("███ ║                                                    └────────────────┘                             ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║            Opcion:____                                                                Cancelar(0).║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
            Console.SetCursorPosition(24,21);
            opcionMenu = Console.ReadLine();
            string argumento = opcionMenu + "|" + NumeroDeTarjeta;
            if (opcionMenu=="4")
            {
                PantallaTiempoAire();
            }
            else if (opcionMenu=="0")
            {
                PantallaMenuCajero();
            }
            Enviar EnviarTipoDeServicio = new Enviar(ipServidor, localIP, puertoCliente, "VerificarPagoDeServicio",argumento);
            if (EnviarTipoDeServicio.InformacionRecibida=="si")
            {
                Console.SetCursorPosition(35, 21);
                Console.WriteLine("Listo");             
            }
            else if (EnviarTipoDeServicio.InformacionRecibida=="no")
            {
                Console.SetCursorPosition(35, 21);
                Console.WriteLine("Saldo insuficiente");
            }
           
        }
        private void PantallaTiempoAire() {
            string opcionSaldo = null;
            Console.Clear();
            Encabezado();
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                    T i e m p o      A i r e  A T & T                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║            ┌────────────────┐       ┌────────────────┐           ┌────────────────┐               ║ ███");
            Console.WriteLine("███ ║            │  1.- 20-20$    │       │  3.- 100-100$  │           │  5.- 500-500$  │               ║ ███");
            Console.WriteLine("███ ║            └────────────────┘       └────────────────┘           └────────────────┘               ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║            ┌────────────────┐        ┌────────────────┐           ┌────────────────┐              ║ ███");
            Console.WriteLine("███ ║            │  2.-50-50$     │        │  4.- 200-200$  │           │  6.-1000-1000$ │              ║ ███");
            Console.WriteLine("███ ║            └────────────────┘        └────────────────┘           └────────────────┘              ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║            Opcion:____                                                                Cancelar(0).║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
            Console.SetCursorPosition(24, 22);
            opcionSaldo = Console.ReadLine();

            string argumento = 4 + "|" + NumeroDeTarjeta+"|"+opcionSaldo;
            Enviar EnviarTipoDeServicio = new Enviar(ipServidor, localIP, puertoCliente, "VerificarPagoDeServicio", argumento);
            if (EnviarTipoDeServicio.InformacionRecibida=="no")
            {
                Console.SetCursorPosition(24, 22);
                Console.WriteLine("                                    Saldo insuficiente");
            }
            else if (EnviarTipoDeServicio.InformacionRecibida=="si")
            {
                Console.SetCursorPosition(24, 22);
                PantallaTiempoAireRecarga();
            }
            PantallaMenuCajero();
        }
        private void PantallaTiempoAireRecarga()
        {
            string numeroDeTelefono = null;
            string numeroDeTelefono1 = null;
            bool salir = true;
            do
            {
                Console.Clear();
                Encabezado();
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                    T i e m p o      A i r e  A T & T                              ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Console.WriteLine("███ ║                                    Solo son 10 dígitos                                            ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║         Ingrese nuemero telefonico:                                                               ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ║         Repita el numero telefonico:                                                              ║ ███");
                Console.WriteLine("███ ║                                                                                                   ║ ███");
                Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
                Banner();
                Console.SetCursorPosition(42, 14);
                numeroDeTelefono = Console.ReadLine();

                Console.SetCursorPosition(43, 16);
                numeroDeTelefono1 = Console.ReadLine();
                if (numeroDeTelefono == numeroDeTelefono1)
                {
                    Console.SetCursorPosition(0, 17);
                    Console.WriteLine("███ ║                                                               listo");
                    Console.ReadKey();
                    PantallaMenuCajero();
                }

            } while (salir);
            
        }
        private void PantallaCambiarNip() {
            Console.Clear();
            Encabezado();
            string nipAnterior = null;
            string nipNuevo = null;
            string nipNuevoCambiado = null;
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                   C A J E R O    A U T O M A T I C O                              ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                    C A M B I A R   N I P                                          ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║       Nip anterior:                                                                               ║ ███");
            Console.WriteLine("███ ║                                                                                                   ║ ███");
            Console.WriteLine("███ ║       Nip nuevo:                                                                                  ║ ███");
            Console.WriteLine("███ ║       Confirmar:                                                                                  ║ ███");
            Console.WriteLine("███ ║                                                                                       (0)Cancelar ║ ███");
            Console.WriteLine("███ ╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣ ███");
            Banner();
            Console.SetCursorPosition(25, 13);
            nipAnterior = Console.ReadLine() ;
            if (nipAnterior=="0")
            {
                PantallaMenuCajero();
            }
            Console.SetCursorPosition(22, 15);
            nipNuevo = Console.ReadLine();
            Console.SetCursorPosition(22, 16);
            nipNuevoCambiado = Console.ReadLine();
            if (nipNuevo==nipNuevoCambiado)
            {
                string argumento =NumeroDeTarjeta+"|"+nipNuevo;
                Enviar CambiarNip = new Enviar(ipServidor, localIP, puertoCliente, "VerificarCambiarNip", argumento);
                if (CambiarNip.InformacionRecibida=="si")
                {
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine("Se a cambiado el nip-Reinciando cuenta");
                    Enviar MenuDecajero = new Enviar(ipServidor, localIP, puertoCliente, "VerificarBilletes", "billetes");
                    string datosCorreo = 2 + "|" + NumeroDeTarjeta + "|" + nombe + "|" + nipNuevo+ "|" + correo;
                    Enviar EnviarCorreoElectronico = new Enviar(ipServidor, localIP, puertoCliente, "EnviarCorreoElectronico", datosCorreo);

                    Pantallainicio(MenuDecajero.InformacionRecibida);

                }
                else if (CambiarNip.InformacionRecibida == "no")
                {
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine("No coincide el nip anterior");

                }

            }
            else
            {
                Console.SetCursorPosition(50, 14);
                Console.WriteLine("No coincide los nip");
                Console.ReadKey();
                PantallaCambiarNip();
            }

        }
        public string LeerNumero()
        {
            string s = "";
            ConsoleKeyInfo pulsación = default(ConsoleKeyInfo);
            do
            {
                pulsación = Console.ReadKey(true);
                if ((char.IsDigit(pulsación.KeyChar)) || (char.IsPunctuation(pulsación.KeyChar)) )
                {
                    s += pulsación.KeyChar;
                    Console.Write(pulsación.KeyChar);
                }

            } while ((pulsación.Key != ConsoleKey.Enter));
            return s;
        }
        public string LeerNip()
        {
            string s = "";
            ConsoleKeyInfo pulsación = default(ConsoleKeyInfo);

            pulsación = Console.ReadKey(true);
            if ((char.IsDigit(pulsación.KeyChar)))
            {
                s += pulsación.KeyChar;
                Console.Write("*");
            }
            return s;
        }
        public string Leer()
        {
            string s = "";
            ConsoleKeyInfo pulsación = default(ConsoleKeyInfo);
           
                pulsación = Console.ReadKey(true);
                if ((char.IsDigit(pulsación.KeyChar)))
            {
                    s += pulsación.KeyChar;
                Console.Write(pulsación.KeyChar);
            }
           
            return s;
        }

        public string Lee()
        {
            string s = "";
            ConsoleKeyInfo pulsación = default(ConsoleKeyInfo);

            pulsación = Console.ReadKey(true);
            if ((char.IsDigit(pulsación.KeyChar)))
            {
                s += pulsación.KeyChar;
                Console.Write(pulsación.KeyChar);
            }
            else
            {
                s += 0;
            }

            return s;
        }
    }
}
