using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VisualArrays;

namespace AppJeuTetris
{
    /// <summary>
    /// Une grille capable d'afficher une seule pièce servant d'aperçu dans le jeu Tétris
    /// </summary>
    public partial class GrilleApercu : VisualIntArray
    {
		/// <summary>
		/// Constructeur unique qui initialise le VisualIntArray
		/// </summary>
		public GrilleApercu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dessine une pièce dans la grille.
        /// </summary>
        public void DessinerPiece(IPiece pPiece)
        {
			Clear();

			if(pPiece == null)
				return;

			for(int index = 0; index < pPiece.NbPoints; index++)
			{
				IPoint point = pPiece.PointAt(index);

				this[point.Rangée - pPiece.OrigineRangée + 1, point.Colonne - pPiece.OrigineColonne + 1] = pPiece.ImageIndex;
			}
		}
    }
}
