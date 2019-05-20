using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePayHomeworkTask.Implementation
{
    public class PercentageFee : IFee
    {
        private int _feePercent = 0;
        public PercentageFee(int feePercent)
        {
            _feePercent = feePercent;
        }
        public DateTime TransactionDate { get; set; }
        public string Client { get; set; }
        public decimal Amount { get; set; }
        public decimal FeeAmount
        {
            get
            {
                return ((Amount * _feePercent) / 100); // TODO: We need some rounding rules here
            }
        }
    }
}
