using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mine_sweeper{
    public partial class Main_Menu : Form{
        int wins, losses, games, mines, size;
        TextBox txtSize = new TextBox();
        TextBox txtMines = new TextBox();

        public Main_Menu(){
            InitializeComponent();
            this.Size = new Size(300, 300);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Button newGame = new Button();
            
            newGame.Text = "Start a new game";
            txtMines.Text = "Mines";
            txtSize.Text = "Size";
            
            newGame.Size = new Size(100, 30);
            txtMines.Size = new Size(50, 30);
            txtSize.Size = new Size(50, 30); 
            
            newGame.Location = new Point(100, 5);
            txtMines.Location = new Point(150, 40);
            txtSize.Location = new Point(100, 40);
            
            newGame.Click += new EventHandler(startNewGame);
            txtSize.GotFocus += new EventHandler(clearTextBox);
            txtMines.GotFocus += new EventHandler(clearTextBox);
            txtSize.LostFocus += new EventHandler(checkTextBox);
            txtMines.LostFocus += new EventHandler(checkTextBox);
            
            this.Controls.Add(txtMines);
            this.Controls.Add(txtSize);
            this.Controls.Add(newGame);
        }

        private void startNewGame(object sender, EventArgs e){
            mines = Convert.ToInt16(txtMines.Text);
            size = Convert.ToInt16(txtSize.Text);
        }

        private void checkTextBox(object sender, EventArgs e){
            TextBox textbox = sender as TextBox;
            int input;
            try {
                input = Convert.ToInt16(textbox.Text);
            }
            catch {
                input = 100;
            }
            if(input == null || input < 1){
                MessageBox.Show("Please enter a value greater than zero.");
            }
            textbox.Text = Convert.ToString(input);
        }

        private void clearTextBox(object sender, EventArgs e){
            TextBox textbox = sender as TextBox;
            textbox.Text = "";
        }
    }
}
