using System;
using System.Collections.Generic;
using System.Text;

namespace LabSpy
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

       [SoftUni("Ivan",Year =2011)]
        private int Id { get; set; }

        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }
}
