using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Google.Protobuf.Collections;
using System.Xml.Serialization;

namespace Proiect
{
    [Serializable]
    public class Sesiune:FormObject
    {
        private string id;
        private DateTime data;
        private string ip;
        private string user_id;
        public void save(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Sesiune));
            Stream s = File.OpenWrite(path);
            serializer.Serialize(s, this);
            s.Close();
        }
        public static void emptySession(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Sesiune));
            Stream s = File.Create(path);
            serializer.Serialize(s, new Sesiune());
            s.Close();
        }
        public static Sesiune restore(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Sesiune));
            FileStream s = File.OpenRead(path);
            Sesiune sesiune = (Sesiune)serializer.Deserialize(s);
            s.Close();
            return sesiune;
        }
        public static string getIpAdress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
        private string genSession()
        {
            Random rdr = new Random();
            string session_id = "";
            for(int i = 0;i<20;i++)
            {
                session_id += ((char)rdr.Next(33, 127)).ToString();

            }
            session_id += user_id.Substring(0,5);
            session_id += this.data.Year.ToString().Substring(2, 2) + this.data.Month.ToString() + this.data.Day+ToString()
                +this.data.Hour.ToString()+this.data.Minute.ToString();
            return session_id;
        }
        public Sesiune(string user_id)
        {
            this.user_id = user_id;
            this.ip = getIpAdress();
            this.data = DateTime.Now;
            this.id = genSession();
        }
        public Sesiune()
        {
            this.user_id = "";
            this.ip = "";
            this.data = DateTime.Now;
            this.id = "";
        }
        public override string ToString()
        {
            return "Id Sesiune: "+this.id+" Ip Utilizator: "+this.ip+" Data: "+this.data.ToString()+" Utilizator: "+this.user_id;
        }

        public override MapField<string, string> fieldValue()
        {
            MapField<string, string> map = new MapField<string, string>();
            map.Add("id_sesiune",id);
            map.Add("data_conectare", data.ToString("yyyy/MM/dd"));
            map.Add("ip", ip);
            map.Add("id_utilizator",user_id);
            return map;
        }

        public override FormObject genObject(MapField<string, string> fieldValue)
        {
            FormObject s = new Sesiune();
            ((Sesiune)s).ip = fieldValue["ip"];
            ((Sesiune)s).user_id = fieldValue["id_utilizator"];
            ((Sesiune)s).data = DateTime.Parse(fieldValue["data_conectare"]);
            ((Sesiune)s).id = fieldValue["id_sesiune"];
            return s;
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string User_id
        {
            get { return this.user_id; }
            set { this.user_id = value;}
        }
        public DateTime Data
        {
            get { return this.data; } set {  this.data = value; }
        }
        public string Ip
        {
            get { return this.ip; }
            set { this.ip = value; }
        }
    }
}
