using System;
using System.Collections.Generic;
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
        public string HelloWorld(string login, string pass)
        {
            try
            {
                CustomValidator v = new CustomValidator();
                v.Validate(login, pass);
                return "Hello world!";
            }
            catch(SecurityTokenException ex)
            {
                return ex.Message;
            }
        }
    }

    class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            AccountModel am = new AccountModel();
            if (am.Login(userName, password))
            {
                return;
            }
            throw new SecurityTokenException("Account is invalid");
        }
    }
}
