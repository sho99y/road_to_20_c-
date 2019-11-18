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
        GussMeth gaus;
        Trend trend;
        TrendKvadr trendKvadr;

        //переменные используемые в классе
        static double pluss = 0.01;
        static double minus = 0.01;
        double finish = 0;

        public void draw_chart(int i, double x, double y) //нарисовать линию 
        {
            chart1.Series[i].Points.AddXY(x, y);
        }

        public void draw_trend()
        {
            for (double i = data.get_x_min; i <= data.get_x_max + 0.2; i += 0.1)
            {
                draw_chart(3, i, trend.get_res(i));
            }

        }

        public void draw_trendKvadr()
        {
            for (double i = data.get_x_min; i <= data.get_x_max ; i += 0.1)
            {
                draw_chart(4, i, trendKvadr.get_res(i));
            }

        }

        public void draw_gaus_chart() //нарисовать гауса и E 
        {
            for (double i = data.get_x_min; i <= data.get_x_max; i += 0.01)
            {
                draw_chart(2, i, gaus.value_y_gauss(i));
            }

            for (double i = data.get_x_min; i <= data.get_x_max; i += 0.01)
            {
                chart2.Series[0].Points.AddXY(i, Math.Abs(gaus.value_y_gauss(i) - data.y_equation(i)));
            }
        }

        public void draw_gaus_chart(double second_value) //нарисовать гауса и E но можно еще и размер поменять 
        {
            for (double i = data.get_x_min; i <= second_value; i += 0.01)
            {
                draw_chart(2, i, gaus.value_y_gauss(i));
            }

            for (double i = data.get_x_min; i <= second_value; i += 0.01)
            {
                chart2.Series[0].Points.AddXY(i, Math.Abs(gaus.value_y_gauss(i) - data.y_equation(i)));
            }
        }

        public void draw_y_equation() //нарисовать данную в задании функцию 
        {
            for (double i = data.get_x_min; i <= data.get_x_max; i += 0.01)
            {
                draw_chart(0, i, data.y_equation(i));
            }
        }

        public void draw_y_equation(double second_value) //нарисовать данную в задании функцию с возможность изменить размер 
        {
            for (double i = data.get_x_min; i <= second_value; i += 0.01)
            {
                draw_chart(0, i, data.y_equation(i));
            }
        }

        public void draw_x_dots() //нарисовать точки 
        {
            for (int i = 0; i <= data.x_value.Length - 1; i++)
            {
                draw_chart(1, data.x_value[i], data.y_equation(data.x_value[i]));
            }
        }

        public void set_x_value() //получить значения x из текстового поля 
        {
            String[] st_x_value = textBox1.Text.Split(' ');
            data.x_value = new double[st_x_value.Length];
            data.a_value_gauss = new double[st_x_value.Length];

            for (int i = 0; i <= st_x_value.Length - 1; i++)
            {
                data.x_value[i] = Convert.ToDouble(st_x_value[i]);
            }
            finish = data.get_x_max;
        }

        //  Граница

        public Form1() //когда запускается программа 
        {
            InitializeComponent();
            set_x_value();

            draw_y_equation();
            draw_x_dots();
        }

        private void button1_Click(object sender, EventArgs e) //интерполяция по гауссу 
        {
            chart1.Series[2].Points.Clear();
            chart2.Series[0].Points.Clear();

            set_x_value();  

            gaus = new GussMeth();

            draw_gaus_chart();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //убрать, добавить первую линию, но её нужно доделать!!!!!!!
        {
            if (checkBox1.Checked == false)
            {
                chart1.Series[0].Points.Clear();
            }
            else
            {
                chart1.Series[0].Points.Clear();
                for (double i = data.get_x_min; i <= finish; i += 0.01)
                {
                    draw_chart(0, i, data.y_equation(i));
                }
            }
        }

        private void restart_Click(object sender, EventArgs e) //перерисовать точки 
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            set_x_value();

            draw_y_equation();
            draw_x_dots();
        }

        private void button_pluss_Click(object sender, EventArgs e) //увеличить размер линий 
        {
            
            chart1.Series[0].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart2.Series[0].Points.Clear();

            gaus = new GussMeth();

            draw_y_equation(finish + pluss);
            draw_gaus_chart(finish + pluss);

            finish += pluss;
            pluss += 0.01;
        }

        private void button_minus_Click(object sender, EventArgs e) //уменьшить размер линий 
        {
            
            chart1.Series[0].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart2.Series[0].Points.Clear();

            gaus = new GussMeth();

            draw_y_equation(finish - minus);
            draw_gaus_chart(finish - minus);

            finish -= minus;
            minus += 0.01;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trend = new Trend();

            draw_trend();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trendKvadr = new TrendKvadr();
           // for (int i = 0; i <= data.x_value.Length - 1; i++) Console.WriteLine("Y VALUE [" + i + "] : " + data.y_equation(data.x_value[i]));

            draw_trendKvadr();
        }
    }
}
