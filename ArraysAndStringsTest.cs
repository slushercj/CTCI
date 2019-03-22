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
        public void IsUniqueTheory(string test, bool expected)
        {
            var actual = arraysAndStrings.IsUnique(test);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abc", "bca", true)]
        [InlineData("racecar", "aaccerr", true)]
        [InlineData("Game of Thrones", "Vikings", false)]
        public void CheckPermutationTheory(string first, string second, bool expected){
            var actual = arraysAndStrings.CheckPermutation(first, second);

            Assert.Equal(expected, actual);
        }
    }
}

