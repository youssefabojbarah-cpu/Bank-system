using System;
using System.Linq;
using System.Collections.Generic;
using BankSystem.Models;
using BankSystem.Repositories;

namespace BankSystem.Services
{
    public class BankService
    {
        private readonly IAccountRepository repository;
        private List<Account> accounts;
        public BankService(IAccountRepository repository)
        {
            this.repository = repository;
            
            accounts = repository.Load();
        }
        private int GetNextId()
        {
            if (accounts.Count == 0)
                return 1;

            return accounts.Max(a => a.Id) + 1;
        }
        public Account CreateCurrentAccount(string ownerName)
        {
            int id = GetNextId();

            Account account = new CurrentAccount(id, ownerName);

            accounts.Add(account);

            repository.Save(accounts);

            return account;
        }
        public Account CreateSavingAccount(string ownerName)
        {
            int id = GetNextId();

            Account account = new SavingAccount(id, ownerName);

            accounts.Add(account);

            repository.Save(accounts);

            return account;
        }
        public Account GetAccount(int id)
        {
            Account account = accounts.FirstOrDefault(a => a.Id == id);

            if (account == null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            return account;
        }
        public void Deposit(int id, decimal amount)
        {
            Account account = GetAccount(id);

            account.Deposit(amount);

            repository.Save(accounts);
        }
        public void Withdraw(int id , decimal amount)
        {
            Account account = GetAccount(id);

            account.Withdraw(amount);

            repository.Save(accounts);
        }
        public void Transfer(int fromId, int toId, decimal amount)
        {
            if (fromId == toId)
            {
                throw new InvalidOperationException("Cannot transfer to the same account.");
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
            }

            Account sourceAccount = GetAccount(fromId);

            Account destinationAccount = GetAccount(toId);

            sourceAccount.Withdraw(amount);

            destinationAccount.Deposit(amount);

            repository.Save(accounts);
        }
    }
}