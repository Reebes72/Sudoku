namespace Sudoku
{
    partial class SudokuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SudokuForm));
         this.BoardGrid = new System.Windows.Forms.DataGridView();
         this.NumberGrid = new System.Windows.Forms.DataGridView();
         this.EmptyGrid = new System.Windows.Forms.DataGridView();
         this.menuPuzzle = new System.Windows.Forms.MenuStrip();
         this.newPuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolcboDifficulty = new System.Windows.Forms.ToolStripComboBox();
         this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.checkSolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.assistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.GameTimer = new System.Windows.Forms.Timer(this.components);
         this.highScoreControl1 = new Sudoku.HighScoreControl();
         ((System.ComponentModel.ISupportInitialize)(this.BoardGrid)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.NumberGrid)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.EmptyGrid)).BeginInit();
         this.menuPuzzle.SuspendLayout();
         this.SuspendLayout();
         // 
         // BoardGrid
         // 
         this.BoardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.BoardGrid.Location = new System.Drawing.Point(350, 36);
         this.BoardGrid.Name = "BoardGrid";
         this.BoardGrid.Size = new System.Drawing.Size(408, 408);
         this.BoardGrid.TabIndex = 2;
         this.BoardGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BoardGrid_CellClick);
         // 
         // NumberGrid
         // 
         this.NumberGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.NumberGrid.Location = new System.Drawing.Point(350, 450);
         this.NumberGrid.Name = "NumberGrid";
         this.NumberGrid.Size = new System.Drawing.Size(408, 45);
         this.NumberGrid.TabIndex = 3;
         this.NumberGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NumberGrid_CellMouseClick);
         // 
         // EmptyGrid
         // 
         this.EmptyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.EmptyGrid.Location = new System.Drawing.Point(300, 450);
         this.EmptyGrid.Name = "EmptyGrid";
         this.EmptyGrid.Size = new System.Drawing.Size(45, 45);
         this.EmptyGrid.TabIndex = 5;
         this.EmptyGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EmptyGrid_CellMouseClick);
         // 
         // menuPuzzle
         // 
         this.menuPuzzle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPuzzleToolStripMenuItem,
            this.toolcboDifficulty,
            this.hintToolStripMenuItem,
            this.checkSolutionToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.assistToolStripMenuItem,
            this.timerToolStripMenuItem,
            this.resultToolStripMenuItem,
            this.toolStripMenuItem1});
         this.menuPuzzle.Location = new System.Drawing.Point(0, 0);
         this.menuPuzzle.Name = "menuPuzzle";
         this.menuPuzzle.Size = new System.Drawing.Size(781, 27);
         this.menuPuzzle.TabIndex = 8;
         // 
         // newPuzzleToolStripMenuItem
         // 
         this.newPuzzleToolStripMenuItem.Name = "newPuzzleToolStripMenuItem";
         this.newPuzzleToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
         this.newPuzzleToolStripMenuItem.Text = "NewPuzzle";
         this.newPuzzleToolStripMenuItem.Click += new System.EventHandler(this.newPuzzleToolStripMenuItem_Click);
         // 
         // toolcboDifficulty
         // 
         this.toolcboDifficulty.AutoCompleteCustomSource.AddRange(new string[] {
            "Easy",
            "Medium",
            "Hard"});
         this.toolcboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.toolcboDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
         this.toolcboDifficulty.Name = "toolcboDifficulty";
         this.toolcboDifficulty.Size = new System.Drawing.Size(121, 23);
         this.toolcboDifficulty.SelectedIndexChanged += new System.EventHandler(this.toolcboDifficulty_SelectedIndexChanged);
         // 
         // hintToolStripMenuItem
         // 
         this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
         this.hintToolStripMenuItem.Size = new System.Drawing.Size(42, 23);
         this.hintToolStripMenuItem.Text = "Hint";
         this.hintToolStripMenuItem.Click += new System.EventHandler(this.hintToolStripMenuItem_Click);
         // 
         // checkSolutionToolStripMenuItem
         // 
         this.checkSolutionToolStripMenuItem.Name = "checkSolutionToolStripMenuItem";
         this.checkSolutionToolStripMenuItem.Size = new System.Drawing.Size(99, 23);
         this.checkSolutionToolStripMenuItem.Text = "Check Solution";
         this.checkSolutionToolStripMenuItem.Click += new System.EventHandler(this.checkSolutionToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
         this.aboutToolStripMenuItem.Text = "Help";
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem1
         // 
         this.aboutToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
         this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 23);
         this.aboutToolStripMenuItem1.Text = "About";
         this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
         // 
         // assistToolStripMenuItem
         // 
         this.assistToolStripMenuItem.Name = "assistToolStripMenuItem";
         this.assistToolStripMenuItem.Size = new System.Drawing.Size(49, 23);
         this.assistToolStripMenuItem.Text = "Assist";
         this.assistToolStripMenuItem.Click += new System.EventHandler(this.assistToolStripMenuItem_Click);
         // 
         // timerToolStripMenuItem
         // 
         this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
         this.timerToolStripMenuItem.Size = new System.Drawing.Size(12, 23);
         // 
         // resultToolStripMenuItem
         // 
         this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
         this.resultToolStripMenuItem.Size = new System.Drawing.Size(12, 23);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 23);
         // 
         // GameTimer
         // 
         this.GameTimer.Enabled = true;
         this.GameTimer.Interval = 1000;
         this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
         // 
         // highScoreControl1
         // 
         this.highScoreControl1.BackColor = System.Drawing.Color.LightGray;
         this.highScoreControl1.Location = new System.Drawing.Point(61, 315);
         this.highScoreControl1.Name = "highScoreControl1";
         this.highScoreControl1.Size = new System.Drawing.Size(208, 178);
         this.highScoreControl1.TabIndex = 9;
         this.highScoreControl1.Load += new System.EventHandler(this.highScoreControl1_Load);
         // 
         // SudokuForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.ClientSize = new System.Drawing.Size(781, 505);
         this.Controls.Add(this.highScoreControl1);
         this.Controls.Add(this.EmptyGrid);
         this.Controls.Add(this.NumberGrid);
         this.Controls.Add(this.BoardGrid);
         this.Controls.Add(this.menuPuzzle);
         this.DoubleBuffered = true;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuPuzzle;
         this.Name = "SudokuForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Sudoku";
         this.Load += new System.EventHandler(this.SudokuForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.BoardGrid)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.NumberGrid)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.EmptyGrid)).EndInit();
         this.menuPuzzle.ResumeLayout(false);
         this.menuPuzzle.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

      #endregion
        private System.Windows.Forms.DataGridView BoardGrid;
        private System.Windows.Forms.DataGridView NumberGrid;
        private System.Windows.Forms.DataGridView EmptyGrid;
        private System.Windows.Forms.MenuStrip menuPuzzle;
        private System.Windows.Forms.ToolStripMenuItem newPuzzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolcboDifficulty;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkSolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem assistToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Timer GameTimer;
        private HighScoreControl highScoreControl1;
    }
}

