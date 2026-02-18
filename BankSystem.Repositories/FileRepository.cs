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
            if (accounts == null)
            {
                throw new ArgumentNullException(nameof(accounts));
            }
            using(StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (Account account in accounts)
                {
                    sw.WriteLine($"{account.Id}|{account.OwnerName}|{account.Balance}|{account.WithdrawalLimit}");
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

                    if (parts.Length != 4)
                        continue;

                    if (!int.TryParse(parts[0], out int id))
                        continue;

                    string ownerName = parts[1];

                    if (!decimal.TryParse(parts[2], out decimal balance))
                        continue;

                    if (!decimal.TryParse(parts[3], out decimal withdrawalLimit))
                        continue;

                    Account account = new Account(id, ownerName, balance, withdrawalLimit, true);

                    accounts.Add(account);
                }
            }

            return accounts;
        }
    }
}