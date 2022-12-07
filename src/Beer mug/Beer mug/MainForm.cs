using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beer_mug
{
    public partial class Beer_Mug : Form
    {
        public Beer_Mug()
        {
            InitializeComponent();
        }
        private Color _incorrectColor = Color.LightPink;
        private void buildButton_Click(object sender, EventArgs e)
        {
            ThicknessTextBox.BackColor = _incorrectColor;
            highTextBox.BackColor = _incorrectColor;
            highCorrectLable.Text = "Incorrect";
            thicknessIncorrectLable.Text = "Incorrect";
        }

        private void MinimumSizeButtom_Click(object sender, EventArgs e)
        {
            double thickness = 5;
            ThicknessTextBox.Text = thickness.ToString();
        }
    }
}
