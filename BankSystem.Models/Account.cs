using System;

namespace BankSystem.Models
{
    public class Account
    {
        public int Id { get; private set; }

        public string OwnerName { get; private set; }

        public decimal Balance { get; private set; }

        public decimal WithdrawalLimit { get; private set; }


        public Account(int id, string ownerName, decimal withdrawalLimit)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be positive!");

            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException("Invalid owner name!");

            if (withdrawalLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(withdrawalLimit), "Withdrawal limit must be positive!");

            Id = id;
            OwnerName = ownerName;
            WithdrawalLimit = withdrawalLimit;
            Balance = 0;
        }
        public Account(int id, string ownerName, decimal balance, decimal withdrawalLimit, bool isFromStorage)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException(nameof(ownerName));

            if (withdrawalLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(withdrawalLimit));

            if (balance < 0)
                throw new ArgumentOutOfRangeException(nameof(balance));

            Id = id;
            OwnerName = ownerName;
            WithdrawalLimit = withdrawalLimit;
            Balance = balance;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero!");

            Balance += amount;
        }


        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero!");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance!");

            if (amount > WithdrawalLimit)
                throw new InvalidOperationException("Withdrawal limit exceeded!");

            Balance -= amount;
        }
    }
}