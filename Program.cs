using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Polynom
    {
        static void Main(string[] args)
        {
            List<double> coef = new List<double>();
            string input = Console.ReadLine();
            int n;
            do
            {
                n = (int) Math.Truncate(ReadValue("Write N"));
            } while (n < 1);

            for (int i = 0; i < n; ++i)
            {
                coef.Add(ReadValue("Input coef"));
                //input = Console.ReadLine();
                //coef.Add(Int32.Parse(input);
            }
            Console.WriteLine("Hello World!");
        }

        static void minMax(List<double> coef, double startx, double endx, double e)
        {
            List<double> coefD = new List<double>();
            for (int i = 1; i < coef.Count; ++i)
            {
                coefD.Add(coef[i] * i);
            }
            List<double> ans = solve(coefD, startx, endx, e);
            ans.Add(startx);
            ans.Add(endx);
            List<double> results = new List<double>();
            for (int i = 0; i < ans.Count; i++)
            {
                results.Add(res(coef, ans[i]));
            }
            Console.WriteLine("Min {}\n Max {}", results.Min(), results.Max());
        }

        static double res(List<double> coef, double x)
        {
            double ans = 0;
            /*
            for (int i = 0; i < coef.Count; ++i)
            {
                ans += coef[i] * Math.Pow(x, i);
            }
            */

            for (int i = coef.Count - 1; i >= 0; ++i)
            {
                ans += (ans + coef[i]) * x;
            }
            return ans;
        }

        static List<double> solve(List<double> coef, double xstart, double xend, double e)
        { 
            
            double last = xstart;
            List<double> ans = new List<double>();
            for (double x = xstart; x <= xend; x += e)
            {
                if ((res(coef, last) > 0 && res(coef, x) < 0) || (last < 0 && x > 0))
                {
                    ans.Add((x + last) / 2);
                }
            }
            return ans;
        }

        static double ReadValue (string Msg)
        {
            while(true)
            {
                Console.Write(Msg);
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                Console.WriteLine("Input Error");
            }
        }



    }
}
