using System;
using System.Diagnostics;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Account name:");
            var accountName = Console.ReadLine();
            Console.WriteLine("Enter {0} to select {1} account", 1, AccountType.Current);
            Console.WriteLine("Enter {0} to select {1} account", 2, AccountType.Savings);
            Console.WriteLine("Enter {0} to select {1} account", 3, AccountType.Student);
            Console.WriteLine("Account type:");
            var accountTypeKey = Console.ReadKey();
            // Account account;
            if(accountTypeKey.Key is ConsoleKey.D2 or ConsoleKey.D1 or ConsoleKey.D3)
            {
                var account = new Account(accountName, Enum.Parse<AccountType>(accountTypeKey.KeyChar.ToString()));
                Operation(account);
                // Console.WriteLine(account.GetAccountBalance());
            }
            else
            {
               Console.WriteLine("Try again");
               Environment.Exit(0);
            }
        }

        private static void ExitOrContinue(Account account)
        {
            Console.WriteLine("Press 0 to exit or 1 to perform another operation.");
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.D0)
            {
                Console.WriteLine("Ok Goodbye {0}", account.GetAccountName());
                Environment.Exit(0);
            }
            Operation(account);
        }

        private static void Operation(Account account)
        {
            Console.WriteLine("");
            Console.WriteLine("What operation do you want to carry out?");
            Console.WriteLine("Enter {0} to Get account balance", 1);
            Console.WriteLine("Enter {0} to select make a deposit", 2);
            Console.WriteLine("Enter {0} to select make a withdrawal", 3);
            Console.WriteLine("Enter {0} to get account number", 4);
            // Console.WriteLine("Enter {0} to select see transaction history", 4);
            Console.WriteLine("Response:");
            var operation = Console.ReadKey();
            Console.WriteLine("");
            if (operation.Key == ConsoleKey.D1)
            {
                // Get account balance
                Console.WriteLine("Hi {0}, your account balance is {1}", account.GetAccountName(), account.GetAccountBalance());
                ExitOrContinue(account);
            }
            else if (operation.Key == ConsoleKey.D2)
            { // Make a deposit
                Console.WriteLine("Deposit Amount: ");
                var amount = Console.ReadLine();
                if (!string.IsNullOrEmpty(amount))
                {
                    var deposit = account.Deposit(Decimal.Parse(amount));
                    if (!deposit.Item2)
                        Console.WriteLine(deposit.Item1);
                }
                Console.WriteLine("Hi {0}, your account balance is {1}", account.GetAccountName(), account.GetAccountBalance());
                ExitOrContinue(account);
            }  
            else if (operation.Key == ConsoleKey.D3)
            { // Make a withdrawal
                Console.WriteLine("Withdrawal Amount: ");
                var amount = Console.ReadLine();
                if (!string.IsNullOrEmpty(amount))
                {
                    var withdrawal = account.Withdraw(Decimal.Parse(amount));
                    if (!withdrawal.Item2)
                        Console.WriteLine(withdrawal.Item1);
                }
                Console.WriteLine("Hi {0}, your new account balance is {1}", account.GetAccountName(), account.GetAccountBalance());
                ExitOrContinue(account);
            } 
            else if (operation.Key == ConsoleKey.D4)
            { // Get account number
                Console.WriteLine("Hi {0}, your new account number is {1}", account.GetAccountName(), account.GetAccountNumber());
                ExitOrContinue(account);
            }
            else
            {
                Console.WriteLine("You did not select anything");
                ExitOrContinue(account);
            }
        }
    }
}