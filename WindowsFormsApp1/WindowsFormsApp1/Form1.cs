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
        }
        
        private int picture = 0;
        private int score = 0;
        private string endings;
        private void Image1_Clicked(object sender, MouseEventArgs e) {
           
                picture = picture + 1;
                score = score + 1;
                if (picture >= 6) {
                    picture = 0;
                }
                endings = "test";
                label2.Text = "" + score + endings + "";
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
    }
}
