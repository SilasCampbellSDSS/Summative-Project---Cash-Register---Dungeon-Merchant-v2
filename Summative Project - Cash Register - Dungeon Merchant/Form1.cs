using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //allows the use of Thread.Sleep()
using System.Media; //allows the use of Sound Player

namespace Summative_Project___Cash_Register___Dungeon_Merchant
{
    public partial class dungeonMerchant : Form

    {
        //Used control K-D to fix formatting errors
        //Changed some of the fonts and designs to make them more visible
        //Also made the UI more consistent

        //globalvariables
        double weaponPrice = 1200;
        double armourPrice = 500;
        double potionPrice = 125;
        int weaponAmount = 0;
        int armourAmount = 0;
        int potionAmount = 0;
        double subtotal = 0;
        double taxRate = 0.13;
        double taxAmount = 0;
        double totalCost = 0;
        int tendered = 0;
        double change = 0;



        public dungeonMerchant()
        {
            InitializeComponent();
        }

        private void merchantInteract_Click(object sender, EventArgs e)
        {
            //Begining of the program starts by interacting with the merchant
            {

                weaponLabel.Visible = true;
                weaponText.Visible = true;
                armourLabel.Visible = true;
                armourText.Visible = true;
                potionLabel.Visible = true;
                potionText.Visible = true;
                calculateButton.Visible = true;
            }

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Calculates how much your order will cost you

                weaponAmount = Convert.ToInt32(weaponText.Text);
                armourAmount = Convert.ToInt32(armourText.Text);
                potionAmount = Convert.ToInt32(potionText.Text);

                subtotal = (weaponPrice * weaponAmount) + (armourPrice * armourAmount) + (potionPrice * potionAmount);
                taxAmount = (subtotal * taxRate);
                totalCost = (taxAmount + subtotal);

                subtotalOutput.Text = $"{subtotal.ToString("C")}";
                taxOutput.Text = $"{taxAmount.ToString("C")}";
                totalOutput.Text = $"{totalCost.ToString("C")}";

                subtotalLabel.Visible = true;
                subtotalOutput.Visible = true;
                taxLabel.Visible = true;
                taxOutput.Visible = true;
                totalLabel.Visible = true;
                totalOutput.Visible = true;
                tenderedLabel.Visible = true;
                tenderedText.Visible = true;
                changeButton.Visible = true;
                changeText.Visible = true;
                receiptButton.Visible = true;
            }
            catch
            {
                //Added a welcome message to help prompt you to click on the merchant,
                //so I also added a command to turn the text red if you try and cheat

                merchantTextLabel.ForeColor = Color.Red;
                merchantTextLabel.Text = "Hey! What are you trying to pull?!?";
                Refresh();
                Thread.Sleep(3000);

                merchantTextLabel.Text = "";

                //Removed close command
            }
        }
        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Calculates the required change that must be given depending on your order and how much was tendered

                tendered = Convert.ToInt32(tenderedText.Text);

                change = tendered - totalCost;

                changeText.Text = $"{change.ToString("C")}";


                if (tendered < (totalCost))
                {
                    merchantTextLabel.Text = "Hey! What are you trying to pull?!?";
                    changeText.Text = "";

                    Refresh();
                    Thread.Sleep(3000);

                    merchantTextLabel.Text = "";
                }


                
                if (tendered < (totalCost))
                {
                    merchantTextLabel.Text = "Hey! What are you trying to pull?!?";

                    subtotalLabel.Visible = false;
                    subtotalOutput.Visible = false;
                    taxLabel.Visible = false;
                    taxOutput.Visible = false;
                    totalLabel.Visible = false;
                    totalOutput.Visible = false;
                    tenderedLabel.Visible = false;
                    tenderedText.Visible = false;
                    changeButton.Visible = false;
                    changeText.Visible = false;
                    receiptButton.Visible = false;

                    receiptLabel.Text = "";
                    weaponText.Text = "";
                    armourText.Text = "";
                    potionText.Text = "";
                    tenderedText.Text = "";
                    changeText.Text = "";

                    weaponAmount = 0;
                    armourAmount = 0;
                    potionAmount = 0;
                    subtotal = 0;
                    taxAmount = 0;
                    totalCost = 0;
                    tendered = 0;
                    change = 0;

                    Refresh();
                    Thread.Sleep(3000);

                    merchantTextLabel.Text = "";
                }

                this.Close();

            }
            catch
            {
                //Added a welcome message to help prompt you to click on the merchant,
                //so I also added a command to turn the text red if you try and cheat

                merchantTextLabel.ForeColor = Color.Red;
                merchantTextLabel.Text = "Hey! What are you trying to pull?!?";

                Refresh();
                Thread.Sleep(3000);

                merchantTextLabel.Text = "";

                //Removed close command
            }


        }
        private void receiptButton_Click(object sender, EventArgs e)
        {
            //Starts to print the receipt with all of the necessary things shown

            //Edited font to make the items on the receipt line up, added an extra \n to the date

            SoundPlayer player = new SoundPlayer(Properties.Resources.receiptPrinter);
            player.Play();

            receiptLabel.Visible = true;

            receiptLabel.Text += $"\nThe dungeon merchant";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\n\nDecember 19th, 1012";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\n\nNumber of Weapons: {weaponAmount}";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\nPieces of Armour: {armourAmount}";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\nNumber of potions: {potionAmount}";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\n\nSubtotal: ${subtotal}";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\nTax: ${taxAmount}";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\nTotal Price: ${totalCost} \n\n";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\n\nTendered: ${tendered}";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\nChange: ${change}";

            Refresh();
            Thread.Sleep(800);

            receiptLabel.Text += $"\n\nGood luck on \n your quest \n adventurer!";

            Refresh();
            Thread.Sleep(800);

            merchantTextLabel.Text = "Order again?";
        }


        private void merchantTextLabel_Click_1(object sender, EventArgs e)
        {
            //Changed the name of the label to avoid confusion
            //Also made all of the new order button completely clear the screen

            weaponLabel.Visible = false;
            weaponText.Visible = false;
            armourLabel.Visible = false;
            armourText.Visible = false;
            potionLabel.Visible = false;
            potionText.Visible = false;
            subtotalLabel.Visible = false;
            subtotalOutput.Visible = false;
            calculateButton.Visible = false;
            taxLabel.Visible = false;
            taxOutput.Visible = false;
            totalLabel.Visible = false;
            totalOutput.Visible = false;
            tenderedLabel.Visible = false;
            tenderedText.Visible = false;
            changeButton.Visible = false;
            changeText.Visible = false;
            receiptButton.Visible = false;
            receiptLabel.Visible = false;

            merchantTextLabel.Text = "";
            receiptLabel.Text = "";
            weaponText.Text = "";
            armourText.Text = "";
            potionText.Text = "";
            tenderedText.Text = "";
            changeText.Text = "";

            weaponAmount = 0;
            armourAmount = 0;
            potionAmount = 0;
            subtotal = 0;
            taxAmount = 0;
            totalCost = 0;
            tendered = 0;
            change = 0;
        }
    }
}
