using System;
using System.Drawing;
namespace AppJeuTetris
{
    /// <summary>
    /// Fournit les fonctionnalités d'une pièce pour un jeu dans une grille 2D
    /// </summary>
    public interface IPiece
    {

        // Obtient la rangée d'origine de la pièce
        int OrigineRangée { get; }

        // Obtient la colonne d'origine de la pièce
        int OrigineColonne { get; }

        // Obtient le nombre de points que possède la pièce.
        int NbPoints { get; }

        // Obtient l'index de l'image utilisé pour dessiner chacun des points de la pièce.
        int ImageIndex { get; }
        
        // Obtient la taille de la pièce: nombre de points en largeur et en hauteur
        Size Taille { get; }
        
        // Fournit un point particulier de la pièce à l'index spécifié.
        IPoint PointAt(int pIndex);

        // Ajoute un point à la pièce, la position du nouveau point est relative au point d'origine de la pièce.
        void AjouterPoint(int pDeplRangée, int pDeplColonne);
        
        //Déplacer une pièce de pDeplRangée et pDeplColonne
        void Déplacer(int pDeplRangée, int pDeplColonne);

		void Placer(int rangée, int colonne);

		//Fait une rotation à droite de la pièce
		void RotationADroite();
        
        //Fait une rotation à gauche de la pièce
        void RotationAGauche();

        //Vérifier si les coordonnées dans pobjPoint correspondent aux coordonnées d'un des points de la pièce
        bool PointExiste(IPoint pPoint);
    }
}
