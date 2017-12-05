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
        }
        
        private int picture = 0;
        private double score = 999997;
        private double scoreToDisplay;
        private string endings;
        private void Image1_Clicked(object sender, MouseEventArgs e) {
           
                picture = picture + 1;
                score = score + 1;
            if (score < 1000000) {
                scoreToDisplay = score;
                endings = "";
            }
            if (1000000 <= score && score < 1000000000) {
                scoreToDisplay = Math.Round((score / 1000000), 5);
               
                endings = "Million";
            }
            if (1000000000 <= score && score < 1000000000000) {
                scoreToDisplay = Math.Round((score / 1000000000), 5);
               
                endings = "Billion";
            }
                if (picture >= 6) {
                    picture = 0;
                }
                
                label2.Text = "" + scoreToDisplay + endings + "";
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

        private void ShopClick(object sender, MouseEventArgs e) {
            pictureBox1.Enabled = false;
            button2.Visible = true;
            button2.Enabled = true;
            label3.Visible = true;
        }
        private void upgrade(object sender, MouseEventArgs e) {

        }
    }
}
