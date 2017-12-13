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

            pictureBox2.MouseDown += new MouseEventHandler(pictureBox2_MouseDown);
            pictureBox2.MouseUp += new MouseEventHandler(pictureBox2_MouseUp);
            pictureBox2.MouseMove += new MouseEventHandler(pictureBox2_MouseMove);

            button4.MouseClick += new MouseEventHandler(reset);
            button5.MouseClick += new MouseEventHandler(redBuy);
            button6.MouseClick += new MouseEventHandler(redPick);
            button7.MouseClick += new MouseEventHandler(blackPick);
            button13.MouseClick += new MouseEventHandler(whitePick);
            button8.MouseClick += new MouseEventHandler(orangePick);

            button14.MouseClick += new MouseEventHandler(orangeBuy);
            button15.MouseClick += new MouseEventHandler(yellowBuy);
            button16.MouseClick += new MouseEventHandler(greenBuy);
            button17.MouseClick += new MouseEventHandler(blueBuy);
            button18.MouseClick += new MouseEventHandler(purpleBuy);

            button8.MouseClick += new MouseEventHandler(orangePick);
            button9.MouseClick += new MouseEventHandler(yellowPick);
            button10.MouseClick += new MouseEventHandler(greenPick);
            button11.MouseClick += new MouseEventHandler(bluePick);
            button12.MouseClick += new MouseEventHandler(purplePick);

            button19.MouseClick += new MouseEventHandler(saveImage);
            button20.MouseClick += new MouseEventHandler(loadImage);
             g = pictureBox2.CreateGraphics();
            
        }
        
        private void showscore(object sender, EventArgs e)
        {

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
        private double score = 0;
        private double scoreToDisplay;
        private string endings;
        private double upgradeScore = 1;
        private void Image1_Clicked(object sender, MouseEventArgs e)
        {

            picture = picture + 1;
            score = score + upgradeScore;

            if (picture >= 6)
            {
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
        Graphics g;
        Bitmap saved;
        Bitmap load;
        private void saveImage(object sender, MouseEventArgs e) {
            saved = new Bitmap(pictureBox2.Width, pictureBox2.Height, g);
            try
            {
                saved.Save("c:\\BitCoinImage.png", System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("Saved");
            }
            catch (Exception) {
                MessageBox.Show("There was a problem saving! Check file permissions.");
            }
        }
        private void loadImage(object sender, MouseEventArgs e) {
            try
            {
                load = new Bitmap("c:\\BitCoinImage.png");
                pictureBox2.Image = load;
            }
            catch (Exception) {
                MessageBox.Show("File was not loaded correctly or does not exsit.");
            }
        }
        SolidBrush brush;
        private bool draw;
        private Color colorBrush = Color.Black;

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            brush = new SolidBrush(colorBrush);
            g.FillRectangle(brush, e.X, e.Y, 10, 10);
            draw = true;

        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {


                brush = new SolidBrush(colorBrush);
                g.FillRectangle(brush, e.X, e.Y, 10, 10);

            }
        }
        Bitmap bitcoin = Properties.Resources.bcoin;
        private void reset(object sender, MouseEventArgs e)
        {
            
            g.Clear(pictureBox2.BackColor);
            pictureBox2.Image = bitcoin;
        }
        private bool redOn;

        private void redBuy(object sender, MouseEventArgs e)
        {

            if (score >= 50)
            {
                score = score - 50;
                redOn = true;
                button6.Visible = true;
                button6.Enabled = true;
                shopDisable();
            }


        }
        private void redPick(object sender, MouseEventArgs e)
        {

            colorBrush = Color.Red;

        }
        private bool orangeOn;

        private void orangeBuy(object sender, MouseEventArgs e)
        {

            if (score >= 50)
            {
                score = score - 50;
                orangeOn = true;
                button8.Visible = true;
                button8.Enabled = true;
                shopDisable();
            }


        }
        private void orangePick(object sender, MouseEventArgs e)
        {

            colorBrush = Color.Orange;

        }
        private bool yellowOn;

        private void yellowBuy(object sender, MouseEventArgs e)
        {

            if (score >= 50)
            {
                score = score - 50;
                yellowOn = true;
                button9.Visible = true;
                button9.Enabled = true;
                shopDisable();
            }


        }
        private void yellowPick(object sender, MouseEventArgs e)
        {

            colorBrush = Color.Yellow;

        }
        private bool greenOn;

        private void greenBuy(object sender, MouseEventArgs e)
        {

            if (score >= 50)
            {
                score = score - 50;
                greenOn = true;
                button10.Visible = true;
                button10.Enabled = true;
                shopDisable();
            }


        }
        private void greenPick(object sender, MouseEventArgs e)
        {

            colorBrush = Color.Green;

        }
        private bool blueOn;

        private void blueBuy(object sender, MouseEventArgs e)
        {

            if (score >= 50)
            {
                score = score - 50;
                blueOn = true;
                button11.Visible = true;
                button11.Enabled = true;
                shopDisable();
            }


        }
        private void bluePick(object sender, MouseEventArgs e)
        {

            colorBrush = Color.Blue;

        }
        private bool purpleOn;

        private void purpleBuy(object sender, MouseEventArgs e)
        {

            if (score >= 50)
            {
                score = score - 50;
                purpleOn = true;
                button12.Visible = true;
                button12.Enabled = true;
                shopDisable();
            }


        }
        private void purplePick(object sender, MouseEventArgs e)
        {

            colorBrush = Color.Purple;

        }
        private void blackPick(object sender, MouseEventArgs e)
        {
            colorBrush = Color.Black;
        }
        private void whitePick(object sender, MouseEventArgs e)
        {
            colorBrush = Color.White;
        }
        private bool shopEnabled;
        private void ShopClick(object sender, MouseEventArgs e)
        {
            shopDisable();
            shopEnabled = true;

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

            if (redOn == false)
            {
                button5.Visible = true;
                button5.Enabled = true;
                label1.Visible = true;
            }
            if (orangeOn == false)
            {
                button14.Visible = true;
                button14.Enabled = true;
                label5.Visible = true;
            }
            if (yellowOn == false)
            {
                button15.Visible = true;
                button15.Enabled = true;
                label6.Visible = true;
            }
            if (greenOn == false)
            {
                button16.Visible = true;
                button16.Enabled = true;
                label7.Visible = true;
            }
            if (blueOn == false)
            {
                button17.Visible = true;
                button17.Enabled = true;
                label8.Visible = true;
            }
            if (purpleOn == false)
            {
                button18.Visible = true;
                button18.Enabled = true;
                label9.Visible = true;
            }
        }
        
        private bool upgradeOn;
        private void upgrade(object sender, MouseEventArgs e)
        {
            if (score >= 30)
            {
                upgradeOn = true;
                score = score - 30;
                upgradeScore = 2;
                shopDisable();
            }
        }
        static Timer timerBot1 = new Timer();
        private bool botOn;
        
        private void bot(object sender, MouseEventArgs e)
        {
            if (score >= 100)
            {

                score = score - 100;
                botOn = true;
                timerBot1.Tick += new EventHandler(botRun);
                timerBot1.Interval = 5000;
                timerBot1.Start();
                shopDisable();
            }
        }
        private void botRun(object sender, EventArgs e)
        {
            score = score + 10;
        }
        private void shopDisable()
        {
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
                button5.Visible = false;
                button5.Enabled = false;
                label1.Visible = false;
                button14.Visible = false;
                button14.Enabled = false;
                label5.Visible = false;
                button15.Visible = false;
                button15.Enabled = false;
                label6.Visible = false;
                button16.Visible = false;
                button16.Enabled = false;
                label7.Visible = false;
                button17.Visible = false;
                button17.Enabled = false;
                label8.Visible = false;
                button18.Visible = false;
                button18.Enabled = false;
                label9.Visible = false;
            }
        }

    }
}

