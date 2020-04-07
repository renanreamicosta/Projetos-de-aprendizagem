using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto_sql.Banco
{
    public class CrudConnection
    {

        private SqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


        //Constructor
        public CrudConnection(string sv, string db, string id, string pass)
        //public DashboardDbConnection()
        {
            Initialize(sv, db, id, pass);
            //Initialize();
        }

        public crudConnection()
        {
        }

        //Initialize values
        private void Initialize(string sv, string db, string id, string pass)
        //private void Initialize()
        {
            try
            {
                server = sv;
                database = db;
                uid = id;
                password = pass;
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; Convert Zero Datetime=True";

                connection = new SqlConnection(connectionString);

            }
            catch (Exception ex)
            {
                LogForm(ex.ToString());
                throw;
            }
        }
    }
}