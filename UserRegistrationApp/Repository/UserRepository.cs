using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UserRegistrationApp.DBManager;
using UserRegistrationApp.Models;
using UserRegistrationApp.viewModel;

namespace UserRegistrationApp.Repository
{
    public class UserRepository
    {
        ProcedureManager procedureManager = new ProcedureManager();
        public List<UserRegModel> display()
        {
            List<UserRegModel> list = new List<UserRegModel>();
            DataTable dt = procedureManager.GetDataList("uSP_select");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new UserRegModel
                {
                    id = Convert.ToInt32(dr["id"]),
                    emailid = Convert.ToString(dr["emailid"]),
                    password = Convert.ToString(dr["password"]),
                    name = Convert.ToString(dr["name"])
                });
            }
            return list;
        }

        public bool InsertData(UserRegModel urm)
        {
            List<KeyValue> keyValues = new List<KeyValue> { };
            keyValues.Add(new KeyValue() { key = "id", value = urm.id });
            keyValues.Add(new KeyValue() { key = "email", value = urm.emailid });
            keyValues.Add(new KeyValue() { key = "pwd", value = urm.password });
            keyValues.Add(new KeyValue() { key = "name", value = urm.name });
            return procedureManager.insert("uSP_insert", keyValues);
        }

        public bool UpdateData(UserRegModel urm)
        {
            List<KeyValue> keyValues = new List<KeyValue> { };
            keyValues.Add(new KeyValue() { key = "id", value = urm.id });
            keyValues.Add(new KeyValue() { key = "email", value = urm.emailid });
            keyValues.Add(new KeyValue() { key = "pwd", value = urm.password });
            keyValues.Add(new KeyValue() { key = "name", value = urm.name });
            return procedureManager.update("uSP_update", keyValues);
        }

        public bool DeleteData(UserRegModel urm)
        {
            List<KeyValue> keyValues = new List<KeyValue> { };
            keyValues.Add(new KeyValue() { key = "id", value = urm.id });
            return procedureManager.delete("uSP_delete", keyValues);
        }
    }
}
