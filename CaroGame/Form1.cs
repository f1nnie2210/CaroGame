using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChestBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();

            ChestBoard = new ChessBoardManager(pnlChessBoard, txbPlayerName, pctbMark);
            ChestBoard.EndedGame += ChestBoard_EndedGame;
            ChestBoard.PlayerMarked += ChestBoard_PlayerMarked;


            prcbCooldown.Step = Cons.COOL_DOWN_STEP;
            prcbCooldown.Maximum = Cons.COOL_DOWN_TIME;
            prcbCooldown.Value = 0;

            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            NewGame();
        }


        #region Methods
        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false;
            MessageBox.Show("Game Over!");
        }

        void NewGame()
        {
            prcbCooldown.Value = 0;
            tmCoolDown.Stop();

            ChestBoard.DrawChessBoard();
        }

        void Quit()
        {
            Application.Exit();
        }

        void Undo()
        {

        }

        private void ChestBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            prcbCooldown.Value = 0;
        }

        private void ChestBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame(); 
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCooldown.PerformStep();

            if (prcbCooldown.Value >= prcbCooldown.Maximum)
            {
                EndGame();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Warning!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        #endregion 
    }
}
