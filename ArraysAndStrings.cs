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
}