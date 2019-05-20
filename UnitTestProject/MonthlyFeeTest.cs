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
    public class MonthlyFeeTest
    {
        [TestMethod]
        public void FixedFeeFirstApply()
        {
            StaticStorage.ClearMonthlyFeeApplication();
            decimal fixedFeeAmount = 29;
            IFee fee = new MonthlyFee(fixedFeeAmount) { TransactionDate = new DateTime(2018, 9, 1), Client = "CLIENT", Amount = 100 };            
            Assert.AreEqual(fixedFeeAmount, fee.FeeAmount);            
        }

        [TestMethod]
        public void FixedFeeAlreadyApplyed()
        {
            StaticStorage.ClearMonthlyFeeApplication();
            decimal fixedFeeAmount = 29;
            IFee fee = new MonthlyFee(fixedFeeAmount) { TransactionDate = new DateTime(2018, 9, 1), Client = "CLIENT", Amount = 100 };
            decimal feeAmount = fee.FeeAmount; // To skip not applyed case
            Assert.AreEqual(0, fee.FeeAmount);
        }
    }
}
