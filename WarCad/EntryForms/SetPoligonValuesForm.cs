using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarCad.EntryForms
{
    public partial class SetPoligonValuesForm : Form
    {
        public SetPoligonValuesForm()
        {
            InitializeComponent();
        }
        public int SidesQty { get; private set; }
        public int Inscribed {  get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(sides.Text) || Convert.ToInt32(sides.Text) < 3) 
            {
                MessageBox.Show("Sides entry must be equal or great than 3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sides.Focus();
                return;
            }
            SidesQty = Convert.ToInt32(sides.Text);
            Inscribed = inscribed.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetPoligonValuesForm_Load(object sender, EventArgs e)
        {
            Text = "Poligon settings";
            inscribed.SelectedIndex = 0;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 30;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 30;
        }
    }
}
