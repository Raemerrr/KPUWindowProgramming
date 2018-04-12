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

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index < 0) {
                return;
            }
            listBox.Items.RemoveAt(index);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            if (text == "")
            {
                return;
            }
            listBox.Items.Add(text);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            bool enablesButton = textBox.Text != "";
            addButton.Enabled = enablesButton;
        }

        private void listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            bool enablesButton = listBox.SelectedIndex >= 0;
            removeButton.Enabled = enablesButton;
        }
    }
}
