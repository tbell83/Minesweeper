using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.Sql;

namespace mine_sweeper{
    public class Player{
        string name;
        const string connectString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:/users/tbell/source/repos/game/mine_sweeper/minesweeper.accdb;";
        OleDbConnection myConnection = new OleDbConnection(connectString);
        int games, wins, losses;

        public Player(string name){
            this.name = name;
            getStats();
        }

        public void updateStats(){
            string update = string.Format("UPDATE players SET wins='{2}', games='{1}', losses='{3}' WHERE player='{0}'", name, games, wins, losses);
            OleDbCommand insertCmd = new OleDbCommand(update, myConnection);
            myConnection.Open();
            insertCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public void newPlayer(){
            string insert = string.Format("INSERT INTO players (player, games, wins, losses) VALUES ('{0}','0','0','0')",name);
            OleDbCommand insertCmd = new OleDbCommand(insert, myConnection);
            myConnection.Open();
            insertCmd.ExecuteNonQuery();
            myConnection.Close();
            getStats();
        }

        public void getStats(){
            string selectStats = string.Format("SELECT * FROM players WHERE player='{0}'", name);
            DataSet dataset = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectStats, myConnection);
            dataAdapter.Fill(dataset);
            if(dataset.Tables[0].Rows.Count > 0){
                DataRow row = dataset.Tables[0].Rows[0];
                this.games = Convert.ToInt16(row["games"]);
                this.wins = Convert.ToInt16(row["wins"]);
                this.losses = Convert.ToInt16(row["losses"]);
            }else{
                newPlayer();
            }
        }

        public void setPlayer(int wins, int losses, int games){
            this.games = games;
            this.wins = wins;
            this.losses = losses;
            updateStats();
        }

        public void setGames(int games){ this.games = games; }

        public int getGames() { return games; }

        public void setWins(int wins) { this.wins = wins; }

        public int getWins() { return wins; }

        public void setLosses(int losses) { this.losses = losses; }

        public int getLosses() { return losses; }

        public void setName(string name){ this.name = name; }

        public string getName(){ return name; }
    }
}