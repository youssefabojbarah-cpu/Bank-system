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
        public Account CreateAccount(int id, string ownerName, decimal withdrawalLimit)
        {
            if (accounts.Any(a => a.Id == id))
            {
                throw new InvalidOperationException("Account with same Id already exists.");
            }

            Account account = new Account(id, ownerName, withdrawalLimit);

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