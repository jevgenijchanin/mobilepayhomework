using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePayHomeworkTask.Implementation
{
    public class PercentageFeeDiscount : IFeeDiscount
    {
        private int _feeDiscountPercent = 0;
        public PercentageFeeDiscount(int feeDiscountPercent)
        {
            _feeDiscountPercent = feeDiscountPercent;
        }
        public DateTime TransactionDate { get; set; }
        public string Client { get; set; }
        public decimal Amount { get; set; }
        public decimal FeeDiscountAmount
        {
            get
            {
                return ((Amount * _feeDiscountPercent) / 100); // TODO: Some rounding rules
            }
        }
    }
}
