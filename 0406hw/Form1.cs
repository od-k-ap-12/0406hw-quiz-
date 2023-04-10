using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace _0406hw
{
    public partial class Form1 : Form
    {
        int Minutes = 5;
        int Seconds = 0;
        public Form1()
        {
            InitializeComponent();
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {

            if (Minutes > 0 && Seconds == 0)
            {
                Minutes -= 1;
                Seconds = 60;
            }
            else if (Minutes == 0)
            {
                timer.Stop();
                Finish.PerformClick();
            }
            else
            {
                Seconds -= 1;
                DisplayTimer.Text = Minutes + ":" + Seconds;
            }
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            int Result = 0;
            if (radioButton1.Checked) { Result++; }
            if (radioButton5.Checked) { Result++; }
            if (radioButton12.Checked) { Result++; }
            if (radioButton7.Checked) { Result++; }
            if (radioButton18.Checked) { Result++; }
            if (radioButton15.Checked) { Result++; }
            if (radioButton24.Checked) { Result++; }
            if (radioButton21.Checked) { Result++; }
            if (checkBox1.Checked&&checkBox2.Checked&&checkBox3.Checked) { Result++; }
            if (checkBox6.Checked&&checkBox5.Checked) { Result++; }
            MessageBox.Show(Convert.ToString(Result)+"\\10","Results");
            SaveResultToFile(Result);
            ResultProgress.Maximum = 10;
            ResultProgress.Value = Result;
        }
        private void SaveResultToFile(int Result)
        {
            StreamWriter writer = new StreamWriter("results.txt", true);
            writer.WriteLine(Convert.ToString(Result) + "\\10", "Results");
            writer.Close();
        }

    }
}
