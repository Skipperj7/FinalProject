using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap drawSpace;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseClick += new MouseEventHandler(Image1_Clicked);
            button1.MouseClick += new MouseEventHandler(ShopClick);
            button2.MouseClick += new MouseEventHandler(upgrade);
            button3.MouseClick += new MouseEventHandler(bot);

            Timer refreshTime = new Timer();
            refreshTime.Tick += new EventHandler(showscore);
            refreshTime.Interval = 1;
            refreshTime.Start();

            pictureBox2.MouseDown += new MouseEventHandler(drawOn);
            pictureBox2.MouseUp += new MouseEventHandler(drawOff);
            drawSpace = new Bitmap(pictureBox2.Size.Width, pictureBox2.Size.Height);
            pictureBox2.Image = drawSpace;
        }
        private void showscore(object sender, EventArgs e) {
            
            if (score < 1000000)
            {
                scoreToDisplay = score;
                endings = "";
            }
            if (1000000 <= score && score < 1000000000)
            {
                scoreToDisplay = Math.Round((score / 1000000), 5);

                endings = "Million";
            }
            if (1000000000 <= score && score < 1000000000000)
            {
                scoreToDisplay = Math.Round((score / 1000000000), 5);

                endings = "Billion";
            }

            label2.Text = "" + scoreToDisplay + endings + "";
        }
        private int picture = 0;
        private double score = 999997;
        private double scoreToDisplay;
        private string endings;
        private double upgradeScore = 1;
        private void Image1_Clicked(object sender, MouseEventArgs e) {
           
                picture = picture + 1;
                score = score + upgradeScore;
           
                if (picture >= 6) {
                    picture = 0;
                }
                
                
                switch (picture)
                {
                    case 0:
                        pictureBox1.Image = Properties.Resources.p11;
                   
                    
                    
                        break;
                    case 1:
                        pictureBox1.Image = Properties.Resources.p61;
                        break;
                    case 2:
                        pictureBox1.Image = Properties.Resources.p21;
                        break;
                    case 3:
                        pictureBox1.Image = Properties.Resources.p31;
                        break;
                    case 4:
                        pictureBox1.Image = Properties.Resources.p41;
                        break;
                    case 5:
                        pictureBox1.Image = Properties.Resources.p51;
                        break;

                
                }
        }
        Timer timer1 = new Timer();
        private bool draw;
        
        private void drawOn(object sender, MouseEventArgs e) {

            draw = true;
            Graphics g;
            
                g = Graphics.FromImage(drawSpace);
                Pen penpen = new Pen(Color.Black);
                g.DrawLine(penpen, 0, 0, MousePosition.X, MousePosition.Y);
                
            pictureBox2.Image = drawSpace;
        }
        private void drawOff(object sender, MouseEventArgs e)
        {

        }
        private bool shopEnabled;
        private void ShopClick(object sender, MouseEventArgs e) {
            shopDisable();
            shopEnabled = true;
            pictureBox1.Enabled = false;
            if (upgradeOn == false)
            {
                button2.Visible = true;
                button2.Enabled = true;
                label3.Visible = true;
            }
            if (botOn == false)
            {
                button3.Visible = true;
                button3.Enabled = true;
                label4.Visible = true;
            }
        }
        private bool upgradeBought;
        private bool upgradeOn;
        private void upgrade(object sender, MouseEventArgs e) {
            if (score >= 10) {
                upgradeOn = true;
                    score = score - 10;
                    upgradeScore = 5;
                shopDisable();
            }
        }
        static Timer timerBot1 = new Timer();
        private bool botOn;
        private bool botBought;
        private void bot(object sender, MouseEventArgs e) {
            if (score >= 100) {
                
                    score = score - 100;
                    botOn = true;
                    timerBot1.Tick += new EventHandler(botRun);
                    timerBot1.Interval = 5000;
                    timerBot1.Start();
                shopDisable();
            }
        }
        private void botRun(object sender, EventArgs e) {
            score = score + 10;
        }
        private void shopDisable() {
            if (shopEnabled)
            {
                shopEnabled = false;
                pictureBox1.Enabled = true;
                button2.Visible = false;
                button2.Enabled = false;
                label3.Visible = false;
                button3.Visible = false;
                button3.Enabled = false;
                label4.Visible = false;
            }
        }
    }
}
