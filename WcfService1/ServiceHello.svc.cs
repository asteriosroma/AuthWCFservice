using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService1.Models;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceHello" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceHello.svc or ServiceHello.svc.cs at the Solution Explorer and start debugging.
    public class ServiceHello : IServiceHello
    {

        public Account HelloAccount(string client_login, string client_pass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    SqlDataReader reader;
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM Accounts";
                    command.Connection = connection;
                    reader = command.ExecuteReader();

                    AccountModel am = new AccountModel();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Account acc = new Account();
                            acc.Username = reader.GetValue(1).ToString().Trim();
                            acc.Password = reader.GetValue(2).ToString().Trim();
                            am.AddAccount(acc);
                        }
                    }

                    MyValidator validator = new MyValidator();
                    validator.Validate(am, client_login, client_pass);
                }

                return new Account(client_login, client_pass);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    class MyValidator
    {
        public void Validate(AccountModel am, string userName, string password)
        {
            if (am.Login(userName, password))
            {
                return;
            }
            throw new SecurityTokenException("Account is invalid");
        }
    }
}
