using System;
using System.IO;
using System.Collections.Generic;
using BankSystem.Models;

namespace BankSystem.Repositories
{
    public class FileRepository : IAccountRepository
    {
        public string FilePath { get; private set; }
        public FileRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Invalid File Path", nameof(filePath));
            }
            FilePath = filePath;
        }
        public void Save(List<Account> accounts)
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (Account account in accounts)
                {
                    string type = account.GetType().Name;

                    sw.WriteLine($"{type}|{account.Id}|{account.OwnerName}|{account.Balance}");
                }
            }
        }

        public List<Account> Load()
        {
            List<Account> accounts = new List<Account>();

            if (!File.Exists(FilePath))
                return accounts;

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');

                    string type = parts[0];
                    int id = int.Parse(parts[1]);
                    string ownerName = parts[2];
                    decimal balance = decimal.Parse(parts[3]);

                    Account account;

                    if (type == "CurrentAccount")
                        account = new CurrentAccount(id, ownerName);

                    else if (type == "SavingAccount")
                        account = new SavingAccount(id, ownerName);

                    else
                        continue;

                    if (balance > 0)
                        account.Deposit(balance);

                    accounts.Add(account);
                }
            }

            return accounts;
        }
        
    }
}