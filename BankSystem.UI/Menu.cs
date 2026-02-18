using System;
using BankSystem.Services;

namespace BankSystem.UI
{
    public class Menu
    {
        private readonly BankService bankService;

        public Menu(BankService bankService)
        {
            this.bankService = bankService;
        }

        public void Show()
        {
            while (true)
            {
                try
                {
                    ShowHeader();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n👉 Select option: ");
                    Console.ResetColor();

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CreateAccount();
                            break;

                        case "2":
                            Deposit();
                            break;

                        case "3":
                            Withdraw();
                            break;

                        case "4":
                            Transfer();
                            break;

                        case "5":
                            Console.WriteLine("Exiting system...");
                            return;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nError: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        private void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔════════════════════════════════════════╗");
            Console.WriteLine("║            BANKING SYSTEM V1.0         ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("\n  [1] 💳 Create New Account");
            Console.WriteLine("  [2] 💰 Deposit Funds");
            Console.WriteLine("  [3] 💸 Withdraw Cash");
            Console.WriteLine("  [4] 🔄 Internal Transfer");
            Console.WriteLine("  [5] ❌ Exit System");

            Console.WriteLine("\n──────────────────────────────────────────");
        }

        private void CreateAccount()
        {
            Console.Write("Enter Account Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            Console.Write("Enter Owner Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Withdrawal Limit: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal limit))
            {
                Console.WriteLine("Invalid withdrawal limit.");
                return;
            }

            bankService.CreateAccount(id, name, limit);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Account created successfully.");
            Console.ResetColor();
        }

        private void Deposit()
        {
            Console.Write("Enter Account Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            bankService.Deposit(id, amount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deposit successful.");
            Console.ResetColor();
        }

        private void Withdraw()
        {
            Console.Write("Enter Account Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            bankService.Withdraw(id, amount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Withdraw successful.");
            Console.ResetColor();
        }

        private void Transfer()
        {
            Console.Write("Enter Source Account Id: ");
            if (!int.TryParse(Console.ReadLine(), out int fromId))
            {
                Console.WriteLine("Invalid source Id.");
                return;
            }

            Console.Write("Enter Destination Account Id: ");
            if (!int.TryParse(Console.ReadLine(), out int toId))
            {
                Console.WriteLine("Invalid destination Id.");
                return;
            }

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            bankService.Transfer(fromId, toId, amount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Transfer successful.");
            Console.ResetColor();
        }
    }
}