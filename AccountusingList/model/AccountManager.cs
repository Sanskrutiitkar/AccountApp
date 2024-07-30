using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AccountusingList.model
{
    internal class AccountManager : Account
    {
        public AccountManager() : base()
        {
            accounts = SerializeDeserialize.DeserializeData();
        }
        public static List<Account> accounts = new List<Account>();
        public static void AccountManagerFunction()
        {
            int operation;
            do
            {
                Console.WriteLine("WELCOME! Select Operation to be performed : ");
                Console.WriteLine("1.ADD 2.PERFORM TRANSACTIONS 3.REMOVE 4.DISPLAY 0.EXIT : ");
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        Console.WriteLine("Enter account number to perform transactions (deposite/withdraw/check balance) : ");
                        int accNumberUpdate = int.Parse(Console.ReadLine());
                        if (FindAccount(accNumberUpdate, accounts, out Account accountToUpdate))
                        {
                            UpdateAccount(accountToUpdate);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter account number to remove : ");
                        int accNumberDel = int.Parse(Console.ReadLine());
                        //manager.RemoveAccount(accNumberDel);
                        if (FindAccount(accNumberDel, accounts, out Account accountToRemove))
                        {
                            RemoveAccount(accNumberDel);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter account number to display information : ");
                        int accNumberDisp = int.Parse(Console.ReadLine());
                        if (FindAccount(accNumberDisp, accounts, out Account accountToDisplay))
                        {
                            DisplayAccount(accountToDisplay);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        FindMaxBalanceAccount(accounts);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (operation != 0);
        }
        public static bool FindAccount(int accountNumber, List<Account> accounts, out Account foundAccount)
        {

            foundAccount = null;
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    foundAccount = account;
                    return true;
                }
            }
            return false;
        }

        public static void UpdateAccount(Account accTransact)
        {
            char choiceAccount = 'Y';

            do
            {
                Console.WriteLine("Enter your choice: 1. Deposit, 2. Withdraw, 3. Account Balance");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter amount to deposit : ");
                        double deposit = double.Parse(Console.ReadLine());
                        Console.WriteLine(accTransact.deposit(deposit));
                        break;
                    case 2:
                        Console.WriteLine("Enter amount to withdraw : ");
                        double withdraw = double.Parse(Console.ReadLine());
                        Console.WriteLine(accTransact.withdraw(withdraw));
                        break;
                    case 3:
                        Console.WriteLine("Total amount present in your account : " + accTransact.checkBalance());
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                Console.WriteLine("Do you wish to continue with the same account Y/N?");
                choiceAccount = char.Parse(Console.ReadLine());

            } while (choiceAccount == 'Y' || choiceAccount == 'y');
            SerializeDeserialize.SerializeData(accounts);
        }

        public static void DisplayAccount(Account account)
        {
            Console.WriteLine("-------DETAILS OF ACCOUNT NUMBER {0}-------", account.AccountNumber);
            Console.WriteLine("Account Name: " + account.AccountName);
            Console.WriteLine("Bank Name: " + account.BankName);
            Console.WriteLine("Account Balance: " + account.checkBalance());
            Console.WriteLine("Adhar number: " + account.AdharNumber);
            Console.WriteLine();
        }

        public static void RemoveAccount(int accountNumber)
        {

            Account accountToRemove = null;

            // Use a foreach loop to find the account
            foreach (Account acc in accounts)
            {
                if (acc.AccountNumber == accountNumber)
                {
                    accountToRemove = acc; // Found 
                    break;
                }
            }
            if (accountToRemove != null)
            {
                accounts.Remove(accountToRemove);
                SerializeDeserialize.SerializeData(accounts);
                Console.WriteLine("Account removed successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public static void AddAccount()
        {
            int accountNumber;
            while (true)
            {
                Console.WriteLine("Enter account number:");
                accountNumber = int.Parse(Console.ReadLine());

                // Check if the account number is already occupied
                if (IsAccountNumberOccupied(accountNumber))
                {
                    Console.WriteLine("Account number already exists. Please enter a different account number.");
                }
                else
                {
                    break; // Exit the loop if the account number is valid
                }
            }

            // Get other account details from the user
            Console.WriteLine("Enter account name:");
            string accountName = Console.ReadLine();
            Console.WriteLine("Enter bank name:");
            string bankName = Console.ReadLine();
            Console.WriteLine("Enter Adhar number:");
            long adharNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter initial balance:");
            double initialBalance = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountNumber, accountName, bankName, adharNumber, initialBalance);

            // Add the new account to the list
            accounts.Add(newAccount);
            SerializeDeserialize.SerializeData(accounts);
            Console.WriteLine("Account added successfully");
        }

        public static bool IsAccountNumberOccupied(int accountNumber)
        {
            foreach (Account acc in accounts)
            {
                if (acc.AccountNumber == accountNumber)
                {
                    return true; // Account number is occupied
                }
            }
            return false; // Account number is available
        }

        public static void FindMaxBalanceAccount(List<Account> accounts)
        {
            Account maxBalanceAccount = null;
            double maxBalance = 0;
            foreach (Account account in accounts)
            {
                if (account.checkBalance() > maxBalance)
                {
                    maxBalance = account.checkBalance();
                    maxBalanceAccount = account;
                }
            }
            if (maxBalanceAccount != null)
            {
                Console.WriteLine("Account with maximum balance:");
                DisplayAccount(maxBalanceAccount);
            }
            else
            {
                Console.WriteLine("No valid accounts found.");
            }
        }


    }

}

