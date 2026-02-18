namespace BankSystem.Models
{
    public class CurrentAccount : Account
    {
         private const decimal LIMIT = 10000;
        public CurrentAccount(int id, string ownerName)
            : base(id, ownerName, LIMIT)
        {
        }
    }
}