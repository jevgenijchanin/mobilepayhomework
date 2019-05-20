using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePayHomeworkTask.Implementation;
using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class PercentageFeeDiscountTest
    {
        [TestMethod]
        public void PercentageFeeAmountAmount()
        {
            int feeDiscountPercent = 1;
            decimal amount = 100;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    decimal manualFeeDiscountCalculation = (amount * feeDiscountPercent) / 100;
                    IFeeDiscount feeDiscount = new PercentageFeeDiscount(feeDiscountPercent) { TransactionDate = new DateTime(2018, 9, 1), Client = "CLIENT", Amount = amount };
                    if (manualFeeDiscountCalculation != feeDiscount.FeeDiscountAmount)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
