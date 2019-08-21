using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Y to execute sample test cases");
            Console.WriteLine("Press anything else to continue with your own number");

            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && !input.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Okey, please enter the number that you want to convert into words..");
                string inputNumber = Console.ReadLine();

                NumToWordConverter objConverter = new NumToWordConverter();
                Console.WriteLine(objConverter.ConvertNumber(inputNumber));
            }
            else
                RunSampleTests();

            Console.WriteLine("====================================================================================================");
            Console.WriteLine("Press any key to exit....");
            Console.ReadLine();
        }

        private static void RunSampleTests()
        {
            NumToWordConverter objConverter;
            {
                objConverter = new NumToWordConverter();
                string result = string.Empty;
                string strInputNumber = string.Empty;

                Console.WriteLine("================================= Here is sample test cases result =================================");
                Console.WriteLine();

                Console.WriteLine(string.Format("Input : {0}             Output : {1}", strInputNumber, objConverter.ConvertNumber(string.Empty)));
                Console.WriteLine(string.Format("Input : {0}             Output : {1}", null, objConverter.ConvertNumber(null)));
                strInputNumber = "000";
                Console.WriteLine(string.Format("Input : {0}          Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "-123";
                Console.WriteLine(string.Format("Input : {0}         Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "0";
                Console.WriteLine(string.Format("Input : {0}            Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "10";
                Console.WriteLine(string.Format("Input : {0}           Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "14";
                Console.WriteLine(string.Format("Input : {0}           Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "143";
                Console.WriteLine(string.Format("Input : {0}          Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "200";
                Console.WriteLine(string.Format("Input : {0}          Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "2000";
                Console.WriteLine(string.Format("Input : {0}         Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "23456";
                Console.WriteLine(string.Format("Input : {0}        Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "50000";
                Console.WriteLine(string.Format("Input : {0}        Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "123456";
                Console.WriteLine(string.Format("Input : {0}       Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "200000";
                Console.WriteLine(string.Format("Input : {0}       Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "1234567";
                Console.WriteLine(string.Format("Input : {0}      Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));
                strInputNumber = "2000000";
                Console.WriteLine(string.Format("Input : {0}      Output : {1}", strInputNumber, objConverter.ConvertNumber(strInputNumber)));

            }
        }
    }
}
