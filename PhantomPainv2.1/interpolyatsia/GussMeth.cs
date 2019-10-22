using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interpolyatsia
{
    class GussMeth
    {
        private double[] graph_gauss() //оно работает значит лучше его не трогать!!!!! 
        {
            int n = data.x_value.Length;
            double s = 0;
            double[,] a = new double[n, n];
            double[] y = new double[n];
            double[] x = new double[n];
           
            for (int i = 0; i <n; i++)
            {
                x[i] = 0;
            }

            for (int i = 0; i < n; i++)
                y[i] = data.y_equation(data.x_value[i]);

            for (int k = 0; k < n; k++)
            {
                for (int i = 0 ; i < n; i++)
                {
                   
                    a[k, i] = Math.Pow(data.x_value[k], i);
                    
                }
            }

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

            return x;
        }

        public double value_y_gauss(double i) //вводит a в уравнение 
        { 
            double summy = 0;
            for (int j = 0; j <= data.x_value.Length - 1; j++)
            {
                summy += graph_gauss()[j] * Math.Pow(i, j);
            }
            return summy;
        }
    }   
}