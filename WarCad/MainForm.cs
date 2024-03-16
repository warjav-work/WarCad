using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarCad
{
    public partial class MainForm : Form
    {
        private ToolStripMenuItem windowsBtn = new ToolStripMenuItem();
        private GraphicsForm graphics;
        private int counter = 1;
        public MainForm()
        {
            InitializeComponent();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            windowsBtn.Name = "windowsbtn";
            windowsBtn.Text = "Windows";
            windowsBtn.Size = new Size(120, 28);

            var item = mainMenu.Items.IndexOf(windowsBtn);
            if(item == -1)
            {
                mainMenu.Items.Add(windowsBtn);
                mainMenu.MdiWindowListItem = windowsBtn;
            }

            graphics = new GraphicsForm();
            graphics.Name = $"Grapthics{counter.ToString()}";
            graphics.Text = graphics.Name;
            graphics.MdiParent = this;

            graphics.Show();
            graphics.WindowState = FormWindowState.Maximized;

            counter++;

        }
    }
}
