using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpolyatsia
{
    class GussMeth
    {
        public double[] Graph_gauss = new double[11];

        public void graph_gauss()
        {
            Form1 form = new Form1();

            //Данные
            double s = 0;
            int n = 11;
            double[,] a = new double[n, n];
            double[] y = new double[n];
            double[] x = new double[n];
            for (int i = 0; i <n; i++)
            {
                x[i] = 0;
            }

            //заполнение y
            for (int i = 0; i < n; i++)
                y[i] = form.y_equation(form.x_value[i]);

            //заполнят x
            for (int k = 0; k < n ; k++)
            {
                for (int i = 0 ; i < n; i++)
                {
                   
                    a[k, i] = Math.Pow(form.x_value[k],i);
                    
                }
            }

            //сам гаусс
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
            for (int i = 0; i < n; i++)
            {
                Graph_gauss[i] = x[i];
            }
 
        }
    }   
}