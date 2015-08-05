using System;
using NUnit.Framework;

namespace BottleOfRum.Business.Tests
{
    [TestFixture()]
    public class TreasureCalculatorCheatTests
    {
        [Test]
        public void GetTreasureCount_Should_Equal_15621_When_Provided_5()
        {
            var tCalculator = new TreasureCalculatorCheat();
            var treasureCount = tCalculator.GetTreasureCount(5);
            Assert.AreEqual(15621, treasureCount);
        }

        [Test]
        public void GetTreasureCount_Should_Equal_79_When_Provided_3()
        {
            var tCalculator = new TreasureCalculatorCheat();
            var treasureCount = tCalculator.GetTreasureCount(3);
            Assert.AreEqual(79, treasureCount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetTreasureCount_Should_Throw_Exeption_Provided_Greater_Than_20()
        {
            var tCalculator = new TreasureCalculatorCheat();
            var treasureCount = tCalculator.GetTreasureCount(21);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetTreasureCount_Should_Throw_Exeption_Provided_Less_Than_2()
        {
            var tCalculator = new TreasureCalculatorCheat();
            var treasureCount = tCalculator.GetTreasureCount(1);
        }
    }
}
