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
    public partial class GUI : Form{
        const int size = 10;
        const int mines = 2;
        int wins = 0;
        int losses = 0;

        public minesweeper game = new minesweeper(size, mines);
        public GUI(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
            game.drawField();
            txtOuput.Text =  game.drawGame();
        }

        private void btnSubmit_Click(object sender, EventArgs e){
            int x = Convert.ToInt16(txtX.Text)-1;
            int y = Convert.ToInt16(txtY.Text)-1;
            if (validatePlot(x,y)){
                game.makeMove(x, y);
            }
            afterClick();
        }

        private void btnFlag_Click(object sender, EventArgs e){
            int x = Convert.ToInt16(txtX.Text) - 1;
            int y = Convert.ToInt16(txtY.Text) - 1;
            if (validatePlot(x, y)){
                game.flagCell(x, y);
            }
            afterClick();
        }

        private bool validatePlot(int x, int y){

            if (x >= size || y >= size){
                MessageBox.Show(String.Format("Please check that your input is between 1 and {0}.", size));
                return false;
            }else{
                return true;
            }
        }

        private void afterClick(){
            txtX.Clear();
            txtY.Clear();
            txtOuput.Text = game.drawGame();
            if (game.gameWon()){
                gameOver(true);
            }else if(game.gameLost()){
                gameOver(false);
            }
        }

        public void gameOver(bool gameState){
            btnFlag.Enabled = false;
            btnSubmit.Enabled = false;
            txtOuput.Text = game.drawGame();
            if (gameState){
                wins++;
            }else{
                losses++;
            }
            End_of_Game eog = new End_of_Game(wins, losses, gameState, game);
            eog.Show();
        }
    }
}
