using MobilePayHomeworkTask.Implementation;
using MobilePayHomeworkTask.Interfaces;
using System;
using System.IO;

namespace MobilePayHomeworkTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataFile = @"C:\tmp\transactions.txt";
                FileParser fileParser = new FileParser();

                if (File.Exists(dataFile))
                {
                    string line;
                    StreamReader file = new StreamReader(dataFile);
                    while ((line = file.ReadLine()) != null)
                    {
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                ITransaction transaction = fileParser.PaymentTransaction(line.Trim());
                                Console.WriteLine(string.Format("{0} {1} {2}", transaction.TransactionDateFormatted, transaction.Client, transaction.FeeAmountFormatted));
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(string.Format("Failed to parse data line. Reason {0}", e.Message));
                            Console.WriteLine(string.Format("Data line: ", line));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected error");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
