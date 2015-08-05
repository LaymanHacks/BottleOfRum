using System;

namespace BottleOfRum.Business
{
    public class TreasureCalculatorCheat : ITreasureCalculator
    {
        /// <summary>
        ///This is called a cheat because it is based  
        ///on the formula found at the following URI: 
        ///http://mathworld.wolfram.com/MonkeyandCoconutProblem.html
        /// N=kn^(n+1)-m(n-1)
        /// </summary> 
        /// <param name="numberOfPirates"></param>
        /// <returns></returns>
        public decimal GetTreasureCount(int numberOfPirates)
        {
            if (numberOfPirates <= 1) throw new ArgumentOutOfRangeException("numberOfPirates", "Please provide a pirate count greater than 1.");
            if (numberOfPirates >= 21) throw new ArgumentOutOfRangeException("numberOfPirates", "Please provide a pirate count less than 21.");

            var remainingCoins = 1*(
                Convert.ToDecimal(Math.Pow(numberOfPirates, (numberOfPirates + 1))) -
                1*(numberOfPirates - 1));
            return remainingCoins;
        }
    }
}