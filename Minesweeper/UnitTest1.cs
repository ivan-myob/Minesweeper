using System;
using Xunit;
using Xunit.Abstractions;

namespace Minesweeper
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
/*        [Fact]
        public void Return_CanAddTheory()
        {
            var Minesweeper = new Minesweeper();

            var result = Minesweeper.Add(value1);

            Assert.Equal(value2, result);
        }*/
    }
}