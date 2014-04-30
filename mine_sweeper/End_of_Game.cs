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
    public partial class End_of_Game : Form{
        public End_of_Game(int wins, int losses, bool gameState, int games, string player){
            InitializeComponent();
            string gameStateText;
            if (gameState) {
                gameStateText = String.Format("{0}, You Won!", player);
            }else {
                gameStateText = String.Format("{0}, You Lost!", player);
            }
            lblGameState.Text = gameStateText;
            lblLosses.Text = losses.ToString();
            lblWins.Text = wins.ToString();
            lblGames.Text = games.ToString();
        }

        private void btnQuit_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}