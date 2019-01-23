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
        private NetworkStuff networkSingleton = NetworkStuff.getNetworkStuffSingleton();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string returnCode = ""; //networkSingleton.sendCardData(pullDataFromTextBoxes());
            Console.WriteLine("Return Code:" + returnCode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void cardNumberBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private string[] pullDataFromTextBoxes()
        {
            string[] cardData = new string[3];
            cardData[0] = cardNumberBox.Text;
            cardData[1] = expDateBox.Text;
            cardData[2] = securityCodeBox.Text;
            return cardData;
        }

    }
}
