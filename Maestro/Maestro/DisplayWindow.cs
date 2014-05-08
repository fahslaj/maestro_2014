using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Maestro
{
    public partial class DisplayWindow : Form
    {
        public DisplayWindow()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)(sender);
            String text = cmb.Text;
            Console.WriteLine(text);
            dataGridView1.DataSource = new BindingSource(DBAccessor.selectAllTable(text), null);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.ShowDialog();
        }

    }
}
 