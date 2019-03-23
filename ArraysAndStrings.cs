using System;

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
        int spaces = countSpaces(input, length);

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

    private int countSpaces(char[] input, int length)
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
}