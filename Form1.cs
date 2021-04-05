using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr14
{
    public partial class Form1 : Form
    {
        DateTimeFormat dtFormat = DateTimeFormat.ShowTime;
        ToolStripMenuItem currentCheckedItem;
        public Form1()
        {
            InitializeComponent();
            Text = "Пример строки состояния";
            CenterToScreen();
            BackColor = Color.CadetBlue;
            currentCheckedItem = toolStripMenuItemTime;
            currentCheckedItem.Checked = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(toolStripTextBoxX.Text);
            double y = Convert.ToDouble(toolStripTextBoxY.Text);
            double z = Convert.ToDouble(toolStripTextBoxZ.Text);
            double a = Convert.ToDouble(toolStripComboBoxA.SelectedItem.ToString());
            double b = Convert.ToDouble(toolStripComboBoxB.SelectedItem.ToString());
            Text = string.Format(" a * x^2 + b * (y - x) + lg(a * z) = {0} ", (a * Math.Pow(x, 2) + b * (y - x) + Math.Log(a * z).ToString()));
        }
        private void timerDateTimeUpdate_Tick(object sender, EventArgs e)
        {
            string info = "";
            if (dtFormat == DateTimeFormat.ShowTime)
                info = DateTime.Now.ToLongTimeString();
            else
                info = DateTime.Now.ToLongDateString();
            toolStripStatusLabelClock.Text = info;
        }
        private void toolStripMenuItem1_Click(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = Math.Cos(e.X * e.X) + Math.Sin(e.Y * e.Y).ToString();
        }
        private void toolStripMenuItem2_Click(object sender, MouseEventArgs e)
        {
             toolStripStatusLabel1.Text = string.Format("z = {0}, f = {1}", (e.Y - Math.Sqrt(e.X)) / (Math.Abs(e.X - e.Y)), Math.Sqrt(Math.Abs(Math.Sqrt(e.X) - Math.Sqrt(e.Y))).ToString());
        }
        
        private void toolStripMenuItemDate_Click(object sender, EventArgs e)
        {
            currentCheckedItem.Checked = false;
            dtFormat = DateTimeFormat.ShowDate;
            currentCheckedItem = toolStripMenuItemDate;
            currentCheckedItem.Checked = true;
        }
        private void toolStripMenuItemTime_Click(object sender, EventArgs e)
        {
            currentCheckedItem.Checked = false;
            dtFormat = DateTimeFormat.ShowTime;
            currentCheckedItem = toolStripMenuItemTime;
            currentCheckedItem.Checked = true;
        }
        public enum DateTimeFormat
        {
            ShowTime,
            ShowDate
        }

        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabelState.Text = string.Format("Координаты: {0}, {1}", e.X, e.Y);
            double x = e.X;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
