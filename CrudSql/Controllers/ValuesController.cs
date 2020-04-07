using Conexao;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudSql.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        public static CrudConnection ConnectionDB()
        {
            var Server = ConfigurationManager.AppSettings["Server"];
            var Database = ConfigurationManager.AppSettings["Database"];
            var Id = ConfigurationManager.AppSettings["Id"];
            var Password = ConfigurationManager.AppSettings["Password"];
            CrudConnection Connection = new CrudConnection(Server, Database, Id, Password);

            return Connection;
        }
     

        [HttpPost]
        public HttpResponseMessage InsertClient([FromBody]Pessoas param)
        {
            CrudConnection conn = ConnectionDB();

            var response = new HttpResponseMessage(conn.InsertUsuario(param));

            return response;
        }
    }
}
