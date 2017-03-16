using System;
using System.Collections.Generic;
using System.Text;

namespace AppJeuTetris
{
	/// <summary>
	/// Fournit les fonctionnalités d'un point.
	/// </summary>
	public class Point : IPoint
	{
		private int m_colonne, m_rangée;

		/// <summary>
		/// Constructeur qui instancie un point à partir de la rangée et de la colonne du point
		/// </summary>
		/// <param name="pRangée">rangée du point</param>
		/// <param name="pColonne">colonne du point</param>
		public Point(int pRangée, int pColonne)
		{
			Rangée = pRangée;
			Colonne = pColonne;
		}

		/// <summary>
		/// Obtient et permet de changer la valeur de la colonne du point
		/// </summary>
		public int Colonne
		{
			get
			{
				return m_colonne;
			}

			set
			{
				m_colonne = value;
			}
		}

		/// <summary>
		/// Obtient et permet de changer la valeur de la rangée du point
		/// </summary>
		public int Rangée
		{
			get
			{
				return m_rangée;
			}

			set
			{
				m_rangée = value;
			}
		}

		/// <summary>
		/// Vérifie si le point est équivalent à un autre en comparant la rangée et la colonne
		/// </summary>
		public override bool Equals(object obj)
		{
			if(obj is IPoint)
			{
				IPoint other = (IPoint)obj;
				return other.Colonne == Colonne && other.Rangée == Rangée;
			}

			return base.Equals(obj);
		}
	}
}
