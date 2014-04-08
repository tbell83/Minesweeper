using System;
using System.Collections.Generic;
using System.Linq;                                                                                                                                                                                          
using System.Text;
using System.Threading.Tasks;

namespace mine_sweeper{
    class cell{
        bool mine;
        bool flagged;
        bool covered;
        int neighbors;

        public cell(){
            neighbors = 0;
            mine = false;
            covered = true;
            flagged = false;
        }

        public void setNeighbors(){
            neighbors++;
        }

        public int getNeighbors(){
            return neighbors;
        }

        public void setMined(bool mine){
            this.mine = mine;
        }

        public bool getMined(){
            if(mine == true){
                return true;
            }else{
                return false;
            }
        }

        public void setFlagged(bool flagged){
            this.flagged = flagged;
        }

        public void setUncovered(){
            covered = false;
        }

        public bool getCovered(){
            if (covered){
                return true;
            }else{
                return false;
            }
        }

    }
}
