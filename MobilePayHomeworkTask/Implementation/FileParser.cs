using MobilePayHomeworkTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MobilePayHomeworkTask.Implementation
{
    public class FileParser : IFileParser
    {
        public ITransaction PaymentTransaction(string dataLine)
        {

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            string preparedDataLine = regex.Replace(dataLine, " ");

            string[] dataItems = preparedDataLine.Split(new char[] { ' ' }); // lets decide space is a split char and client names do not contains spaces

            if(dataItems.Length == 3)
            {
                bool parseResult = false;
                DateTime transactionDate;
                string client;
                decimal amount;

                #region Parsing date

                parseResult = DateTime.TryParse(dataItems[0], out transactionDate);

                if(!parseResult)
                    throw new Exception("Wrong data line"); // TODO: We will implement our exceptions in the future :)

                #endregion

                #region Client parsing

                client = dataItems[1];

                #endregion

                #region Amount parsing

                parseResult = decimal.TryParse(dataItems[2], out amount);

                if (!parseResult)
                    throw new Exception("Wrong data line"); // TODO: We will implement our exceptions in the future :)

                #endregion

                return new Transaction(transactionDate, client, amount);
            }
            else
            {
                throw new Exception("Wrong data line"); // TODO: We will implement our exceptions in the future :)
            }
        }
    }
}
