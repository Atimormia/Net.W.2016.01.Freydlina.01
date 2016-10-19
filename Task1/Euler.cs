using System;
using System.Collections.Generic;

namespace Task1
{
    public struct Vector
    {
        public double x;
        public double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    //
    // Summary:
    //      Represents methods for solving Koshi's problem  
    //      y' = 1 - sin(alpha * x + y) + beta * y / (alpha + x)
    //      where x on [0,1] and y(0) = 0
    public class Euler
    {
        
        double n;
        double k;
        static double h = 0.1;
        static Vector V0 = new Vector(0, 0);
        double alpha;
        double beta;

        private void CalculateParams()
        {
            alpha = 1 + 0.125 * k;
            beta = -0.3 + 0.1 * n;
        }

        public Euler()
        {
            n = 5;
            k = 2.6;
            CalculateParams();
        }

        public Euler(double n, double k)
        {
            this.n = n;
            this.k = k;
            CalculateParams();
        }

        public IEnumerable<Vector> Forecast()
        {
            int len = (int)Math.Round(1 / h, 0) + 1;
            Vector[] forecast = new Vector[len];
            forecast[0] = V0;

            for (int i = 0; i < len - 1; i++)
            {
                forecast[i + 1].x = forecast[i].x + h;
                forecast[i + 1].y = forecast[i].y + h * F(forecast[i]);
                yield return forecast[i];
            }
        }

        public IEnumerable<Vector> Correction()
        {
            int len = (int)(1 / (h / 2)) + 1;
            Vector[] correction = new Vector[len];
            correction[0] = V0;

            for (int i = 0; i < len - 1; i++)
            {
                correction[i + 1].x = correction[i].x + h / 2;
                correction[i + 1].y = Y(correction[i]);
                yield return correction[i];
            }
        }

        double Y(Vector v)
        {
            double k = h / 2 * F(v);
            return v.y + h * F(new Vector(v.x + h / 2, v.y + k));
        }

        double F(Vector v)
        {
            return 1 - Math.Sin(alpha * v.x + v.y) + beta * v.y / (alpha + v.x);
        }

    }
}
