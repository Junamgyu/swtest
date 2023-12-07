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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.Left)
            {
                await semaphoreSlim.WaitAsync();
                Tetris.MoveLeft();
                Tetris.DrawBoard((Form)this);
                semaphoreSlim.Release();
            }

            if (e.KeyCode == Keys.Right)
            {
                await semaphoreSlim.WaitAsync();
                Tetris.MoveRight();
                Tetris.DrawBoard((Form)this);
                semaphoreSlim.Release();
            }

            if (e.KeyCode == Keys.Up)
            {
                await semaphoreSlim.WaitAsync();
                Tetris.NextDirection();
                Tetris.DrawBoard((Form)this);
                semaphoreSlim.Release();
            }

            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Down)
            {
                await semaphoreSlim.WaitAsync();
                Tetris.MoveDown();
                Tetris.DrawBoard((Form)this);
                semaphoreSlim.Release();
            }

        }
    }
}

