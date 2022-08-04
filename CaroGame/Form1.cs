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

            ChestBoard.DrawChessBoard();
        }

        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false;
            MessageBox.Show("Game Over!");
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
    }
}
