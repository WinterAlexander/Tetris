using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using VisualArrays;
using System.Runtime.CompilerServices;

namespace AppJeuTetris
{
    /// <summary>
    /// Représente une grille de 9x9 à laquelle on a ajouté des fonctions de manipulation d'une pièce.
    /// </summary>
    public partial class GrilleTétris : VisualIntArray
    {
		private const int NIVEAU_MAX = 12;

		public const int CARRE_VIDE = 0;
        public const int CARRE_BLEU = 1;
        public const int CARRE_GRISÉ = 8;

		//variable membres
        private IPiece pieceCourante = null, pieceSuivante = null, pieceBonus = null;
        private Random m_objRandom = new Random();
        private int[] m_uses;

		private int m_score;
		private int m_niveau, m_niveauDepart;
		private int m_rangees;
		private int bonusUses;

		private bool freezeTick;

		// --- nombre de rangées complétées
		private int[] m_tabNbLignesParNiveau = { 10, 25, 40, 60, 85, 110, 140, 160, 200, 250, 666, int.MaxValue};
		//private int[] m_tabNbLignesParNiveau = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, int.MaxValue };
		// --- délai en ms par niveau
		private int[] m_tabDelaiParNiveau = { 500, 450, 400, 350, 300, 225, 150, 100, 75, 60, 50, 40};

        private Color[] m_couleursPieces = { Color.White, Color.Blue, Color.Cyan, Color.Yellow, Color.Lime, Color.Purple, Color.Orange, Color.Red, Color.Gray };
		
		/// <summary>
		/// Se produit lorsque le score change.
		/// </summary>
		public event EventHandler ScoreChanged;

        /// <summary>
        /// Se produit lorsque le niveau change.
        /// </summary>
        public event EventHandler NiveauChanged;

        /// <summary>
        /// Se produit lorsque la partie est terminée.
        /// </summary>
        public event EventHandler GameOver;
        

        private GrilleApercu m_grilleApercu, m_grilleBonus;
        [DefaultValue(null), Browsable(true)]

		/// <summary>
		/// Permet d'obtenir la grille d'aperçu de la pièce suivante en lecture et en écriture
		/// </summary>
		public GrilleApercu GrilleApercu
        {
            get
			{
				return m_grilleApercu;
			}

            set
            {
                m_grilleApercu = value;
                if (value != null)
                    m_grilleApercu.EnabledAppearance.ImageList = this.imlPièces;
            }
        }

		public GrilleApercu GrilleBonus
		{
			get
			{
				return m_grilleBonus;
			}

			set
			{
				m_grilleBonus = value;
				if(value != null)
					m_grilleBonus.EnabledAppearance.ImageList = this.imlPièces;
			}
		}

		/// <summary>
		/// Constructeur unique de la grille Tétris 
		/// Initialise la grille et mets le niveau à 0
		/// </summary>
		public GrilleTétris()
        {
            InitializeComponent();
			NiveauDepart = 0;

            m_uses = new int[9];
        }


		/// <summary>
		/// Part une nouvelle partie en lancant une nouvelle pièce et ensuite en démarrant l'horloge.
		/// Lance un événement pour changer le niveau si besoin
		/// </summary>
		public void NouvellePartie()
		{
			for(int i = 1; i < m_uses.Length - 1; i++)
				m_uses[i] = 0;
			m_uses[1] = 1; //les escaliers
			m_uses[2] = 1;
			m_uses[0] = m_uses[8] = int.MaxValue; //carré vide et grisé

			Niveau = NiveauDepart;

			m_rangees = 0;
			m_score = 0;
			freezeTick = false;

			m_grilleBonus.Clear();

			if(NiveauChanged != null)
				NiveauChanged.Invoke(this, EventArgs.Empty);

			Clear();
			pieceSuivante = pieceCourante = pieceBonus = null;
			PieceSuivante();
			DessinerPieceCourante();
			tmrDrop.Start();
			tmrDrop.Interval = m_tabDelaiParNiveau[m_niveau];
			tmrKeyRepeatLeft.Enabled = false;
			tmrKeyRepeatRight.Enabled = false;
			Focus();

		}

