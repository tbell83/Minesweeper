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
        int size;
        int mines;
        private Button[,] grid;
        private Bitmap flag = new Bitmap(mine_sweeper.Properties.Resources.flag, new Size(30,30));
        private Bitmap mine = new Bitmap(mine_sweeper.Properties.Resources.mine, new Size(30, 30));
        minesweeper game;
        Player player;

        public GUI_form(minesweeper game, int size, int mines, Player player){
            this.size = size;
            this.mines = mines;
            this.game = game;
            this.player = player;
            InitializeComponent();
            generateGrid();
            Button reset = new Button();
            reset.Size = new Size(50, 30);
            reset.Location = new Point(((size * 30) / 2)-25, (size*30)+5);
            reset.Text = "Reset";
            reset.Click += new EventHandler(resetGame);
            this.Controls.Add(reset);
        }

        private void Form1_Load(object sender, EventArgs e){
            game.makeField();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size((size * 30) + 17, (size * 30) + 76);
        }

        private void resetGame(object sender, EventArgs e){
            game.reset();
            game.makeField();
            foreach (Button item in grid) { item.Enabled = true; }
            redraw();
        }

        private void afterClick(){
            if(game.gameOver()){
                redraw();
                gameOver();
            }
            redraw();
        }

        private void redraw(){
            for(int x = 0;x < size;x++){
                for(int y = 0;y < size;y++){
                    string text = game.drawCell(x,y);
                    if (text == "0") {
                        grid[x, y].BackColor = Color.Green;
                    }else if(text == "F"){
                        grid[x, y].BackColor = Color.Yellow;
                        grid[x, y].BackgroundImage = flag;
                    }else if(text == "X"){
                        grid[x, y].BackColor = Color.Red;
                        grid[x, y].BackgroundImage = mine;
                    }else{
                        grid[x, y].Text = text;
                        grid[x, y].BackColor = Color.LightGray;
                        grid[x, y].BackgroundImage = null;
                    }
                }
            }
        }

        private void gameOver(){
            int wins= game.getWins();
            int losses = game.getLosses();
            int games = game.getGames();
            string name = player.getName();
            End_of_Game eog = new End_of_Game(wins, losses, game.gameWon(), games, name);
            player.setPlayer(wins, losses, games);
            this.Enabled = false;
            eog.ShowDialog(this);
            this.Enabled = true;
            game.reset();
        }

        private void generateGrid(){
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

        private void cellClick(object sender, MouseEventArgs e){
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