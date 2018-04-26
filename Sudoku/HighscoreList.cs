using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class HighscoreList
    {
        private List<string> HighScores { get; set; } //Contains list of highscores
        private List<DateTime> DatesOfHighScores { get; set; } //List of Dates of Highscores

        //File Names
        private string HighScoreFileName {get; set;}
        private string DatesFileName { get; set; }


        //Constructor creates the list and saves the file names
        public HighscoreList(string scoresFileName, string datesFileName)
        {
            string line;
            HighScores = new List<string>();
            DatesOfHighScores = new List<DateTime>();
            using (StreamReader reader = new StreamReader(scoresFileName))
            {
                while((line = reader.ReadLine()) != null)
                {
                    HighScores.Add(line);
                }
            }

            using (StreamReader reader = new StreamReader(datesFileName))
            {
                while((line = reader.ReadLine()) != null)
                {
                    DatesOfHighScores.Add(DateTime.Parse(line));
                }
            }


            HighScoreFileName = scoresFileName;
            DatesFileName = datesFileName;

        }

        //Tests each score to see if it is greater than a current high score then calls method to alter the file
        public void UpdateHighScoreList(string score)
        {
            int result = int.Parse(score);
            DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            for (int i = 0; i < HighScores.Count; i++)
            {
                if (result > int.Parse(HighScores[i]) && result != 0 )
                {
                    HighScores.Insert(i, result.ToString());
                    HighScores.RemoveAt(10);
                    DatesOfHighScores.Insert(i, date);
                    DatesOfHighScores.RemoveAt(10);
                    result = 0;
                    WriteToFile(HighScores, DatesOfHighScores);
                }
            }
        }

        //Updates the file to the current top 10 high scores
        private void WriteToFile(List<string> highScores, List<DateTime> dates) 
        {

            using (FileStream fs = new FileStream(HighScoreFileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var e in highScores)
                    {
                        sw.WriteLine(e);
                    }
                }
            }

            using(FileStream fs = new FileStream(DatesFileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach(var e in dates)
                    {
                        sw.WriteLine(e);
                    }
                }
            }
        }
    }
}
