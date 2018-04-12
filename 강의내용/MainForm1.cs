using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();
        }

        private void fruitRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            displayLabel.Text = "Selected : " + r.Text;
        }
    }
}
