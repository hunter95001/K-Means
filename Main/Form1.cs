using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_Means.Main;         //Lookup 폼을 불러오기 위해서
using K_Means.Processing;   //전처리, AI기법을 불러오기 위해서 

namespace K_Means
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        String imagePath;

        public Form1()
        {
            //Part #1 초기화 부분 
            InitializeComponent();
            imagePath = "C:\\Users\\KYJ\\Desktop\\Git Hub\\K-Means\\K-Means\\Image\\Observer.jpg";
            bitmap = new Bitmap(imagePath);

            //Part #2 
            Pretreatment prtment = new Pretreatment(new Bitmap(bitmap));
            prtment.Gray();

            // Part #3 A.I 
            AI aI = new AI(new Bitmap(prtment.getBitmap()));
            aI.Kmeans();
            

            // Part #4 View
            Lookup lookup = new Lookup(aI.getBitmap());
            lookup.Show();

            pictureBox1.Image = bitmap;
            pictureBox2.Image = prtment.getBitmap();
            pictureBox3.Image = aI.getBitmap();
        }
    }
}
