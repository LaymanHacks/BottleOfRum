using System;

namespace BottleOfRum.Business
{
    public class TreasureCalculator : ITreasureCalculator
    {
        public decimal GetTreasureCount(int numberOfPirates)
        {
            if (numberOfPirates <= 1) throw new ArgumentOutOfRangeException("numberOfPirates", "Please provide a pirate count greater than 1.");
            if (numberOfPirates >= 21) throw new ArgumentOutOfRangeException("numberOfPirates", "Please provide a pirate count less than 21.");

            decimal candidateNumber = 1;
            decimal startingTreasureCount = 0;

            var resolved = false;
            while (!resolved)
            {
                candidateNumber = GetBaseCandidate(numberOfPirates, candidateNumber);
                startingTreasureCount = CheckCandidateNumber(candidateNumber, numberOfPirates);
                resolved = startingTreasureCount != 0;
            }
            return startingTreasureCount;
        }

        private decimal CheckCandidateNumber(decimal candidateNumber, int numberOfPirates)
        {
            for (var i = 1; i < numberOfPirates + 1; i++)
            {
                candidateNumber = ((candidateNumber/(numberOfPirates - 1))*numberOfPirates) + 1;
                if (candidateNumber%numberOfPirates != 1 && candidateNumber%(numberOfPirates - 1) != 0) return 0;
            }
            return candidateNumber;
        }

        private decimal GetBaseCandidate(int numberOfPirates, decimal startingIndex, int length = 10)
        {
            var upperRange = startingIndex + length;
            for (var i = startingIndex; i < upperRange; i++)
            {
                var tempCandidate = ((numberOfPirates - 1)*i);
                if (tempCandidate%numberOfPirates == 1 && tempCandidate%(numberOfPirates - 1) == 0)
                {
                    return tempCandidate;
                }
            }
            return GetBaseCandidate(numberOfPirates, startingIndex + length, length);
        }
    }
}