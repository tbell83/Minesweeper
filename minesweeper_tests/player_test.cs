using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mine_sweeper;
using System.Data;
using System.Data.Sql;
using System.Data.OleDb;

namespace minesweeper_tests
{
    [TestClass]
    public class player_test
    {
        string name = "Sean McGillicutty";
        int games = 99;
        int wins = 63;
        int losses = 55;

        [TestMethod]
        public void test_Player(){
            Player player = new Player(name);
            Assert.AreEqual(player.getName(), name);
            Assert.AreEqual(player.getGames(), 0);
            Assert.AreEqual(player.getWins(), 0);
            Assert.AreEqual(player.getLosses(), 0);
            remove_testData();
        }

        [TestMethod]
        public void test_updateStats(){
            Player player = new Player(name);
            player.setPlayer(wins, losses, games);
            player.updateStats();
            player = new Player(name);
            Assert.AreEqual(player.getWins(), wins);
            Assert.AreEqual(player.getLosses(), losses);
            Assert.AreEqual(player.getGames(), games);
            remove_testData();
        }

        [TestMethod]
        public void test_setGames(){
            Player player = new Player(name);
            player.setGames(games);
            Assert.AreEqual(player.getGames(), games);
            remove_testData();
        }

        [TestMethod]
        public void test_setWins(){
            Player player = new Player(name);
            player.setWins(wins);
            Assert.AreEqual(player.getWins(), wins);
            remove_testData();
        }

        [TestMethod]
        public void test_setLosses(){
            Player player = new Player(name);
            player.setLosses(losses);
            Assert.AreEqual(player.getLosses(), losses);
            remove_testData();
        }

        [TestMethod]
        public void test_setName(){
            Player player = new Player(name);
            player.setName("Test");
            Assert.AreEqual(player.getName(), "Test");
            remove_testData();
        }

        public void remove_testData(){
            const string connectString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:/users/tbell/source/repos/game/mine_sweeper/minesweeper.accdb;";
            OleDbConnection myConnection = new OleDbConnection(connectString);
            string removeTestData = string.Format("DELETE FROM players WHERE player='{0}'", name);
            OleDbCommand command = new OleDbCommand(removeTestData, myConnection);
            myConnection.Open();
            command.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
