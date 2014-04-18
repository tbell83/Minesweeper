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
        int mines, size;
        minesweeper game;
        Player player;
        TextBox txtSize = new TextBox();
        TextBox txtMines = new TextBox();
        TextBox txtPlayer = new TextBox();

        public Main_Menu(){
            InitializeComponent();
            this.Size = new Size(120, 130);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Button newGame = new Button();
            
            newGame.Text = "Start a new game";
            txtMines.Text = "Mines";
            txtSize.Text = "Size";
            txtPlayer.Text = "Player Name";
            
            newGame.Size = new Size(100, 30);
            txtMines.Size = new Size(50, 30);
            txtSize.Size = new Size(50, 30);
            txtPlayer.Size = new Size(100, 30);
            
            newGame.Location = new Point(10, 5);
            txtMines.Location = new Point(60, 40);
            txtSize.Location = new Point(10, 40);
            txtPlayer.Location = new Point(10, 65);
            
            newGame.Click += new EventHandler(startNewGame);
            txtSize.GotFocus += new EventHandler(clearTextBox);
            txtMines.GotFocus += new EventHandler(clearTextBox);
            txtSize.LostFocus += new EventHandler(checkTextBox);
            txtMines.LostFocus += new EventHandler(checkTextBox);
            
            this.Controls.Add(txtMines);
            this.Controls.Add(txtSize);
            this.Controls.Add(newGame);
            this.Controls.Add(txtPlayer);

            newGame.Focus();
        }

        private void startNewGame(object sender, EventArgs e){
            mines = Convert.ToInt16(txtMines.Text);
            size = Convert.ToInt16(txtSize.Text);
            player = new Player(txtPlayer.Text);
            game = new minesweeper(size, mines, player.getGames(), player.getWins(), player.getLosses());
            GUI_form gui = new GUI_form(game, size, mines, player);
            gui.ShowDialog();
        }

        private void checkTextBox(object sender, EventArgs e){
            TextBox textbox = sender as TextBox;
            int input;
            try {
                input = Convert.ToInt16(textbox.Text);
            }
            catch {
                input = 10;
            }
            if(input < 1){
                MessageBox.Show("Please enter a value greater than zero.");
            }
            textbox.Text = Convert.ToString(input);
        }

        private void clearTextBox(object sender, EventArgs e){
            TextBox textbox = sender as TextBox;
            if(textbox == null){
                textbox.Text = "";
            }
        }
    }
}