		/// <summary>
		/// Affiche un message au centre de la grille de jeu.
		/// La couleur du texte est blanc et le fond de la cellule Tomate.
		/// </summary>
		/// <param name="pMessage">message à afficher</param>
		public void AfficherAuCentre(string pMessage)
        {
            Font police = new Font("Verdana", 18, FontStyle.Bold);
            for (int index = 0; index < pMessage.Length; index++)
            {
                AddCellVisualElement(RowCount / 2, index, new BorderElement(new Padding(2, 2, 2, 2), Color.Tomato));
                AddCellVisualElement(RowCount / 2, index, new TextElement(police, pMessage[index].ToString(), this[RowCount / 2, index] == 6 ? Color.Black : Color.Tomato));
                //AddCellVisualElement(ligneCentrale, index, new BorderElement(new Padding(2, 2, 2, 2), Color.Black));
            }
        }

		/// <summary>
		/// Retire un message précédemment affiché au centre
		/// </summary>
		public void NettoyerCentre()
		{
			for(int index = 0; index < ColumnCount; index++)
				ClearCellVisualElements(RowCount / 2, index);
		}
	
		
		/// <summary>
		/// Instancie une nouvelle pièce à la position et la forme de pièce spécifiée en paramètre.
		/// </summary>
		private IPiece FabriquerPiece(int pOrgLigne, int pOrgColonne, enuFormePièce pFormePièce)
		{
			IPiece piece;

			switch(pFormePièce)
			{
				case enuFormePièce.Triangle:
					piece = new Piece(new Size(3, 2), pOrgLigne, pOrgColonne, (int)pFormePièce + 1);
					piece.AjouterPoint(0, 0);
					piece.AjouterPoint(-1, 0);
					piece.AjouterPoint(0, 1);
					piece.AjouterPoint(0, -1);
					break;

				case enuFormePièce.Barre:
					piece = new Piece(new Size(4, 1), pOrgLigne, pOrgColonne, (int)pFormePièce + 1);
					piece.AjouterPoint(0, 0);
					piece.AjouterPoint(0, 1);
					piece.AjouterPoint(0, -1);
					piece.AjouterPoint(0, 2);
					break;

				case enuFormePièce.Carre:
					piece = new Piece(new Size(2, 2), pOrgLigne, pOrgColonne, (int)pFormePièce + 1);
					piece.AjouterPoint(0, 0);
					piece.AjouterPoint(-1, 0);
					piece.AjouterPoint(0, -1);
					piece.AjouterPoint(-1, -1);
					break;

				case enuFormePièce.Escalier_G:
					piece = new Piece(new Size(3, 2), pOrgLigne, pOrgColonne, (int)pFormePièce + 1);
					piece.AjouterPoint(0, 0);
					piece.AjouterPoint(-1, 0);
					piece.AjouterPoint(0, 1);
					piece.AjouterPoint(-1, -1);
					break;

				case enuFormePièce.Escalier_D:
					piece = new Piece(new Size(3, 2), pOrgLigne, pOrgColonne, (int)pFormePièce + 1);
					piece.AjouterPoint(0, 0);
					piece.AjouterPoint(-1, 0);
					piece.AjouterPoint(-1, 1);
					piece.AjouterPoint(0, -1);
					break;


				case enuFormePièce.L_Normal:
					piece = new Piece(new Size(3, 2), pOrgLigne, pOrgColonne, (int)pFormePièce + 1);
					piece.AjouterPoint(-1, 0);
					piece.AjouterPoint(-1, 1);
					piece.AjouterPoint(-1, -1);
					piece.AjouterPoint(0, -1);
					break;

				case enuFormePièce.L_Inverse:
					piece = new Piece(new Size(3, 2), pOrgLigne, pOrgColonne, (int)pFormePièce + 1);
					piece.AjouterPoint(-1, 0);
					piece.AjouterPoint(-1, 1);
					piece.AjouterPoint(-1, -1);
					piece.AjouterPoint(0, 1);
					break;

				default:
                    throw new IndexOutOfRangeException(((int)pFormePièce).ToString());
			}

			return piece;
		}
		
