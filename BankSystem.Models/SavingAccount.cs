namespace BankSystem.Models
{
    public class SavingAccount : Account
    {
         private const decimal LIMIT = 5000;
        public SavingAccount(int id, string ownerName)
            : base(id, ownerName, 5000)
        {
        }
    }
}