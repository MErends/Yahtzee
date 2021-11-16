using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class Yahtzee : Form
    {
        int[] diceArray = new int[] { 0, 0, 0, 0, 0 };
        int numRoll = 0, count;
        bool gameRunning;

        public Yahtzee()
        {
            InitializeComponent();
        }

        private void checkUpper()
        {
            int upper = 0;
            if (!onesButton.Enabled && !twosButton.Enabled && !threesButton.Enabled && !foursButton.Enabled && !fivesButton.Enabled && !sixesButton.Enabled)
            {
                upper = Convert.ToInt16(onesLabel.Text) + Convert.ToInt16(twosLabel.Text) + Convert.ToInt16(threesLabel.Text) + Convert.ToInt16(foursLabel.Text) + Convert.ToInt16(fivesLabel.Text) + Convert.ToInt16(sixesLabel.Text);
                subtotalLabel.Text = upper.ToString();
                if (upper >= 63)
                {
                    bonusLabel.Text = "35";
                    upperLabel1.Text = upperLabel2.Text = (upper + 35).ToString();
                }
                else
                {
                    bonusLabel.Text = "0";
                    upperLabel1.Text = upperLabel2.Text = upper.ToString();
                }
            }
        }

        private void checkLower()
        {
            int lower = 0;
            if (!threeOfAKindButton.Enabled && !fourOfAKindButton.Enabled && !fullHouseButton.Enabled && !smallStraightButton.Enabled && !largeStraightButton.Enabled && !yahtzeeButton.Enabled && !chanceButton.Enabled)
            {
                lower = Convert.ToInt16(threeOfAKindLabel.Text) + Convert.ToInt16(fourOfAKindLabel.Text) + Convert.ToInt16(fullHouseLabel.Text) + Convert.ToInt16(smallStraightLabel.Text) + Convert.ToInt16(largeStraightLabel.Text) + Convert.ToInt16(yahtzeeLabel.Text) + Convert.ToInt16(chanceLabel.Text);
                lowerLabel.Text = lower.ToString();
            }
        }

        private void checkEnd()
        {
            if (lowerLabel.Text != "" && upperLabel2.Text != "")
            {
                int total = 0;
                total = Convert.ToInt16(lowerLabel.Text) + Convert.ToInt16(upperLabel2.Text);
                totalLabel.Text = total.ToString();
                gameRunning = false;
                rollButton.Enabled = false;
                MessageBox.Show("You finished the game with " + totalLabel.Text + " points! Well done!", "Congratulations");
            }
        }

        private int countNumber(int number)
        {
            count = 0;
            foreach (int i in diceArray) if (i == number) count++;
            return count;
        }

        private void clearDice()
        {
            clearChecks();
            enableChecks(false);
            numRoll = 0;
            remainingLabel.Text = "3";
            rollButton.Enabled = true;
            diceArray[0] = 0;
        }

        private void clearChecks()
        {
            foreach (Control control in checkPanel.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                checkBox.Checked = false;
            }
        }

        private void enableChecks(bool open)
        {
            foreach (Control control in checkPanel.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                checkBox.Enabled = open;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to quit?", "Quit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            var r = new Random();
            if (numRoll == 0) enableChecks(true);
            numRoll++;
            remainingLabel.Text = (3 - numRoll).ToString();
            if (!(checkBox1.Checked))
            {
                diceArray[0] = r.Next(1, 7);
                pictureBox1.ImageLocation = "images/die" + diceArray[0].ToString() + ".png";
            }
            if (!(checkBox2.Checked))
            {
                diceArray[1] = r.Next(1, 7);
                pictureBox2.ImageLocation = "images/die" + diceArray[1].ToString() + ".png";
            }
            if (!(checkBox3.Checked))
            {
                diceArray[2] = r.Next(1, 7);
                pictureBox3.ImageLocation = "images/die" + diceArray[2].ToString() + ".png";
            }
            if (!(checkBox4.Checked))
            {
                diceArray[3] = r.Next(1, 7);
                pictureBox4.ImageLocation = "images/die" + diceArray[3].ToString() + ".png";
            }
            if (!(checkBox5.Checked))
            {
                diceArray[4] = r.Next(1, 7);
                pictureBox5.ImageLocation = "images/die" + diceArray[4].ToString() + ".png";
            }
            if (numRoll == 3) rollButton.Enabled = false;
        }

        private void newGameMenuItem_Click(object sender, EventArgs e)
        {
            if (gameRunning)
            {
                if (MessageBox.Show("A game is in progress.\nAre you sure you want to start over?", "New game", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }
            clearDice();
            foreach (Control control in dicePanel.Controls)
            {
                PictureBox diePicture = control as PictureBox;
                diePicture.ImageLocation = "";
            }
            
            foreach (Control control in buttonPanel.Controls)
            {
                Button scoreButton = control as Button;
                scoreButton.Enabled = true;
            }

            foreach (Control control in scorePanel.Controls)
            {
                Label scoreLabel = control as Label;
                scoreLabel.Text = null;
            }
            gameRunning = true;
        }

        private void onesButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            onesLabel.Text = (countNumber(1)*1).ToString();
            onesButton.Enabled = false;
            clearDice();
            checkUpper();
            checkEnd();
        }

        public void twosButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            twosLabel.Text = (countNumber(2)*2).ToString();
            twosButton.Enabled = false;
            clearDice();
            checkUpper();
            checkEnd();
        }

        private void threesButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            threesLabel.Text = (countNumber(3)*3).ToString();
            threesButton.Enabled = false;
            clearDice();
            checkUpper();
            checkEnd();
        }

        private void foursButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            foursLabel.Text = (countNumber(4)*4).ToString();
            foursButton.Enabled = false;
            clearDice();
            checkUpper();
            checkEnd();
        }

        private void fivesButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            fivesLabel.Text = (countNumber(5)*5).ToString();
            fivesButton.Enabled = false;
            clearDice();
            checkUpper();
            checkEnd();
        }

        private void sixesButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            sixesLabel.Text = (countNumber(6)*6).ToString();
            sixesButton.Enabled = false;
            clearDice();
            checkUpper();
            checkEnd();
        }

        private void threeOfAKindButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            if ((countNumber(diceArray[0]) >= 3) || (countNumber(diceArray[1]) >= 3) || (countNumber(diceArray[2]) >= 3)) threeOfAKindLabel.Text = (diceArray.Sum()).ToString();
            else threeOfAKindLabel.Text = "0";
            threeOfAKindButton.Enabled = false;
            clearDice();
            checkLower();
            checkEnd();
        }

        private void fourOfAKindButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            if ((countNumber(diceArray[0]) >= 4) || (countNumber(diceArray[1]) >= 4)) fourOfAKindLabel.Text = (diceArray.Sum()).ToString();
            else fourOfAKindLabel.Text = "0";
            fourOfAKindButton.Enabled = false;
            clearDice();
            checkLower();
            checkEnd();
        }

        private void fullHouseButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            Array.Sort(diceArray);
            if ((diceArray[0] == diceArray[2]) && (diceArray[3] == diceArray[4]) && (diceArray[0] != diceArray[4]) || ((diceArray[0] == diceArray[1]) && (diceArray[2] == diceArray[4]) && (diceArray[0] != diceArray[4]))) fullHouseLabel.Text = "25";
            else fullHouseLabel.Text = "0";
            fullHouseButton.Enabled = false;
            clearDice();
            checkLower();
            checkEnd();
        }

        private void smallStraightButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            if ((diceArray.Contains(1) && diceArray.Contains(2) && diceArray.Contains(3) && diceArray.Contains(4)) || (diceArray.Contains(5) && diceArray.Contains(2) && diceArray.Contains(3) && diceArray.Contains(4)) || (diceArray.Contains(5) && diceArray.Contains(6) && diceArray.Contains(3) && diceArray.Contains(4))) smallStraightLabel.Text = "30";
            else smallStraightLabel.Text = "0";
            smallStraightButton.Enabled = false;
            clearDice();
            checkLower();
            checkEnd();
        }

        private void largeStraightButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            if ((diceArray.Contains(1) && diceArray.Contains(2) && diceArray.Contains(3) && diceArray.Contains(4) && diceArray.Contains(5)) || (diceArray.Contains(2) && diceArray.Contains(3) && diceArray.Contains(4) && diceArray.Contains(5) && diceArray.Contains(6))) largeStraightLabel.Text = "40";
            else largeStraightLabel.Text = "0";
            largeStraightButton.Enabled = false;
            clearDice();
            checkLower();
            checkEnd();
        }

        private void chanceButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return; else chanceLabel.Text = diceArray.Sum().ToString();
            chanceButton.Enabled = false;
            clearDice();
            checkLower();
            checkEnd();
        }

        private void yahtzeeButton_Click(object sender, EventArgs e)
        {
            if (diceArray[0] == 0) return;
            if (countNumber(diceArray[0]) == 5) yahtzeeLabel.Text = "50"; else yahtzeeLabel.Text = "0";
            yahtzeeButton.Enabled = false;
            clearDice();
            checkLower();
            checkEnd();
        }
    }
}
