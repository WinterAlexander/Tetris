using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AppJeuTetris
{
	/// <summary>
	/// Fournit les fonctionnalités d'une pièce pour un jeu dans une grille 2D
	/// </summary>
	public class Piece : IPiece
	{
		private List<IPoint> m_colPoints;

		private Size m_taille;
		private int m_origineRangée, m_origineColonne;
		private int m_imageIndex;

		/// <summary>
		/// Instancie une pièce à l'aide de sa taille, son origine et l'index de son image
		/// </summary>
		/// <param name="pTaille">Taille de la pièce</param>
		/// <param name="pOrigineRangée">Origine de la pièce en rangés</param>
		/// <param name="pOrigineColonne">Origine de la pièce en colonnes</param>
		/// <param name="pImageIndex">Index de l'image</param>
		public Piece(Size pTaille, int pOrigineRangée, int pOrigineColonne, int pImageIndex)
		{
			m_colPoints = new List<IPoint>();

			m_taille = pTaille;
			m_origineRangée = pOrigineRangée;
			m_origineColonne = pOrigineColonne;
			m_imageIndex = pImageIndex;
		}

		/// <summary>
		/// Obtient l'index de l'image utilisé pour dessiner chacun des points de la pièce.
		/// </summary>
		public int ImageIndex
		{
			get
			{
				return m_imageIndex;
			}
		}

		/// <summary>
		/// Obtient le nombre de points de la pièce
		/// </summary>
		public int NbPoints
		{
			get
			{
				return m_colPoints.Count;
			}
		}

		/// <summary>
		/// Obtient la colonne d'origine de la pièce
		/// </summary>
		public int OrigineColonne
		{
			get
			{
				return m_origineColonne;
			}
		}

		/// <summary>
		/// Obtient la rangée d'origine de la pièce
		/// </summary>
		public int OrigineRangée
		{
			get
			{
				return m_origineRangée;
			}
		}

		/// <summary>
		/// Obtient la taille de la pièce: nombre de points en largeur et en hauteur
		/// </summary>
		public Size Taille
		{
			get
			{
				return m_taille;
			}
		}

		/// <summary>
		/// Ajoute un point à la pièce, la position du nouveau point est relative au point d'origine de la pièce.
		/// </summary>
		/// <param name="pDeplRangée">Le déplacement en rangés du point par rapport à l'origine</param>
		/// <param name="pDeplColonne">Le déplacement en colonnes du point par rapport à l'origine</param>
		public void AjouterPoint(int pDeplRangée, int pDeplColonne)
		{
			IPoint point = new Point(OrigineRangée + pDeplRangée, OrigineColonne + pDeplColonne);

			m_colPoints.Add(point);
		}

		/// <summary>
		/// Déplacer une pièce de pDeplRangée et pDeplColonne
		/// </summary>
		/// <param name="pDeplRangée">Le déplacement en rangés du point par rapport à l'origine</param>
		/// <param name="pDeplColonne">Le déplacement en colonnes du point par rapport à l'origine</param>
		public void Déplacer(int pDeplRangée, int pDeplColonne)
		{
			m_origineRangée += pDeplRangée;
			m_origineColonne += pDeplColonne;

			foreach(IPoint point in m_colPoints)
			{
				point.Rangée += pDeplRangée;
				point.Colonne += pDeplColonne;
			}
		}

		public void Placer(int rangée, int colonne)
		{
			foreach(IPoint point in m_colPoints)
			{
				point.Rangée = point.Rangée - m_origineRangée + rangée;
				point.Colonne = point.Colonne - m_origineColonne + colonne;
			}

			m_origineRangée = rangée;
			m_origineColonne = colonne;
		}

		/// <summary>
		/// Fournit un point particulier de la pièce à l'index spécifié.
		/// </summary>
		/// <param name="pIndex">L'index du point dans la collection</param>
		/// <returns>Le point spécifié</returns>
		public IPoint PointAt(int pIndex)
		{
			return m_colPoints[pIndex];
		}

		/// <summary>
		/// Vérifier si les coordonnées dans pobjPoint correspondent aux coordonnées d'un des points de la pièce
		/// </summary>
		/// <param name="pPoint">Le point qui nécéssite vérification</param>
		/// <returns>Si le point existe</returns>
		public bool PointExiste(IPoint pPoint)
		{
			//façon de faire qui override le Equals de Point
			//approuvé par le prof
			return m_colPoints.Contains(pPoint);
		}

		

		//-----------------------------------------------------------------------------
		// Algorithme de rotation d'une pièce vers la droite :
		//-----------------------------------------------------------------------------
		/// <summary>
		/// Effectue une rotation à droite de la pièce
		/// </summary>
		public void RotationADroite()
		{
			// ---- cas du carre (pas de rotation) ----------------
			if(m_taille.Width == m_taille.Height) return;

			// ---- cas pour la barre ----------------------------
			if(m_taille.Width == 1)
			{
				RotationAGauche();
				return;
			}
			//--- pour les autres cas ----------------------------
			// --- Déplace la figure à l'origine
			for(int index = 0; index < m_colPoints.Count; index++)
			{
				m_colPoints[index].Colonne -= m_origineColonne;
				m_colPoints[index].Rangée -= m_origineRangée;
			}
			//--- Effectue la rotation
			for(int index = 0; index < m_colPoints.Count; index++)
			{
				int tempX = m_colPoints[index].Colonne;
				int tempY = m_colPoints[index].Rangée;

				m_colPoints[index].Colonne = -tempY;
				m_colPoints[index].Rangée = tempX;
			}
			// --- Replace la pièce à son emplacement de départ
			for(int index = 0; index < m_colPoints.Count; index++)
			{
				m_colPoints[index].Colonne += m_origineColonne;
				m_colPoints[index].Rangée += m_origineRangée;
			}
			// --- Correction de rotation nécessaire par le Tétris
			if(m_taille.Width == 2)
			{
				Déplacer(-1, 0);
				m_origineRangée++;
			}
			// --- Échanger largeur et hauteur -----
			int temp = m_taille.Width;
			m_taille.Width = m_taille.Height;
			m_taille.Height = temp;
		}

		//-----------------------------------------------------------------------------
		// Algorithme de rotation d'une pièce vers la gauche :
		//-----------------------------------------------------------------------------
		/// <summary>
		/// Effectue une rotation à gauche de la pièce
		/// </summary>
		public void RotationAGauche()
		{
			// ---- cas du carre (pas de rotation) ----------------
			if(m_taille.Width == m_taille.Height) return;

			// --- cas pour la barre ------------------------------
			if(m_taille.Width == 4)
			{
				RotationADroite();
				return;
			}
			//--- pour les autres cas ----------------------------
			for(int index = 0; index < m_colPoints.Count; index++)
			{
				m_colPoints[index].Colonne -= m_origineColonne;
				m_colPoints[index].Rangée -= m_origineRangée;
			}
			// --- Effectue la rotation ------------------
			for(int index = 0; index < m_colPoints.Count; index++)
			{
				int tempX = m_colPoints[index].Colonne;
				int tempY = m_colPoints[index].Rangée;

				m_colPoints[index].Colonne = tempY;
				m_colPoints[index].Rangée = -tempX;
			}
			// --- Replace la pièce à son emplacement de départ
			for(int index = 0; index < m_colPoints.Count; index++)
			{
				m_colPoints[index].Colonne += m_origineColonne;
				m_colPoints[index].Rangée += m_origineRangée;
			}
			// --- Correction de rotation nécessaire par le Tétris
			if(m_taille.Width == 3)
			{
				Déplacer(0, 1);
				m_origineColonne--;
			}
			// --- Échanger largeur et hauteur
			int temp = m_taille.Width;
			m_taille.Width = m_taille.Height;
			m_taille.Height = temp;
		}
		
	}
}
