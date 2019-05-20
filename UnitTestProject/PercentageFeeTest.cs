using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePayHomeworkTask.Implementation;
using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class PercentageFeeTest
    {
        [TestMethod]
        public void PercentageFeeAmountAmount()
        {
            int feePercent = 1;
            decimal amount = 100;

            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 1000; j++)
                {
                    decimal manualFeeCalculation = (amount * feePercent) / 100;
                    IFee fee = new PercentageFee(feePercent) { TransactionDate = new DateTime(2018, 9, 1), Client = "CLIENT", Amount = amount };
                    if(manualFeeCalculation != fee.FeeAmount)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
