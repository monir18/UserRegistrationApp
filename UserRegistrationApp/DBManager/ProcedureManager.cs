using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UserRegistrationApp.viewModel;

namespace UserRegistrationApp.DBManager
{
    public class ProcedureManager
    {
        //ConnectionManager connection = new ConnectionManager();
        public DataTable GetDataList(string spName)
        {
            SqlCommand cmd = new SqlCommand(spName, ConnectionManager.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
        public bool insert(string spname, List<KeyValue> keyValues)
        {
            
            int i;           
            SqlCommand cmd = new SqlCommand(spname, ConnectionManager.GetConnection());
            if (keyValues.Count > 0)
            {
                for (int j = 0; j < keyValues.Count; j++)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(keyValues[j].key, keyValues[j].value);
                }
            }
            cmd.Connection.Open();
            i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                cmd.Connection.Close();
                return true;
            }               
            else
            {
                cmd.Connection.Close();
                return false;
            }               
        }
        public bool update(string spname, List<KeyValue> keyValues)
        {
            int i;
            SqlCommand cmd = new SqlCommand(spname, ConnectionManager.GetConnection());
            if (keyValues.Count > 0)
            {
                for (int j = 0; j < keyValues.Count; j++)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(keyValues[j].key, keyValues[j].value);
                }
            }
            cmd.Connection.Open();
            i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                cmd.Connection.Close();
                return true;
            }

            else
            {
                cmd.Connection.Close();
                return true;
            }
        }

        public bool delete(string spname, List<KeyValue> keyValues)
        {
            int i;
            SqlCommand cmd = new SqlCommand(spname, ConnectionManager.GetConnection());
            if (keyValues.Count > 0)
            {
                for (int j = 0; j < keyValues.Count; j++)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(keyValues[j].key, keyValues[j].value);
                }
            }
            cmd.Connection.Open();
            i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                cmd.Connection.Close();
                return false;
            }              
            else
            {
                cmd.Connection.Close();
                return false;
            }             
        }
    }
}
