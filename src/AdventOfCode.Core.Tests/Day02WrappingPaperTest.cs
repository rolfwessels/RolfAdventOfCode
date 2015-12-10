using AdventOfCode.Core.Tests.Samples;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Core.Tests
{
    [TestFixture]
    public class Day2WrappingPaperTests
    {

        private Day02WrappingPaper _day02WrappingPaper;

        #region Setup/Teardown

        public void Setup()
        {
            _day02WrappingPaper = new Day02WrappingPaper();
        }

        #endregion

        [Test]
        public void Constructor_WhenCalled_ShouldNotBeNull()
        {
            // arrange
            Setup();
            // assert
            _day02WrappingPaper.Should().NotBeNull();
        }

        [Test]
        public void Calculate_GivenSampleOne_ShouldCalculateTotal()
        {
            // arrange
            Setup();
            // action
            var calculate = _day02WrappingPaper.Calculate("2x3x4");
            // assert
            calculate.Should().Be(58);

        }

        [Test]
        public void Calculate_GivenSampleTwo_ShouldCalculateTotal()
        {
            // arrange
            Setup();
            // action
            var calculate = _day02WrappingPaper.Calculate("1x1x10");
            // assert
            calculate.Should().Be(43);

        }

        [Test]
        public void Calculate_GivenMultpleLines_ShouldCalculateTotal()
        {
            // arrange
            Setup();
            // action
            var calculate = _day02WrappingPaper.Calculate("2x3x4\n1x1x10");
            // assert
            calculate.Should().Be(58 + 43);

        }

        [Test]
        public void Calculate_GivenBigSample_ShouldCalculateTotal()
        {
            // arrange
            Setup();
            var readResource = EmbededResourceHelper.ReadResource("AdventOfCode.Core.Tests.Samples.Day2Input.txt",
                GetType().Assembly);
            // action
            var calculate = _day02WrappingPaper.Calculate(readResource);
            // assert
            calculate.Should().Be(1598415);

        }

    } 

    
}