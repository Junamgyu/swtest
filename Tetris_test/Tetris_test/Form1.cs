using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Tetris_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    private async Task<bool> MoveBlockDownLooplyAsync()
    {
        while (true)
        {
            await semaphoreSlim.WaitAsync();
            Tetris.MoveDown();
            semaphoreSlim.Release();
            Tetris.DrawBoard((Form)this);

            if (Tetris.IsGameOver())
            {
                break;
            }

            Text = Tetris.CurrentBlock.ToString();
            await Task.Delay(150);
        }
        return true;
    }
}

}
