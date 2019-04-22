using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fuzzy  {

    public static bool Bool(int var_A, int var_B, int var_C)
    {

        float result = Random.value;

        if (result > 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
