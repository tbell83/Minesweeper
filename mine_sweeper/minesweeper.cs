using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mine_sweeper{
    class minesweeper{
        int size;
        int mines;
        List<cell> grid = new List<cell>();

        public minesweeper(int size, int mines){
            size = this.size;
            mines = this.mines;
            for (int i = 0; i < Math.Pow(size,2)){
                cell cell = new cell();
                grid.Add(cell);
            }
        }

        private void mineTheField(){
            Random rand = new Random();
            for(int i = 0;i < mines; i++){
                rand.Next(1,mines);
            }

    }
}