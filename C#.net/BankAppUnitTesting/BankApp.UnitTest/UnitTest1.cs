using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAppExceptions;
using System.Security.Principal;
using Moq;
using BankApp.DataAccessLayer;
using BankApp.BusinessLayer;

namespace BankApp.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        AccountManager accman;
        Mock<IDataStorage> mock;
        Mock<NotificationSender> mockns;
        [TestInitialize]
        public void Init()
        {
            mock = new Mock<IDataStorage>();
            mockns = new Mock<NotificationSender>();
            mockns.Setup(m => m.EmailNotificationForWithdrawl(It.IsAny<double>()));
            mockns.Setup(m => m.EmailNotificationForDeposition(It.IsAny<double>()));
            mockns.Setup(m => m.EmailNotificationForTransfer(It.IsAny<double>()));
            mock.Setup(m=>m.Save(string.Empty)).Returns(true);
            accman = new AccountManager(mock.Object,mockns.Object);
        }
        [TestCleanup]
        public void Cleanup()
        {
            accman = null;
            mock = null;
            mockns = null;
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void AccountOpeningOnlyOnce()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            accman.OpenAccount(account);
            accman.CloseAccount(account);
            accman.OpenAccount(account);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void ClosingAnAccountNotPresent()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            accman.CloseAccount(account);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void ClosingAnAccountAlreadyClosed()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            accman.OpenAccount(account);
            accman.CloseAccount(account);
            accman.CloseAccount(account);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void ClosingAnAccountWithBalanceMoreThanZero()
        {
            Account account = new Account {Accno=1234,Name="Rakshitha",Pin=2468,Balance=93287};
            accman.OpenAccount(account);
            accman.CloseAccount(account);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void OpeningAccountAlreadyOpen()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            accman.OpenAccount(account);
            accman.OpenAccount(account);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void AccountClosedWhileWithdrawing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            accman.OpenAccount(account);
            accman.CloseAccount(account);
            accman.Withdraw(account, 10000, 2468);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void AccountNotFoundWhileWithdrawing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.Withdraw(account, 10000, 2468);
        }
        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void WrongPinWhileWithdrawing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account);
            accman.Withdraw(account, 10000, 2883);
        }
        [TestMethod]
        [ExpectedException(typeof(OperationException), "Amount cannot be less than 0")]
        public void AmountLessThanZeroWhileWithdrawing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account);
            accman.Withdraw(account, -29743, 2883);
        }
        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void AmountMoreThanBalanceWhileWithdrawing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account);
            accman.Withdraw(account, 10001, 2883);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void AccountClosedWhileDepositing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            accman.OpenAccount(account);
            accman.CloseAccount(account);
            accman.Deposit(account, 10000);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void AccountNotFoundWhileDepositing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.Deposit(account, 10000);
        }
        [TestMethod]
        [ExpectedException(typeof(OperationException), "Amount cannot be less than 0")]
        public void AmountLessThanZeroWhileDepositing()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account);
            accman.Deposit(account, -29743);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void FromAccountClosedWhileTransfering()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            Account account2 = new Account { Accno = 4567, Name = "Prakash", Pin = 8783, Balance = 900 };
            accman.OpenAccount(account1);
            accman.CloseAccount(account1);
            accman.OpenAccount(account2);
            accman.Transfer(account1, 1000,account2);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void FromAccountNotFoundWhileTransfering()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 4567, Name = "Prakash", Pin = 8783, Balance = 900 };
            accman.OpenAccount(account2);
            accman.Transfer(account1, 1000, account2);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void ToAccountClosedWhileTransfering()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 4567, Name = "Prakash", Pin = 8783, Balance = 0 };
            accman.OpenAccount(account1);
            accman.OpenAccount(account2);
            accman.CloseAccount(account2);
            accman.Transfer(account1, 1000, account2);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountException))]
        public void ToAccountNotFoundWhileTransfering()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 4567, Name = "Prakash", Pin = 8783, Balance = 900 };
            accman.OpenAccount(account1);
            accman.Transfer(account1, 1000, account2);
        }
        [TestMethod]
        [ExpectedException(typeof(OperationException), "Amount cannot be less than 0")]
        public void AmountLessThanZeroWhileTransfering()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 4567, Name = "Prakash", Pin = 8783, Balance = 900 };
            accman.OpenAccount(account1);
            accman.OpenAccount(account2);
            accman.Transfer(account1, -1000, account2);
        }
        [TestMethod]
        public void TestingDeposition()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account);
            accman.Deposit(account, 1000);
            double target = account.Balance;
            Assert.AreEqual(11000,target);
        }
        [TestMethod]
        public void TestingWithdrawl ()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account);
            accman.Withdraw(account, 1000,2468);
            double target = account.Balance;
            Assert.AreEqual(9000, target);
        }
        [TestMethod]
        public void TestingTransfer_SenderBalance()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 7890, Name = "Prakash", Pin = 6756, Balance = 900 };
            accman.OpenAccount(account1);
            accman.OpenAccount(account2);
            accman.Transfer(account1, 100, account2);
            double target = account1.Balance;
            Assert.AreEqual(9900, target);
        }
        [TestMethod]
        public void TestingTransfer_ReceiverBalance()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 7890, Name = "Prakash", Pin = 6756, Balance = 900 };
            accman.OpenAccount(account1);
            accman.OpenAccount(account2);
            accman.Transfer(account1, 100, account2);
            double target = account2.Balance;
            Assert.AreEqual(1000, target);
        }
        [TestMethod]
        public void TestingOpenAccount()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account);
            bool target = account.isActive;
            Assert.AreEqual(true, target);
        }
        [TestMethod]
        public void TestingCloseAccount()
        {
            Account account = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 0 };
            accman.OpenAccount(account);
            accman.CloseAccount(account);
            bool target = account.isActive;
            Assert.AreEqual(false, target);
        }
        [TestMethod]
        public void TransferDataStoredInDB()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 7890, Name = "Prakash", Pin = 6756, Balance = 900 };
            accman.OpenAccount(account1);
            accman.OpenAccount(account2);
            accman.Transfer(account1, 100, account2);
            mock.Verify(m=>m.Save("Rs. 100 transfered from Rakshitha to Prakash"), Times.Once());
        }
        [TestMethod]
        [ExpectedException(typeof(MoreThan3TransactionsTodayException))]
        public void TestingMoreThan3TransactionsToday()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 7890, Name = "Prakash", Pin = 6756, Balance = 900 };
            accman.OpenAccount(account1);
            accman.OpenAccount(account2);
            accman.Transfer(account1, 100, account2);
            accman.Transfer(account1, 100, account2);
            accman.Transfer(account1, 100, account2);
            accman.Transfer(account1, 100, account2);
        }
        [TestMethod]
        public void TestingNotificationSenderForWithdrawl()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account1);
            accman.Withdraw(account1, 100,2468);
            mockns.Verify(m=>m.EmailNotificationForWithdrawl(100),Times.Once());
        }
        [TestMethod]
        public void TestingNotificationSenderForDeposition()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            accman.OpenAccount(account1);
            accman.Deposit(account1, 100);
            mockns.Verify(m => m.EmailNotificationForDeposition(100), Times.Once());
        }
        [TestMethod]
        public void TestingNotificationSenderForTransfer()
        {
            Account account1 = new Account { Accno = 1234, Name = "Rakshitha", Pin = 2468, Balance = 10000 };
            Account account2 = new Account { Accno = 7890, Name = "Prakash", Pin = 6756, Balance = 900 };
            accman.OpenAccount(account1);
            accman.OpenAccount(account2);
            accman.Transfer(account1, 100, account2);
            mockns.Verify(m => m.EmailNotificationForTransfer(100), Times.Once());
        }
    }
}