		/// <summary>
		/// Dessine la pièce courante dans la grille.
		/// </summary>
		private void DessinerPieceCourante()
		{
			for(int index = 0; index < pieceCourante.NbPoints; index++)
			{
				IPoint point = pieceCourante.PointAt(index);

				this[point.Rangée, point.Colonne] = pieceCourante.ImageIndex;
			}
		}
		
		/// <summary>
		/// Efface la pièce courante de la grille
		/// </summary>
		private void EffacerPieceCourante()
		{
			for(int index = 0; index < pieceCourante.NbPoints; index++)
			{
				IPoint point = pieceCourante.PointAt(index);

				this[point.Rangée, point.Colonne] = CARRE_VIDE;
			}
		}

		/// <summary>
		/// Vérifie si un des points de la pièce courante est en collision avec les murs (bords)
		/// de la grille ou avec une cellule non vide.
		/// </summary>
		/// <returns>Vrai, si en collision</returns>
		private bool EstEnCollision()
		{
			for(int index = 0; index < pieceCourante.NbPoints; index++)
			{
				IPoint point = pieceCourante.PointAt(index);

				if(point.Rangée >= this.RowCount || point.Rangée < 0)
					return true;

				if(point.Colonne >= this.ColumnCount || point.Colonne < 0)
					return true;

				if(this[point.Rangée, point.Colonne] != CARRE_VIDE)
					return true;
			}

			return false;
		}



        /// <summary>
        /// Dès que l'utilisateur appuie sur une des touches suivantes du clavier:
        /// - flèche vers le bas    ou NumPad2 --> la pièce descend d'une cellule vers le bas
        /// - flèche vers la gauche ou NumPad4 --> la pièce se déplace d'une cellule vers la gauche
        /// - flèche vers la droite ou NumPad6 --> la pièce se déplace d'une cellule vers la droite
        /// - espace                ou NumPad5 --> rotation à gauche ou à droite
        /// </summary>
        private void GrilleTétris_KeyDown(object sender, KeyEventArgs e)
		{
			if(!tmrDrop.Enabled)
				return;

			if(e.KeyCode == Keys.C)
			{
				PieceBonus();
				return;
			}

            if(e.KeyCode == Keys.Down)
            {
                tmrDrop.Interval = 25;
                return;
            }

			switch(e.KeyCode)
			{
                case Keys.Up:
                case Keys.Z:
                    BeginUpdate();
                    EffacerPieceCourante();
                    pieceCourante.RotationAGauche();
					if(EstEnCollision())
						pieceCourante.RotationADroite();
                    DessinerPieceCourante();
                    EndUpdate();
                    break;

                case Keys.X:
                    BeginUpdate();
                    EffacerPieceCourante();
                    pieceCourante.RotationADroite();
                    if(EstEnCollision())
                        pieceCourante.RotationAGauche();
                    DessinerPieceCourante();
                    EndUpdate();
                    break;

                case Keys.Space:
                    BeginUpdate();
                    EffacerPieceCourante();
                    while (DescendrePièceCourante())
                    {
                        DessinerPieceCourante();
                        EndUpdate();
                        BeginUpdate();
                        EffacerPieceCourante();
                    }
                    DessinerPieceCourante();
                    EndUpdate();
                    TraiterLaPieceAuPlancher();
                    return;

				case Keys.Left:
                    tmrKeyRepeatLeft.Enabled = true;
                    break;

				case Keys.Right:
                    tmrKeyRepeatRight.Enabled = true;
                    break;
			}
		}
        
		private void PieceBonus()
		{
			if(bonusUses > 2 || Niveau >= 10)
				return;

			EffacerPieceCourante();

			enuFormePièce type = (enuFormePièce)pieceCourante.ImageIndex - 1;
			pieceCourante = pieceBonus;
			pieceBonus = FabriquerPiece(1, 1, type);

			GrilleBonus.DessinerPiece(pieceBonus);

			if(pieceCourante == null)
				PieceSuivante();

			pieceCourante.Placer(1, 4);
			bonusUses++;

			if(EstEnCollision())
			{
				FinirPartie();
				return;
			}
			
			DessinerPieceCourante();
		}

