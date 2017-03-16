using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VisualArrays;
using System.IO;

namespace AppJeuTetris
{
    public partial class TopScoresPro : BaseGrid, TopScores
    {
		public const string FICHIER_SCORES = "Top10.bin";

		private Font m_policeNumero = new Font("Arial", 16, FontStyle.Bold);
        private Font m_policeScore = new Font("Arial", 18, FontStyle.Bold);
        private Font m_policeDate = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
		
        private Score[] m_tabScores;
	
        
        public TopScoresPro()
        {
            InitializeComponent();
            m_tabScores = new Score[RowCount];
            Clear();

		}
        
        public override int RowCount
        {
            get
            {
                return base.RowCount;
            }
            set
            {
                // ----- change le nombre de colonnes, instancie le tableau de score, vide la grille.
                base.RowCount = value;
                m_tabScores = new Score[RowCount];
                Clear();
            }
        }
		
		/// <summary>
		/// Met tous les scores à 0, déselectionne et visualise les scores.
		/// </summary>
		public new void Clear()
        {
            SelectedIndex = -1;
            for(int index = 0; index < m_tabScores.Length; index++)
                m_tabScores[index] = new Score(DateTime.Now, 0);

            Visualiser();
        }
        
        /// <summary>
        /// Affiche les scores dans la grille en soignant l'alignement:
        ///       - utiliser AddCellVisualElement
        ///       - utiliser les VisualElement suivants: FillShapeElement, ShapeElement, TextElement
        ///       - ContentAlignement et Padding
        /// </summary>
        public void Visualiser()
        {
            BeginUpdate();
            for (int index = 0; index < m_tabScores.Length; index++)
            {
                ClearCellVisualElements(index);
                AddCellVisualElement(index, new FillShapeElement(enuShape.Rectangle,Color.SaddleBrown));
                AddCellVisualElement(index, new ShapeElement(enuShape.Rectangle, 1, Color.YellowGreen,0));
                AddCellVisualElement(index, new TextElement(m_policeNumero, (index + 1) + "-", Color.YellowGreen,
                                            ContentAlignment.MiddleLeft, new Padding(10, 0, 0, 0)));
                if (m_tabScores[index] != null && m_tabScores[index].Valeur > 0)
                {
                    AddCellVisualElement(index, new TextElement(m_policeScore, m_tabScores[index].Valeur.ToString(), Color.Yellow,
                                            ContentAlignment.MiddleRight, new Padding(0, 0, 220, 0)));
                    AddCellVisualElement(index, new TextElement(m_policeDate, m_tabScores[index].Date.ToString("dd-MM-yyyy HH:mm:ss"),
                                            Color.YellowGreen, ContentAlignment.MiddleRight, new Padding(0, 0, 12, 0)));
                }
            }
            EndUpdate();
        }
        
        /// <summary>
        /// Ajoute le score à la bonne place dans la grille. Les scores sont en ordre décroissant.
        /// </summary>
        /// <param name="pValeurScore">valeur du score à ajouter</param>
        public void Ajouter(int pValeurScore)
        {
            if (pValeurScore == 0) return;

            // on doit trouver l'emplacement ou placer le nouveau score
            int indexInsertion = 0;
            while (indexInsertion < m_tabScores.Length && m_tabScores[indexInsertion]!= null && m_tabScores[indexInsertion].Valeur > pValeurScore)
                indexInsertion++;

            // si le score doit être placé dans la liste alors on déplace les autres éléments
            if (indexInsertion < m_tabScores.Length)
            {
                for (int index = Length - 1; index > indexInsertion; index--)
                    m_tabScores[index] = m_tabScores[index - 1];

                m_tabScores[indexInsertion] = new Score(DateTime.Now, pValeurScore);

                Visualiser();
                SelectedIndex = indexInsertion;
            }
            else // le nouveau scrore n'est pas dans la liste des meilleurs scrores
            {
                SelectedIndex = -1;
            }
        }
        
        /// <summary>
        /// Remplit la collection de scores à partir des objets lus dans le fichier.
        /// On lit d'abord un entier int indiquant le nombre d'objets "scores" à lire.
        /// Ensuite on lit chacun des objets "scores" que l'on stocke dans la collection.
        /// </summary>
        public void Charger()
        {
			if(!File.Exists(FICHIER_SCORES))
				return;

			FileStream objStream = new FileStream(FICHIER_SCORES, FileMode.Open);
			BinaryReader objReader = new BinaryReader(objStream);

			int count = objReader.ReadInt32();

			m_tabScores = new Score[count];

			for(int index = 0; index < count; index++)
				m_tabScores[index] = new Score(objReader);

			objReader.Close();
		}
        
        /// <summary>
        /// Écrit dans le fichier binaire, les objets de la collection de scores.
        /// - Écrit d'abord le nombre de scores
        /// - ensuite écrit chacun des objets "scores" de la collection.
        /// </summary>
        public void Enregistrer()
        {
			FileStream objStream = new FileStream(FICHIER_SCORES, FileMode.Create);
			BinaryWriter objWriter = new BinaryWriter(objStream);

			objWriter.Write(m_tabScores.Length);

			foreach(Score score in m_tabScores)
				score.Ecrire(objWriter);

			objWriter.Close();
		}
    }
}
