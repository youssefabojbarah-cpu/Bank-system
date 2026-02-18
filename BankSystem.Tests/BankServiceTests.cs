using Xunit;
using BankSystem.Services;
using BankSystem.Models;

namespace BankSystem.Tests
{
    public class BankSystemTests
    {
        [Fact]
        public void CreatCurrentAccount_SholdCreatAccount()
        {
            var repo = new FakeRepository();

            var service = new BankService(repo);

            var account = service.CreateCurrentAccount("Youssef");
            
            Assert.NotNull(account);

            Assert.Equal("Youssef", account.OwnerName);
    
            Assert.Equal(0, account.Balance);

            Assert.True(account.Id > 0);
        }
        
        [Fact]
        public void Deposit_ShouldIncreaseBalance()
        {
            // Arrange
            var repo = new FakeRepository();

            var service = new BankService(repo);

            var account = service.CreateCurrentAccount("Ahmed");

            service.Deposit(account.Id,500);

            Assert.Equal(500, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldDecreaseBalance()
        {
            var repo = new FakeRepository();

            var service = new BankService(repo);

            var account = service.CreateCurrentAccount("Youssef");

            service.Deposit(account.Id,1000);

            service.Withdraw(account.Id, 600);

            Assert.Equal(400, account.Balance);
        }

        [Fact]
        public void Transfer_ShouldMoveMoneyBetweenAccounts()
        {
            var repo = new FakeRepository();

            var service = new BankService(repo);

            var account1 = service.CreateCurrentAccount("Youssef");

            var account2 = service.CreateCurrentAccount("Ahmed");

            service.Deposit(account1.Id, 1000);

            service.Transfer(account1.Id, account2.Id, 300);

            Assert.Equal(700, account1.Balance);

            Assert.Equal(300, account2.Balance);
        }

        [Fact]
        public void Transfer_ShouldThrowException_WhenBalanceInsufficient()
        {
            var repo = new FakeRepository();

            var service = new BankService(repo);

            var account1 = service.CreateCurrentAccount("Youssef");

            var account2 = service.CreateCurrentAccount("Ahmed");

            service.Deposit(account1.Id, 100);

            Assert.Throws<InvalidOperationException>(() =>
                service.Transfer(account1.Id, account2.Id, 500)
            );
        }

        [Fact]
        public void SavingAccount_ShouldRespectWithdrawalLimit()
        {
            var repo = new FakeRepository();

            var service = new BankService(repo);

            var account = service.CreateSavingAccount("Youssef");

            service.Deposit(account.Id, 10000);

            Assert.Throws<InvalidOperationException>(() =>
                service.Withdraw(account.Id, 6000)
            );
        }

        [Fact]
        public void CurrentAccount_ShouldAllowHigherLimit()
        {
            var repo = new FakeRepository();

            var service = new BankService(repo);

            var account = service.CreateCurrentAccount("Ahmed");

            service.Deposit(account.Id, 10000);

            service.Withdraw(account.Id, 8000);

            Assert.Equal(2000, account.Balance);
        }
    }
}