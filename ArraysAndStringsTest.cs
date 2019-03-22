using System;
using Xunit;

namespace Ctci
{
    public class ArraysAndStringsTest
    {
        ArraysAndStrings arraysAndStrings;

        public ArraysAndStringsTest(){
            arraysAndStrings = new ArraysAndStrings();
        }

        [Theory]
        [InlineData("abcd", true)]
        [InlineData("Ragnar", false)]
        public void Test1(string test, bool expected)
        {
            var actual = arraysAndStrings.IsUnique(test);

            Assert.Equal(actual, expected);
        }
    }
}

