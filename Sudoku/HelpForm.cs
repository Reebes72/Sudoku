using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }



        private void RulesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpTextBox.Clear();


            using (StreamReader sr = new StreamReader("SudokuRules.txt"))
            {
                String line = sr.ReadToEnd();
                HelpTextBox.Text = line;
            }

        }

        private void HowToPlay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpTextBox.Clear();


            using (StreamReader sr = new StreamReader("HowToPlay.txt"))
            {
                String line = sr.ReadToEnd();
                HelpTextBox.Text = line;
            }
        }

        private void ScoringSystemLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpTextBox.Clear();

            using (StreamReader sr = new StreamReader("Scoring.txt"))
            {
                String line = sr.ReadToEnd();
                HelpTextBox.Text = line;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
