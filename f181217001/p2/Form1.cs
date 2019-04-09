using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace p2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process p1 = new Process();

            p1.StartInfo.FileName = "p1.exe";
            p1.StartInfo.Arguments = "--gen";
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.CreateNoWindow = true;
            p1.Start();

            p1.WaitForExit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process p2 = new Process();

            p2.StartInfo.FileName = "p1.exe";
            p2.StartInfo.Arguments = "--sort";
            p2.StartInfo.UseShellExecute = false;
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.CreateNoWindow = true;
            p2.Start();

            p2.WaitForExit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process p3 = new Process();

            p3.StartInfo.FileName = "p1.exe";
            p3.StartInfo.Arguments = "--view";
            p3.StartInfo.UseShellExecute = false;
            p3.StartInfo.RedirectStandardOutput = true;
            p3.StartInfo.CreateNoWindow = true;
            p3.Start();

            label1.Text = p3.StandardOutput.ReadToEnd();

            p3.WaitForExit();
        }
    }
}
