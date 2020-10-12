using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_12_事件代码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("大家好！我是" + ((Button)sender).Text);
        }
        private void SayHill(object sender, EventArgs e)
        {
            MessageBox.Show("大家好！我是" + ((Button)sender).Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Click += new System.EventHandler(this.SayHill);
            this.button3.Click += new System.EventHandler(this.SayHill);
            this.button4.Click += new System.EventHandler(this.SayHill);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.button2.Click -= new System.EventHandler(this.button2_Click);
        }
    }
}
