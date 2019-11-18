using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpolyatsia
{
    static class data 
    {
        public static double[] x_value; // массив x

        public static double[] a_value_gauss; // массив a

        public static double y_equation(double x) //функиция из задания 
        {
            double y = Math.Sin(x * x) * Math.Pow(Math.E, -(x / 2));
            return y;
        }

        public static double get_x_max //получить максимальное число в массиве x 
        {
            get {
                double max = 0;

                foreach (double value in x_value)
                {
                    if (value > max)
                        max = value;
                }

                return max;
            }
            
        }

        public static double get_x_min //получить минимальное число в массиве x 
        {
            get {
                double min = 0;

                foreach (double value in x_value)
                {
                    if (value < min)
                        min = value;
                }

                return min;
            }
            
        }
    }
}
