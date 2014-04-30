using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mine_sweeper;

namespace minesweeper_tests
{
    [TestClass]
    public class minesweeper_test
    {
        int mines = 9;
        int size = 9;
        int wins = 8;
        int losses = 5;
        int games = 3;

        [TestMethod]
        public void test_minesweeperDefault(){
            minesweeper game = new minesweeper(size, mines);
            var priObj = new PrivateObject(game);
            Assert.AreEqual(size, priObj.GetField("size"));
            Assert.AreEqual(mines, priObj.GetField("mines"));
        }

        [TestMethod]
        public void test_minesweeperOverride(){
            minesweeper game = new minesweeper(size, mines, games, wins, losses);
            var priObj = new PrivateObject(game);
            Assert.AreEqual(size, priObj.GetField("size"));
            Assert.AreEqual(mines, priObj.GetField("mines"));
            Assert.AreEqual(games+1, priObj.GetField("games"));
            Assert.AreEqual(wins, priObj.GetField("wins"));
            Assert.AreEqual(losses, priObj.GetField("losses"));
        }

        [TestMethod]
        public void test_flagCell(){
            minesweeper game = new minesweeper(size, mines);
            game.flagCell(size-1, size-1);
            Assert.AreEqual("F", game.drawCell(size-1, size-1));
        }

        [TestMethod]
        public void test_gameOver(){
            minesweeper game = new minesweeper(size, mines);
            var priObj = new PrivateObject(game);

        }

        [TestMethod]
        public void test_getWins(){
            minesweeper game = new minesweeper(size, mines, games, wins, losses);
            Assert.AreEqual(wins, game.getWins());
        }

        [TestMethod]
        public void test_getLosses(){
            minesweeper game = new minesweeper(size, mines, games, wins, losses);
            Assert.AreEqual(losses, game.getLosses());
        }

        [TestMethod]
        public void test_getGames(){
            minesweeper game = new minesweeper(size, mines, games, wins, losses);
            Assert.AreEqual(games+1, game.getGames());
        }

        [TestMethod]
        public void test_gameWon(){
            minesweeper game = new minesweeper(size, mines);
            Assert.AreEqual(false, game.gameWon());
        }

        [TestMethod]
        public void test_gameLost(){
            minesweeper game = new minesweeper(size, mines);
            Assert.AreEqual(false, game.gameLost());
        }
    }
}