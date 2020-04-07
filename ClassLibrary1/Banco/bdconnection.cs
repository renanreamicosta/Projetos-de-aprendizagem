using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
        public string message;

        //Constructor
        public CrudConnection(string sv, string db, string id, string pass)
        //public DashboardDbConnection()
        {
            Initialize(sv, db, id, pass);
            //Initialize();
        }

        public CrudConnection()
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
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                connection = new SqlConnection(connectionString);

            }
            catch (Exception)
            {
                throw;
            }
        }

       

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
          
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public HttpStatusCode InsertUsuario(Pessoas param)
        {

            try
            {
                string query = "";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    SqlCommand cmd = new SqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;
                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();

                    message = "seu usuario foi cadastrado com sucesso";
                }
                else
                {
                    return HttpStatusCode.InternalServerError;
                }

            }
            catch (Exception)
            {
                message = "erro ao inserir dados na tabela";
            }

            return HttpStatusCode.OK;
        }
    }
}