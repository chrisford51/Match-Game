using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match_Game
{
    public partial class Form1 : Form
    {
        //firstClicked points to the first Label Control that the player
        //clicks, but it will be null if the player hasn't clicked a label yet
        Label firstClicked = null;

        //secondClicked points to the second Label control that the player clicks
        Label secondClicked = null;

        //Use this Random object to choose random icons for the squares
        Random random = new Random();

        //Each of these letters is an interesting icon in the Wingdins font,
        // and each icon appears twice in the list
        List<string> icons = new List<string>()
        {
            "N", "N", "B", "B", "C", "C", "E", "E", "D", "D", "G", "G", "K", "K", "I", "I"
        };

        //Assign each icon from the list of icons to a random square
        private void AssignIconsToSquares()
        {
            //The TableLayoutPanel has 16 Labels, and the icon list has 16 icons,
            //so an icon is pulled at random from the list and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        //Every label's Click event is handled by this event handler
        // 'sender' being the label that was clicked
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                //If the clicked label is black, the player clicked an icon that's
                //already been revealed -- ignore the click
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                //If firstClicked is null, this is the first icon in the pair the 
                //player clicked, so set firstClicked to the label that the player
                //clicked, change its color to black and return
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }
            }
        }
    }
}
