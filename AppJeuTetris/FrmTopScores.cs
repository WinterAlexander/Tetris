using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppJeuTetris
{
	/// <summary>
	/// Formulaire modal servant à afficher la liste des meilleurs scores
	/// </summary>
	public partial class FrmTopScores : Form
	{
		/// <summary>
		/// Constructeur unique construisant le formulaire et chargant la liste des scores
		/// </summary>
		public FrmTopScores()
		{
			InitializeComponent();
			topScores.Charger();
			topScores.Visualiser();
		}

		/// <summary>
		/// Obtiens la variable topScores qui elle permet d'accéder aux 10 meilleurs scores
		/// </summary>
		public TopScores TopScores
		{
			get
			{
				return topScores;
			}
		}
	}
}
