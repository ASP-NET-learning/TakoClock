using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Lab0110_TakoClock
{
    public partial class Form1 : Form
    {
        public int systemCounter = 0;
        public Form1()
        {
            InitializeComponent();
           
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory;
            string music = path.Replace(@"\bin\Debug", @"\Audio\ina語音包.wav");

            systemCounter = Convert.ToInt16(label1.Text);
            systemCounter--;
            if(systemCounter == 0)
            {
                try
                {
                    this.timer1.Stop();
                    SoundPlayer simpleSound = new SoundPlayer(music);
                    simpleSound.Play();
                }
                catch
                {
                    label1.Text = "Not Find Ina";
                    return;
                }
                
            }
            this.textBox1.Text = systemCounter.ToString().Trim();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            label1.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.timer1.Interval = 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }
    }
}
