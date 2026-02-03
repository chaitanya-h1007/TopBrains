using NUnit.Framework;
using System;

namespace M1_Practice{
    /// <summary>
    /// Test fixture for M1_Practice containing unit tests for bank account operations (Deposit and Withdraw).
    /// Uses NUnit framework for testing.
    /// </summary>
    [TestFixture]
    public class TestCase
    {
        /// <summary>
        /// Test Case 1: Validates that a valid deposit amount increases the account balance correctly.
        /// </summary>
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            // Arrange: Create an account with initial balance of 20000
            Program account = new Program(20000m);

            // Act: Deposit 5000 into the account
            account.Deposit(5000m);

            // Assert: Verify the new balance equals 25000 (20000 + 5000)
            Assert.AreEqual(25000m, account.Balance);
        }

        /// <summary>
        /// Test Case 2: Validates that depositing a negative amount throws an exception with the correct message.
        /// </summary>
        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            // Arrange: Create an account with initial balance of 5000
            Program account = new Program(5000m);

            // Act & Assert: Attempt to deposit negative amount and verify exception is thrown
            var ex = Assert.Throws<Exception>(() => account.Deposit(-20m));

            // Verify the exception message matches the expected error
            Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        /// <summary>
        /// Test Case 3: Validates that a valid withdrawal amount decreases the account balance correctly.
        /// </summary>
        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            // Arrange: Create an account with initial balance of 200
            Program account = new Program(200m);

            // Act: Withdraw 80 from the account
            account.Withdraw(80m);

            // Assert: Verify the new balance equals 120 (200 - 80)
            Assert.AreEqual(120m, account.Balance);
        }

        /// <summary>
        /// Test Case 4: Validates that withdrawing more than available balance throws an exception with the correct message.
        /// </summary>
        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            // Arrange: Create an account with initial balance of 100
            Program account = new Program(100m);

            // Act & Assert: Attempt to withdraw 150 (more than balance) and verify exception is thrown
            var ex = Assert.Throws<Exception>(() => account.Withdraw(150m));

            // Verify the exception message matches the expected error
            Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}