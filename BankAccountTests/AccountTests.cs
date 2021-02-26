using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize] // Run code before EACH Test
        public void Initialize()
        {
            acc = new Account();
        }

        [TestMethod]
        [DataRow(10_000)]
        [DataRow(11234.12)]
        [DataRow(10000.01)]
        [DataRow(double.MaxValue)]
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {
            Account acc = new Account();
            
           
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit));
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(9999.99)]
        [DataRow(.01)]
        public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
        {
            // AAA - Arrange Act Assert

            // Arrange - Creating variables/object
            Account acc = new Account();
           const double startBalance = 0;
            
            // Act - Execute method under test
              acc.Deposit(initialDeposit);

            // Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod]
        //[TestCategory("Something else")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            Account acc = new Account();
            double initialBalance = 0;
            double depositAmount = 10.55;

            // Act
          double newBalance = acc.Deposit(depositAmount);

            // Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.AreEqual(expectedBalance, newBalance);
        }
        [TestMethod]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            Account acc = new Account();
            double deposit1 = 10;
            double deposit2 = 25;
            double expectedBalance = deposit1 + deposit2;

            // Act
          double intermediateBalance = acc.Deposit(deposit1);
            double finalBalance = acc.Deposit(deposit2);

            // Assert
            Assert.AreEqual(deposit1, intermediateBalance);
            Assert.AreEqual(expectedBalance, finalBalance);
        }

        // Test - test for negative deposits
        [TestMethod]
        public void Deposit_NegativeAmounts_ThrowsArgumentException()
        {
            Account acc = new Account();
            double negativeDeposit = -1;

            // Assert => 
            Assert.ThrowsException<ArgumentException>
                (
                    () => acc.Deposit(negativeDeposit)
                );
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(50, 50)]
        [DataRow(9.99, 9.99)]
        public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {
            double expectedBalance = initialDeposit - withdrawAmount;

            // Assert.Fail();
             acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_MoreThanBalance_ThrowsArgumentException()
        {
            // double initialBalance = 0;
            // An account created with the default constructor has a 0 balance
            Account myAccount = new Account();
            double withdrawAmount = 1000;


            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(1));
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            Assert.Fail();
        }
    }
}