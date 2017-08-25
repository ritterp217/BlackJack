using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class RandomNumber
    {
        private static readonly System.Security.Cryptography.RNGCryptoServiceProvider _seed = new System.Security.Cryptography.RNGCryptoServiceProvider();
        public static int NumberBetween(int minimum, int maximum)
        {
            byte[] randomNumber = new byte[1];

            _seed.GetBytes(randomNumber);

            double asciiValue = Convert.ToDouble(randomNumber[0]);

            double multiplier = Math.Max(0, (asciiValue / 255d) - 0.00000000001d);

            // adding one to the range, to allow for rounding 
            int range = maximum - minimum + 1;

            double randomValue = Math.Floor(multiplier * range); // rounds to ensure within range

            return (int)(minimum + randomValue); // adds minvalue to randomvalue(0 to max)
        }

    } // END RandomNumber
}