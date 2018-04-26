using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public partial class HighScoreControl : UserControl
    {
        public HighScoreControl()
        {
            InitializeComponent();
        }
        //Reads text files containing dates and scores and assigns them to the controls
        private void HighScoreControl_Load(object sender, EventArgs e)
        {
           /* using (StreamReader sr = new StreamReader(@"C:\Users\Andy\Desktop\newsudoku\Sudoku\Sudoku\Sudoku\bin\Debug\HighScores.txt"))
            {
                Score1.Text = sr.ReadLine();
                Score2.Text = sr.ReadLine();
                Score3.Text = sr.ReadLine();
                Score4.Text = sr.ReadLine();
                Score5.Text = sr.ReadLine();
                Score6.Text = sr.ReadLine();
                Score7.Text = sr.ReadLine();
                Score8.Text = sr.ReadLine();
                Score9.Text = sr.ReadLine();
                Score10.Text = sr.ReadLine();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\Andy\Desktop\newsudoku\Sudoku\Sudoku\Sudoku\bin\Debug\DatesOfHighScores.txt"))
            {
                DateTime date = Convert.ToDateTime(sr.ReadLine());
                Date1.Text = date.Month + "/" + date.Day + "/" + date.Year;

                date = Convert.ToDateTime(sr.ReadLine());
                Date2.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date3.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date4.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date5.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date6.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date7.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date8.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date9.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date10.Text = date.Month + "/" + date.Day + "/" + date.Year;


    
            }*/
        }

        //Method to update the control after each game.
        public void refresh(string highScores, string dates)
        {
            using (StreamReader sr = new StreamReader(highScores))
            {
                Score1.Text = sr.ReadLine();
                Score2.Text = sr.ReadLine();
                Score3.Text = sr.ReadLine();
                Score4.Text = sr.ReadLine();
                Score5.Text = sr.ReadLine();
                Score6.Text = sr.ReadLine();
                Score7.Text = sr.ReadLine();
                Score8.Text = sr.ReadLine();
                Score9.Text = sr.ReadLine();
                Score10.Text = sr.ReadLine();
            }

            using (StreamReader sr = new StreamReader(dates))
            {
                DateTime date = Convert.ToDateTime(sr.ReadLine());
                Date1.Text = date.Month + "/" + date.Day + "/" + date.Year;

                date = Convert.ToDateTime(sr.ReadLine());
                Date2.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date3.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date4.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date5.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date6.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date7.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date8.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date9.Text = date.Month + "/" + date.Day + "/" + date.Year;
                date = Convert.ToDateTime(sr.ReadLine());
                Date10.Text = date.Month + "/" + date.Day + "/" + date.Year;



            }
        }

    }
}
