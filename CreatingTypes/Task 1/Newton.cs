using System;

namespace CreatingTypes
{
    public class Newton
    {
        static public double FindNthRoot(double a, int n, double eps)
        {
            if (n % 2 == 0 && a < 0) throw new ArgumentException();
            else if (n < 1) throw new ArgumentException("n - must be a positive number");
            else if (eps < 0 && eps < 1) throw new ArgumentException("eps is precision. It must be a positive number");

            double x = Math.Pow(n, sizeof(int)*8/n);
            double nextX;

            while(true)
            {
                nextX = (1 / (double)n) * ((n - 1) * x + Math.Abs(a) / Math.Pow(x, n - 1));
                if (Math.Abs(x - nextX) < eps) break;
                x = nextX;
            }

            double result = Math.Round(nextX, eps.ToString().Length - 2);
            return (a > 0) ? result : -result;  
        }
    }
}
