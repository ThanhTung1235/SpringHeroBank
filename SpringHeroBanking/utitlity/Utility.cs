using System;
using System.Runtime.InteropServices;

namespace SpringHeroBanking.Unity
{
    public class Utility
    {
        public int getNumber()
        {
            var number = 0;
            while (true)
            {
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Pleas enter number:");
                }
            }

            return number;
        }

        public decimal getDecimal()
        {
            decimal number = 0;
            while (true)
            {
                try
                {
                    number = Decimal.Parse(Console.ReadLine());
                    if (number < 0)
                    {
                        throw new Exception("Please enter a larger value");
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Pleas enter number:");
                }
            }

            return number;
        }
    }
}