using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsHamsterGame
{
    public partial class HamsterGame : Form
    {
        public static Button[] buttons = new Button[16];
        public static bool[] chosen = new bool[16];
        public static Queue<int> oldest = new Queue<int>();
        public static int count;
        private static System.Timers.Timer aTimer;
        public static int trackBarValue;

        public HamsterGame()
        {
            InitializeComponent();
            trackBar1.Value = 500;
            trackBarValue = 500;
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;
            buttons[9] = button10;
            buttons[10] = button11;
            buttons[11] = button12;
            buttons[12] = button13;
            buttons[13] = button14;
            buttons[14] = button15;
            buttons[15] = button16;
            for (int i = 0; i < 16; i++)
            {
                chosen[i] = false;
            }
            count = 0;
            oldest = new Queue<int>();
            SetTimer();

            //colorChosen();
        }

        private void splitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            int newLabelX = (e.SplitX - 112) / 2;
            int newLabelY = label1.Top;
            int newLabelBarX = (splitContainer1.SplitterDistance - trackBar1.Width) / 2;
            int newLabelBarY = trackBar1.Top;
            label1.Location = new Point(newLabelX, newLabelY);
            trackBar1.Location = new Point(newLabelBarX, newLabelBarY);


        }

        private static void colorChosen(Object source, ElapsedEventArgs e)
        {
            int idx;
            Random rand = new Random();
            while (oldest.Count > 0)
            {
                int index = oldest.Dequeue();
                if (chosen[index])
                {
                    chosen[index] = false;
                    count--;
                    buttons[index].BackColor = Color.DimGray;
                    break;
                }
            }

            while (count < 5)
            {
                idx = rand.Next(16);
                if (!chosen[idx])
                {
                    chosen[idx] = true;
                    count++;
                    oldest.Enqueue(idx);
                }
            }
            for (int i = 0; i < 16; i++)
            {
                if (chosen[i])
                {
                    buttons[i].BackColor = Color.Blue;
                }
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn.BackColor != Color.DimGray)
            {
                btn.BackColor = Color.DimGray;
                chosen[Convert.ToInt32(btn.Tag)] = false;
                count--;
            }
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            int time = 500000 / trackBarValue;
            aTimer = new System.Timers.Timer(time);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += colorChosen;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            var trackBar = sender as TrackBar;
            trackBarValue = trackBar.Value;
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
                SetTimer();
            }
        }
    }
}
