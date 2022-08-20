using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PersonNumber
{
    public class ControlPersonNumber
    {
        private int[] numbers = new int[10];
        private int[] evenNumbers = new int[5];
        int sumOfOddNumbers, sumOfEvenNumbers = 0;

        /// <summary>
        /// Method that sums all numbers together
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int GetSumOfDigits(int digit) => digit.ToString().Select(x => int.Parse(x.ToString())).ToArray().Sum();
        
        /// <summary>
        /// Method that calculates the numbers and returns true if the total sum is modulus 10, otherwise returns false
        /// </summary>
        /// <param name="pnr"></param>
        /// <returns></returns>
        int Calculate(string pnr)
        {  
            for(int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    numbers[i] = ((int)char.GetNumericValue(pnr[i])) * 2;
                    if (numbers[i] > 9)
                        evenNumbers[i / 2] = GetSumOfDigits(numbers[i]);
                    else
                        evenNumbers[i / 2] = numbers[i];
                    sumOfEvenNumbers += evenNumbers[i / 2];
                }
                else
                {
                    numbers[i] = ((int)char.GetNumericValue(pnr[i]));
                    sumOfOddNumbers += numbers[i];
                }
            }

            return ((sumOfEvenNumbers + sumOfOddNumbers) % 10);

        }
        /// <summary>
        /// Method that determines the gender based on odd or even number
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        string GetGender(char c) => (((int)char.GetNumericValue(c)) % 2) == 1 ? "Man" : "Kvinna";

        /// <summary>
        /// Methods that checks the person number and returns the gender and true if it is a correct number, otherwise false
        /// </summary>
        /// <param name="personNumber"></param>
        /// <returns></returns>
        public Tuple<bool, string> CheckPersonNummer(string personNumber)
        {
            string pnr = Regex.Replace(personNumber, "[^0-9]+", ""); // clear everthing that is not numbers
            if (pnr.Length == 12)
                pnr = pnr.Substring(2);
            if (pnr.Length == 10) 
            {
                if(Calculate(pnr) == 0)
                    return new Tuple<bool, string>(true, GetGender(pnr[8]));
            }

            return new Tuple<bool, string>(false, String.Empty);
        }
       
    }
}
