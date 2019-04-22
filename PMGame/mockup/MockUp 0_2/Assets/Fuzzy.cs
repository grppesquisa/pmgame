using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuzzy {

    public static string ResolveFuzzy (int var_A, int var_B, int var_C)
    {

        int r = Random.Range(-10, 10);
        if (r > 0)
        {
            return "True";
        }
        else
        {
            return "False";
        }
    }

}