		private void FinirPartie()
		{
			tmrDrop.Stop();
			GameOver.Invoke(this, EventArgs.Empty);
			AfficherAuCentre("FIN PARTIE");
		}


		private void GrilleTétris_KeyUp(object sender, KeyEventArgs e)
        {
            if(!tmrDrop.Enabled)
                return;

            switch(e.KeyCode)
            {
                case Keys.Left:
                    tmrKeyRepeatLeft.Enabled = false;
                    break;

                case Keys.Right:
                    tmrKeyRepeatRight.Enabled = false;
                    break;

                case Keys.Down:
                    tmrDrop.Interval = m_tabDelaiParNiveau[Niveau];
                    break;
            }
        }

        private void tmrKeyRepeatLeft_Tick(object sender, EventArgs e)
        {
            if(!tmrKeyRepeatLeft.Enabled)
                return;

            BeginUpdate();
            EffacerPieceCourante();
            pieceCourante.Déplacer(0, -1);

            if(EstEnCollision())
                pieceCourante.Déplacer(0, 1);

            DessinerPieceCourante();
            EndUpdate();
        }

        private void tmrKeyRepeatRight_Tick(object sender, EventArgs e)
        {
            if(!tmrKeyRepeatRight.Enabled)
                return;

            BeginUpdate();
            EffacerPieceCourante();
            pieceCourante.Déplacer(0, 1);

            if(EstEnCollision())
                pieceCourante.Déplacer(0, -1);

            DessinerPieceCourante();
            EndUpdate();
        }


        /// <summary>
        /// Permet de descendre la pièce courante d'une rangée vers les bas jusqu'à une collision
        /// </summary>
        /// <returns>true si la pièce a pu descendre normalement, sinon false</returns>
        private bool DescendrePièceCourante()
        {
			EffacerPieceCourante();
			pieceCourante.Déplacer(1, 0);

			if(EstEnCollision())
			{
				pieceCourante.Déplacer(-1, 0);
				DessinerPieceCourante();
				return false;
			}
			DessinerPieceCourante();
			return true;
        }
		
        /// <summary>
        /// Événement qui permet de faire descendre la pièce courante vers le bas.
        /// Si une collision se produit (ca veut dire que la pièce ne peut plus descendre),
        /// on crée alors une nouvelle pièce.
        /// </summary>
        private void tmrDrop_Tick(object sender, EventArgs e)
        {
			if(freezeTick)
			{
				freezeTick = false;
				return;
			}

			EffacerPieceCourante();
			if(!DescendrePièceCourante())
			{
				DessinerPieceCourante();
				TraiterLaPieceAuPlancher();
			}
			else
				DessinerPieceCourante();
		}
        
        /// <summary>
        /// Lorsqu'une pièce arrive au plancher:
        /// - Supprimer les lignes pleines (voir la méthode ci-après).
        /// - Lancer une nouvelle pièce
        /// - Vérifier s’il y a collision, on arrête l’horloge car c’est la fin de la partie.
        /// </summary>
        public void TraiterLaPieceAuPlancher()
        {
			DessinerPieceCourante();
			SupprimerLignesPleines();
			PieceSuivante();
			if(EstEnCollision())
			{
				FinirPartie();
				return;
			}
			
			m_score += 25;
			freezeTick = true;
			if(ScoreChanged != null)
				ScoreChanged.Invoke(this, EventArgs.Empty);

			DessinerPieceCourante();
        }

        /// <summary>
        /// Pour chaque ligne
        /// 	Si une seule cellule d’une ligne est vide, on ne supprime pas cette ligne.
        /// 	S’il faut supprimer une ligne : on utilise la méthode SupprimerUneLigne(ligne).
        /// 	Une fois toutes les lignes supprimées, on redessine toute la grille.
        /// </summary>
        public void SupprimerLignesPleines()
        {
			int lignes = 0;
			for(int row = 0; row < RowCount; row++)
			{
				bool lignePleine = true;

				for(int col = 0; col < ColumnCount; col++)
				{
					if(this[row, col] == CARRE_VIDE)
					{
						lignePleine = false;
						break;
					}
				}

				if(lignePleine)
				{
					SupprimerLaLigne(row);
					lignes++;
				}
			}

			m_rangees += lignes;
			m_score += lignes * lignes * 25 * (Niveau + 1);

			while(m_rangees >= m_tabNbLignesParNiveau[Niveau])
				Niveau++;

			if(NiveauChanged != null)
				NiveauChanged.Invoke(this, EventArgs.Empty);
		}

