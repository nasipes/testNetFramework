using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLibrary;

namespace InterForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            this.comboBox1.DropDownWidth = 250;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.comboBox1.DropDownWidth = 150;
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            Class1.ProgressStart();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
