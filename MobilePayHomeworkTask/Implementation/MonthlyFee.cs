using MobilePayHomeworkTask.Data;
using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePayHomeworkTask.Implementation
{
    public class MonthlyFee : IFee
    {
        private decimal _fixedMonthlyFee = 0;
        public MonthlyFee(decimal fixedMonthlyFee)
        {
            _fixedMonthlyFee = fixedMonthlyFee;
        }
        public DateTime TransactionDate { get; set; }
        public string Client { get; set; }
        public decimal Amount { get; set; }
        public decimal FeeAmount
        {
            get
            {
                if(StaticStorage.IsMonthlyFeeApplyed(TransactionDate, Client, Amount))
                {
                    return 0;
                }
                else
                {
                    if (Amount > 0)
                        return _fixedMonthlyFee;
                    else
                        return 0;
                }
            }
        }
    }
}
