using System;

namespace NumberToWordProcessor
{
    internal class NumToWordConverter
    {
        readonly string[] arrOneToNine = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        readonly string[] arrTenToTwenty = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                                                         "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty" };
        readonly string[] arrThirtyToNinety = new string[] { "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        readonly string strInvalidNumber = "Please enter valid number and try again....";

        public string ConvertNumber(string inputNum)
        {
            string resultVal;
            try
            {
                //First cehck if input is numeric (not alpha numeric)
                if (long.TryParse(inputNum, out long result))
                {
                    if (inputNum == "0")
                        return "Zero only";

                    //Number is not Zero, it may start with Minus or may not, so check the condition and take decision
                    if (inputNum.StartsWith("-"))
                        resultVal = String.Format("Minus {0}", StartConversion(inputNum.Substring(1, inputNum.Length - 1)));
                    else
                        resultVal = StartConversion(inputNum);
                }
                else
                    return strInvalidNumber;
            }
            catch
            {
                //Handle the exception, log it in appropriate location
                return "Something went wrong, please try again!";
            }
            return string.IsNullOrEmpty(resultVal) ? strInvalidNumber : string.Concat(resultVal, " Only");
        }
        private String StartConversion(String inputNumber)
        {
            bool isCompleted = false;
            string resultStr = string.Empty;
            double number = (Convert.ToDouble(inputNumber));

            if (number > 0)
            {
                int currentPosition = 0;
                int numDigits = inputNumber.Length;
                String currentPlace = string.Empty;
                switch (numDigits)
                {
                    case 1:
                        resultStr = ConvertOnes(inputNumber);
                        isCompleted = true;
                        break;
                    case 2:
                        resultStr = ConvertTens(inputNumber);
                        isCompleted = true;
                        break;
                    case 3:
                        currentPosition = (numDigits % 3) + 1;
                        currentPlace = " Hundred ";
                        break;
                    case 4:
                    case 5:
                        currentPosition = (numDigits % 4) + 1;
                        currentPlace = " Thousand ";
                        break;
                    case 6:
                        currentPosition = (numDigits % 6) + 1;
                        currentPlace = " Lac ";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        currentPosition = (numDigits % 7) + 1;
                        currentPlace = " Million ";
                        break;
                    case 10:
                    case 11:
                    case 12:
                        currentPosition = (numDigits % 10) + 1;
                        currentPlace = " Billion ";
                        break;
                    default:
                        isCompleted = true;
                        break;
                }
                if (!isCompleted)
                {
                    if (inputNumber.Substring(0, currentPosition) != "0" && inputNumber.Substring(currentPosition) != "0")
                        resultStr = StartConversion(inputNumber.Substring(0, currentPosition)) + currentPlace + StartConversion(inputNumber.Substring(currentPosition));
                    else
                        resultStr = StartConversion(inputNumber.Substring(0, currentPosition)) + StartConversion(inputNumber.Substring(currentPosition));
                }

                if (resultStr.Trim().Equals(currentPlace.Trim()))
                    resultStr = string.Empty;
            }
            return resultStr.Trim();
        }
        private String ConvertTens(String inputNumber)
        {
            Int64 number = Convert.ToInt64(inputNumber);

            if (number >= 10 && number <= 20)
                return arrTenToTwenty[number - 10];
            else if (number >= 30 && number <= 90 && number % 10 == 0)
                return arrThirtyToNinety[(number / 10) - 3];
            else if (number > 0)
                return string.Concat(ConvertTens(inputNumber.Substring(0, 1) + "0"), " ", ConvertOnes(inputNumber.Substring(1)));

            return string.Empty;
        }
        private String ConvertOnes(String inputNumber)
        {
            return arrOneToNine[Convert.ToInt64(inputNumber) - 1];
        }
    }
}