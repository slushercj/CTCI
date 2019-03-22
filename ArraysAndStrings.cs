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
}