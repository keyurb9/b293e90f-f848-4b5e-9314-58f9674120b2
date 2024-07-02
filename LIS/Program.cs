using System.Collections.Generic;
using System.Diagnostics;

namespace LIS;

public class Program
{
    public static string findLIS(string vals)
    {
        int[] intArr = Array.ConvertAll(vals.Split(' '), int.Parse);

        List<int> subSeq = new List<int>();
        List<int> tempSubSeq = new List<int>();

        int arrLen = intArr.Length;

        for (int i = 0; i < arrLen; i++)
        {
            bool isFirst = i == 0;
            bool isLast = arrLen - i == 1;
            int curr = intArr[i];

            int cursorPos = isLast ? -1 : 1;
            int next = intArr[i + cursorPos];

            int prev = isFirst ? 0 : intArr[i - 1];

            if (!isLast && curr < next) // next is bigger than current
            {
                tempSubSeq.Add(curr);
                continue;
            }
            else
            {
                if(curr > prev) tempSubSeq.Add(curr); //last value is still relevent

                if (tempSubSeq.Count > subSeq.Count)
                {
                    subSeq = new List<int>();
                    subSeq.AddRange(tempSubSeq);
                }
            }
            tempSubSeq = new List<int>(); //reset the temp list
        }


        // Convert the list of integers back to a space-separated string
        return string.Join(" ", subSeq);
    }
    static void Main(string[] args)
    {
        string input = "1 3 6 4 2 1";
        string output = findLIS(input);

        Console.WriteLine(output);
    }
}