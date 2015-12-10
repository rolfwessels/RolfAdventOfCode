using AdventOfCode.Core.Tests.Samples;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Core.Tests
{
    [TestFixture]
    public class Day04StockingStufferTests
    {

        private Day04StockingStuffer _day04StockingStuffer;

        #region Setup/Teardown

        public void Setup()
        {
            _day04StockingStuffer = new Day04StockingStuffer();
        }

        #endregion


        [Test]
        public void Calculate_GivenValueShouldBeMd_ShouldBe1()
        {
            // arrange
            Setup();
            // action
            var calculate = _day04StockingStuffer.GetHash("pqrstuv1048970");
            // assert
            calculate.Should().StartWith("000006136EF");

        }

        [Test]
        [Explicit]
        public void Calculate_GivenNoSteps_ShouldBe1()
        {
            // arrange
            Setup();
            // action
            var calculate = _day04StockingStuffer.Calculate("abcdef", "00000");
            // assert
            calculate.Should().Be(609043);

        }

        [Test]
        [Explicit]
        public void Calculate_Givenpqrstuv_ShouldBe1()
        {
            // arrange
            Setup();
            // action
            var calculate = _day04StockingStuffer.Calculate("pqrstuv", "00000");
            // assert
            calculate.Should().Be(1048970);

        }

      
        [Test]
        [Explicit]
        public void Calculate_GivenBigSample_ShouldCalculateTotal()
        {
            // arrange
            Setup();
            
            // action
            var calculate = _day04StockingStuffer.Calculate("iwrupvqb", "00000");
            // assert
            calculate.Should().Be(346386);

        }
        
        [Test]
        [Explicit]
        public void Calculate_GivenBigSample_ShouldWithSixZeros()
        {
            // arrange
            Setup();
            
            // action
            var calculate = _day04StockingStuffer.Calculate("iwrupvqb", "000000");
            // assert
            calculate.Should().Be(346386);

        }

    }
}