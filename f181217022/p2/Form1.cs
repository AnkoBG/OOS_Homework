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
using System.Net;
using System.Net.Sockets;

namespace p2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void GenButton_Click(object sender, EventArgs e)
        {
            string args = "-gen " + textBox1.Text + " " + numericUpDown1.Value.ToString();

            DoTask(args);
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            string args = "-sort " + textBox1.Text;
            DoTask(args);
        }

        private void SortDescButton_Click(object sender, EventArgs e)
        {
            string args = "-sortdesc " + textBox1.Text;
            DoTask(args);
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            string args = "-view " + textBox1.Text;
            DoTask(args);
        }

        public void DoTask(string args)
        {
            if (comboBox1.SelectedIndex == 0)
                StartProcess(args);
            else
                UseService(args);
        }

        public void StartProcess(string args)
        {
            Process p = new Process();

            p.StartInfo.FileName = "p1.exe";
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();

            label3.Text = output != "" ? output : label3.Text;

            p.WaitForExit();
        }

        public void UseService(string args)
        {
            TcpClient tcpClient = new TcpClient();

            tcpClient.Connect("127.0.0.1", 13000);

            NetworkStream stream = tcpClient.GetStream();

            stream.Write(Encoding.ASCII.GetBytes(args), 0, args.Length);

            byte[] bytes = new byte[512];
            while (true)
            {
                stream.Read(bytes, 0, bytes.Length);
                string response = Encoding.UTF8.GetString(bytes).Trim('\0');
                if (response != "")
                {
                    label3.Text = response != "" ? response : label3.Text;
                    break;
                }
            }

        }
    }
}
