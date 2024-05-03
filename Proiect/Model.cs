using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf.Reflection;

namespace Proiect
{    
    public enum FieldTypeSQL {numeric,character,date};
    
    public abstract class FormObject
    {
        public FormObject() { }
        abstract public MapField<string, string> fieldValue();
        abstract public FormObject genObject(MapField<string,string> fieldValue);
    }
    public class Model
    {
        private Database db;
        string[] fields;
        string table;
        FieldTypeSQL[] types;
        FieldTypeSQL[] fieldTypes;
        public Model(Database db, string[] fields,FieldTypeSQL[] types,string table)
        {
            this.db = db;
            this.fields = fields;
            this.table = table;
            this.types = types;
        }
        public List<FormObject>select(FormObject transformer,string filter="")
        {
            OracleCommand command = new OracleCommand();
            List<FormObject> list = new List<FormObject>();
            string query = "SELECT ";
            foreach(string str in fields)
            {
                query += str + ",";
            }
            query = query.Remove(query.Length - 1, 1);
            query += " FROM " + table;
            if(filter!="")
            {
                query += " WHERE " + filter;
            }
            command.Connection = db.connection;
            command.CommandText = query;
            //MessageBox.Show(query,"v",MessageBoxButtons.OK);
            OracleDataReader read = command.ExecuteReader();
            while(read.Read())
            {
                MapField<string, string> map = new MapField<string, string>();
                foreach(string str in fields)
                {
                    map.Add(str, read[str].ToString());
                }
                FormObject obj = transformer.genObject(map);
                list.Add(obj);
            }
            return list;
        }
        public int insert(FormObject ob)
        {
            MapField<string, string> map = ob.fieldValue();
            string query1 = "INSERT INTO " + table + "(";
            string query2 = " VALUES(";
            foreach (var it in map)
            {
                int i = 0;
                while (i < fields.Length && !fields[i].Equals(it.Key))
                {
                    i++;
                }

                query1 += it.Key + ",";
                if (types[i].Equals(FieldTypeSQL.character))
                    query2 += "'" + it.Value + "'" + ",";
                else if (types[i].Equals(FieldTypeSQL.date))
                    query2 += "to_date('" + it.Value + "','YYYY/MM/DD')" + ",";
                else
                    query2 += it.Value + ",";
            }
            query1 = query1.Remove(query1.Length - 1, 1);
            query2 = query2.Remove(query2.Length - 1, 1);
            query1 += ") ";
            query2 += ")";
            OracleCommand oracleCommand = new OracleCommand();
            oracleCommand.Connection = db.connection;
            oracleCommand.CommandText = query1 + query2;
            int result = oracleCommand.ExecuteNonQuery();

            return result;
        }
        public int update(FormObject ob,string[] fieldsToUpdate,string filter)
        {
            if (filter == "" || fieldsToUpdate.Length == 0)
                return 0;

            MapField<string, string> map = ob.fieldValue();
            string query = "UPDATE " + table+" ";
            foreach( string it in fieldsToUpdate)
            {
                int i = 0;
                while (i < fields.Length && !fields[i].Equals(it))
                {
                    i++;
                }
                string formatted = "";
                if (types[i].Equals(FieldTypeSQL.character))
                    formatted = "'" + map[it] + "'";
                else if (types[i].Equals(FieldTypeSQL.date))
                    formatted = "to_date('" + map[it] + "','YYYY/MM/DD')";
                else
                    formatted = map[it];
                
                query += "SET " + it + "=" + formatted + ",";
            }
            query = query.Remove(query.Length - 1, 1);
            query += " WHERE " + filter;
            OracleCommand cm = new OracleCommand();
            cm.Connection = db.connection;
            cm.CommandText = query;
            int result = cm.ExecuteNonQuery();
            return result;
        }
        public int delete(string filter)
        {
            string query = "DELETE FROM "+table+" WHERE "+filter;
            OracleCommand cm = new OracleCommand();
            cm.Connection = db.connection;
            cm.CommandText = query;
            int result = cm.ExecuteNonQuery();
            return result;
        }
    }
}
