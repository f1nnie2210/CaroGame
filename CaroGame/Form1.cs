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

            ChestBoard.DrawChessBoard();
        }
    }
}
