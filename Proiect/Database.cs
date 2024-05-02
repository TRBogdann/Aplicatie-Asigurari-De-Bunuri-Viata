using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Proiect
{

    internal class Database
    {
        private string error = "";
        private bool closed = true;
        private string host;
        private int port;
        private string username;
        private string password;
        private string name;
        public OracleConnection connection = null;
        public string Host { get { return host; } set { host = value; } }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public Database(string host,int port,string name,string username, string password) 
        {
            this.host = host;
            this.port = port;
            this.username = username;
            this.name = name;
            this.password = password;

        }
        public bool isOpen()
        {
            return !this.closed;
        }
        public string GetError()
        {
            return this.error;
        }
        public void Connect()
        {
            try
            {
                error = "";
                closed = false;
                
                string connstring = string.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};", host,port,name, username, password);
                connection = new OracleConnection(connstring);
                connection.Open();
            }
            catch(Exception e)
            {
                error = e.Message;
                closed = true;
            }
          
        }
        public void Close()
        {
            if (isOpen())
            {
                connection.Close();
                this.closed = true;
            }
            
        }
       }
}
