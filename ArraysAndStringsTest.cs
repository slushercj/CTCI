using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Ctci
{
    public class TestDataGenerator : IEnumerable<object[,]>
    {
        private readonly List<object[,]> _data = new List<object[,]>
            {
                new object[,] {
                    {5, 1, 3},
                    {5, 1, 3},
                    {5, 1, 3}
                }
            };

        public IEnumerator<object[,]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ArraysAndStringsTest
    {
        ArraysAndStrings arraysAndStrings;
        public static IEnumerable<object[]> ZeroMatrixData => new List<object[]> {
            new object[] {  // Each object is a matrix to be tested
                new int[,]  // one instance of a matrix
                {
                    {1, 2, 3},
                    {0, 5, 6},
                    {7, 8, 0},
                    {11, 12, 13}
                },
                new int[,]
                {
                    {0, 2, 0},
                    {0, 0, 0},
                    {0, 0, 0},
                    {0, 12, 0}
                }
            }
        };
        public static IEnumerable<object[]> RotateMatrixData => new List<object[]> {
            new object[] {  // Each object is a matrix to be tested
                new int[,]  // one instance of a matrix
                {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                },
                new int[,]
                {
                    {7, 4, 1},
                    {8, 5, 2},
                    {9, 6, 3}
                }
            }
        };

        public ArraysAndStringsTest()
        {
            arraysAndStrings = new ArraysAndStrings();
        }

        // 1.9
        [Theory(Timeout = 50)]
        [InlineData("waterbottle", "erbottlewat", true)]
        [InlineData("black", "mirror", false)]
        public void StringRotationTest(string first, string second, bool expected)
        {
            var actual = arraysAndStrings.StringRotation(first, second);

            Assert.Equal(expected, actual);
        }

        // 1.8
        [Theory(Timeout = 50)]
        [MemberData(nameof(ZeroMatrixData))]
        public void ZeroMatrixTest(int[,] matrix, int[,] expected)
        {
            var actual = arraysAndStrings.ZeroMatrix(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Assert.True(actual[i,j] == expected[i,j]);
        }

        // 1.7
        [Theory(Timeout = 50)]
        [MemberData(nameof(ZeroMatrixData))]
        public void RotateMatrix(int[,] matrix, int[,] expected)
        {
            var actual = arraysAndStrings.RotateMatrix(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // TODO
                    //Assert.True(actual[i,j] == expected[i,j]);
                }
            }
        }

        // 1.6
        [Theory(Timeout = 50)]
        [InlineData("aabcccccaaa", "a2b1c5a3")]
        [InlineData("care", "care")]
        public void StringCompressionTest(string input, string expected)
        {
            string actual = arraysAndStrings.StringCompression(input);

            Assert.Equal(expected, actual);
        }

        // 1.5
        [Theory(Timeout = 50)]
        [InlineData("pale", "ple", true)]
        [InlineData("pales", "pale", true)]
        [InlineData("pale", "bale", true)]
        [InlineData("pale", "bake", false)]
        public void OneAwayTest(string first, string second, bool expected)
        {
            bool actual = arraysAndStrings.OneAway(first, second);

            Assert.Equal(expected, actual);
        }

        // 1.4
        [Theory(Timeout = 50)]
        [InlineData("Tact Coa", true)]
        [InlineData("racecar", true)]
        [InlineData("Targaryan", false)]
        public void PalindromePermutationTest(string permutation, bool expected)
        {
            bool actual = arraysAndStrings.PalindromePermutation(permutation);

            Assert.Equal(expected, actual);
        }

        // 1.3
        [Theory(Timeout = 50)]
        [InlineData("Mr John Smith    ", 13, "Mr%20John%20Smith")]
        public void URLifyTest(string sentence, int length, string expected)
        {
            char[] input = sentence.ToCharArray();
            arraysAndStrings.URLify(input, length);

            string actual = String.Join("", input);

            Assert.Equal(expected, actual);
        }

        // 1.2
        [Theory(Timeout = 50)]
        [InlineData("abc", "bca", true)]
        [InlineData("racecar", "aaccerr", true)]
        [InlineData("Game of Thrones", "Vikings", false)]
        public void CheckPermutationTheory(string first, string second, bool expected)
        {
            var actual = arraysAndStrings.CheckPermutation(first, second);

            Assert.Equal(expected, actual);
        }

        // 1.1
        [Theory(Timeout = 50)]
        [InlineData("abcd", true)]
        [InlineData("Ragnar", false)]
        public void IsUniqueTheory(string test, bool expected)
        {
            var actual = arraysAndStrings.IsUnique(test);

            Assert.Equal(expected, actual);
        }
    }

}

