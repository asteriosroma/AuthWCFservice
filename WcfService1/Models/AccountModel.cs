using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.Models
{
    public class AccountModel
    {
        List<Account> listAccounts = new List<Account>();

        public bool Login(string username, string password)
        {
            return listAccounts.Any(acc => acc.Username == username && acc.Password == password);
        }

        public void AddAccount(Account acc)
        {
            listAccounts.Add(acc);
        }
    }
}