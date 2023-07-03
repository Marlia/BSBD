using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace БСБД27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Покупатель b = new Покупатель();
            b.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Продавец s = new Продавец();
            s.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Риелтор r = new Риелтор();
            r.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Юрист l = new Юрист();
            l.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Произвольные_запросы pz = new Произвольные_запросы();
            pz.ShowDialog();
        }
    }
}
