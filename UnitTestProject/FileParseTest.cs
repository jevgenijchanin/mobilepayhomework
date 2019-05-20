using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePayHomeworkTask.Implementation;
using MobilePayHomeworkTask.Interfaces;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class FileParseTest
    {
        [TestMethod]
        public void ParsingValidTransactionLine()
        {
            FileParser fileParser = new FileParser();
            ITransaction transaction = fileParser.PaymentTransaction("2018-09-01 7-ELEVEN 100");
            if(transaction.TransactionDate != new DateTime(2018, 9, 01) || transaction.Client != "7-ELEVEN" || transaction.Amount != 100)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ParsingValidTransactionLine_MultipleSpace()
        {
            FileParser fileParser = new FileParser();
            ITransaction transaction = fileParser.PaymentTransaction("2018-09-01    7-ELEVEN   100");
            if (transaction.TransactionDate != new DateTime(2018, 9, 01) || transaction.Client != "7-ELEVEN" || transaction.Amount != 100)
            {
                Assert.Fail();
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))] // TODO: We will use our own exception to detect the origin of error
        public void ParsingValidTransactionLine_ParamsLessThan3()
        {
            FileParser fileParser = new FileParser();
            ITransaction transaction = fileParser.PaymentTransaction("2018-09-01 7-ELEVEN");            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))] // TODO: We will use our own exception to detect the origin of error
        public void ParsingValidTransactionLine_ParamsMoreThan3()
        {
            FileParser fileParser = new FileParser();
            ITransaction transaction = fileParser.PaymentTransaction("2018-09-01 7-ELEVEN 100 a");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))] // TODO: We will use our own exception to detect the origin of error
        public void ParsingValidTransactionLine_WrongDateFormat()
        {
            FileParser fileParser = new FileParser();
            ITransaction transaction = fileParser.PaymentTransaction("2018-AA-01 7-ELEVEN 100");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))] // TODO: We will use our own exception to detect the origin of error
        public void ParsingValidTransactionLine_WrongAmountFormat()
        {
            FileParser fileParser = new FileParser();
            ITransaction transaction = fileParser.PaymentTransaction("2018-09-01 7-ELEVEN 1A00");
        }

    }
}
