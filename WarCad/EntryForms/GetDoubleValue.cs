using System;
using System.Windows.Forms;

namespace WarCad.EntryForms
{
    public partial class GetDoubleValue : Form
    {
        public GetDoubleValue()
        {
            InitializeComponent();
        }

        public string Title { private get; set; }
        public double ResultValue { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                ResultValue = Convert.ToDouble(txtValue.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Input value is not correct", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValue.Focus();
                return;
            }
        }

        private void GetDoubleValue_Load(object sender, EventArgs e)
        {
            Text = $"Get {Title} Value";
            Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
