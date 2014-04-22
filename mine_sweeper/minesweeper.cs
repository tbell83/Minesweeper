using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mine_sweeper{
    public class minesweeper{
        private int size;
        private int mines;
        private int wins = 0;
        private int losses = 0;
        private int games = 0;
        private cell[,] grid;
        private List<int[]> minePlacement;

        public minesweeper(int size, int mines){
            this.size = size;
            this.mines = mines;
            reset();
        }

        public minesweeper(int size, int mines, int games, int wins, int losses){
            this.games = games;
            this.wins = wins;
            this.losses = losses;
            this.size = size;
            this.mines = mines;
            reset();
        }

        public void reset(){
            grid = new cell[size, size];
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++){
                    cell cell = new cell();
                    grid[x, y] = cell;
                }
            }
            mineTheField();
            games++;
        }

        private void mineTheField(){
            Random rand = new Random();
            minePlacement = new List<int[]>();
            for (int i = 0; i < mines; i++) {
                int[] plot = {rand.Next(0,size), rand.Next(0,size)};
                minePlacement.Add(plot);
            }

            for (int i = 0; i < mines; i++){
                for (int x = i + 1; x < mines; x++){
                    if ((minePlacement[i][0] == minePlacement[x][0]) && (minePlacement[i][1] == minePlacement[x][1])){
                        minePlacement.RemoveAt(i);
                        int[] plot = { rand.Next(0, size), rand.Next(0, size) };
                        minePlacement.Add(plot);
                        i = 0;
                    }
                }
            }

            foreach (int[] item in minePlacement){
                int x = item[0];
                int y = item[1];
                grid[x, y].setMined();
                if ((x == 0) && (y == 0)){
                    grid[x + 1, y].setNeighbors();
                    grid[x + 1, y + 1].setNeighbors();
                    grid[x, y + 1].setNeighbors();
                }else if((x == size - 1)&&(y == 0)){
                    grid[x-1,y].setNeighbors();
                    grid[x-1,y+1].setNeighbors();
                    grid[x,y+1].setNeighbors();
                }else if ((x == size - 1) && (y == size - 1)){
                    grid[x, y - 1].setNeighbors();
                    grid[x - 1, y - 1].setNeighbors();
                    grid[x - 1, y].setNeighbors();
                }else if((x == 0)&&(y == size - 1)){
                    grid[x,y-1].setNeighbors();
                    grid[x+1,y-1].setNeighbors();
                    grid[x+1,y].setNeighbors();
                }else if ((x == size - 1) && (y != 0)){
                    grid[x,y-1].setNeighbors();
                    grid[x-1,y-1].setNeighbors();
                    grid[x-1,y].setNeighbors();
                    grid[x-1,y+1].setNeighbors();
                    grid[x,y+1].setNeighbors();
                }else if((x != 0)&&(y == size - 1)){
                    grid[x-1,y].setNeighbors();
                    grid[x-1,y-1].setNeighbors();
                    grid[x,y-1].setNeighbors();
                    grid[x+1,y-1].setNeighbors();
                    grid[x+1,y].setNeighbors();
                }else if((x != 0)&&(y == 0)){
                    grid[x-1,y].setNeighbors();
                    grid[x-1,y+1].setNeighbors();
                    grid[x,y+1].setNeighbors();
                    grid[x+1,y+1].setNeighbors();
                    grid[x+1,y].setNeighbors();
                }else if((x == 0)&&(y != 0)){
                    grid[x,y-1].setNeighbors();
                    grid[x+1,y-1].setNeighbors();
                    grid[x+1,y].setNeighbors();
                    grid[x+1,y+1].setNeighbors();
                    grid[x,y+1].setNeighbors();
                }else if ((x != 0) && (y != 0)){
                    grid[x-1,y-1].setNeighbors();
                    grid[x,y-1].setNeighbors();
                    grid[x+1,y-1].setNeighbors();
                    grid[x-1,y].setNeighbors();
                    grid[x+1,y].setNeighbors();
                    grid[x - 1, y + 1].setNeighbors();
                    grid[x, y+1].setNeighbors();
                    grid[x + 1, y+1].setNeighbors();
                }
            }
        }

        public void makeField(){
            Console.WriteLine();
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    if (grid[x, y].getMined()){
                        Console.Write("X ");
                    }else if(grid[x,y].getFlagged()){
                        Console.Write("F ");
                    }else{
                        Console.Write(grid[x,y].getNeighbors() + " ");
                    }
                }
                Console.Write("\r\n");
            }
        }

        public string drawCell(int x, int y){
            string output = "";
            if(grid[x,y].getFlagged()){
                output = output + "F";
            }else if (grid[x, y].getCovered()){
                output = output + "";
            }else if(grid[x,y].getMined()){
                output = output + "X";
            }else{
                output = output + grid[x, y].getNeighbors();
            }
            return output;
        }

        public void makeMove(int x, int y){
            if(!grid[x,y].getFlagged()){
                grid[x, y].setUncovered();
                if (grid[x, y].getNeighbors() == 0){
                    for (int x2 = x-1; x2 < x+2; x2++){
                        for (int y2 = y-1; y2 < y+2; y2++){
                            if((x2 >= 0 && y2 >=0) && (x2 <= size-1 && y2 <= size-1) && grid[x2,y2].getCovered()){
                                makeMove(x2, y2);
                            }
                        }
                    }
                }
            }else{
                grid[x,y].setFlagged();
            }

        }

        public void flagCell(int x, int y){ grid[x, y].setFlagged(); }

        public bool gameOver(){
            if(gameLost()){
                losses++;
                this.showMines();
                return true;
            }else if(gameWon()){
                wins++;
                return true;
            }
            return false;
        }

        public int getWins(){ return wins; }

        public int getLosses(){ return losses; }

        public int getGames() { return games; }

        public bool gameWon(){
            foreach (cell item in grid){
                if ((item.getMined() && !item.getCovered()) || (!item.getMined() && item.getCovered())) {
                    return false;
                }
            }
            return true;
        }

        public bool gameLost(){
            foreach (cell item in grid){
                if (item.getMined() && !item.getCovered()) {
                    return true;
                }
            }
            return false;
        }

        public void showMines(){
            foreach (int[] item in minePlacement){
                int x = item[0];
                int y = item[1];
                grid[x,y].setUncovered();
            }
        }
    }
}