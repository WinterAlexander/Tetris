namespace AppJeuTetris
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
			this.txtNiveauCourant = new System.Windows.Forms.TextBox();
			this.lblNiveauCourant = new System.Windows.Forms.Label();
			this.txtScore = new System.Windows.Forms.TextBox();
			this.lblScore = new System.Windows.Forms.Label();
			this.txtNbRangées = new System.Windows.Forms.TextBox();
			this.lblNbRangées = new System.Windows.Forms.Label();
			this.lblNext = new System.Windows.Forms.Label();
			this.lblHold = new System.Windows.Forms.Label();
			this.startDifficulty = new System.Windows.Forms.TrackBar();
			this.levelProgress = new System.Windows.Forms.ProgressBar();
			this.lblLevel1 = new System.Windows.Forms.Label();
			this.lblLevel10 = new System.Windows.Forms.Label();
			this.lblLevel5 = new System.Windows.Forms.Label();
			this.lblLevel11 = new System.Windows.Forms.Label();
			this.lblLevel12 = new System.Windows.Forms.Label();
			this.lblDifficulty = new System.Windows.Forms.Label();
			this.btnNouvellePartie = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.btnListScores = new System.Windows.Forms.Button();
			this.grilleBonus = new AppJeuTetris.GrilleApercu();
			this.grilleSuivant = new AppJeuTetris.GrilleApercu();
			this.grilleTetris = new AppJeuTetris.GrilleTétris();
			((System.ComponentModel.ISupportInitialize)(this.startDifficulty)).BeginInit();
			this.SuspendLayout();
			// 
			// txtNiveauCourant
			// 
			this.txtNiveauCourant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtNiveauCourant.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNiveauCourant.ForeColor = System.Drawing.Color.White;
			this.txtNiveauCourant.Location = new System.Drawing.Point(548, 169);
			this.txtNiveauCourant.Name = "txtNiveauCourant";
			this.txtNiveauCourant.ReadOnly = true;
			this.txtNiveauCourant.Size = new System.Drawing.Size(153, 44);
			this.txtNiveauCourant.TabIndex = 24;
			this.txtNiveauCourant.TabStop = false;
			this.txtNiveauCourant.Text = "0";
			this.txtNiveauCourant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblNiveauCourant
			// 
			this.lblNiveauCourant.AutoSize = true;
			this.lblNiveauCourant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.lblNiveauCourant.Location = new System.Drawing.Point(545, 150);
			this.lblNiveauCourant.Name = "lblNiveauCourant";
			this.lblNiveauCourant.Size = new System.Drawing.Size(120, 16);
			this.lblNiveauCourant.TabIndex = 23;
			this.lblNiveauCourant.Text = "Niveau courant :";
			// 
			// txtScore
			// 
			this.txtScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtScore.ForeColor = System.Drawing.Color.White;
			this.txtScore.Location = new System.Drawing.Point(548, 361);
			this.txtScore.Name = "txtScore";
			this.txtScore.ReadOnly = true;
			this.txtScore.Size = new System.Drawing.Size(153, 44);
			this.txtScore.TabIndex = 22;
			this.txtScore.TabStop = false;
			this.txtScore.Text = "0";
			this.txtScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblScore
			// 
			this.lblScore.AutoSize = true;
			this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.lblScore.Location = new System.Drawing.Point(545, 342);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(57, 16);
			this.lblScore.TabIndex = 21;
			this.lblScore.Text = "Score :";
			// 
			// txtNbRangées
			// 
			this.txtNbRangées.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txtNbRangées.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNbRangées.ForeColor = System.Drawing.Color.White;
			this.txtNbRangées.Location = new System.Drawing.Point(548, 295);
			this.txtNbRangées.Name = "txtNbRangées";
			this.txtNbRangées.ReadOnly = true;
			this.txtNbRangées.Size = new System.Drawing.Size(153, 44);
			this.txtNbRangées.TabIndex = 20;
			this.txtNbRangées.TabStop = false;
			this.txtNbRangées.Text = "0";
			this.txtNbRangées.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblNbRangées
			// 
			this.lblNbRangées.AutoSize = true;
			this.lblNbRangées.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.lblNbRangées.Location = new System.Drawing.Point(545, 276);
			this.lblNbRangées.Name = "lblNbRangées";
			this.lblNbRangées.Size = new System.Drawing.Size(164, 16);
			this.lblNbRangées.TabIndex = 19;
			this.lblNbRangées.Text = "Rangées complétées :";
			// 
			// lblNext
			// 
			this.lblNext.AutoSize = true;
			this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
			this.lblNext.Location = new System.Drawing.Point(573, 23);
			this.lblNext.Name = "lblNext";
			this.lblNext.Size = new System.Drawing.Size(98, 29);
			this.lblNext.TabIndex = 28;
			this.lblNext.Text = "Suivant";
			// 
			// lblHold
			// 
			this.lblHold.AutoSize = true;
			this.lblHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHold.Location = new System.Drawing.Point(44, 21);
			this.lblHold.Name = "lblHold";
			this.lblHold.Size = new System.Drawing.Size(86, 29);
			this.lblHold.TabIndex = 29;
			this.lblHold.Text = "Bonus";
			// 
			// startDifficulty
			// 
			this.startDifficulty.Location = new System.Drawing.Point(10, 328);
			this.startDifficulty.Maximum = 11;
			this.startDifficulty.Name = "startDifficulty";
			this.startDifficulty.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.startDifficulty.Size = new System.Drawing.Size(45, 355);
			this.startDifficulty.TabIndex = 30;
			// 
			// levelProgress
			// 
			this.levelProgress.Cursor = System.Windows.Forms.Cursors.Default;
			this.levelProgress.Location = new System.Drawing.Point(548, 219);
			this.levelProgress.Name = "levelProgress";
			this.levelProgress.Size = new System.Drawing.Size(153, 23);
			this.levelProgress.TabIndex = 31;
			this.levelProgress.Tag = "";
			// 
			// lblLevel1
			// 
			this.lblLevel1.AutoSize = true;
			this.lblLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLevel1.ForeColor = System.Drawing.Color.LimeGreen;
			this.lblLevel1.Location = new System.Drawing.Point(45, 663);
			this.lblLevel1.Name = "lblLevel1";
			this.lblLevel1.Size = new System.Drawing.Size(51, 20);
			this.lblLevel1.TabIndex = 32;
			this.lblLevel1.Text = "Facile";
			// 
			// lblLevel10
			// 
			this.lblLevel10.AutoSize = true;
			this.lblLevel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLevel10.ForeColor = System.Drawing.Color.Chocolate;
			this.lblLevel10.Location = new System.Drawing.Point(45, 395);
			this.lblLevel10.Name = "lblLevel10";
			this.lblLevel10.Size = new System.Drawing.Size(60, 20);
			this.lblLevel10.TabIndex = 33;
			this.lblLevel10.Text = "Difficile";
			// 
			// lblLevel5
			// 
			this.lblLevel5.AutoSize = true;
			this.lblLevel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLevel5.ForeColor = System.Drawing.Color.Goldenrod;
			this.lblLevel5.Location = new System.Drawing.Point(45, 540);
			this.lblLevel5.Name = "lblLevel5";
			this.lblLevel5.Size = new System.Drawing.Size(56, 20);
			this.lblLevel5.TabIndex = 34;
			this.lblLevel5.Text = "Moyen";
			// 
			// lblLevel11
			// 
			this.lblLevel11.AutoSize = true;
			this.lblLevel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLevel11.ForeColor = System.Drawing.Color.Red;
			this.lblLevel11.Location = new System.Drawing.Point(45, 361);
			this.lblLevel11.Name = "lblLevel11";
			this.lblLevel11.Size = new System.Drawing.Size(68, 20);
			this.lblLevel11.TabIndex = 35;
			this.lblLevel11.Text = "Extrème";
			// 
			// lblLevel12
			// 
			this.lblLevel12.AutoSize = true;
			this.lblLevel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLevel12.ForeColor = System.Drawing.Color.DarkRed;
			this.lblLevel12.Location = new System.Drawing.Point(45, 328);
			this.lblLevel12.Name = "lblLevel12";
			this.lblLevel12.Size = new System.Drawing.Size(47, 20);
			this.lblLevel12.TabIndex = 36;
			this.lblLevel12.Text = "Spicy";
			// 
			// lblDifficulty
			// 
			this.lblDifficulty.AutoSize = true;
			this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDifficulty.Location = new System.Drawing.Point(12, 295);
			this.lblDifficulty.Name = "lblDifficulty";
			this.lblDifficulty.Size = new System.Drawing.Size(130, 29);
			this.lblDifficulty.TabIndex = 37;
			this.lblDifficulty.Text = "Difficultée";
			// 
			// btnNouvellePartie
			// 
			this.btnNouvellePartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNouvellePartie.Location = new System.Drawing.Point(10, 142);
			this.btnNouvellePartie.Name = "btnNouvellePartie";
			this.btnNouvellePartie.Size = new System.Drawing.Size(153, 33);
			this.btnNouvellePartie.TabIndex = 38;
			this.btnNouvellePartie.Text = "Nouvelle Partie";
			this.btnNouvellePartie.UseVisualStyleBackColor = true;
			this.btnNouvellePartie.Click += new System.EventHandler(this.btnNouvellePartie_Click);
			// 
			// btnPause
			// 
			this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPause.Location = new System.Drawing.Point(10, 182);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(153, 31);
			this.btnPause.TabIndex = 39;
			this.btnPause.Text = "Pause";
			this.btnPause.UseVisualStyleBackColor = true;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnListScores
			// 
			this.btnListScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnListScores.Location = new System.Drawing.Point(548, 411);
			this.btnListScores.Name = "btnListScores";
			this.btnListScores.Size = new System.Drawing.Size(153, 30);
			this.btnListScores.TabIndex = 41;
			this.btnListScores.Text = "Meilleurs scores";
			this.btnListScores.UseVisualStyleBackColor = true;
			this.btnListScores.Click += new System.EventHandler(this.btnListScores_Click);
			// 
			// grilleBonus
			// 
			this.grilleBonus.BackColor = System.Drawing.Color.Black;
			this.grilleBonus.CellMargin = 1;
			this.grilleBonus.CellSize = new System.Drawing.Size(32, 30);
			this.grilleBonus.ColumnCount = 4;
			this.grilleBonus.GridAppearance.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.grilleBonus.Location = new System.Drawing.Point(10, 55);
			this.grilleBonus.Name = "grilleBonus";
			this.grilleBonus.RowCount = 2;
			this.grilleBonus.RowHeader.ForeColor = System.Drawing.Color.White;
			this.grilleBonus.Size = new System.Drawing.Size(153, 79);
			this.grilleBonus.SpecialValue = 0;
			this.grilleBonus.TabIndex = 27;
			this.grilleBonus.Text = "grilleApercu2";
			this.grilleBonus.View = VisualArrays.enuIntView.ImageList;
			// 
			// grilleSuivant
			// 
			this.grilleSuivant.BackColor = System.Drawing.Color.Black;
			this.grilleSuivant.CellMargin = 1;
			this.grilleSuivant.CellSize = new System.Drawing.Size(32, 30);
			this.grilleSuivant.ColumnCount = 4;
			this.grilleSuivant.GridAppearance.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.grilleSuivant.Location = new System.Drawing.Point(548, 55);
			this.grilleSuivant.Name = "grilleSuivant";
			this.grilleSuivant.RowCount = 2;
			this.grilleSuivant.RowHeader.ForeColor = System.Drawing.Color.White;
			this.grilleSuivant.Size = new System.Drawing.Size(153, 79);
			this.grilleSuivant.SpecialValue = 0;
			this.grilleSuivant.TabIndex = 26;
			this.grilleSuivant.View = VisualArrays.enuIntView.ImageList;
			// 
			// grilleTetris
			// 
			this.grilleTetris.BackColor = System.Drawing.Color.Black;
			this.grilleTetris.CellMargin = 0;
			this.grilleTetris.CellSize = new System.Drawing.Size(35, 35);
			this.grilleTetris.ColumnCount = 10;
			this.grilleTetris.EnabledAppearance.Style = VisualArrays.enuBkgStyle.None;
			this.grilleTetris.GridAppearance.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.grilleTetris.GrilleApercu = this.grilleSuivant;
			this.grilleTetris.GrilleBonus = this.grilleBonus;
			this.grilleTetris.Location = new System.Drawing.Point(169, 2);
			this.grilleTetris.Name = "grilleTetris";
			this.grilleTetris.Niveau = 0;
			this.grilleTetris.NiveauDepart = 0;
			this.grilleTetris.RowCount = 19;
			this.grilleTetris.RowHeader.ForeColor = System.Drawing.Color.White;
			this.grilleTetris.Size = new System.Drawing.Size(373, 697);
			this.grilleTetris.SpecialValue = 0;
			this.grilleTetris.TabIndex = 12;
			this.grilleTetris.View = VisualArrays.enuIntView.ImageList;
			this.grilleTetris.ScoreChanged += new System.EventHandler(this.UpdateStats);
			this.grilleTetris.NiveauChanged += new System.EventHandler(this.UpdateStats);
			this.grilleTetris.GameOver += new System.EventHandler(this.griTétris_GameOver);
			// 
			// FrmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::AppJeuTetris.Properties.Resources.background;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(708, 699);
			this.Controls.Add(this.btnListScores);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.btnNouvellePartie);
			this.Controls.Add(this.lblDifficulty);
			this.Controls.Add(this.lblLevel12);
			this.Controls.Add(this.lblLevel11);
			this.Controls.Add(this.lblLevel5);
			this.Controls.Add(this.lblLevel10);
			this.Controls.Add(this.lblLevel1);
			this.Controls.Add(this.levelProgress);
			this.Controls.Add(this.startDifficulty);
			this.Controls.Add(this.lblHold);
			this.Controls.Add(this.lblNext);
			this.Controls.Add(this.grilleBonus);
			this.Controls.Add(this.grilleSuivant);
			this.Controls.Add(this.txtNiveauCourant);
			this.Controls.Add(this.lblNiveauCourant);
			this.Controls.Add(this.txtScore);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.txtNbRangées);
			this.Controls.Add(this.lblNbRangées);
			this.Controls.Add(this.grilleTetris);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "FrmPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tetris - Spicy Edition";
			((System.ComponentModel.ISupportInitialize)(this.startDifficulty)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		private GrilleTétris grilleTetris;
        private System.Windows.Forms.TextBox txtNiveauCourant;
        private System.Windows.Forms.Label lblNiveauCourant;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtNbRangées;
        private System.Windows.Forms.Label lblNbRangées;
        private GrilleApercu grilleSuivant;
        private GrilleApercu grilleBonus;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblHold;
		private System.Windows.Forms.TrackBar startDifficulty;
		private System.Windows.Forms.ProgressBar levelProgress;
		private System.Windows.Forms.Label lblLevel1;
		private System.Windows.Forms.Label lblLevel10;
		private System.Windows.Forms.Label lblLevel5;
		private System.Windows.Forms.Label lblLevel11;
		private System.Windows.Forms.Label lblLevel12;
		private System.Windows.Forms.Label lblDifficulty;
		private System.Windows.Forms.Button btnNouvellePartie;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button btnListScores;
	}
}

