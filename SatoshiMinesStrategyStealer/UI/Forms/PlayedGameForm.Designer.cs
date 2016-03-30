namespace SatoshiMinesStrategyStealer.UI.Forms
{
    partial class PlayedGameForm
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
            this.plMines = new SatoshiMinesStrategyStealer.UI.Controls.PrefixLabel();
            this.plGuesses = new SatoshiMinesStrategyStealer.UI.Controls.PrefixLabel();
            this.plBet = new SatoshiMinesStrategyStealer.UI.Controls.PrefixLabel();
            this.smgMain = new SatoshiMinesStrategyStealer.UI.Controls.SatoshiMinesGrid();
            this.plWon = new SatoshiMinesStrategyStealer.UI.Controls.PrefixLabel();
            this.SuspendLayout();
            // 
            // plMines
            // 
            this.plMines.AutoSize = true;
            this.plMines.Location = new System.Drawing.Point(270, 57);
            this.plMines.Name = "plMines";
            this.plMines.Prefix = "Mines: ";
            this.plMines.RealText = null;
            this.plMines.Size = new System.Drawing.Size(48, 13);
            this.plMines.TabIndex = 2;
            this.plMines.Text = "Mines: ";
            // 
            // plGuesses
            // 
            this.plGuesses.AutoSize = true;
            this.plGuesses.Location = new System.Drawing.Point(270, 105);
            this.plGuesses.Name = "plGuesses";
            this.plGuesses.Prefix = "Guesses: ";
            this.plGuesses.RealText = null;
            this.plGuesses.Size = new System.Drawing.Size(64, 13);
            this.plGuesses.TabIndex = 2;
            this.plGuesses.Text = "Guesses: ";
            // 
            // plBet
            // 
            this.plBet.AutoSize = true;
            this.plBet.Location = new System.Drawing.Point(270, 153);
            this.plBet.Name = "plBet";
            this.plBet.Prefix = "Bet: ";
            this.plBet.RealText = null;
            this.plBet.Size = new System.Drawing.Size(35, 13);
            this.plBet.TabIndex = 2;
            this.plBet.Text = "Bet: ";
            // 
            // smgMain
            // 
            this.smgMain.GameStarted = false;
            this.smgMain.Location = new System.Drawing.Point(12, 12);
            this.smgMain.Name = "smgMain";
            this.smgMain.Size = new System.Drawing.Size(252, 252);
            this.smgMain.TabIndex = 0;
            this.smgMain.Text = "satoshiMinesGrid1";
            // 
            // plWon
            // 
            this.plWon.AutoSize = true;
            this.plWon.Location = new System.Drawing.Point(270, 201);
            this.plWon.Name = "plWon";
            this.plWon.Prefix = "Won: ";
            this.plWon.RealText = null;
            this.plWon.Size = new System.Drawing.Size(40, 13);
            this.plWon.TabIndex = 2;
            this.plWon.Text = "Won: ";
            // 
            // PlayedGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 271);
            this.Controls.Add(this.plMines);
            this.Controls.Add(this.plGuesses);
            this.Controls.Add(this.plBet);
            this.Controls.Add(this.smgMain);
            this.Controls.Add(this.plWon);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PlayedGameForm";
            this.Text = "{0} - Game #{1} / {2}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayedGameForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.SatoshiMinesGrid smgMain;
        private Controls.PrefixLabel plMines;
        private Controls.PrefixLabel plGuesses;
        private Controls.PrefixLabel plBet;
        private Controls.PrefixLabel plWon;
    }
}