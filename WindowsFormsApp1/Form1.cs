using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        static readonly IntPtr HWND_TOP = new IntPtr(0);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        const UInt32 SWP_NOSIZE = 0x0001;

        const UInt32 SWP_NOMOVE = 0x0002;

        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        
        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public Form1()
        {
            InitializeComponent();
            this.TopLevel = true;
            this.TopMost = true;
            this.MinimizeBox = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}