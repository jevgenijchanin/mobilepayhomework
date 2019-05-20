using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePayHomeworkTask.Interfaces
{
    public interface IFileParser
    {
        ITransaction PaymentTransaction(string dataLine);
    }
}
