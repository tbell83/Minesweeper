using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mine_sweeper{
    class minesweeper{
        int size;
        int mines;
        cell[,] grid;

        public minesweeper(int size, int mines){
            this.size = size;
            this.mines = mines;

            grid = new cell[size, size];
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++){
                    cell cell = new cell();
                    grid[x, y] = cell;
                }
            }

            mineTheField();
        }

        private void mineTheField(){
            Random rand = new Random();
            List<int[]> minePlacement = new List<int[]>();
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
                grid[x, y].setMined(true);
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

        public void drawField(){
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    if (grid[x, y].getMined()){
                        Console.Write("X");
                    }else{
                        Console.Write(grid[x,y].getNeighbors());
                    }
                }
                Console.Write("\r\n");
            }
        }

        public string drawGame(){
            string output = "";
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    if (grid[x, y].getCovered()){
                        output = output + "? ";
                    }else{
                        output = output + grid[x, y].getNeighbors() + " ";
                    }
                }
                output = output + "\r\n";
            }
            return output;
        }

        public bool makeMove(int x, int y){
            grid[x, y].setUncovered();
            if (gameWon()){
                return true;
            }
            return false;
        }

        public bool gameWon(){
            foreach (cell item in grid){
                if ((item.getMined() && !item.getCovered()) || (!item.getMined() && item.getCovered())) {
                    return false;
                }
            }
            return true;
        }
    }
}