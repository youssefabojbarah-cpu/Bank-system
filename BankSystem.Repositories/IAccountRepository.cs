using System;
using System.IO;
using System.Collections.Generic;
using BankSystem.Models;

namespace BankSystem.Repositories
{
    public interface IAccountRepository
    {
        void Save(List<Account> accounts);
        List<Account> Load();
    }
}