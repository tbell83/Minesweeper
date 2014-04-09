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

        public void setMined(){
            mine = true;
        }

        public bool getMined(){
            return mine;
        }

        public void setFlagged(){
            if (flagged){
                flagged = false;
            }else{
                flagged = true;
            }
        }

        public bool getFlagged(){
            return flagged;
        }

        public void setUncovered(){
            covered = false;
        }

        public bool getCovered(){
            return covered;
        }
    }
}
