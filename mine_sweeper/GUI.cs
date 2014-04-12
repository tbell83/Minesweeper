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
        const int size = 10;
        const int mines = 10;
        int wins = 0;
        int losses = 0;
        Button[,] grid;

        public minesweeper game = new minesweeper(size, mines);

        public GUI_form(){
            InitializeComponent();
            generateGrid();
            Button reset = new Button();
            reset.Size = new System.Drawing.Size(50, 30);
            reset.Location = new Point(((size * 30) / 2)-25, (size*30)+5);
            reset.Text = "Reset";
            reset.Click += new EventHandler(resetGame);
            this.Controls.Add(reset);
        }

        private void Form1_Load(object sender, EventArgs e){
            game.drawField();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size((size * 30) + 17, (size * 30) + 76);
        }

        private void resetGame(object sender, EventArgs e){
            game.mineTheField();
            redraw();
        }

        private void afterClick(){
            redraw();
            if (game.gameWon()){
                gameOver(true);
            }else if(game.gameLost()){
                gameOver(false);
            }
        }

        private void redraw(){
            for(int x = 0;x < size;x++){
                for(int y = 0;y < size;y++){
                    grid[x, y].BackColor = Color.LightGray;
                    string text = game.drawCell(x,y);
                    grid[x,y].Text = text;
                    if (text == "0") {
                        grid[x, y].Text = "";
                        grid[x, y].BackColor = Color.Green;
                    }else if(text == "F"){
                        grid[x, y].BackColor = Color.Yellow;
                    }
                }
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
                    button.Tag = string.Format("{0},{1}", x, y);
                    button.Text = game.drawCell(x, y);
                    button.BackColor = Color.LightGray;
                    button.FlatStyle = FlatStyle.Flat;
                    grid[x, y] = button;
                    button.MouseDown += new MouseEventHandler(cellClick);
                    this.Controls.Add(button);
                }
            }
        }

        public void cellClick(object sender, MouseEventArgs e){
            Button button = sender as Button;
            string[] coord = button.Tag.ToString().Split(',');
            int x = Convert.ToInt16(coord[0]);
            int y = Convert.ToInt16(coord[1]);
            if(e.Button == System.Windows.Forms.MouseButtons.Left){
                game.makeMove(x, y);
            }else if(e.Button == System.Windows.Forms.MouseButtons.Right){
                game.flagCell(x, y);
            }
            afterClick();
        }
    }
}