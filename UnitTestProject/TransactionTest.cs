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
    public class TransactionTest
    {
        [TestMethod]
        public void DateFormattingTest()
        {
            ITransaction transaction = new Transaction(new DateTime(2018, 9, 1), "CLIENT", 100);
            Assert.AreEqual("2018-09-01", transaction.TransactionDateFormatted);
        }

        [TestMethod]
        public void AmountFormattingTest()
        {
            ITransaction transaction = new Transaction(new DateTime(2018, 9, 1), "CLIENT", 100);
            Assert.AreEqual("100.00", transaction.AmountFormatted);
        }

        [TestMethod]
        public void FeeAmountWithFixedTest()
        {
            StaticStorage.ClearMonthlyFeeApplication();
            decimal feeAmount = 30;
            ITransaction transaction = new Transaction(new DateTime(2018, 9, 1), "CLIENT", 100);
            Assert.AreEqual(feeAmount, transaction.FeeAmount);
        }

        [TestMethod]
        public void FeeAmountWithoutFixedTest()
        {
            StaticStorage.ClearMonthlyFeeApplication();
            decimal feeAmount = 1;

            ITransaction transaction1 = new Transaction(new DateTime(2018, 9, 1), "CLIENT", 100);
            decimal t1Fee = transaction1.FeeAmount;

            ITransaction transaction2 = new Transaction(new DateTime(2018, 9, 2), "CLIENT", 100);
            Assert.AreEqual(feeAmount, transaction2.FeeAmount);
        }

        [TestMethod]
        public void FeeAmountFormattingTest()
        {
            StaticStorage.ClearMonthlyFeeApplication();
            ITransaction transaction = new Transaction(new DateTime(2018, 9, 1), "CLIENT", 100);
            Assert.AreEqual("30.00", transaction.FeeAmountFormatted);
        }
    }
}