        /// <summary>
        /// Permet de mettre des cellules vides à la rangée 0 et 
        /// de décaler les rangées jusqu’à la ligne à supprimer.  
        /// </summary>
        /// <param name="pLigneASupprimer">indice de la ligne à supprimer</param>
        public void SupprimerLaLigne(int pRangéeASupprimer)
        {
			for(int rowIndex = pRangéeASupprimer; rowIndex >= 0; rowIndex--)
				for(int colIndex = 0; colIndex < ColumnCount; colIndex++)
					this[rowIndex, colIndex] = rowIndex != 0 ? this[rowIndex - 1, colIndex] : CARRE_VIDE;
        }
		
		/// <summary>
		/// Change la pièce courante pour la pièce suivante et fabrique une nouvelle pièce suivante
		/// </summary>
		public void PieceSuivante()
		{
			if(pieceSuivante == null)
				pieceSuivante = FabriquerPiece(1, 4, (enuFormePièce)PieceAleatoire());

			pieceCourante = pieceSuivante;
			pieceSuivante = FabriquerPiece(1, 4, (enuFormePièce)PieceAleatoire());
			m_grilleApercu.DessinerPiece(pieceSuivante);
			bonusUses = 0;
		}
		
        private int PieceAleatoire()
        {
			if(Niveau == 11)
				return (int)(m_objRandom.Next(0, 2) == 0 ? enuFormePièce.Escalier_D : enuFormePièce.Escalier_G);

            List<int> lessUsed = new List<int>();
            int least = int.MaxValue, index;


			foreach(int use in m_uses)
				if(use < least)
					least = use;

			for(index = 1; index < m_uses.Length - 1; index++)
            {
				if(m_uses[index] <= least + Niveau)
				{
					lessUsed.Add(index);
					continue;
				}
			}

			index = lessUsed[m_objRandom.Next(lessUsed.Count)];
			m_uses[index]++;
            return index - 1;
        }
		
		/// <summary>
		/// Obtiens le niveau du jeu et permet de le modifier
		/// Lance un événement lors de l'écriture de la valeur de la variable
		/// </summary>
		public int Niveau
		{
			get
			{
				return m_niveau;
			}

			set
			{
				m_niveau = value;

				if(m_niveau == 10)
					m_uses[7] = int.MaxValue;
			}
		}

		/// <summary>
		/// Retourne le niveau de départ du jeu, celui qui sera utilisé lors de la prochaine partie
		/// </summary>
		public int NiveauDepart
		{
			get
			{
				return m_niveauDepart;
			}

			set
			{
				m_niveauDepart = value;
			}
		}

		/// <summary>
		/// Donne accès en lecture et écriture du score Tétris
		/// Lance un événement lors de l'écriture de la valeur de la variable
		/// </summary>
		public int Score
		{
			get
			{
				return m_score;
			}
		}

		/// <summary>
		/// Retourne le nombre de rangées qui ont été complétés dans le niveau
		/// </summary>
		public int RangeesCompletees
		{
			get
			{
				return m_rangees;
			}
		}

		/// <summary>
		/// Retourne la progression du niveau courant, 1 étant complété et 0 étant non commencé
		/// </summary>
		public float ProgressionNiveau
		{
			get
			{
				float rowsDone = m_rangees, rowsTodo = m_tabNbLignesParNiveau[Niveau];

				if(NiveauDepart > 0 && Niveau == NiveauDepart)
				{
					rowsDone += m_tabNbLignesParNiveau[NiveauDepart - 1];
					rowsTodo += m_tabNbLignesParNiveau[NiveauDepart - 1];
				}

				if(Niveau > 0)
				{
					rowsDone -= m_tabNbLignesParNiveau[Niveau - 1];
					rowsTodo -= m_tabNbLignesParNiveau[Niveau - 1];
				}

				return rowsDone / rowsTodo;
			}
		}
	}
}
