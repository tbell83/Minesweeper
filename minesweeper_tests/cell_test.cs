using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mine_sweeper;

namespace minesweeper_tests{
    [TestClass]
    public class cell_test{
        [TestMethod]
        public void test_cell(){
            cell cell = new cell();
            Assert.AreEqual(cell.getNeighbors(), 0);
            Assert.AreEqual(cell.getMined(), false);
            Assert.AreEqual(cell.getCovered(), true);
            Assert.AreEqual(cell.getFlagged(), false);
        }

        [TestMethod]
        public void test_setNeighbors(){
            cell cell = new cell();
            cell.setNeighbors();
            Assert.AreEqual(cell.getNeighbors(), 1);
        }

        [TestMethod]
        public void test_setMined(){
            cell cell = new cell();
            cell.setMined();
            Assert.AreEqual(cell.getMined(), true);
        }

        [TestMethod]
        public void test_setFlagged(){
            cell cell = new cell();
            cell.setFlagged();
            Assert.AreEqual(cell.getFlagged(), true);
            cell.setFlagged();
            Assert.AreEqual(cell.getFlagged(), false);
        }

        [TestMethod]
        public void test_setUncovered(){
            cell cell = new cell();
            cell.setUncovered();
            Assert.AreEqual((cell.getFlagged() && cell.getCovered()),false);
        }
    }
}
