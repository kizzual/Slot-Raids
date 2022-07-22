using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConvertText 
{
    private static string[] names = new[]
    {
        "",
        "K",
        "M",
        "B"
    };

    public static string FormatNumb(decimal num)
    {
        if (num == 0) return "0";
           num = decimal.Round(num);

        int i = 0;
        while (i + 1 < names.Length && num >= 1000m)
        {
            num /= 1000;
            i++;
        }


    //    return string.Format("{0}{1}", num, names[i]);
          return num.ToString(format: "#.##") + names[i];
    }


}

