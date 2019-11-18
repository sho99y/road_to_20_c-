using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpolyatsia
{
    class Trend
    {
        double summatorX = 0;
        double summatorY = 0;
        double summatorX2 = 0;
        double summatorXandY = 0;
        double a, b;

        public Trend()
        {
            for (int i = 0; i <= data.x_value.Length - 1; i++)
            {
                summatorX += data.x_value[i];
                summatorY += data.y_equation(data.x_value[i]);
                summatorX2 += Math.Pow(data.x_value[i], 2);
                summatorXandY += (data.x_value[i] * data.y_equation(data.x_value[i]));
            }
            a = (data.x_value.Length * summatorXandY - (summatorX * summatorY)) /
                (data.x_value.Length * summatorX2 - summatorX * summatorX);
            b = (summatorX * summatorXandY - summatorX2 * summatorY) /
                ((summatorX * summatorX) - data.x_value.Length * summatorX2);
        }

       public double get_res(double x) {
            
            double y = a * x + b;
            Console.WriteLine("a : " + a + " | b : " + b + " | y : " + y);
            return y;
        }
    }
}
