using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwentyOneGame_MatthewPrindle
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int total = 0;
        int previoustotal = 0;
        int dice1=0;
        int dice2=0;
        int diceTotal = 0;
        
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        private void rollBtn_Click(object sender, EventArgs e)
        {
            previoustotal = total;
            
            if (total < 15)
            {
                rollBtn.Text = "Roll Two Dice!";
                dice1 = RollDice();
                dice2 = RollDice();
                diceTotal = dice1 + dice2;
                total = dice1 + dice2 + total;
                DisplayData();
                checkVictory();
                if (total >= 15) { rollBtn.Text = "Roll One Dice!"; }
            }
            else if (total >= 15)
            {
                rollBtn.Text = "Roll One Dice!";
                dice1 = RollDice();
                dice2 = 0;
                diceTotal = dice1;
                total = dice1 + dice2 + total;
                DisplayData();
                checkVictory();
            }
        }
        public int RollDice()
        {
            int result = 0;
            result = rnd.Next(1,6);
            return result;
        }
        public void DisplayData()
        {
            previousTotalTxtB.Text = Convert.ToString(previoustotal);
            totalTxtB.Text = Convert.ToString(total);
            dice1ValueTxtB.Text = Convert.ToString(dice1);
            dice2ValueTxtB.Text = Convert.ToString(dice2);
            diceTotalTxtB.Text = Convert.ToString(diceTotal);
            
        }
        public void checkVictory()
        {
            if (total == 21) { MessageBox.Show("Winner Winner Chicken Dinner! Lucky You!"); Reset(); }
            else if (total > 21) { MessageBox.Show("You have gone over 21, too bad, you have lost"); Reset(); }
        }
        public void Reset()
        {
            rollBtn.Text = "Roll Two Dice!";
            total = 0;
            previoustotal = 0;
            dice1 = 0;
            dice2 = 0;
            diceTotal = 0;
            DisplayData();
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
