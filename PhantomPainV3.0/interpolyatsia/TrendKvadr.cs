using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpolyatsia
{
    class TrendKvadr
    {
        double[,] a = new double[3, 3];
        double[] y = new double[3];
        double[] x = new double[3];

        public TrendKvadr()
        {
            int n = 3;
            double s = 0;

            for (int i = 0; i < n; i++)
            {
                x[i] = 0;
            }

            y[0] = y_x_x();
            y[1] = y_x();
            y[2] = y_last();

            a[0, 0] = x_multi(4);
            a[0, 1] = x_multi(3);
            a[0, 2] = x_multi(2);

            a[1, 0] = x_multi(3);
            a[1, 1] = x_multi(2);
            a[1, 2] = x_multi();

            a[2, 0] = x_multi(2);
            a[2, 1] = x_multi();
            a[2, 2] = data.x_value.Length;

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }
                    y[i] = y[i] - y[k] * a[i, k] / a[k, k];
                }
            }

            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < n; j++)
                    s = s + a[k, j] * x[j];
                x[k] = (y[k] - s) / a[k, k];
            }
            
        }

        public double get_res(double i)
        {
            double y = x[0] * i * i + x[1] * i + x[2];
            Console.WriteLine("a : " + x[0] + " | b : " + x[1] + " | c : " + x[2]);
            return y;
        }


        double x_multi(int scale)
        {
            double value = 0;
            for (int i = 0; i <= data.x_value.Length - 1; i++) value += Math.Pow(data.x_value[i], scale);
            return value;
        }
        double x_multi()
        {
            double value = 0;
            for (int i = 0; i <= data.x_value.Length - 1; i++) value += data.x_value[i];
            return value;
        }


        double y_x_x()
        {
            double value = 0;
            for (int i = 0; i <= data.x_value.Length - 1; i++) value += data.y_equation(data.x_value[i]) * data.x_value[i] * data.x_value[i];
            return value;
        }

        double y_x()
        {
            double value = 0;
            for (int i = 0; i <= data.x_value.Length - 1; i++) value += data.y_equation(data.x_value[i]) * data.x_value[i];
            return value;
        }

        double y_last()
        {
            double value = 0;
            for (int i = 0; i <= data.x_value.Length - 1; i++) value += data.y_equation(data.x_value[i]);
            return value;
        }
    }
}
