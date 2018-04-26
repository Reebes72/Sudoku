using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
   public partial class SudokuForm : Form
   {
      const int colwidth = 45;
      const int rowheight = 45;
      const int maxcell = 9;
      const int border = colwidth * maxcell + 3;

        //Andy4/18 - Constants for the file names to be sent to the Highscore class 
        const string HIGH_SCORES = "HighScores.txt";
        const string DATES = "DatesOfHighScores.txt";
        //Andy4/18 - Initializing Highscore class
        HighscoreList HighScores = new HighscoreList(HIGH_SCORES, DATES);
        

        
        int hints = 0;
      int errorcount = 0;
      int randomcount = 0;


      //variables for timer
      int minute = 0;
      int second = 0;

      int score = 0;

      int[,] SudokuArray = new int[9, 9];

      Boolean checkresult = false;
      Boolean puzzleAssist = false;   //Terry Assist off  *******

      public SudokuForm()
      {
         InitializeComponent();

            highScoreControl1.refresh(HIGH_SCORES, DATES);
      }


      private void SudokuForm_Load(object sender, EventArgs e)
      {
         toolcboDifficulty.SelectedIndex = 0;
         InitForm();
         InitBoardGrid();
         InitNumberGrid();
         InitEmptyGrid();
         InitBoard();

         score = 0;

      }



      private void btnCheckResults_Click(object sender, EventArgs e)
      {
         string boardvalue, arrayvalue;
         ResetSelects();
         checkresult = true;
         for (int i = 0; i < 9; ++i)
         {
            for (int y = 0; y < 9; ++y)
            {
               try
               {
                  boardvalue = BoardGrid.Rows[i].Cells[y].Value.ToString();
               }
               catch
               {
                  boardvalue = "";
               }
               arrayvalue = SudokuArray[i, y].ToString();

               if (boardvalue != arrayvalue)
               {
                  BoardGrid.Rows[i].Cells[y].Style.BackColor = Color.Red;
                  errorcount += 1;
               }

               BoardGrid.Rows[i].Cells[y].Value = SudokuArray[i, y].ToString();
            }
         }

         errorcount = 0;
      }

      private void btnNewPuzzle_Click(object sender, EventArgs e)
      {

         switch (checkresult)
         {
            case true:
               {
                  ResetSelects();
                  InitForm();
                  InitBoardGrid();
                  InitNumberGrid();
                  InitEmptyGrid();
                  InitBoard();
                  break;
               }
            default:
               {
                  if (MessageBox.Show("Are you sure you want a new puzzle?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                  {
                     ResetSelects();
                     InitForm();
                     InitBoardGrid();
                     InitNumberGrid();
                     InitEmptyGrid();
                     InitBoard();

                     score = 0;
                  }
                  break;
               }


         }

      }

      private void BoardGrid_CellClick(object sender, DataGridViewCellEventArgs e)
      {

         if (this.EmptyGrid.CurrentCell.Selected == true)
         {


            if (this.BoardGrid.CurrentCell.Style.BackColor == Color.Bisque || this.BoardGrid.CurrentCell.Style.BackColor == Color.White)
            {
               this.BoardGrid.CurrentCell.Value = null;
               this.BoardGrid.CurrentCell.Style.BackColor = Color.White;
               if (puzzleAssist) this.BoardGrid.CurrentCell.Style.ForeColor = Color.DarkRed;      //Terry set number color Default ********
            }

         }
         else
         {
            if (this.BoardGrid.CurrentCell.Style.BackColor == Color.Bisque || this.BoardGrid.CurrentCell.Style.BackColor == Color.White)
            {
               this.BoardGrid.CurrentCell.Value = NumberGrid.CurrentCell.Value;
               this.BoardGrid.CurrentCell.Style.BackColor = Color.Bisque;
               if (puzzleAssist) this.BoardGrid.CurrentCell.Style.ForeColor = Color.Orange;      //Terry set number color Default ********
            }



         }



      }

      public void InitBoard()
      {

         Random randomNumber = new Random();

         // int randomcount = 0;
         //Moved to widen scope


         if (toolcboDifficulty.SelectedIndex == 0)
         {
            randomcount = 55;
            hints = 5;
         }

         if (toolcboDifficulty.SelectedIndex == 1)
         {
            randomcount = 45;
            hints = 2;
         }

         if (toolcboDifficulty.SelectedIndex == 2)
         {
            randomcount = 25;
            hints = 0;
         }


         for (int i = 0; i < randomcount; i++)
         {

            Boolean cellset = false;
            Boolean maxset = false;

            do
            {
               int rowdigit = randomNumber.Next(0, 9);
               int coldigit = randomNumber.Next(0, 9);
               maxset = false;
               maxset = CheckForMax(rowdigit, coldigit);
               if (this.BoardGrid.Rows[rowdigit].Cells[coldigit].Value == null && maxset == false)
               {
                  BoardGrid.Rows[rowdigit].Cells[coldigit].Value = SudokuArray[rowdigit, coldigit].ToString();
                  BoardGrid.Rows[rowdigit].Cells[coldigit].Style.BackColor = Color.Beige;
                  BoardGrid.Rows[rowdigit].Cells[coldigit].ReadOnly = true;
                  cellset = true;
               }
            } while (cellset == false);

         }

         if (hints < 1)
         {
            hintToolStripMenuItem.Visible = false;
            hintToolStripMenuItem.Enabled = false;
         }
         else
         {
            hintToolStripMenuItem.Visible = true;
            hintToolStripMenuItem.Enabled = true;
            hintToolStripMenuItem.Text = string.Concat("Hints = ", hints);

         }


      }

      public static int[,] GenSudokuPuzzle()
      {
         // Generate puzzle
         int[,] sudokuArray = new int[9, 9];
         Random randomNumber = new Random();
         // generate 1-9 in row 0
         for (int i = 0; i < 9; ++i)
         {
            int digit = randomNumber.Next(1, 10);
            // check for duplicate
            for (int c = 0; c < 9; ++c)
            {
               if (sudokuArray[0, c] == digit)  // duplicate
               {
                  --i;  //get another digit since duplicate
                  break;
               }
               if (sudokuArray[0, c] == 0) // if 0 then set digit & BUILD EASY PUZZLE
               {
                  sudokuArray[0, i] = digit;
                  sudokuArray[1, (i + 3) % 9] = digit;
                  sudokuArray[2, (i + 6) % 9] = digit;
                  sudokuArray[3, (i + 5) % 9] = digit;
                  sudokuArray[4, (i + 2) % 9] = digit;
                  sudokuArray[5, (i + 8) % 9] = digit;
                  sudokuArray[6, (i + 1) % 9] = digit;
                  sudokuArray[7, (i + 4) % 9] = digit;
                  sudokuArray[8, (i + 7) % 9] = digit;
                  break;
               }
            }
         }
         //
         //  scramble rows and columns to get dificult puzzle
         int column1 = randomNumber.Next(0, 3);
         for (int x = 0; x < 3; ++x) //swap columns
         {
            int column2 = (column1 / 3) * 3 + ((column1 % 3 + 1) % 3);
            //Console.WriteLine($"\ncolumn {column1} {column2}\n");
            for (int r = 0; r < 9; ++r)
            {   //swap entries
               int z = sudokuArray[r, column1];
               sudokuArray[r, column1] = sudokuArray[r, column2];
               sudokuArray[r, column2] = z;
            }
            column1 = (column2 + 3) % 9; // get column next block
                                         // Display Sudoku array
                                         //              DisplaySudoku(sudokuArray);
         }
         int row1 = randomNumber.Next(0, 3);
         for (int x = 0; x < 3; ++x) //swap columns
         {
            int row2 = (row1 / 3) * 3 + ((row1 % 3 + 1) % 3);
            //Console.WriteLine($"\row {row1} {row2}\n");
            for (int c = 0; c < 9; ++c)
            {   //swap entries
               int z = sudokuArray[row1, c];
               sudokuArray[row1, c] = sudokuArray[row2, c];
               sudokuArray[row2, c] = z;
            }
            row1 = (row2 + 3) % 9; // get column next block
                                   // Display Sudoku array
                                   //                DisplaySudoku(sudokuArray);
         }

         return sudokuArray;
      }


      public void InitBoardGrid()
      {
         BoardGrid.Name = "BoardGrid";
         BoardGrid.AllowUserToResizeColumns = false;
         BoardGrid.AllowUserToResizeRows = false;
         BoardGrid.AllowUserToAddRows = false;
         BoardGrid.RowHeadersVisible = false;
         BoardGrid.ColumnHeadersVisible = false;
         BoardGrid.GridColor = Color.DarkRed;
         //BoardGrid.DefaultCellStyle.BackColor = Color.White;
         BoardGrid.ScrollBars = ScrollBars.None;
         BoardGrid.Size = new Size(border, border);
         //BoardGrid.Location = new Point(50, 50);
         BoardGrid.Font = new System.Drawing.Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
         BoardGrid.ForeColor = Color.DarkRed;
         BoardGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;

         for (int i = 0; i < maxcell; i++)
         {
            DataGridViewTextBoxColumn playcol = new DataGridViewTextBoxColumn();
            playcol.MaxInputLength = 1;
            BoardGrid.Columns.Add(playcol);
            BoardGrid.Columns[i].Name = "playcol " + (i + 1).ToString();
            BoardGrid.Columns[i].Width = colwidth;
            BoardGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewRow playrow = new DataGridViewRow();
            playrow.Height = rowheight;
            BoardGrid.Rows.Add(playrow);
         }

         BoardGrid.Columns[2].DividerWidth = 2;
         BoardGrid.Columns[5].DividerWidth = 2;
         BoardGrid.Rows[2].DividerHeight = 2;
         BoardGrid.Rows[5].DividerHeight = 2;

         BoardGrid.Top = 35;
         BoardGrid.Left = 350;

         BoardGrid.Rows[0].Cells[0].Selected = false;
         for (int i = 0; i < 9; ++i)
         {
            for (int y = 0; y < 9; ++y)
            {
               BoardGrid.Rows[i].Cells[y].Value = null;
               BoardGrid.Rows[i].Cells[y].Style.BackColor = Color.White;
               BoardGrid.Rows[i].Cells[y].ReadOnly = true;
            }
         }

      }

      public void InitNumberGrid()
      {


         NumberGrid.Name = "NumberGrid";
         NumberGrid.AllowUserToResizeColumns = false;
         NumberGrid.AllowUserToResizeRows = false;
         NumberGrid.AllowUserToAddRows = false;
         NumberGrid.RowHeadersVisible = false;
         NumberGrid.ColumnHeadersVisible = false;
         NumberGrid.GridColor = Color.DarkRed;
         NumberGrid.DefaultCellStyle.BackColor = Color.Beige;
         NumberGrid.ScrollBars = ScrollBars.None;
         NumberGrid.Size = new Size(border, rowheight);
         //NumberGrid.Location = new Point(50, 50);
         NumberGrid.Font = new System.Drawing.Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
         NumberGrid.ForeColor = Color.DarkRed;
         NumberGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;

         //Disabled multiple cell selection
         NumberGrid.MultiSelect = false;

         for (int i = 0; i < maxcell; i++)
         {
            DataGridViewTextBoxColumn numbercol = new DataGridViewTextBoxColumn();
            numbercol.MaxInputLength = 1;
            NumberGrid.Columns.Add(numbercol);
            NumberGrid.Columns[i].Name = " numbercol " + (i + 1).ToString();
            NumberGrid.Columns[i].Width = colwidth;
            NumberGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
         }


         DataGridViewRow numberrow = new DataGridViewRow();
         numberrow.Height = rowheight;
         NumberGrid.Rows.Add(numberrow);

         for (int i = 0; i < maxcell; i++)
         {

            NumberGrid.Rows[0].Cells[i].Value = (i + 1).ToString();
            NumberGrid.Rows[0].Cells[i].ReadOnly = true;
         }

         NumberGrid.Top = 450;
         NumberGrid.Left = 350;


         NumberGrid.Rows[0].Cells[0].Selected = false;
      }
      public void InitEmptyGrid()
      {
         EmptyGrid.Name = "EmptyGrid";
         EmptyGrid.AllowUserToResizeColumns = false;
         EmptyGrid.AllowUserToResizeRows = false;
         EmptyGrid.AllowUserToAddRows = false;
         EmptyGrid.RowHeadersVisible = false;
         EmptyGrid.ColumnHeadersVisible = false;
         EmptyGrid.GridColor = Color.DarkRed;
         EmptyGrid.DefaultCellStyle.BackColor = Color.Beige;
         EmptyGrid.ScrollBars = ScrollBars.None;
         EmptyGrid.Size = new Size(rowheight, rowheight);
         //EmptyGrid.Location = new Point(50, 50);
         EmptyGrid.Font = new System.Drawing.Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
         EmptyGrid.ForeColor = Color.DarkRed;
         EmptyGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
         DataGridViewTextBoxColumn emptycol = new DataGridViewTextBoxColumn();
         emptycol.MaxInputLength = 1;
         EmptyGrid.Columns.Add(emptycol);
         EmptyGrid.Columns[0].Name = " emptycol ";
         EmptyGrid.Columns[0].Width = colwidth;
         EmptyGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


         DataGridViewRow emptyrow = new DataGridViewRow();
         emptyrow.Height = rowheight;
         EmptyGrid.Rows.Add(emptyrow);

         EmptyGrid.Rows[0].Cells[0].Value = " ";
         EmptyGrid.Rows[0].Cells[0].ReadOnly = true;


         EmptyGrid.Top = 450;
         EmptyGrid.Left = 300;
         EmptyGrid.Rows[0].Cells[0].Selected = true;

      }
      public void InitForm()
      {
         //reset timer
         GameTimer.Start();
         minute = second = 0;
         resultToolStripMenuItem.Text = "";
         highScoreControl1.Visible = false;
         checkresult = false;
         errorcount = 0;
         SudokuArray = GenSudokuPuzzle();
      }

      public void ResetSelects()
      {
         BoardGrid.CurrentCell.Selected = false;
         NumberGrid.CurrentCell.Selected = false;
         EmptyGrid.Rows[0].Cells[0].Selected = true;
         hilightNumbers(false);   //Terry reset ForeColor to DarkRed ********
      }

      private void EmptyGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {
         this.NumberGrid.CurrentCell.Selected = false;
         hilightNumbers(false);  //Terry set ForeColor to DarkRed  ******
      }

      private void NumberGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {
         this.EmptyGrid.CurrentCell.Selected = false;
         hilightNumbers(true);  //Terry set selected number ForeColor to Red all others to DarkRed ******
      }



      private void newPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
      {
         switch (checkresult)
         {
            case true:
               {
                  ResetSelects();
                  InitForm();
                  InitBoardGrid();
                  InitNumberGrid();
                  InitEmptyGrid();
                  InitBoard();
                  break;
               }
            default:
               {
                  if (MessageBox.Show("Are you sure you want a new puzzle?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                  {
                     ResetSelects();
                     InitForm();
                     InitBoardGrid();
                     InitNumberGrid();
                     InitEmptyGrid();
                     InitBoard();


                  }
                  break;
               }


         }
      }

      private void checkSolutionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string boardvalue, arrayvalue;
         ResetSelects();
         checkresult = true;
         for (int i = 0; i < 9; ++i)
         {
            for (int y = 0; y < 9; ++y)
            {
               try
               {
                  boardvalue = BoardGrid.Rows[i].Cells[y].Value.ToString();
               }
               catch
               {
                  boardvalue = "";
               }
               arrayvalue = SudokuArray[i, y].ToString();

               if (boardvalue != arrayvalue)
               {
                  BoardGrid.Rows[i].Cells[y].Style.BackColor = Color.Red;
                  errorcount += 1;
               }

               BoardGrid.Rows[i].Cells[y].Value = SudokuArray[i, y].ToString();
            }
         }

         score = calculateScore(toolcboDifficulty.SelectedIndex, minute, second, errorcount, hints, randomcount, score);

            //Andy4/18 New highscore system
            HighScores.UpdateHighScoreList(score.ToString());
            //Andy4/18 Updates highscore control to reflect the current state of the high scores
            highScoreControl1.refresh(HIGH_SCORES, DATES);

            //Andy4/18 The new timer wasn't resetting on new game. Fixed.
            second = minute = 0;


         if (errorcount > 0)
         {
            //lblResult.Text = "You Lost!!!!";
            // MessageBox.Show("You Lost!!!!", "Score: " + score, MessageBoxButtons.OK);
            resultToolStripMenuItem.Text = String.Concat("You Lost!!! Score: ", score.ToString());
            highScoreControl1.Visible = true;
            GameTimer.Stop();

         }
         else
         {
            //lblResult.Text = "You Won!!!!";
            //MessageBox.Show("You Won!!!!", "Score: " + score, MessageBoxButtons.OK);
            resultToolStripMenuItem.Text = String.Concat("You Won!!! Score: ", score.ToString());
            highScoreControl1.Visible = true;
            GameTimer.Stop();
         }
         errorcount = 0;
      }

      private void hintToolStripMenuItem_Click(object sender, EventArgs e)
      {
         int numexposed = 0;
         if (this.EmptyGrid.CurrentCell.Selected == false)
         {
            string boardvalue, arrayvalue, numbervalue;

            for (int i = 0; i < 9; ++i)
            {
               for (int y = 0; y < 9; ++y)
               {
                  try
                  {
                     boardvalue = BoardGrid.Rows[i].Cells[y].Value.ToString();
                  }
                  catch
                  {
                     boardvalue = "";
                  }
                  arrayvalue = SudokuArray[i, y].ToString();
                  numbervalue = NumberGrid.CurrentCell.Value.ToString();

                  if (boardvalue == "" & numbervalue == arrayvalue)
                  {

                     BoardGrid.Rows[i].Cells[y].Value = SudokuArray[i, y].ToString();

                     BoardGrid.Rows[i].Cells[y].Style.BackColor = Color.Beige;
                     numexposed++;
                  }
               }
            }

         }

         if (numexposed > 0)
         {
            hints--;
         }
         if (hints < 1)
         {
            hintToolStripMenuItem.Visible = false;
            hintToolStripMenuItem.Enabled = false;
         }
         else
         {
            hintToolStripMenuItem.Visible = true;
            hintToolStripMenuItem.Enabled = true;
            hintToolStripMenuItem.Text = string.Concat("Hints = ", hints);

         }
      }

      private void toolcboDifficulty_Click(object sender, EventArgs e)
      {
      }

      private void toolcboDifficulty_SelectedIndexChanged(object sender, EventArgs e)
      {
         this.menuPuzzle.Focus();
         this.newPuzzleToolStripMenuItem.Select();
      }



      public Boolean CheckForMax(int row, int col)
      {
         int count = 0;

         //check row for set numbers
         count = 0;
         for (int i = 0; i < 9; ++i)
         {
            if (BoardGrid.Rows[row].Cells[i].Style.BackColor == Color.White)
            {
               count++;
            }

         }
         if (count < 2)
         {
            return true;
         }

         //check col for set numbers
         count = 0;
         for (int i = 0; i < 9; ++i)
         {
            if (BoardGrid.Rows[i].Cells[col].Style.BackColor == Color.White)
            {
               count++;
            }
         }
         if (count < 2)
         {
            return true;
         }

         //check grid for set numbers

         int blocknumber = 0;

         switch ((row + 1).ToString() + (col + 1).ToString())
         {
            case "11":
               {
                  blocknumber = 1;
                  break;
               }
            case "12":
               {
                  blocknumber = 1;
                  break;
               }
            case "13":
               {
                  blocknumber = 1;
                  break;
               }
            case "14":
               {
                  blocknumber = 2;
                  break;
               }
            case "15":
               {
                  blocknumber = 2;
                  break;
               }
            case "16":
               {
                  blocknumber = 2;
                  break;
               }
            case "17":
               {
                  blocknumber = 3;
                  break;
               }
            case "18":
               {
                  blocknumber = 3;
                  break;
               }
            case "19":
               {
                  blocknumber = 3;
                  break;
               }
            case "21":
               {
                  blocknumber = 1;
                  break;
               }
            case "22":
               {
                  blocknumber = 1;
                  break;
               }
            case "23":
               {
                  blocknumber = 1;
                  break;
               }
            case "24":
               {
                  blocknumber = 2;
                  break;
               }
            case "25":
               {
                  blocknumber = 2;
                  break;
               }
            case "26":
               {
                  blocknumber = 2;
                  break;
               }
            case "27":
               {
                  blocknumber = 3;
                  break;
               }
            case "28":
               {
                  blocknumber = 3;
                  break;
               }
            case "29":
               {
                  blocknumber = 3;
                  break;
               }
            case "31":
               {
                  blocknumber = 1;
                  break;
               }
            case "32":
               {
                  blocknumber = 1;
                  break;
               }
            case "33":
               {
                  blocknumber = 1;
                  break;
               }
            case "34":
               {
                  blocknumber = 2;
                  break;
               }
            case "35":
               {
                  blocknumber = 2;
                  break;
               }
            case "36":
               {
                  blocknumber = 2;
                  break;
               }
            case "37":
               {
                  blocknumber = 3;
                  break;
               }
            case "38":
               {
                  blocknumber = 3;
                  break;
               }
            case "39":
               {
                  blocknumber = 3;
                  break;
               }
            case "41":
               {
                  blocknumber = 4;
                  break;
               }
            case "42":
               {
                  blocknumber = 4;
                  break;
               }
            case "43":
               {
                  blocknumber = 4;
                  break;
               }
            case "44":
               {
                  blocknumber = 5;
                  break;
               }
            case "45":
               {
                  blocknumber = 5;
                  break;
               }
            case "46":
               {
                  blocknumber = 5;
                  break;
               }
            case "47":
               {
                  blocknumber = 6;
                  break;
               }
            case "48":
               {
                  blocknumber = 6;
                  break;
               }
            case "49":
               {
                  blocknumber = 6;
                  break;
               }
            case "51":
               {
                  blocknumber = 4;
                  break;
               }
            case "52":
               {
                  blocknumber = 4;
                  break;
               }
            case "53":
               {
                  blocknumber = 4;
                  break;
               }
            case "54":
               {
                  blocknumber = 5;
                  break;
               }
            case "55":
               {
                  blocknumber = 5;
                  break;
               }
            case "56":
               {
                  blocknumber = 5;
                  break;
               }
            case "57":
               {
                  blocknumber = 6;
                  break;
               }
            case "58":
               {
                  blocknumber = 6;
                  break;
               }
            case "59":
               {
                  blocknumber = 6;
                  break;
               }
            case "61":
               {
                  blocknumber = 4;
                  break;
               }
            case "62":
               {
                  blocknumber = 4;
                  break;
               }
            case "63":
               {
                  blocknumber = 4;
                  break;
               }
            case "64":
               {
                  blocknumber = 5;
                  break;
               }
            case "65":
               {
                  blocknumber = 5;
                  break;
               }
            case "66":
               {
                  blocknumber = 5;
                  break;
               }
            case "67":
               {
                  blocknumber = 6;
                  break;
               }
            case "68":
               {
                  blocknumber = 6;
                  break;
               }
            case "69":
               {
                  blocknumber = 6;
                  break;
               }

            case "71":
               {
                  blocknumber = 7;
                  break;
               }
            case "72":
               {
                  blocknumber = 7;
                  break;
               }
            case "73":
               {
                  blocknumber = 7;
                  break;
               }
            case "74":
               {
                  blocknumber = 8;
                  break;
               }
            case "75":
               {
                  blocknumber = 8;
                  break;
               }
            case "76":
               {
                  blocknumber = 8;
                  break;
               }
            case "77":
               {
                  blocknumber = 9;
                  break;
               }
            case "78":
               {
                  blocknumber = 9;
                  break;
               }
            case "79":
               {
                  blocknumber = 9;
                  break;
               }
            case "81":
               {
                  blocknumber = 7;
                  break;
               }
            case "82":
               {
                  blocknumber = 7;
                  break;
               }
            case "83":
               {
                  blocknumber = 7;
                  break;
               }
            case "84":
               {
                  blocknumber = 8;
                  break;
               }
            case "85":
               {
                  blocknumber = 8;
                  break;
               }
            case "86":
               {
                  blocknumber = 8;
                  break;
               }
            case "87":
               {
                  blocknumber = 9;
                  break;
               }
            case "88":
               {
                  blocknumber = 9;
                  break;
               }
            case "89":
               {
                  blocknumber = 9;
                  break;
               }
            case "91":
               {
                  blocknumber = 7;
                  break;
               }
            case "92":
               {
                  blocknumber = 7;
                  break;
               }
            case "93":
               {
                  blocknumber = 7;
                  break;
               }
            case "94":
               {
                  blocknumber = 8;
                  break;
               }
            case "95":
               {
                  blocknumber = 8;
                  break;
               }
            case "96":
               {
                  blocknumber = 8;
                  break;
               }
            case "97":
               {
                  blocknumber = 9;
                  break;
               }
            case "98":
               {
                  blocknumber = 9;
                  break;
               }
            case "99":
               {
                  blocknumber = 9;
                  break;
               }

         }



         count = 0;


         switch (blocknumber)
         {
            case 1:
               {
                  if (BoardGrid.Rows[1 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[1 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[1 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 2:
               {
                  if (BoardGrid.Rows[1 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[1 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[1 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 3:
               {
                  if (BoardGrid.Rows[1 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[1 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[1 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[2 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[3 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 4:
               {
                  if (BoardGrid.Rows[4 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[4 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[4 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 5:
               {
                  if (BoardGrid.Rows[4 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[4 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[4 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 6:
               {
                  if (BoardGrid.Rows[4 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[4 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[4 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[5 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[6 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 7:
               {
                  if (BoardGrid.Rows[7 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[7 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[7 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[1 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[2 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[3 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 8:
               {
                  if (BoardGrid.Rows[7 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[7 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[7 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[4 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[5 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[6 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }
            case 9:
               {
                  if (BoardGrid.Rows[7 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[7 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[7 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[8 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[7 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[8 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }
                  if (BoardGrid.Rows[9 - 1].Cells[9 - 1].Style.BackColor == Color.White)
                  {
                     count++;
                  }

                  break;
               }

         }

         if (count < 2)
         {
            return true;
         }


         return false;
      }
      //Increments timer every second

      private void menuPuzzle_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
      {

      }

      //
      public int calculateScore(int difficulty, int minute, int second, int errors, int hints, int randomcount, int previousScore)
      {
            int score;
            int time = (minute * 60) + second;
            int timeBonus = 300 * (difficulty + 1);
            int bonus;

            //Modifier for the Bonus when time (updated: Improved logic)
            if (timeBonus > time)
            {
                bonus = 5000 + ((timeBonus - time) * 3);

            }
            else if (timeBonus * 2 > time)
            {
                bonus = 2500 + (((timeBonus * 2) - time) * 3);
            }
            else
            {
                bonus = 0;
            }

            score = bonus + ((81 - randomcount - errors) * 100);

            if ((difficulty == 2 && errors == 0) || (difficulty == 1 && errors == 0 && hints == 2) || (difficulty == 0 && errors == 0 && hints == 5))
            {
                score += 5000;
            }
            if (errors > 0)
            {
                score = ((81 - randomcount - errors) * 100);
            }

            if (puzzleAssist == true)
            {
                score -= 1000;
            }
            if (score < 0)
            {
                score = 0;
            }


            if (previousScore < score)
            {
               // HighScoreBox.Text = score.ToString();
            }
            return score;



        }

        private void HighScoreBox_Click(object sender, EventArgs e)
      {

      }
      private void hilightNumbers(bool assist)    //Terry puzzle assist if on highlight selected numbers in red *********
      {
         if (!puzzleAssist) return;         // return if puzzle assist is off
         string boardvalue, numbervalue;
         Color numberColor = Color.DarkRed;
         if (assist) numberColor = Color.Orange;
         for (int i = 0; i < 9; ++i)
         {
            for (int y = 0; y < 9; ++y)
            {
               try
               {
                  boardvalue = BoardGrid.Rows[i].Cells[y].Value.ToString();
               }
               catch
               {
                  boardvalue = "";
               }

               numbervalue = NumberGrid.CurrentCell.Value.ToString();

               if (numbervalue == boardvalue)
               {
                  BoardGrid.Rows[i].Cells[y].Style.ForeColor = numberColor;
               }
               else { BoardGrid.Rows[i].Cells[y].Style.ForeColor = Color.DarkRed; }




            }
         }

      }

      //private void btnPuzzleAssist_Click(object sender, EventArgs e)  //Terry Puzzle Assist Button  *************
      //{
      //   if (puzzleAssist)
      //   {
      //      hilightNumbers(false);  // reset board
      //      puzzleAssist = false;   // assist off
      //      btnPuzzleAssist.BackColor = DefaultBackColor;
      //   }
      //   else
      //   {
      //      puzzleAssist = true;    // assist on
      //      btnPuzzleAssist.BackColor = Color.Blue;
      //      hilightNumbers(true);   // set highlights
      //   }
      //}

      private void assistToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (puzzleAssist)
         {
            hilightNumbers(false);  // reset board
            puzzleAssist = false;   // assist off
            assistToolStripMenuItem.BackColor = DefaultBackColor;
         }
         else
         {
            puzzleAssist = true;    // assist on
            assistToolStripMenuItem.BackColor = Color.LightBlue;
            if (EmptyGrid.CurrentCell.Selected == false)
            {

               hilightNumbers(true);   // set highlights

            }
            else
            {
               hilightNumbers(false);
            }
            
         }
      }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //increment second
            second++;

            //resets seconds to zero adds a minute
            if (second == 60)
            {
                minute++;
                second = 0;
            }

            //Formatting for timer
            if (second < 10)
            {
                timerToolStripMenuItem.Text = minute + ":0" + second;
            }
            else
            {
                timerToolStripMenuItem.Text = minute + ":" + second;
            }
        }

        private void highScoreControl1_Load(object sender, EventArgs e)
        {

        }


      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         HelpForm help = new HelpForm();
         help.Show();
      }

      private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         MessageBox.Show(
    "Team Charlie Sudoku Project\n" +
    "Created: Spring 2018\n\n" +
    "Team Members\n" +
    "Andy Reeves\n" + "Steve Coats\n" + "Terry Smith",
    "About Sudoku App",
    MessageBoxButtons.OK);
      }
   }

}

