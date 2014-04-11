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
    public partial class GUI_form : Form{
        const int size = 3;
        const int mines = 1;
        int wins = 0;
        int losses = 0;
        Button[,] grid;

        public minesweeper game = new minesweeper(size, mines);

        public GUI_form(){
            InitializeComponent();
            generateGrid();
        }

        private void Form1_Load(object sender, EventArgs e){
            game.drawField();
            this.Size = new System.Drawing.Size((size * 30) + 17, (size * 30) + 38);
        }

        private void afterClick(){
            if (game.gameWon()){
                gameOver(true);
            }else if(game.gameLost()){
                gameOver(false);
            }
        }

        public void gameOver(bool gameState){
            if (gameState){
                wins++;
            }else{
                losses++;
            }
            End_of_Game eog = new End_of_Game(wins, losses, gameState);
            eog.Show();
            game.reset();
        }

        public void generateGrid(){
            grid = new Button[size,size];
            for(int x = 0;x < size;x++){
                for(int y = 0;y < size;y++){
                    Button button = new Button();
                    button.Location = new Point(x*30,y*30);
                    button.Size = new Size(30, 30);
                    button.Text = string.Format("{0},{1}", x, y);
                    button.MouseDown += new MouseEventHandler((s, e) => cellClick(s, e, x, y));
                    grid[x, y] = button;
                    this.Controls.Add(button);
                }
            }
        }

        public void cellClick(object sender, MouseEventArgs e, int x, int y){
            if(e.Button == System.Windows.Forms.MouseButtons.Left){
                MessageBox.Show(string.Format("Left {0},{1}", x, y));
            }else if(e.Button == System.Windows.Forms.MouseButtons.Right){
                MessageBox.Show(string.Format("Right {0},{1}", x, y));
            }
        }
    }
}