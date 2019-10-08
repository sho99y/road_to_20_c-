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
    public partial class Form1 : Form
    {
        //формула y
        public double y_equation(double i)
        {
            //в эту переменную пищите свою формулу по варианту
            double Y = i * Math.Cos(i + Math.Log10(1 + i));
            return Y;
        }

        //штука чтобы рисовать 
        //i - это номер линии на графике, а x y это x и y 
        public void draw_chart(int i, double x, double y)
        {
            chart1.Series[i].Points.AddXY(x, y);
        }

        //массив  x получается их тех textBox в приложении
        public double[] x_value = new double [11];

        

        //тута типо программа
        public Form1()
        {
            InitializeComponent();
            
            //вот тута получают значения x и передаются в массив x_value
            x_value[0] = Convert.ToDouble(textBox1.Text);
            x_value[1] = Convert.ToDouble(textBox2.Text);
            x_value[2] = Convert.ToDouble(textBox3.Text);
            x_value[3] = Convert.ToDouble(textBox4.Text);
            x_value[4] = Convert.ToDouble(textBox5.Text);
            x_value[5] = Convert.ToDouble(textBox6.Text);
            x_value[6] = Convert.ToDouble(textBox7.Text);
            x_value[7] = Convert.ToDouble(textBox8.Text);
            x_value[8] = Convert.ToDouble(textBox9.Text);
            x_value[9] = Convert.ToDouble(textBox10.Text);
            x_value[10] = Convert.ToDouble(textBox11.Text);

            //вот тута выводятся y в приложении
            //0.000000 чтобы число было не большим 
            label3.Text = y_equation(x_value[0]).ToString("0.000000");
            label4.Text = y_equation(x_value[1]).ToString("0.000000");
            label5.Text = y_equation(x_value[2]).ToString("0.000000");
            label6.Text = y_equation(x_value[3]).ToString("0.000000");
            label7.Text = y_equation(x_value[4]).ToString("0.000000");
            label8.Text = y_equation(x_value[5]).ToString("0.000000");
            label9.Text = y_equation(x_value[6]).ToString("0.000000");
            label10.Text = y_equation(x_value[7]).ToString("0.000000");
            label11.Text = y_equation(x_value[8]).ToString("0.000000");
            label12.Text = y_equation(x_value[9]).ToString("0.000000");
            label13.Text = y_equation(x_value[10]).ToString("0.000000");

            //у вас в задании задан предел в квадратных скобках 
            //в i ставите то число что с лева 
            //а в место 5 то что справа
            //[1;5] 
            //и шаг можете делать меньше 0.01 но это почти ни как не повлияет из-за особенности spline
            for (double i = 1; i <= 5; i += 0.01)
            {
                draw_chart(0, i, y_equation(i));
            }

            //вот эта штука берет значения из массива x_vlaue и ставит точки
            for (int i = 0; i <= 10; i++)
            {
                draw_chart(1, x_value[i], y_equation(x_value[i]));
            }

            
        }

        //короче если что textBox не работают если вы в них что нибудь напишите после запуска программы ничего не произойдет
        //так что это программа по сути просто чертит график и ставит точки

        //Все что с низу не используется просто скажите что мол на будущее
        //Но удалять я не советую вродебы программа не будет работать

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {

             
        }
    }
}
