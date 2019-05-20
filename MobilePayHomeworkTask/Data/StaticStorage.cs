using MobilePayHomeworkTask.Implementation;
using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePayHomeworkTask.Data
{

    struct DateClientFeeApplyed
    {
        public string Month { get; set; }
        public string Client { get; set; }
    }

    public static class StaticStorage // Let it be our persistance storage
    {
        private static List<DateClientFeeApplyed> _monthFeeApplyed = new List<DateClientFeeApplyed>();
        public static IFee GetFee(DateTime transactionDate, string client, decimal amount) // In case if we will need more params in future
        {
            IFee fee = new PercentageFee(1) { TransactionDate = transactionDate, Client = client, Amount = amount  };
            return fee;
        }

        public static IFeeDiscount GetDiscount(DateTime transactionDate, string client, decimal amount) // In case if we will need more params in future
        {
            Dictionary<string, IFeeDiscount> discounts = new Dictionary<string, IFeeDiscount>();
            discounts.Add("TELIA", new PercentageFeeDiscount(10));
            discounts.Add("CIRCLE_K", new PercentageFeeDiscount(20));

            if (discounts.ContainsKey(client))
                return discounts[client];
            else
                return null;
        }

        public static IFee GetMonthlyFee(DateTime transactionDate, string client, decimal amount) // In case if we will need more params in future
        {
            return new MonthlyFee(29);
        }

        public static bool IsMonthlyFeeApplyed(DateTime transactionDate, string client, decimal amount)
        {
            bool isApplyed = false;

            if(_monthFeeApplyed.Where(t => t.Month == transactionDate.ToString("yyyyMM") && t.Client == client ).Count() > 0 )
            {
                isApplyed = true;
            }
            else
            {
                _monthFeeApplyed.Add(new DateClientFeeApplyed() { Month = transactionDate.ToString("yyyyMM"), Client = client });
            }

            return isApplyed;
        }

        public static void ClearMonthlyFeeApplication()
        {
            _monthFeeApplyed = new List<DateClientFeeApplyed>();
        }


    }
}
