namespace Sudoku
{
    partial class HelpForm
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
         this.RulesLink = new System.Windows.Forms.LinkLabel();
         this.HelpTextBox = new System.Windows.Forms.RichTextBox();
         this.HowToPlay = new System.Windows.Forms.LinkLabel();
         this.ScoringSystemLink = new System.Windows.Forms.LinkLabel();
         this.CloseButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // RulesLink
         // 
         this.RulesLink.AutoSize = true;
         this.RulesLink.Location = new System.Drawing.Point(13, 23);
         this.RulesLink.Name = "RulesLink";
         this.RulesLink.Size = new System.Drawing.Size(86, 13);
         this.RulesLink.TabIndex = 0;
         this.RulesLink.TabStop = true;
         this.RulesLink.Text = "Rules of Sudoku";
         this.RulesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RulesLink_LinkClicked);
         // 
         // HelpTextBox
         // 
         this.HelpTextBox.Location = new System.Drawing.Point(140, 12);
         this.HelpTextBox.Name = "HelpTextBox";
         this.HelpTextBox.ReadOnly = true;
         this.HelpTextBox.Size = new System.Drawing.Size(228, 206);
         this.HelpTextBox.TabIndex = 1;
         this.HelpTextBox.Text = "";
         // 
         // HowToPlay
         // 
         this.HowToPlay.AutoSize = true;
         this.HowToPlay.Location = new System.Drawing.Point(13, 36);
         this.HowToPlay.Name = "HowToPlay";
         this.HowToPlay.Size = new System.Drawing.Size(68, 13);
         this.HowToPlay.TabIndex = 2;
         this.HowToPlay.TabStop = true;
         this.HowToPlay.Text = "How To Play";
         this.HowToPlay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HowToPlay_LinkClicked);
         // 
         // ScoringSystemLink
         // 
         this.ScoringSystemLink.AutoSize = true;
         this.ScoringSystemLink.Location = new System.Drawing.Point(13, 49);
         this.ScoringSystemLink.Name = "ScoringSystemLink";
         this.ScoringSystemLink.Size = new System.Drawing.Size(92, 13);
         this.ScoringSystemLink.TabIndex = 3;
         this.ScoringSystemLink.TabStop = true;
         this.ScoringSystemLink.Text = "Scoring Explained";
         this.ScoringSystemLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ScoringSystemLink_LinkClicked);
         // 
         // CloseButton
         // 
         this.CloseButton.AutoSize = true;
         this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.CloseButton.Location = new System.Drawing.Point(16, 191);
         this.CloseButton.Name = "CloseButton";
         this.CloseButton.Size = new System.Drawing.Size(75, 25);
         this.CloseButton.TabIndex = 4;
         this.CloseButton.Text = "Exit";
         this.CloseButton.UseVisualStyleBackColor = true;
         this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
         // 
         // HelpForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(376, 226);
         this.Controls.Add(this.CloseButton);
         this.Controls.Add(this.ScoringSystemLink);
         this.Controls.Add(this.HowToPlay);
         this.Controls.Add(this.HelpTextBox);
         this.Controls.Add(this.RulesLink);
         this.MaximizeBox = false;
         this.Name = "HelpForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Help";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel RulesLink;
        private System.Windows.Forms.RichTextBox HelpTextBox;
        private System.Windows.Forms.LinkLabel HowToPlay;
        private System.Windows.Forms.LinkLabel ScoringSystemLink;
        private System.Windows.Forms.Button CloseButton;
    }
}