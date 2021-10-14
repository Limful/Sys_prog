using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;


namespace l1
{
    
    public partial class Form1 : Form
    {
        public int thread_id = 0;
        Process Child = null;
        EventWaitHandle evStart = new EventWaitHandle(false, EventResetMode.ManualReset, "EventStart");
        EventWaitHandle evStop = new EventWaitHandle(false, EventResetMode.ManualReset, "EventStop");

        
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int text = (int)numericUpDown1.Value;
            if ((Child == null) || (Child.HasExited))
            {
                Child = Process.Start("..\\LAB1\\Debug\\L1c.exe");
              
            }
            else
            {

                for (int i = 0; i < text; i++)
                {
                    comboBox1.Items.Add($"id {thread_id}\n");
                    thread_id++;
                    evStart.Set();
                  
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (thread_id > 0)
            {
                comboBox1.Items.RemoveAt(thread_id -1);
                thread_id--;
                evStop.Reset();
                evStop.Set();

            }
            

            evStop.Set();
            evStop.Reset();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Child?.Kill();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
