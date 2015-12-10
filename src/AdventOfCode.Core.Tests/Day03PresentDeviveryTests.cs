using AdventOfCode.Core.Tests.Samples;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Core.Tests
{
    [TestFixture]
    public class Day03PresentDeviveryTests
    {

        private Day03PresentDevivery _day03PresentDevivery;

        #region Setup/Teardown

        public void Setup()
        {
            _day03PresentDevivery = new Day03PresentDevivery();
        }

        #endregion


        [Test]
        public void Calculate_GivenNoSteps_ShouldBe1()
        {
            // arrange
            Setup();
            // action
            var calculate = _day03PresentDevivery.Calculate("");
            // assert
            calculate.Should().Be(1);

        }

        [Test]
        public void Calculate_GivenSampleOne_ShouldDeliverTo2Houses()
        {
            // arrange
            Setup();
            // action
            var calculate = _day03PresentDevivery.Calculate(">");
            // assert
            calculate.Should().Be(2);

        }

       

        [Test]
        public void Calculate_GivenBoxedDeliver_ShouldDeliverTo4Houses()
        {
            // arrange
            Setup();
            // action
            var calculate = _day03PresentDevivery.Calculate("^>v<");
            // assert
            calculate.Should().Be(4);

        }


        [Test]
        public void Calculate_GivenRepeatingMovement_ShouldDeliverTo2Houses()
        {
            // arrange
            Setup();
            // action
            var calculate = _day03PresentDevivery.Calculate("^v^v^v^v^v");
            // assert
            calculate.Should().Be(2);

        }

        [Test]
        public void Calculate_GivenBigSample_ShouldCalculateTotal()
        {
            // arrange
            Setup();
            var readResource = EmbededResourceHelper.ReadResource("AdventOfCode.Core.Tests.Samples.Day3Input.txt",
                GetType().Assembly);
            // action
            var calculate = _day03PresentDevivery.Calculate(readResource);
            // assert
            calculate.Should().Be(2592);

        }

    }
}