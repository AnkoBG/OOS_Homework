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

        private void GenButton_Click(object sender, EventArgs e)
        {
            string args = "-gen " + textBox1.Text + " " + numericUpDown1.Value.ToString();
            Process p = ConfigureProcess(args);
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            label3.Text = output != "" ? output : label3.Text;
            p.WaitForExit();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            string args = "-sort " + textBox1.Text;
            Process p = ConfigureProcess(args);
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            label3.Text = output != "" ? output : label3.Text;
            p.WaitForExit();
        }

        private void SortDescButton_Click(object sender, EventArgs e)
        {
            string args = "-sortdesc " + textBox1.Text;
            Process p = ConfigureProcess(args);
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            label3.Text = output != "" ? output : label3.Text;
            p.WaitForExit();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            string args = "-view " + textBox1.Text;
            Process p = ConfigureProcess(args);
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            label3.Text = output != "" ? output : label3.Text;
            p.WaitForExit();
        }


        public Process ConfigureProcess(string args)
        {
            Process p = new Process();
            p.StartInfo.FileName = "p1.exe";
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            return p;
        }

    }
}
