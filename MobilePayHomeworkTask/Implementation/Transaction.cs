using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MobilePayHomeworkTask.Implementation
{
    public class Transaction : ITransaction
    {
        private DateTime _transactionDate;
        private string _client;
        private decimal _amount;
        public Transaction(DateTime transactionDate, string client, decimal amount)
        {
            _transactionDate = transactionDate.Date;
            _client = client;
            _amount = amount;
        }
        public DateTime TransactionDate
        {
            get
            {
                return _transactionDate;
            }
        }

        public string TransactionDateFormatted
        {
            get
            {
                return _transactionDate.ToString("yyyy-MM-dd");
            }
        }

        public string Client
        {
            get
            {
                return _client;
            }
        }

        public decimal FeeAmount
        {
            get
            {
                IFeeCalculator calculator = new FeeCalculator() { TransactionDate = _transactionDate, Client = _client, Amount = _amount };
                return calculator.TotalFeeAmount;
            }
        }

        public string FeeAmountFormatted
        {
            get
            {
                return FeeAmount.ToString("N2", new NumberFormatInfo() { NumberDecimalSeparator = "." });
            }
        }

        public decimal Amount
        {
            get
            {
                return _amount;
            }
        }

        public string AmountFormatted
        {
            get
            {
                return _amount.ToString("N2", new NumberFormatInfo() { NumberDecimalSeparator = "."});
            }
        }
    }
}
