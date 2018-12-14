using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Sockets;
using ImgLib;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace PicSecureRest
{
    public class PicSecManage
    {
        private const string CONNECTIONSTRING = "Server=tcp:picsecure.database.windows.net,1433;Initial Catalog=PicSecure;Persist Security Info=False;User ID={PicSecure};Password={Diller12345.com};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private string insertSql = "insert into TestTable(@testimg, @testtitle, @testtid)";

        public List<ImgModel> UseCommands()
        {
            List<ImgModel> images = new List<ImgModel>();

            using (SqlConnection connection = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                }
            }
        }
       

        









    }
}
