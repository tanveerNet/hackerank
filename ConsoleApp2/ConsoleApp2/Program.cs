using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {

        List<(int x, int y)> US = new List<(int x, int y)>();
        List<(int x, int y)> DS = new List<(int x, int y)>();
        List<(int x, int y)> LS = new List<(int x, int y)>();
        List<(int x, int y)> RS = new List<(int x, int y)>();
        List<(int x, int y)> ULD = new List<(int x, int y)>();
        List<(int x, int y)> URD = new List<(int x, int y)>();
        List<(int x, int y)> LLD = new List<(int x, int y)>();
        List<(int x, int y)> LRD = new List<(int x, int y)>();       

        List<(int x, int y)> cords = new List<(int x, int y)>();

        for (int i = r_q + 1; i <= n; i++)
            US.Add((i, c_q));
        for (int i = r_q - 1; i > 0; i--)
            DS.Add((i, c_q));
        for (int i = c_q + 1; i <= n; i++)
            RS.Add((r_q, i));
        for (int i = c_q - 1; i > 0; i--)
            LS.Add((r_q, i));

        int x = 1, y = 1;
        while (r_q + x <= n && c_q - y > 0)
        {
            ULD.Add(( r_q + x, c_q - y));
            x++; y++;
        }
        x = 1; y = 1;

        while (r_q - x > 0 && c_q - y > 0)
        {
            LLD.Add((r_q - x, c_q - y ));
            x++; y++;
        }

        x = 1; y = 1;
        while (r_q + x <= n && c_q + y <= n)
        {
            URD.Add(( r_q + x, c_q + y));
            x++; y++;
        }

        x = 1; y = 1;
        while (r_q - x > 0 && c_q + y <= n)
        {
            LRD.Add((r_q - x, c_q + y));
            x++; y++;
        }

        for(int i=0; i<obstacles.Count(); i++)
        {
            if(US.Contains((obstacles[i][0], obstacles[i][1])))
            US.RemoveAll(x => US.IndexOf((x)) > US.IndexOf((obstacles[i][0],obstacles[i][1]))-1);
            if (DS.Contains((obstacles[i][0], obstacles[i][1])))
            DS.RemoveAll(x => DS.IndexOf((x)) > DS.IndexOf((obstacles[i][0], obstacles[i][1])) - 1);
            if (LS.Contains((obstacles[i][0], obstacles[i][1])))
            LS.RemoveAll(x => LS.IndexOf((x)) > LS.IndexOf((obstacles[i][0], obstacles[i][1])) - 1);
            if (RS.Contains((obstacles[i][0], obstacles[i][1])))
            RS.RemoveAll(x => RS.IndexOf((x)) > RS.IndexOf((obstacles[i][0], obstacles[i][1])) - 1);
            if (ULD.Contains((obstacles[i][0], obstacles[i][1])))
                ULD.RemoveAll(x => ULD.IndexOf((x)) > ULD.IndexOf((obstacles[i][0], obstacles[i][1])) - 1);
            if (LLD.Contains((obstacles[i][0], obstacles[i][1])))
                LLD.RemoveAll(x => LLD.IndexOf((x)) > LLD.IndexOf((obstacles[i][0], obstacles[i][1])) - 1);
            if (URD.Contains((obstacles[i][0], obstacles[i][1])))
                URD.RemoveAll(x => URD.IndexOf((x)) > URD.IndexOf((obstacles[i][0], obstacles[i][1])) - 1);
            if (LRD.Contains((obstacles[i][0], obstacles[i][1])))
                LRD.RemoveAll(x => LRD.IndexOf((x)) > LRD.IndexOf((obstacles[i][0], obstacles[i][1])) - 1);

        }


        return US.Count() + DS.Count() + LS.Count() + RS.Count() + ULD.Count() + LLD.Count() + URD.Count() + LRD.Count();
   
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        // chekcing commit
        TextWriter textWriter = new StreamWriter(@"c:\temp\\myfile1.txt", true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();


        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        Console.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
