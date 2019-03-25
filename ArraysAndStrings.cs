using System;
using System.Collections.Generic;
using System.Text;

public class ArraysAndStrings
{
    internal bool IsUnique(string sentence)
    {
        for(var i = 0; i < sentence.Length - 1; i++){
            for(var j = i + 1; j < sentence.Length; j++){
                if(sentence[i] == sentence[j]){
                    return false;
                }
            }
        }

        return true;
    }

    internal bool CheckPermutation(string first, string second)
    {
        var freq = new int[26];

        foreach(var c in first){
            if(!char.IsLetter(c))
                continue;

            freq[char.ToLower(c) - 'a']++;
        }

        foreach(var c in second){
            if(!char.IsLetter(c))
                continue;

            int index = char.ToLower(c) - 'a';
            freq[index]--;

            if(freq[index] < 0)
                return false;
        }

        foreach(var f in freq){
            if(f != 0)
                return false;
        }

        return true;
    }

    internal void URLify(char[] input, int length)
    {
        int spaces = CountSpaces(input, length);

        for(var i = length - 1; i >= 0; i--){
            char current = input[i];

            if(current == ' '){
                spaces--;
                input[i + 2 * spaces] = '%';
                input[i + 2 * spaces + 1] = '2';
                input[i + 2 * spaces + 2] = '0';
            }
            else{
                input[i + 2 * spaces] = input[i];
            }
        }
    }

    internal int[,] RotateMatrix(int[,] matrix)
    {
        /*

        {1, 2, 3},      {7, 4, 1},
        {4, 5, 6},      {8, 5, 2},
        {7, 8, 9}       {9, 6, 3}

        */
        // TODO
        return null;
    }

    private int CountSpaces(char[] input, int length)
    {
        int spaces = 0;
        for(int i = 0; i < length; i++){
            if(input[i] == ' ')
                spaces++;
        }

        return spaces;
    }

    internal bool PalindromePermutation(string permutation)
    {
        int[] freqCount = new int[26];

        for(int i = 0; i < permutation.Length; i++){

            if(!char.IsLetter(permutation[i]))
                continue;

            freqCount[char.ToLower(permutation[i]) - 'a']++;
        }

        int numOdds = 0;
        for(int i = 0; i < freqCount.Length; i++){
            if(freqCount[i] % 2 != 0)
                numOdds++;

            if(numOdds > 1)
                return false;
        }

        return true;
    }

    internal object StringRotation(string first, string second)
    {
        return (second + second).Contains(first);
    }

    internal int[,] ZeroMatrix(int[,] matrix)
    {
        var zeroedColumns = new HashSet<int>();
        var zeroedRows = new HashSet<int>();

        for(var i = 0; i < matrix.GetLength(0); i++)
            for(var j = 0; j < matrix.GetLength(1); j++)
            {
                if(matrix[i,j] == 0){
                    zeroedRows.Add(i);
                    zeroedColumns.Add(j);
                }
            }
        
        for(var i = 0; i < matrix.GetLength(0); i++)
            for(var j = 0; j < matrix.GetLength(1); j++)
                if(zeroedRows.Contains(i) || zeroedColumns.Contains(j))
                    matrix[i,j] = 0;

        return matrix;
    }

    internal bool OneAway(string first, string second)
    {
        if(first == second)
            return true;
        
        return first.Length == second.Length ? IsOneReplacementAway(first, second) : IsOneInsertionAway(first, second);
    }

    internal string StringCompression(string input)
    {
        var compressedString = new StringBuilder();

        var i = 0;
        while(i < input.Length){
            var currentChar = input[i];

            int count;
            for(count = 0; i + count < input.Length && input[i + count] == currentChar; count++);
            compressedString.Append($"{currentChar}{count}");

            i = i + count;
        }

        if(compressedString.Length >= input.Length)
            return input;
        
        return compressedString.ToString();
    }

    private bool IsOneInsertionAway(string first, string second)
    {
        if(first.Length > second.Length)
        {
            string temp = first;
            first = second;
            second = temp;
        }

        for(int i = 0; i < first.Length; i++){
            if(first[i] != second[i])
            {
                string newFirst = first.Insert(i, second[i].ToString());

                if(newFirst != second){
                    return false;
                }
                else{
                    return true;
                }
            }
        }

        return true;
    }

    private bool IsOneReplacementAway(string first, string second)
    {
        for(int i = 0; i < first.Length; i++)
        {
            if(first[i] != second[i])
            {
                if(first.Remove(i, 1) == second.Remove(i, 1))
                    return true;
                else
                    return false;
            }
        }

        return true;
    }
}