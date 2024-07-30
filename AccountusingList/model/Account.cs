using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountusingList.model
{
    internal class Account
    {
        private int _accountNumber;
        private string _accountName;
        private string _bankName;
        private double _accountBalance;
        private long _adharNumber;
        static double MIN_BALANCE = 500;

        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }
        public long AdharNumber
        {
            get { return _adharNumber; }
            set { _adharNumber = value; }
        }
        public double AccountBalance
        {
            get { return _accountBalance; }
            set { _accountBalance = value; }
        }

        public Account()
        {

        }

        public Account(int accountNumber, string accountName, string bankName, long adharNumber, double accountBalance)
        {
            _accountNumber = accountNumber;
            _accountName = accountName;
            _bankName = bankName;
            _adharNumber = adharNumber;
            if (accountBalance < MIN_BALANCE)
            {
                _accountBalance = MIN_BALANCE;
            }
            else
            {
                _accountBalance = accountBalance;
            }
        }

        public string deposit(double amount)
        {
            _accountBalance = _accountBalance + amount;
            return "amount deposited successfully";
        }

        public string withdraw(double amount)
        {
            if (_accountBalance - amount < MIN_BALANCE)
                return "amount is less than min amount";
            _accountBalance = _accountBalance - amount;
            return "amount " + amount + " withdrawn successfully ";
        }

        public double checkBalance()
        {
            return _accountBalance;
        }





    }
}
