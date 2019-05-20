using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePayHomeworkTask.Interfaces
{
    public interface ITransaction
    {
        DateTime TransactionDate { get; }
        string TransactionDateFormatted { get; }
        string Client { get; }
        decimal FeeAmount { get; }
        string FeeAmountFormatted { get; }
        decimal Amount { get; }
        string AmountFormatted { get; }
    }
}
