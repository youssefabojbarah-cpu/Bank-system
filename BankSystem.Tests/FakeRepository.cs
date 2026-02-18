using System.Collections.Generic;
using BankSystem.Models;
using BankSystem.Repositories;

namespace BankSystem.Tests
{
    public class FakeRepository : IAccountRepository
    {
        private List<Account> accounts = new List<Account>();

        public List<Account> Load() => accounts;
        public void Save(List<Account> accounts)
        {
            this.accounts = accounts;
        }
    }
}