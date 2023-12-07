using Newtonsoft.Json.Linq;

namespace ConversionAPI.Services
{
    public class ConvertNumService : IConvertNumService
    {
        public string ConvertNum(double amount)
        {

            decimal money = Math.Round((decimal)amount, 2);
            int number = (int)money;
            int decimalValue = 0;
            string doller = string.Empty;
            string cents = string.Empty;
            doller = ConvertToWords(number);
            if (money.ToString().Contains("."))
            {
                decimalValue = int.Parse(money.ToString().Split('.')[1]);
                cents = ConvertToWords(decimalValue);
            }
            string result = !string.IsNullOrEmpty(cents) ? (decimalValue == 1 ? string.Format("{0} dollar and {1} cent Only.", doller, cents) : string.Format("{0} dollars and {1} cents only.", doller, cents)) : 
                            (money == 1 ? string.Format("{0} dollar only.", doller) : string.Format("{0} dollars only.", doller));
            return result;
        }

        public static string ConvertToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ConvertToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += ConvertToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                var twenties = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tens = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += twenties[number];
                else
                {
                    words += tens[(number) / 10];
                    if ((number % 10) > 0)
                        words += " " + twenties[(number) % 10];
                }
            }
            return words;
        }
    }
}
