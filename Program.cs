using System;
using System.Collections.Generic;

namespace Ctci{

    public class Program{
        private static ArraysAndStrings arraysAndStrings;
        private static List<Action> programs;
        private static bool RunOnlyLatest { get; set; }
        
        static Program(){
            programs = new List<Action>();
            arraysAndStrings = new ArraysAndStrings();
            RunOnlyLatest = true;
        }

        public Program(){
            arraysAndStrings = new ArraysAndStrings();
        }

        // public static void Main(string[] args){
        //     AddChap1();

        //     if(RunOnlyLatest){
        //         if(programs.Count > 0)
        //             programs[0]();
        //     }
        //     else{
        //         foreach(var program in programs)
        //             program();
        //     }
        // }

        private static void AddChap1()
        {
            // 1.6
            Add(() => {
                var first = "aabcccccaaa";
                var expected = "a2b1c5a3";

                var actual = arraysAndStrings.StringCompression(first);

                AssertEqual(expected, actual);
            });

            // 1.5
            Add(() => {
                var first = "pale";
                var second = "ple";
                var expected = true;

                var actual = arraysAndStrings.OneAway(first, second);

                AssertEqual(expected, actual);
            });

            // 1.4
            Add(() => {
                var first = "Tact Coa";
                var expected = true;

                var actual = arraysAndStrings.PalindromePermutation(first);

                AssertEqual(expected, actual);
            });

            // 1.3
            Add(() => {
                var first = "Mr John Smith    ".ToCharArray();
                var second = 13;
                var expected = true;

                arraysAndStrings.URLify(first, second);
                string actual = string.Join(string.Empty, first);

                AssertEqual(expected, actual);
            });

            // 1.2
            Add(() => {
                var first = "abc";
                var second = "bca";
                var expected = true;

                var actual = arraysAndStrings.CheckPermutation(first, second);

                AssertEqual(expected, actual);
            });

            // 1.1
            Add(() => {
                var text1 = "abcd";
                var text2 = "Ragnar";

                AssertEqual(true, arraysAndStrings.IsUnique(text1));
                AssertEqual(false, arraysAndStrings.IsUnique(text2));
            });
        }

        // 1.2
        public void CheckPermutationTheory(string first, string second, bool expected){
            var actual = arraysAndStrings.CheckPermutation(first, second);

            AssertEqual(expected, actual);
        }

        // 1.3
        public void URLifyTest(string sentence, int length, string expected){
            char[] input = sentence.ToCharArray();
            arraysAndStrings.URLify(input, length);

            string actual = String.Join("", input);
            
            AssertEqual(expected, actual);
        }

        // 1.4
        public void PalindromePermutationTest(string permutation, bool expected){
            bool actual = arraysAndStrings.PalindromePermutation(permutation);

            AssertEqual(expected, actual);
        }

        // 1.5
        public void OneAwayTest(string first, string second, bool expected){
            bool actual = arraysAndStrings.OneAway(first, second);

            AssertEqual(expected, actual);
        }

        // 1.6
        public void StringCompressionTest(string input, string expected){
            string actual = arraysAndStrings.StringCompression(input);

            AssertEqual(expected, actual);
        }

        private static void Add(Action action){
            programs.Add(action);
        }

        private static bool AssertEqual(object expected, object actual)
        {
            if(!expected.Equals(actual))
                throw new Exception($"Assertion failed");
            
            Console.WriteLine("Test ran successfully");

            return true;
        }
    }
}