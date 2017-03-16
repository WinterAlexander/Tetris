using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using VisualArrays;

namespace AppJeuTetris
{
	/// <summary>
	/// Formulaire principal du jeu 
	/// Encapsule plusieurs fonctionnalités du jeu dont la grille Tétris, 
	/// le formulaire des scores et des champs de textes affichante des statistiques
	/// </summary>
    public partial class FrmPrincipal : Form
    {

		private FrmTopScores m_frmTopScores;
        private bool canPause;

		/// <summary>
		/// Constructeur qui initialise les composants
		/// </summary>
		public FrmPrincipal()
        {
            InitializeComponent();
			KeyDown += FrmPrincipal_KeyDown;

			m_frmTopScores = new FrmTopScores();
			btnNouvellePartie_Click(this, EventArgs.Empty);
        }

		/// <summary>
		/// Se déclenche lorsque le score ou le niveau de la GrilleTétris est changé
		/// </summary>
		private void UpdateStats(object sender, EventArgs args)
		{
			txtScore.Text = grilleTetris.Score.ToString();
			txtNbRangées.Text = grilleTetris.RangeesCompletees.ToString();
			int progress = (int)(grilleTetris.ProgressionNiveau * 100);

			if(progress > 100)
			{
				MessageBox.Show(grilleTetris.ProgressionNiveau.ToString());
			}
			else
				levelProgress.Value = progress;
			txtNiveauCourant.Text = (grilleTetris.Niveau + 1).ToString();
		}

	    /// <summary>
		/// Se déclenche lorsque le bouton pause du menu fichier est enclenché
		/// </summary>
		private void Pause()
        {
            if(!canPause)
                return;

			if(grilleTetris.tmrDrop.Enabled)
			{
				grilleTetris.tmrDrop.Stop();
				grilleTetris.AfficherAuCentre(" EN PAUSE ");
				return;
			}

			grilleTetris.NettoyerCentre();
			grilleTetris.tmrDrop.Start();
			grilleTetris.Focus();
		}

		/// <summary>
		/// Se déclenche lors de la fin de la partie
		/// </summary>
		private void griTétris_GameOver(object sender, EventArgs e)
        {
			canPause = false;
			m_frmTopScores.TopScores.Ajouter(grilleTetris.Score);
			m_frmTopScores.TopScores.Enregistrer();
			
			m_frmTopScores.ShowDialog();
		}

		private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.N && e.Control)
			{
				btnNouvellePartie_Click(this, EventArgs.Empty);
				return;
			}

			if(e.KeyCode == Keys.P && e.Control)
				btnPause_Click(this, EventArgs.Empty);
		}

		private void btnNouvellePartie_Click(object sender, EventArgs e)
		{
			grilleTetris.NiveauDepart = startDifficulty.Value;
			grilleTetris.NouvellePartie();
			canPause = true;
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			Pause();
		}

		private void btnListScores_Click(object sender, EventArgs e)
		{
			if(grilleTetris.tmrDrop.Enabled)
				Pause();
			m_frmTopScores.ShowDialog();
			Pause();
		}

	}
}