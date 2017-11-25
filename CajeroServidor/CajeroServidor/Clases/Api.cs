using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace CajeroServidor.Clases
{
    class Api
    {
        public string ipRespues {
            get;
            set;

        }
        public string PaisRespuesta {
            get;
            set;
        }
        public string CodigoRespueta
        {
            get;
            set;
        }

        public string CordenadasRespuesta
        {
            get;
            set;
        }



        public Api() {
            string url = string.Format("{0}/?q={1}",   "https://freegeoip.net/json", "148.246.193.63");//"201.116.38.18");
            string details = CallRestMethod(url);
           
        
        }
        public  string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            //webrequest.Headers.Add("Username", "xyz");
            //webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            //Console.WriteLine(result.ToString());

            var datos = JsonConvert.DeserializeObject<Datos>(result);

            //Console.WriteLine("Ip: {0}\nPais: {1}\nCodigo: {2}\nLatitud: {3}\nLongitud: {4}",
            //datos.ip, datos.country_name, datos.country_code, datos.latitude, datos.longitude);
            ipRespues = datos.ip;
            PaisRespuesta= datos.country_name;
            CodigoRespueta = datos.country_code;
            CordenadasRespuesta= datos.latitude + ":::" + datos.longitude;

            //Serialize
            //List<HtmlItem> html = new List<HtmlItem>();
            //html.Add(new HtmlItem("foo"));
            //html.Add(new HtmlItem("bar"));
            //html.Html = "foo";
            //html.Html = "bar";

            //string json = JsonConvert.SerializeObject(html);
            //Console.WriteLine("json= {0}", json);
            //Deserialize and print the html items.        
            //List<HtmlItem> htmlList = JsonConvert.DeserializeObject<List<HtmlItem>>(json);
            //htmlList.ForEach((item) => Console.WriteLine(item.Html)); // foo bar
            return result;
        }
        public class HtmlItem
        {
            [JsonProperty("html")]
            public string Html { get; set; }

            public HtmlItem(string Html)
            {
                this.Html = Html;
            }
        }
        class Datos
        {
            [JsonProperty(PropertyName = "ip")]
            public string ip { get; set; }

            [JsonProperty(PropertyName = "country_code")]
            public string country_code { get; set; }
            [JsonProperty(PropertyName = "country_name")]
            public string country_name { get; set; }
            [JsonProperty(PropertyName = "latitude")]
            public string latitude { get; set; }
            [JsonProperty(PropertyName = "longitude")]
            public string longitude { get; set; }


        }



    }
}
