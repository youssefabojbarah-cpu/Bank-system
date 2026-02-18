using BankSystem.Repositories;
using BankSystem.Services;
using BankSystem.UI;

namespace BankSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccountRepository repository = new FileRepository("accounts.txt");

            BankService bankService = new BankService(repository);

            Menu menu = new Menu(bankService);

            menu.Show();
        }
    }
}