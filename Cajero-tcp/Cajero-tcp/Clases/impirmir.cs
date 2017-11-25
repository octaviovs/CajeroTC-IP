using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace Cajero_tcp.Clases
{
    class impirmir
    {
        private Font fuente;
        private StreamReader sr;

        // Imprimir el contenido de un fichero
        public void ImprimirDocumento(string fichero)
        {
            try
            {
                sr = new StreamReader(fichero);
                try
                {
                    fuente = new Font("Arial", 7);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.ImprimirPagina);
                    pd.Print(); // invoca a ImprimirPagina
                }
                finally
                {
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Respuesta al evento PrintPage producido por Print()
        private void ImprimirPagina(object obj, PrintPageEventArgs ev)
        {
            float lineasPorPag = 0;
            float pos_Y = 0;
            int cuenta = 0;
            float margenIzq = ev.MarginBounds.Left;
            float margenSup = ev.MarginBounds.Top;
            string linea = null;

            // Calcular el número de líneas por página
            float altoFuente = fuente.GetHeight(ev.Graphics);
            lineasPorPag = ev.MarginBounds.Height / altoFuente;

            // Imprimir cada una de las líneas del fichero
            while (cuenta < lineasPorPag && ((linea = sr.ReadLine()) != null))
            {
                pos_Y = margenSup + (cuenta * altoFuente);
                ev.Graphics.DrawString(linea, fuente, Brushes.Black, margenIzq, pos_Y, new StringFormat());
                cuenta++;
            }

            // Si hay más líneas, imprimir otra página
            if (linea != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
    }
}
