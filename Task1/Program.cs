using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Атака_Инопланетян
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            string line;
            int n = Convert.ToInt32(sr.ReadLine());
            int[,] arr = new int[n, 4];
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(new char[] { ' ' });
                arr[i, 0] = Convert.ToInt32(words[0]);
                arr[i, 1] = Convert.ToInt32(words[1]);
                arr[i, 2] = Convert.ToInt32(words[2]);
                arr[i, 3] = arr[i, 0] + arr[i, 1] + arr[i, 2];
                i++;
            }

            double res=0;
            res = Result(arr);

            string result = String.Format("{0:0.000}", res);
            result = result.Replace(',', '.');

            Console.WriteLine(result);
            sw.WriteLine(result);
            sr.Close();
            sw.Close();

        }

        static double Result(int[,] arr)
        {
            double answ = 0;
            int minB = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            for(int i=0; i<arr.GetLength(0); i++)
            {
                if (arr[i,0] > maxX) maxX = arr[i,0];
                if (arr[i, 1] > maxY) maxY = arr[i, 1];
                if (arr[i, 3] < minB) minB = arr[i, 3];
            }
            bool ex = true;
            for (int j = 0; j < arr.GetLength(0); j++)
                if (arr[j, 1] >= -arr[j, 0] + minB) ex = false;
            if(ex)
            if (minB - maxY <= maxX) answ = 0; else
            answ = Math.Pow(Math.Abs(Math.Abs(minB - maxY) - maxX), 2) / 2;
            return answ;
        }
    }
}
 
