using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CajeroServidor.Clases
{
    class EnviarCorreo
    {
         string[] Cadena {
            get;
            set;
        }
        public string fechaActual = DateTime.Now.ToLongDateString();
        public string horaActual = DateTime.Now.ToLongTimeString();
        public EnviarCorreo(string argumento) {

           

            //0  1            2          3                4       5             6
            //ipserviro /// /puerto///   tipo      +numero tarjeta+///nombre///retiro

            string informacion = Convert.ToString(argumento);
            Console.WriteLine(informacion);
            Cadena = informacion.Split('|');
            //creacion del hilo
            ThreadStart EnvioMensajeProceso = new ThreadStart(EnviodeMensaje);
            Thread hilo = new Thread(EnvioMensajeProceso);
            hilo.Start();
           
         
        }

        private void EnviodeMensaje()
        {

            switch (Cadena[3])
            {
                case "1"://retiro
                    EnviarCorreoRetiro(Cadena[1], Cadena[4], Cadena[5], Cadena[6], Cadena[7]);
                    break;
                case "2"://cambio de nip
                    EnviarCorreoCambioNip(Cadena[1], Cadena[4], Cadena[5], Cadena[6], Cadena[7]);
                    break;
                case "3"://cambio de nip
                    EnviarCorreoBaner(Cadena[1], Cadena[5], Cadena[6], Cadena[7]);
                    break;
            }

        }
        private void EnviarCorreoRetiro(string numeroCajero,string cuenta,string nombre,string cantidad,string correo ) {
            string Mensaje = null;
            Mensaje = "                   at & t                  \n          Recibo de notificacion            \n  Fecha y " + fechaActual + "                   \n  Hora:" + horaActual + "                     \n                                            \nTipo de tramite : Retiro en efectivo        \n                                            \nCliente:" + nombre + "                          \nCuenta:" + cuenta + "                           \nCantidad:  " + cantidad + "                        \n  Numero Cajero:" + numeroCajero + "              \n";
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("octavio_larregui@hotmail.com");
            mail.To.Add(correo);
            mail.Subject = "Banco- AT & T.-Retiro de dinero.";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = Mensaje;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("octavio_larregui@hotmail.com", "superman1230..");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        private void EnviarCorreoCambioNip(string numeroCajero, string nip,string cuenta, string nombre,  string correo)
        {
            string Mensaje = null;
            Mensaje = "at & t Recibo de notificacion,       Fecha :"+fechaActual+"   Hora:"+horaActual+",         Tipo de tramite:Cambio de nip,        Cliente:"+nombre+"    Cuenta:"+cuenta+" Nip nuevo"+nip+"    Numero Cajero:"+numeroCajero;
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("octavio_larregui@hotmail.com");
            mail.To.Add(correo);
            mail.Subject = "Banco- AT & T.-Cambio de nip.";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = Mensaje;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("octavio_larregui@hotmail.com", "superman1230..");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        private void EnviarCorreoBaner(string numeroCajero,  string cuenta, string nombre, string correo)
        {
            string Mensaje = null;
            Mensaje = "at & t Recibo de notificacion,       Fecha :" + fechaActual + "   Hora:" + horaActual + ",         Tipo de tramite:Notificacion de estado de tarjeta,        Cliente:" + nombre + "    Cuenta:" + cuenta + " Estdo de la tarjeta" + "inactivo" + "    Numero Cajero:" + numeroCajero;
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("octavio_larregui@hotmail.com");
            mail.To.Add(correo);
            mail.Subject = "Banco- AT & T.-Cambio de nip.";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = Mensaje;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("octavio_larregui@hotmail.com", "TuContraseña");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

    }
}
