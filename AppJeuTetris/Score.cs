using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace AppJeuTetris
{
	/// <summary>
	/// Représente le score d'un joueur de Tétris
	/// </summary>
    public class Score
    {
        

        private DateTime m_date;
		private int m_valeur;

		/// <summary>
		/// Donne accès à la date en lecture seulement
		/// </summary>
		public DateTime Date
        {
            get
			{
				return m_date;
			}
        }

		/// <summary>
		/// Donne accès à la valeur du score en lecture et écriture
		/// </summary>
        public int Valeur
        {
            get
			{
				return m_valeur;
			}

            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException();
                m_valeur = value;
                
            }
        }
        

        
        /// <summary>
        /// Initialise une instance de Score
        /// </summary>
        /// <param name="pDate">date du score</param>
        /// <param name="pValeur">valeur du score</param>
        public Score(DateTime pDate, int pValeur)
        {
            m_date = pDate;
            m_valeur = pValeur;
        }

        /// <summary>
        /// Initialise une instance de Score à partir d'un objet stocké dans un fichier binaire.
        /// On lit d'abord la date (un entier long) et ensuite on lit la valeur du score (un entier int).
        /// </summary>
        /// <param name="pobjBinaryReader">adresse du fichier binaire où lire</param>
        public Score(BinaryReader pobjBinaryReader)
        {
			m_date = new DateTime(pobjBinaryReader.ReadInt64());
			m_valeur = pobjBinaryReader.ReadInt32();
        }
        

        
        /// <summary>
        /// Écrit un objet "Score" dans le fichier binaire indiqué en paramètre.
        /// Écrit d'abord la date et ensuite la valeur du score.
        /// </summary>
        /// <param name="pobjBinaryWriter">adresse du fichier binaire où écrire</param>
        public void Ecrire(BinaryWriter pobjBinaryWriter)
        {
			pobjBinaryWriter.Write(m_date.Ticks);
			pobjBinaryWriter.Write(m_valeur);
        }
		
		/// <summary>
		/// Converti les valeurs du score en chaine de caractères
		/// </summary>
		/// <returns>Représentation du score en une chaine de caractères</returns>
        public override string ToString()
        {
            return m_valeur + "," + m_date.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
    }
}
