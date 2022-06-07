using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rate = (double)edRate.Value;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(i, rate);
        }

        const double k = 0.05;
        int i = 0;
        double rate;
        double rubles = 100;
        double mu = 0.0001, sigma = 0.0084;
        int dollars = 0;
        Random random = new Random();
        private void btStart_Click(object sender, EventArgs e)
        {
            rate = (double)edRate.Value;

            i++;
            rate = rate * Math.Exp((mu - sigma * sigma / (double)2) + sigma * (2 * random.NextDouble() - 1));

            chart1.Series[0].Points.AddXY(i, rate);

            textBox1.Text = rubles.ToString("F2");
            textBox2.Text = dollars.ToString();
            textBox3.Text = "          ";
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            if (rubles >= rate) // если достаточно средств
            {
                dollars++;
                rubles -= rate;
                textBox1.Text = rubles.ToString("F2");
                textBox2.Text = dollars.ToString();
                textBox3.Text = "Покупка прошла успешно";
            }
            else
            {
                textBox3.Text = "Недостаточно средств"; // не можем купить
            }
        }

        private void Sale_Click(object sender, EventArgs e)
        {
            if (dollars >= 1)
            {
                dollars--;
                rubles += rate;
                textBox1.Text = rubles.ToString("F2");
                textBox2.Text = dollars.ToString();
                textBox3.Text = "Продажа прошла успешно";
            }
            else
            {
                textBox3.Text = "Недостаточно долларов для продажи"; // не можем продать
            }
        }

    }
}
