using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.Models
{
    public class AccountModel
    {
        List<Account> listAccounts = new List<Account>();

        public AccountModel()
        {
            listAccounts.Add(new Account { Username = "test", Password = "test" });
        }

        public bool Login(string username, string password)
        {
            return listAccounts.Count(acc => acc.Username.Equals(username) &&
                acc.Password.Equals(password)) > 0;
        }
    }
}