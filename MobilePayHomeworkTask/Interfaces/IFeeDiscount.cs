using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePayHomeworkTask.Interfaces
{
    public interface IFeeDiscount
    {
        DateTime TransactionDate { get; set; }
        string Client { get; set; }
        decimal Amount { get; set; }
        decimal FeeDiscountAmount { get; }
    }
}
