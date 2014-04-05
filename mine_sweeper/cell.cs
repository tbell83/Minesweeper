using System;
using System.Collections.Generic;
using System.Linq;                                                                                                                                                                                          
using System.Text;
using System.Threading.Tasks;

namespace mine_sweeper{
    class cell{
        bool mine = false;
        bool flagged = false;
        bool covered = true;
        int neighbors;

        public cell(){}

        public void setNeighbors(int neighbors){
            this.neighbors = neighbors;
        }

        public void setMined(bool mine){
            this.mine = mine;
        }

        public void setFlagged(bool flagged){
            this.flagged = flagged;
        }

    }
}
