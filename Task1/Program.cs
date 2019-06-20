using System;
using System.IO;

namespace Атака_Инопланетян
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            int n = Convert.ToInt32(sr.ReadLine());
            int[,] arr = new int[n, 4];
            for(int i=0; i<n;i++)
            {
                string line = sr.ReadLine();
                string[] words = line.Split(new char[] { ' ' });
                arr[i, 0] = Convert.ToInt32(words[0]);
                arr[i, 1] = Convert.ToInt32(words[1]);
                arr[i, 2] = Convert.ToInt32(words[2]);
                arr[i, 3] = arr[i, 0] + arr[i, 1] + arr[i, 2];
            }

            double res=0;
            if(arr.GetLength(0)!=0)
            res = Result(arr);

            string result = String.Format("{0:0.000}", res);
            result = result.Replace(',', '.');
            
            sw.WriteLine(result);
            sr.Close();
            sw.Close();

        }
       
        static double Result(int[,] arr)
        {
            double res = 0;
            bool ok = true;
            int curX = arr[0, 0];
            int curY = arr[0, 1];
            int curB = arr[0, 3];
            int curL = Math.Abs(curB - curY - curX);
            for(int i=0; i<arr.GetLength(0);i++)
            {
                if(arr[i,3]>curX+curY )
                {
                    if(arr[i,0]<curX+curL&&arr[i,1]<curY+curL)
                    {
                        if(arr[i,0]+arr[i,2]>curX&&arr[i,1]+arr[i,2]>curY)
                        {
                            if (arr[i, 3] < curB) curB = arr[i, 3];
                            if (arr[i, 0] > curX) curX = arr[i, 0];
                            if (arr[i, 1] > curY) curY = arr[i, 1];
                            curL = Math.Abs(curB - curY - curX);
                        }
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                    else
                    {
                        ok = false;
                        break;
                    }
                }
                else
                {
                    ok = false;
                    break;
                }
            }
            if(ok) res= Math.Pow(Math.Abs(Math.Abs(curB - curY) - curX), 2) / 2;
            return res;
        }
    }
}
