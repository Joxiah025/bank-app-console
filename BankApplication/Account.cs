using System;

namespace BankApplication
{
    public class Account
    {
        private long _accountNumber = 1000000000;
        private readonly string _accountName;
        private decimal _accountBalance;
        private AccountType _accountType;

        public Account(string accountName, AccountType accountType)
        {
            _accountName = accountName;
            _accountBalance = 0;
            _accountType = accountType;
            _accountNumber++;
        }

        public string GetAccountName()
        {
            return _accountName;
        }

        public long GetAccountNumber()
        {
            return _accountNumber;
        }

        public decimal GetAccountBalance()
        {
            return _accountBalance;
        }

        public (string, bool) Withdraw(decimal amount)
        {
            if (amount > _accountBalance) return ("Insufficient funds", false);
            _accountBalance -= amount;
            return ("Operation was successful", true);
        }

        public (string, bool) Deposit(decimal amount)
        {
            if (amount <= 0) return ("Amount must be greater zero", false);
            _accountBalance += amount;
            return ("Operation was successful", true);
        }

        public void Transfer(decimal amount, Account account)
        {
            // Withdraw from current account
            Withdraw(amount);
            // Deposit in other account
            account.Deposit(amount);
        }
        
    }
}