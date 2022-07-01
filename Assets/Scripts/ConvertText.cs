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
        /*   var tmp = 5252/1000;
           Debug.Log(String.Format("{0:0.00K}", tmp));
           double i = 0;
           if (num < 1000)
           {
               return num.ToString();
           }
           if (num >= 1000 && num <= 1000000)
           {
               i = (double)(num / 1000);
               return string.Format( " {0:0.00K}", i); ;

           }
           if (num >= 1000000 && num <= 1000000000)
           {
               i = (double)(num / 1000000);
               return string.Format( " {0:0.00M}", i); ;
           }
           if (num >= 1000000000)
           {
               i = (double)(num / 1000000000);
               return string.Format( " {0:0.00B}", i); ;
           }
           return num.ToString();*/
    }


    /* public static string Convert(decimal value)
     {
         if(value < 1000)
         {
             return value.ToString();
         }
         if(value >= 1000 &&  value < 10000)
         {
             return (value / 1000).ToString() + "." + 
         }

     }*/
}

