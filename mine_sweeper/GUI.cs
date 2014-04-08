using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mine_sweeper
{
    public partial class GUI : Form
    {
        minesweeper game = new minesweeper(5, 5);
        public GUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game.drawField();
            txtOuput.Text =  game.drawGame();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtX.Text)-1;
            int y = Convert.ToInt16(txtY.Text)-1;
            game.probeCell(x, y);
            txtOuput.Text = game.drawGame();
        }
    }
}
