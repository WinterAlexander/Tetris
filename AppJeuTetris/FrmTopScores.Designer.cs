namespace AppJeuTetris
{
	partial class FrmTopScores
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
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.topScores = new AppJeuTetris.TopScoresPro();
			this.SuspendLayout();
			// 
			// topScores
			// 
			this.topScores.AddressView = VisualArrays.enuAddressView.Mode1D;
			this.topScores.BackColor = System.Drawing.Color.Black;
			this.topScores.CellMargin = 5;
			this.topScores.CellSize = new System.Drawing.Size(342, 28);
			this.topScores.ColumnCount = 1;
			this.topScores.Enabled = false;
			this.topScores.EnabledAppearance.BackgroundColor = System.Drawing.Color.Maroon;
			this.topScores.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.topScores.GridAppearance.LineSize = 0;
			this.topScores.Location = new System.Drawing.Point(0, 0);
			this.topScores.Margin = new System.Windows.Forms.Padding(0);
			this.topScores.Name = "topScores";
			this.topScores.Padding = new System.Windows.Forms.Padding(20);
			this.topScores.RowCount = 10;
			this.topScores.RowHeader.ForeColor = System.Drawing.Color.White;
			this.topScores.SelectionAppearance.Color = System.Drawing.Color.Lime;
			this.topScores.SelectionAppearance.Padding = new System.Windows.Forms.Padding(2);
			this.topScores.SelectionAppearance.PenWidth = 5;
			this.topScores.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.topScores.Size = new System.Drawing.Size(392, 420);
			this.topScores.TabIndex = 0;
			this.topScores.Text = "topScoresPro1";
			// 
			// FrmTopScores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(389, 417);
			this.Controls.Add(this.topScores);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmTopScores";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Top 10 des meilleurs scores";
			this.ResumeLayout(false);

		}

		

		private TopScoresPro topScores;
	}
}