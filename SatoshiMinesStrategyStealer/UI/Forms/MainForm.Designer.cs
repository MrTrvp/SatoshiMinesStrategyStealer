namespace SatoshiMinesStrategyStealer.UI.Forms
{
    partial class MainForm
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
                components.Dispose();

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
            this.lvLiveGames = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWinLoss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProfit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGameHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSecret = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsLiveGames = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProfit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameHash = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSecret = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStartLoadingStrategy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFollowSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewDetailsForSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.pgMain = new System.Windows.Forms.PropertyGrid();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiStartStrategy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWithdrawToWallet = new System.Windows.Forms.ToolStripMenuItem();
            this.smgMain = new SatoshiMinesStrategyStealer.UI.Controls.SatoshiMinesGrid();
            this.cmsLiveGames.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLiveGames
            // 
            this.lvLiveGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chBet,
            this.chWinLoss,
            this.chProfit,
            this.chGameHash,
            this.chSecret});
            this.lvLiveGames.ContextMenuStrip = this.cmsLiveGames;
            this.lvLiveGames.FullRowSelect = true;
            this.lvLiveGames.Location = new System.Drawing.Point(12, 233);
            this.lvLiveGames.Name = "lvLiveGames";
            this.lvLiveGames.Size = new System.Drawing.Size(583, 128);
            this.lvLiveGames.TabIndex = 1;
            this.lvLiveGames.UseCompatibleStateImageBehavior = false;
            this.lvLiveGames.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 170;
            // 
            // chBet
            // 
            this.chBet.Text = "Bet";
            this.chBet.Width = 80;
            // 
            // chWinLoss
            // 
            this.chWinLoss.Text = "Win / Loss";
            this.chWinLoss.Width = 80;
            // 
            // chProfit
            // 
            this.chProfit.Text = "Profit";
            this.chProfit.Width = 80;
            // 
            // chGameHash
            // 
            this.chGameHash.Text = "Game Hash";
            this.chGameHash.Width = 170;
            // 
            // chSecret
            // 
            this.chSecret.Text = "Secret";
            this.chSecret.Width = 170;
            // 
            // cmsLiveGames
            // 
            this.cmsLiveGames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tsmiClear,
            this.tsmiStartLoadingStrategy,
            this.tsmiFollowSelected,
            this.tsmiViewDetailsForSelected});
            this.cmsLiveGames.Name = "cmsLiveGames";
            this.cmsLiveGames.Size = new System.Drawing.Size(203, 114);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiName,
            this.tsmiBet,
            this.tsmiWin,
            this.tsmiProfit,
            this.tsmiGameHash,
            this.tsmiSecret});
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(202, 22);
            this.tsmiCopy.Text = "Copy";
            // 
            // tsmiName
            // 
            this.tsmiName.Name = "tsmiName";
            this.tsmiName.Size = new System.Drawing.Size(135, 22);
            this.tsmiName.Text = "Name";
            this.tsmiName.Click += new System.EventHandler(this.tsmiCopyClick);
            // 
            // tsmiBet
            // 
            this.tsmiBet.Name = "tsmiBet";
            this.tsmiBet.Size = new System.Drawing.Size(135, 22);
            this.tsmiBet.Text = "Bet";
            this.tsmiBet.Click += new System.EventHandler(this.tsmiCopyClick);
            // 
            // tsmiWin
            // 
            this.tsmiWin.Name = "tsmiWin";
            this.tsmiWin.Size = new System.Drawing.Size(135, 22);
            this.tsmiWin.Text = "Win";
            this.tsmiWin.Click += new System.EventHandler(this.tsmiCopyClick);
            // 
            // tsmiProfit
            // 
            this.tsmiProfit.Name = "tsmiProfit";
            this.tsmiProfit.Size = new System.Drawing.Size(135, 22);
            this.tsmiProfit.Text = "Profit";
            this.tsmiProfit.Click += new System.EventHandler(this.tsmiCopyClick);
            // 
            // tsmiGameHash
            // 
            this.tsmiGameHash.Name = "tsmiGameHash";
            this.tsmiGameHash.Size = new System.Drawing.Size(135, 22);
            this.tsmiGameHash.Text = "Game Hash";
            this.tsmiGameHash.Click += new System.EventHandler(this.tsmiCopyClick);
            // 
            // tsmiSecret
            // 
            this.tsmiSecret.Name = "tsmiSecret";
            this.tsmiSecret.Size = new System.Drawing.Size(135, 22);
            this.tsmiSecret.Text = "Secret";
            this.tsmiSecret.Click += new System.EventHandler(this.tsmiCopyClick);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(202, 22);
            this.tsmiClear.Text = "Clear";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tsmiStartLoadingStrategy
            // 
            this.tsmiStartLoadingStrategy.Name = "tsmiStartLoadingStrategy";
            this.tsmiStartLoadingStrategy.Size = new System.Drawing.Size(202, 22);
            this.tsmiStartLoadingStrategy.Text = "Start Loading Strategy";
            this.tsmiStartLoadingStrategy.Click += new System.EventHandler(this.tsmiStartLoadingStrategy_Click);
            // 
            // tsmiFollowSelected
            // 
            this.tsmiFollowSelected.Name = "tsmiFollowSelected";
            this.tsmiFollowSelected.Size = new System.Drawing.Size(202, 22);
            this.tsmiFollowSelected.Text = "Follow Selected";
            this.tsmiFollowSelected.Click += new System.EventHandler(this.tsmiFollowSelected_Click);
            // 
            // tsmiViewDetailsForSelected
            // 
            this.tsmiViewDetailsForSelected.Name = "tsmiViewDetailsForSelected";
            this.tsmiViewDetailsForSelected.Size = new System.Drawing.Size(202, 22);
            this.tsmiViewDetailsForSelected.Text = "View Details for Selected";
            this.tsmiViewDetailsForSelected.Click += new System.EventHandler(this.tsmiViewDetailsForSelected_Click);
            // 
            // pgMain
            // 
            this.pgMain.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pgMain.Location = new System.Drawing.Point(233, 12);
            this.pgMain.Name = "pgMain";
            this.pgMain.Size = new System.Drawing.Size(367, 215);
            this.pgMain.TabIndex = 10;
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStartStrategy,
            this.tsmiWithdrawToWallet});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(178, 70);
            // 
            // tsmiStartStrategy
            // 
            this.tsmiStartStrategy.Name = "tsmiStartStrategy";
            this.tsmiStartStrategy.Size = new System.Drawing.Size(177, 22);
            this.tsmiStartStrategy.Text = "Start Strategy";
            this.tsmiStartStrategy.Click += new System.EventHandler(this.tsmiStartStrategy_Click);
            // 
            // tsmiWithdrawToWallet
            // 
            this.tsmiWithdrawToWallet.Name = "tsmiWithdrawToWallet";
            this.tsmiWithdrawToWallet.Size = new System.Drawing.Size(177, 22);
            this.tsmiWithdrawToWallet.Text = "Withdraw To Wallet";
            this.tsmiWithdrawToWallet.Click += new System.EventHandler(this.tsmiWithdrawToWallet_Click);
            // 
            // smgMain
            // 
            this.smgMain.ContextMenuStrip = this.cmsMain;
            this.smgMain.GameStarted = false;
            this.smgMain.Location = new System.Drawing.Point(12, 12);
            this.smgMain.Name = "smgMain";
            this.smgMain.Size = new System.Drawing.Size(215, 215);
            this.smgMain.TabIndex = 11;
            this.smgMain.Text = "satoshiMinesGrid1";
            this.smgMain.OnCashoutClicked += new System.EventHandler(this.smgMain_OnCashoutClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 373);
            this.Controls.Add(this.smgMain);
            this.Controls.Add(this.pgMain);
            this.Controls.Add(this.lvLiveGames);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Mr. Trvp\'s Strategy Stealer";
            this.cmsLiveGames.ResumeLayout(false);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvLiveGames;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chBet;
        private System.Windows.Forms.ColumnHeader chWinLoss;
        private System.Windows.Forms.ColumnHeader chProfit;
        private System.Windows.Forms.ColumnHeader chGameHash;
        private System.Windows.Forms.ColumnHeader chSecret;
        private System.Windows.Forms.ContextMenuStrip cmsLiveGames;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiName;
        private System.Windows.Forms.ToolStripMenuItem tsmiBet;
        private System.Windows.Forms.ToolStripMenuItem tsmiWin;
        private System.Windows.Forms.ToolStripMenuItem tsmiProfit;
        private System.Windows.Forms.ToolStripMenuItem tsmiGameHash;
        private System.Windows.Forms.ToolStripMenuItem tsmiSecret;
        private System.Windows.Forms.PropertyGrid pgMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartLoadingStrategy;
        private System.Windows.Forms.ToolStripMenuItem tsmiFollowSelected;
        public Controls.SatoshiMinesGrid smgMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartStrategy;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewDetailsForSelected;
        private System.Windows.Forms.ToolStripMenuItem tsmiWithdrawToWallet;
    }
}