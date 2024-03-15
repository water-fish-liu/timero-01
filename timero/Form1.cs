using System;
using System.Media;
using System.Windows.Forms;


namespace CountdownTimerApp
{
    public partial class MainForm : Form
    {
        private int secondsRemaining;
        private SoundPlayer soundPlayer;
        private SoundPlayer soundPlayer1;

        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();
            InitializeSoundPlayer();
            InitializeSoundPlayer1();
        }

        private void InitializeTimer()
        {
            timer1.Interval = 1000; // 1
            timer1.Tick += Timer1_Tick;
        }
        private void InitializeSoundPlayer()
        {
            // 初始化 
            soundPlayer = new SoundPlayer(".\\file.wav");
        }
        private void InitializeSoundPlayer1()
        {
            // 初始化 
            soundPlayer1 = new SoundPlayer(".\\1.wav");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (secondsRemaining > 0)
            {
                secondsRemaining--;
                UpdateDisplay();
                PlayAudio1();
            }
            else
            {
                timer1.Stop();
                PlayAudio();
                MessageBox.Show("倒计时结束！");
                label1.Text = $"  已结束  ";
                DisPlayAudio();

                //计算式
            }
        }

        private void PlayAudio()
        {
            // 播
            soundPlayer.Play();
        }
        private void PlayAudio1()
        {
            // 播
            soundPlayer1.Play();
        }
        private void DisPlayAudio()
        {
            //停
            soundPlayer.Stop();
        }

        private void UpdateDisplay()
        {
            label1.Text = $"还剩{secondsRemaining}秒";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 时分秒控件的值
                int hours = (int)numericUpDownHours.Value;
                int minutes = (int)numericUpDownMinutes.Value;
                int seconds = (int)numericUpDownSeconds.Value;

                // 防呆傻
                if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
                {
                    MessageBox.Show("请输入有效的时间范围。");
                    return; // 拒绝
                }

                // 将时分秒转化为秒
                int s = hours * 3600 + minutes * 60 + seconds;
                secondsRemaining = s;
                UpdateDisplay();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}");
                // 实际用不到
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //终止按钮
            timer1.Stop();
            MessageBox.Show("倒计时已终止！");
            label1.Text = $"  已终止  ";
        }
    }
}