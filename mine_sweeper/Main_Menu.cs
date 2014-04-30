using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace mine_sweeper{
    public partial class Main_Menu : Form{
        int mines, size;
        minesweeper game;
        Player player;
        TextBox txtSize = new TextBox();
        TextBox txtMines = new TextBox();
        TextBox txtPlayer = new TextBox();
        Label lblSize = new Label();
        Label lblMines = new Label();
        Label lblPlayer = new Label();

        public Main_Menu(){
            InitializeComponent();
            this.Size = new Size(235, 280);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Button newGame = new Button();
            Button stats = new Button();
            
            newGame.Text = "Start a new game";
            stats.Text = "Show stats";
            lblMines.Text = "Number of mines:";
            lblSize.Text = "Size of field:";
            lblPlayer.Text = "Player Name:";
            
            newGame.Size = new Size(200, 60);
            lblMines.Size = new Size(100, 30);
            txtMines.Size = new Size(100, 30);
            lblSize.Size = new Size(100, 30);
            txtSize.Size = new Size(100, 30);
            lblPlayer.Size = new Size(100, 30);
            txtPlayer.Size = new Size(200, 30);
            stats.Size = new Size(200, 60);
            
            newGame.Location = new Point(10, 5);
            txtMines.Location = new Point(110, 90);
            lblMines.Location = new Point(110, 70);
            txtSize.Location = new Point(10, 90);
            lblSize.Location = new Point(10, 70);
            txtPlayer.Location = new Point(10, 140);
            lblPlayer.Location = new Point(10, 120);
            stats.Location = new Point(10, 170);
            
            newGame.Click += new EventHandler(startNewGame);
            stats.Click += new EventHandler(showStats);
            txtSize.GotFocus += new EventHandler(clearTextBox);
            txtMines.GotFocus += new EventHandler(clearTextBox);
            txtSize.LostFocus += new EventHandler(checkTextBox);
            txtMines.LostFocus += new EventHandler(checkTextBox);
            
            this.Controls.Add(txtMines);
            this.Controls.Add(txtSize);
            this.Controls.Add(newGame);
            this.Controls.Add(txtPlayer);
            this.Controls.Add(lblMines);
            this.Controls.Add(lblPlayer);
            this.Controls.Add(lblSize);
            this.Controls.Add(stats);
            this.AcceptButton = newGame;
            txtSize.Focus();
        }

        private void startNewGame(object sender, EventArgs e){
            try {
                mines = Convert.ToInt16(txtMines.Text);
                size = Convert.ToInt16(txtSize.Text);
                if (txtPlayer.Text == ""){
                    player = new Player("Anonymous");
                }
                player = new Player(txtPlayer.Text);
                if (size * size < mines){
                    mines = (size * size) - 1;
                    MessageBox.Show(String.Format("Number of mines cannot exceed size of the field.\nSettings mines to {0}", mines));
                }
            }catch{
                mines = 10;
                size = 10;
                player = new Player("Anonymous");
            }
            game = new minesweeper(size, mines, player.getGames(), player.getWins(), player.getLosses());
            GUI_form gui = new GUI_form(game, size, mines, player);
            this.Hide();
            gui.ShowDialog();
            this.Show();
        }

        private void showStats(object sender, EventArgs e){
            Form statsPage = new Form();

            const string connectString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:/users/tbell/source/repos/game/mine_sweeper/minesweeper.accdb;";
            OleDbConnection myConnection = new OleDbConnection(connectString);
            string selectStats = "SELECT * FROM players";
            DataSet dataset = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectStats, myConnection);
            dataAdapter.Fill(dataset);

            ListBox results = new ListBox();
            foreach(DataRow row in dataset.Tables[0].Rows){
                Label player = new Label();
                Label games = new Label();
                Label wins = new Label();
                Label losses = new Label();
                player.Text = Convert.ToString(row["player"]);
                games.Text = Convert.ToString(row["games"]);
                wins.Text = Convert.ToString(row["wins"]);
                losses.Text = Convert.ToString(row["losses"]);

            }

            this.Hide();
            statsPage.ShowDialog();
            this.Show();
            
        }

        private void checkTextBox(object sender, EventArgs e){
            TextBox textbox = sender as TextBox;
            int input;
            try {
                input = Convert.ToInt16(textbox.Text);
                if(input < 1){
                    MessageBox.Show("Please enter a value greater than zero.");
                }
                textbox.Text = Convert.ToString(input);
            }catch{
                textbox.Text = "10";
            }
        }

        private void clearTextBox(object sender, EventArgs e){
            TextBox textbox = sender as TextBox;
            textbox.Text = "";
        }
    }
}