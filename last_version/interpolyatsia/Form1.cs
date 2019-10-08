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
        //уравненение по варианту
        public double y_equation(double x)
        {
            //double Y = i * Math.Cos(i + Math.Log10(1 + i));
            double y = Math.Sin(x * x) * Math.Pow(Math.E, -(x / 2));
            return y;
        }

        //штука чтобы рисовать 
        public void draw_chart(int i, double x, double y)
        {
            chart1.Series[i].Points.AddXY(x, y);
        }

        //значениея x
        public double[] x_value = new double [11];

        GussMeth GM = new GussMeth();

        public void get_x_value()
        {
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
        }

        public void get_y_value()
        {
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
        }
        //тута выводятся данные
        public Form1()
        {
            InitializeComponent();

            get_x_value();
            get_y_value();

            for (double i = 0; i <= 3; i += 0.01)
            {
                draw_chart(0, i, y_equation(i));
            }

            for (int i = 0; i <= 10; i++)
            {
                draw_chart(1, x_value[i], y_equation(x_value[i]));
            }
            


        }


      

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        GussMeth gaus = new GussMeth();
        private void button1_Click(object sender, EventArgs e)
        {
            gaus.graph_gauss();

            for (double i = 0; i <= 3; i += 0.01)
            {
                draw_chart(2, i, gaus.Graph_gauss[0]* Math.Pow(i,0) + gaus.Graph_gauss[1] * Math.Pow(i, 1) + gaus.Graph_gauss[2] * Math.Pow(i, 2) +
                    gaus.Graph_gauss[3] * Math.Pow(i, 3) + gaus.Graph_gauss[4] * Math.Pow(i, 4) + gaus.Graph_gauss[5] * Math.Pow(i, 5) +
                    gaus.Graph_gauss[6] * Math.Pow(i, 6) + gaus.Graph_gauss[7] * Math.Pow(i, 7) + gaus.Graph_gauss[8] * Math.Pow(i, 8) +
                    gaus.Graph_gauss[9] * Math.Pow(i, 9) + gaus.Graph_gauss[10] * Math.Pow(i, 10) );
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();
            get_x_value();
            get_y_value();
            for (int i = 0; i <= 10; i++)
            {
                draw_chart(1, x_value[i], y_equation(x_value[i]));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                chart1.Series[0].Points.Clear();
            }
            else
            {
                for (double i = 0; i <= 3; i += 0.01)
                {
                    draw_chart(0, i, y_equation(i));
                }
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (double i = 0; i <= 3; i += 0.01)
            {
                chart2.Series[0].Points.AddXY(i, Math.Abs(gaus.Graph_gauss[0] * Math.Pow(i, 0) + gaus.Graph_gauss[1] * Math.Pow(i, 1) + gaus.Graph_gauss[2] * Math.Pow(i, 2) +
                    gaus.Graph_gauss[3] * Math.Pow(i, 3) + gaus.Graph_gauss[4] * Math.Pow(i, 4) + gaus.Graph_gauss[5] * Math.Pow(i, 5) +
                    gaus.Graph_gauss[6] * Math.Pow(i, 6) + gaus.Graph_gauss[7] * Math.Pow(i, 7) + gaus.Graph_gauss[8] * Math.Pow(i, 8) +
                    gaus.Graph_gauss[9] * Math.Pow(i, 9) + gaus.Graph_gauss[10] * Math.Pow(i, 10) - y_equation(i)));
            }
            
        }
    }
}
