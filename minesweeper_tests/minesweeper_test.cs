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

        [TestMethod]
        public void test_minesweeperDefault(){
            minesweeper game = new minesweeper(size, mines);

        }
    }
}
