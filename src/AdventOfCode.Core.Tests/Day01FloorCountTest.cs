using AdventOfCode.Core.Tests.Samples;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Core.Tests
{
    [TestFixture]
    public class Day01FloorCountTest
    {
        private Day01FloorCount _day01FloorCount;

        #region Setup/Teardown

	    public void Setup()
	    {
	        _day01FloorCount = new Day01FloorCount();
	    }

        [TearDown]
	    public void TearDown()
	    {

	    }

	    #endregion

	    [Test]
        public void CalculateFloor_GivenEmptyString_ResultIn0()
	    {
		    // arrange
		    Setup();
		    // action
	        var floor = _day01FloorCount.CalculateFloor("");
	        // assert
	        floor.Should().Be(0);
	    }


        [Test]
        public void CalculateFloor_GivenOneMoveUp_ResultIn1()
        {
            // arrange
            Setup();
            // action
            var floor = _day01FloorCount.CalculateFloor("(");
            // assert
            floor.Should().Be(1);
        }

        [Test]
        public void CalculateFloor_GivenOneMoveDown_ResultInNegative1()
        {
            // arrange
            Setup();
            // action
            var floor = _day01FloorCount.CalculateFloor(")");
            // assert
            floor.Should().Be(-1);
        }

        [Test]
        public void CalculateFloor_GivenExampleOne_ResultIn0()
        {
            // arrange
            Setup();
            // action
            var floor = _day01FloorCount.CalculateFloor("(())()()");
            // assert
            floor.Should().Be(0);
        }
 
        
        [Test]
        public void CalculateFloor_GivenExampleTwo_ResultIn0()
        {
            // arrange
            Setup();
            // action
            var floor = _day01FloorCount.CalculateFloor("(()(()(");
            // assert
            floor.Should().Be(3);
        }

        [Test]
        public void CalculateFloor_GivenFullInputFile_ShouldResultInFile()
        {
            // arrange
            Setup();
            // action
            var calculateFloor = _day01FloorCount.CalculateFloor(
                EmbededResourceHelper.ReadResource("AdventOfCode.Core.Tests.Samples.Day1Input.txt",
                    GetType().Assembly));
            // assert
            calculateFloor.Should().Be(232);
        }



    }
}