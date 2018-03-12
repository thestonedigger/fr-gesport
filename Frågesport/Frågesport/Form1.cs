using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Frågesport
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            SlidePanel.expandedWidth = panelSide.Width;
            SlidePanel.collapsedWidth = 50;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            /*
            PopUp exitPopUp = new PopUp();

            exitPopUp.message = "Are you sure that you want to exit the application?";
            exitPopUp.caption = "Caution!";
            exitPopUp.buttons = MessageBoxButtons.YesNo;

            exitPopUp.result = MessageBox.Show(exitPopUp.message, exitPopUp.caption, exitPopUp.buttons);

            if(exitPopUp.result == DialogResult.Yes)
            {
                this.Close();
            }
            */
            this.Close();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //timer1.Start();

            if(panelSide.Width == SlidePanel.expandedWidth)
            {
                panelSide.Visible = false;
                panelSide.Width = SlidePanel.collapsedWidth;
                panelTransition.ShowSync(panelSide);
            }
            else if (panelSide.Width == SlidePanel.expandedWidth)
            {
                panelSide.Visible = false;
                panelSide.Width = SlidePanel.expandedWidth;
                panelTransition.ShowSync(panelSide);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            if (SlidePanel.hidden)
            {
                panelSide.Width += 10;

                if (panelSide.Width >= SlidePanel.width)
                {
                    timer1.Stop();
                    SlidePanel.hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                panelSide.Width -= 10;

                if (panelSide.Width <= 0)
                {
                    timer1.Stop();
                    SlidePanel.hidden = true;
                    this.Refresh();
                }
            }
            */
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
