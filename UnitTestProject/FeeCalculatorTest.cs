using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePayHomeworkTask.Data;
using MobilePayHomeworkTask.Implementation;
using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class FeeCalculatorTest
    {
        [TestMethod]
        public void FeeAmountWithFixedTest()
        {
            StaticStorage.ClearMonthlyFeeApplication();
            decimal feeAmount = 30;
            IFeeCalculator calc = new FeeCalculator() { TransactionDate = new DateTime(2018, 9, 1), Client = "CLIENT", Amount = 100 };
            Assert.AreEqual(feeAmount, calc.TotalFeeAmount);
        }

        [TestMethod]
        public void FeeAmountWithoutFixedTest()
        {
            StaticStorage.ClearMonthlyFeeApplication();
            decimal feeAmount = 1;

            IFeeCalculator calc1 = new FeeCalculator() { TransactionDate = new DateTime(2018, 9, 1), Client = "CLIENT", Amount = 100 };
            decimal t1Fee = calc1.TotalFeeAmount;

            IFeeCalculator calc2 = new FeeCalculator() { TransactionDate = new DateTime(2018, 9, 1), Client = "CLIENT", Amount = 100 };
            Assert.AreEqual(feeAmount, calc2.TotalFeeAmount);
        }
    }
}
