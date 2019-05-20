using MobilePayHomeworkTask.Data;
using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePayHomeworkTask.Implementation
{
    public class FeeCalculator : IFeeCalculator
    {
        public DateTime TransactionDate { get; set; }
        public string Client { get; set; }
        public decimal Amount { get; set; }

        public decimal TotalFeeAmount
        {
            get
            {
                decimal feeAmount = 0;
                decimal feeDiscountAmount = 0;
                decimal totalDiscount = 0;
                
                IFee fee = StaticStorage.GetFee(TransactionDate, Client, Amount);
                feeAmount = fee.FeeAmount;

                IFeeDiscount discount = StaticStorage.GetDiscount(TransactionDate, Client, Amount);
                if (discount != null)
                {
                    discount.TransactionDate = TransactionDate;
                    discount.Client = Client;
                    discount.Amount = feeAmount;

                    feeDiscountAmount = discount.FeeDiscountAmount;
                }

                totalDiscount = (feeAmount - feeDiscountAmount);

                IFee monthlyFee = StaticStorage.GetMonthlyFee(TransactionDate, Client, Amount);
                monthlyFee.TransactionDate = TransactionDate;
                monthlyFee.Client = Client;
                monthlyFee.Amount = feeAmount;

                totalDiscount += monthlyFee.FeeAmount;

                return totalDiscount;
            }
        }
    }
}
