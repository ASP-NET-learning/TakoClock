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

namespace TakoClock1
{
    public partial class Form1 : Form
    {
        private SoundPlayer simpleSound;

        public Form1()
        {
            InitializeComponent();
            string path = Environment.CurrentDirectory;
            string musicPath = path.Replace(@"\bin\Debug", @"\Audio\ina語音包.wav");
            simpleSound = new SoundPlayer(musicPath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateCurrentTime();
        }

        private void UpdateCurrentTime()
        {
            // 取得當前的日期和時間
            DateTime currentTime = DateTime.Now;

            // 將當前時間顯示在 Label 控制項上
            labelCurrentTime.Text = currentTime.ToString("HH:mm:ss");
        }

        private void labelCurrentTime_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateCurrentTime();

            if (DateTime.TryParse(textBox1.Text, out DateTime userInput))
            {
                DateTime currentTime = DateTime.Now;
                string curTime = currentTime.ToString("HH:mm");
                string userTime = userInput.ToString("HH:mm");
                string curTime2 = currentTime.ToString("ss");

                // 比對時間
                if (curTime == userTime && curTime2 == "00")
                {
                    
                    try
                    {
                        label1.Text = "時間到!";
                        timer1.Stop();
                        simpleSound.PlayLooping(); 
                    }
                    catch
                    {
                        label1.Text = "Not Find Ina";
                        return;
                    }
                    
                }
            }
            else
            {
                // 使用者輸入的不是有效的日期時間字串，你可以在這裡處理錯誤
                //MessageBox.Show("請輸入有效的日期時間格式。");
                label1.Text = "時間還沒到!";
                return;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputLabel.Text = textBox1.Text; 
        }

        private void inputLabel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCurrentTime();
            timer1.Start();
            textBox1.Text = "00:00";
            inputLabel.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            simpleSound.Stop();
        }
    }
}
