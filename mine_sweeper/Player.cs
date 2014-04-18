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
        const string connectString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=minesweeper.accdb;";
        OleDbConnection myConnection = new OleDbConnection(connectString);
        int games, wins, losses;

        public Player(string name) {
            this.name = name;
            this.games = 0;
            this.wins = 0;
            this.losses = 0;
            setStats();
            getStats();
        }

        public void setStats(){
            string insert = string.Format("INSERT INTO players (player, games, wins, losses) VALUES ('{0}','{1}','{2}','{3}')",name, games, wins, losses);
            OleDbCommand insertCmd = new OleDbCommand(insert, myConnection);
            myConnection.Open();
            insertCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public void getStats(){
            string selectStats = string.Format("SELECT * FROM players WHERE player='{0}'", name);
            DataSet dataset = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(selectStats, myConnection);
            dataAdapter.Fill(dataset);
            DataRow row = dataset.Tables[0].Rows[0];
        }

        public void setGames(int games){ this.games = games; }

        public void setWins(int wins) { this.wins = wins; }

        public void setLosses(int losses) { this.losses = losses; }

        public void setName(string name){ this.name = name; }

        public string getName(){ return name; }
    }
}
