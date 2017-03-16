using System;
using System.Collections.Generic;
using System.Text;

namespace AppJeuTetris
{
	public interface TopScores
	{
		/// <summary>
		/// Met tous les scores à 0, déselectionne et visualise les scores.
		/// </summary>
		void Clear();

		/// <summary>
		/// Affiche les scores dans la grille en soignant l'alignement:
		///       - utiliser AddCellVisualElement
		///       - utiliser les VisualElement suivants: FillShapeElement, ShapeElement, TextElement
		///       - ContentAlignement et Padding
		/// </summary>
		void Visualiser();

		/// <summary>
		/// Ajoute le score à la bonne place dans la grille. Les scores sont en ordre décroissant.
		/// </summary>
		/// <param name="pValeurScore">valeur du score à ajouter</param>
		void Ajouter(int pValeurScore);

		/// <summary>
		/// Remplit la collection de scores à partir des objets lus dans le fichier.
		/// La façon de lire les objects peut varier
		/// </summary>
		void Charger();

		/// <summary>
		/// Écrit les scores
		/// La façon d'écrire les scores peut varier
		/// </summary>
		void Enregistrer();
	}
}
