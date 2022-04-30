using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary_Calculator_Tryout
{
    // programmed by MOOICT.COM 2022
    // for educational purpose only

    public partial class Form1 : Form
    {

        int[] binaryValues = {1, 2, 4, 8, 16, 32, 64, 128, 256 };

        Random random = new Random();

        List<ComboBox> comboBoxes = new List<ComboBox>();
       

        int total;
        int questionNumber;

        Label lblTotal = new Label();
        Label question = new Label();
        Label header = new Label();

        public Form1()
        {
            InitializeComponent();

            loadComboBoxes();
        }

        private void loadComboBoxes()
        {
            Array.Reverse(binaryValues); // reverse the binary numbers array


            questionNumber = 10; // generate a random number between 1 and 510

            this.BackColor = Color.FromArgb(64, 64, 64); // dark background


            // 
            header.Text = "Binary Calculator Game" + Environment.NewLine + "by MOO ICT";
            header.AutoSize = false;
            header.Width = this.ClientSize.Width;
            header.Height = 70;
            header.TextAlign = ContentAlignment.MiddleCenter;
            header.ForeColor = Color.White;
            header.Font = new Font("Arial", 20);

            this.Controls.Add(header);


            
            question.Text = "What is - " + questionNumber +  " - in Binary?";
            question.AutoSize = false;
            question.Width = this.ClientSize.Width;
            question.Height = 50;
            question.TextAlign = ContentAlignment.MiddleCenter;
            question.ForeColor = Color.LightGreen;
            question.Font = new Font("Arial", 20);
            question.Top = 180;

            this.Controls.Add(question);



            lblTotal.Text = "Total: " + total;
            lblTotal.AutoSize = false;
            lblTotal.Width = this.ClientSize.Width;
            lblTotal.Height = 50;
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            lblTotal.ForeColor = Color.White;
            lblTotal.Font = new Font("Arial", 20);
            lblTotal.Top = 230;

            this.Controls.Add(lblTotal);




            // for the combo box and labels
            int x = 30;
            int y = 120;

            for (int i = 0; i < 9; i++)
            {
                ComboBox comboBox = new ComboBox();

                comboBox.Width = 50;
                comboBox.Items.Add("0");
                comboBox.Items.Add("1");
                comboBox.SelectedIndex = 0;
                comboBox.Font = new Font("Arial", 16);
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Tag = binaryValues[i].ToString();
                comboBox.Left = x;
                comboBox.Top = y;
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                comboBoxes.Add(comboBox);

                Label lblVal = new Label();
                lblVal.Text = binaryValues[i].ToString();
                lblVal.Font = new Font("Arial", 16);
                lblVal.Location = new Point(x, y - 32);
                lblVal.AutoSize = false;
                lblVal.Height = 30;
                lblVal.Width = 50;

                Color c = Color.FromArgb(random.Next(200, 255), random.Next(150, 255), random.Next(150, 255));

                lblVal.BackColor = c;
                lblVal.ForeColor = Color.Black;
                lblVal.TextAlign = ContentAlignment.MiddleCenter;

                comboBox.BackColor = c;

                this.Controls.Add(comboBox);
                this.Controls.Add(lblVal);
                x += 60;
            }

        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string binaryCode = null;
            total = 0;

            foreach (ComboBox combo in comboBoxes)
            {

                if (combo.SelectedIndex == 1)
                {

                    int i = Convert.ToInt32(combo.Tag);

                    total += i;
                }

                binaryCode += combo.Text;
            }

           lblTotal.Text = "Total: " + total + " Binary:" + binaryCode;

            if (total == questionNumber)
            {
                
                MessageBox.Show("Correct! Well done, Now try another", "MOO Says");
                questionNumber = random.Next(1, 510);

                question.Text = "What is - " + questionNumber + " - in Binary?";

                total = 0;
                binaryCode = null;

                ResetBoxes();

                lblTotal.Text = "Total: " + total + " Binary:" + binaryCode;

            }


        }

        public void ResetBoxes()
        {
            foreach (ComboBox combo in comboBoxes)
            {
                combo.SelectedIndex = 0;
            }
        }

    }
}
