
#region TESTS DE LA PREMIÈRE PARTIE ( /40)
///------------------------------------------------------------------------------------------
/// Ces tests devrait fonctionner lorsque vous aurez ajouté vos classes Point et Piece
/// ainsi que lorsque vous aurez copié dans la GrilleTétris les méthodes suivantes :
///     FabriquerPièce, DessinerPièceCourante, EffacerPièceCourante et EstEnCollision
///------------------------------------------------------------------------------------------
#define A_Point
#define B1_PieceConstructeur
#define B2_PieceAjouterPoint
#define B3_PieceDeplacer
#define B4_PieceRotation
#define B5_PiecePointExiste
/////------------------------------------------------------------------------------------------
///// Tests de GrilleTéris avec les méthodes de la première partie
#define C1_FabriquerPiècesTriangle
#define C2_DessinerPièceTriangle
#define C3_EffacerPièceTriangle
#define C4_EstEnCollisionTriangle

#define D1_FabriquerPiècesAutres
#define D2_DessinerPièceAutres
#define D3_EffacerPièceAutres
#define D4_EstEnCollisionAutres
///------------------------------------------------------------------------------------------
#endregion

#region TESTS SPÉCIFIQUE AU JEU TÉTRIS ( /16)

#define E1_DescendrePièceCourante
#define F1_SupprimerLaLigne
#define F2_SupprimerLignesPleines

#endregion

using AppJeuTetris;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;

namespace CorrecteurTetris
{

    /// <summary>
    ///Classe de test pour corriger les classes de l'application Tétris
    ///</summary>
    [TestClass()]
    public class Correcteur
    {
        public static string m_version = "Correcteur H16.1.1";
        #region Attributs de tests

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion

        #region Attributs de tests supplémentaires
        private static int m_totalScore;
        private static int m_maxScore;
        private static Random m_objRandom = new Random();

        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            m_totalScore = 0;
            m_maxScore = 0;
        }
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            StreamWriter ficScore = new StreamWriter("../../../Score.txt");
            ficScore.Write(m_version + " : " + FrmPrincipal.APP_INFO + "\n");
            ficScore.Write(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            ficScore.Write("\nRésultat de la correction\nScore : " + m_totalScore + "/" + m_maxScore, Correcteur.m_version, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ficScore.Close();
        }
        //------------------------------------------------------------------------------------------------------
        private bool CoordonnéesValidesDuPoint(IPiece pobjPiece, int pRangée, int pColonne)
        {
            for (int index = 0; index < pobjPiece.NbPoints; index++)
                if (pobjPiece.PointAt(index).Rangée == pRangée && pobjPiece.PointAt(index).Colonne == pColonne)
                    return true;
            return false;
        }
        #endregion

        #region TESTS DE LA PREMIÈRE PARTIE

        #region TESTS DE LA CLASSE Point
#if A_Point
        /// <summary>
        ///Test pour la classe Point, 2 champs et aucune méthode
        ///</summary>
        [TestMethod()]
        public void A_Point()
        {
            m_maxScore += 2;

            AppJeuTetris.Point target = new AppJeuTetris.Point(1, 2);
            Assert.AreEqual(1, target.Rangée);
            Assert.AreEqual(2, target.Colonne);

            target = new AppJeuTetris.Point(2, 1);
            Assert.AreEqual(2, target.Rangée);
            Assert.AreEqual(1, target.Colonne);

            //test le setter
            target.Rangée = 4;
            target.Colonne = 5;

            Assert.AreEqual(4, target.Rangée);
            Assert.AreEqual(5, target.Colonne);

            m_totalScore += 2;
        }
#endif
        #endregion

        #region TESTS DE LA CLASSE Piece

#if B1_PieceConstructeur
        /// <summary>
        ///Test pour Constructeur Piece
        ///Test aussi les propriétés
        ///    Taille
        ///    OrigineRangée
        ///    OrigineColonne
        ///    ImageIndex
        ///    NbPoints
        ///</summary>
        [TestMethod()]
        public void B1_PieceConstructeur()
        {
            m_maxScore += 2;

            Piece target = new Piece(new Size(3, 4), 5, 6, 7);

            Assert.AreEqual(3, target.Taille.Width);
            Assert.AreEqual(4, target.Taille.Height);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(6, target.OrigineColonne);
            Assert.AreEqual(7, target.ImageIndex);
            Assert.AreEqual(0, target.NbPoints);

            target = new Piece(new Size(4, 1), 4, 5, 6);

            Assert.AreEqual(4, target.Taille.Width);
            Assert.AreEqual(1, target.Taille.Height);
            Assert.AreEqual(4, target.OrigineRangée);
            Assert.AreEqual(5, target.OrigineColonne);
            Assert.AreEqual(6, target.ImageIndex);
            Assert.AreEqual(0, target.NbPoints);

            m_totalScore += 2;
        }
#endif

#if B2_PieceAjouterPoint
        /// <summary>
        ///Test des méthodes : AjouterPoint et PointAt
        ///Test aussi NbPoints
        ///</summary>
        [TestMethod()]
        public void B2a_PieceAjouterPoint_PointAt()
        {
            m_maxScore += 2;

            Piece target = new Piece(new Size(2, 2), 3, 4, 0);

            Assert.AreEqual(0, target.NbPoints);
            // on commence par ajouter un point à l'origine
            target.AjouterPoint(0, 0);
            Assert.AreEqual(1, target.NbPoints);
            Assert.AreEqual(3, target.PointAt(0).Rangée);
            Assert.AreEqual(4, target.PointAt(0).Colonne);
            m_totalScore++;

            // on va ajouter un autre point
            target.AjouterPoint(1, -1);
            Assert.AreEqual(2, target.NbPoints);
            Assert.AreEqual(4, target.PointAt(1).Rangée);
            Assert.AreEqual(3, target.PointAt(1).Colonne);
            m_totalScore++;

        }
        /// <summary>
        ///Test de la méthode :  PointAt avec débordement levant une exception
        ///</summary>
        [TestMethod()]
        public void B2b_PiecePointAt_Exceptions()
        {
            m_maxScore += 2;

            Piece target = new Piece(new Size(2, 2), 3, 4, 0);

            Assert.AreEqual(0, target.NbPoints);
            // on commence par ajouter un point à l'origine
            target.AjouterPoint(0, 0);

            // on va ajouter un autre point
            target.AjouterPoint(1, -1);
            Assert.AreEqual(2, target.NbPoints);

            // on va vérifier l'index pour la méthode PointAt
            try
            {
                target.PointAt(-1);
                Assert.Fail("ArgumentOutOfRangeException attendue");
            }
            catch (ArgumentOutOfRangeException)
            {
                m_totalScore++;
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentOutOfRangeException attendue");
            }

            // on va vérifier l'index pour la méthode PointAt
            try
            {
                target.PointAt(target.NbPoints);
                Assert.Fail("ArgumentOutOfRangeException attendue");
            }
            catch (ArgumentOutOfRangeException)
            {
                m_totalScore++;
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentOutOfRangeException attendue");
            }

        }

#endif

#if B3_PieceDeplacer
        /// <summary>
        ///Test de la méthode Déplacer
        ///</summary>
        [TestMethod()]
        public void B3_PieceDéplacer()
        {
            m_maxScore += 4;

            Piece target = new Piece(new Size(3, 3), 8, 9, 0); // origine (8,9)
            target.AjouterPoint(-1, -1); // position réelle (7,8)
            target.AjouterPoint(1, 1); // position réelle (9,10)

            target.Déplacer(0, 1); // on va déplacer la pièce vers la droite
            Assert.AreEqual(8, target.OrigineRangée); // pas de mouvement
            Assert.AreEqual(10, target.OrigineColonne);  // déplacement à droite
            Assert.AreEqual(7, target.PointAt(0).Rangée); // pas de mouvement
            Assert.AreEqual(9, target.PointAt(0).Colonne); // déplacement à droite
            Assert.AreEqual(9, target.PointAt(1).Rangée); // pas de mouvement
            Assert.AreEqual(11, target.PointAt(1).Colonne); // déplacement à droite
            m_totalScore++;

            target.Déplacer(0, -1); // on va déplacer la pièce vers la gauche
            Assert.AreEqual(8, target.OrigineRangée); // pas de mouvement
            Assert.AreEqual(9, target.OrigineColonne);  // déplacement à gauche
            Assert.AreEqual(7, target.PointAt(0).Rangée); // pas de mouvement
            Assert.AreEqual(8, target.PointAt(0).Colonne); // déplacement à gauche
            Assert.AreEqual(9, target.PointAt(1).Rangée); // pas de mouvement
            Assert.AreEqual(10, target.PointAt(1).Colonne); // déplacement à gauche
            m_totalScore++;

            target.Déplacer(1, 0); // on va déplacer la pièce vers le bas
            Assert.AreEqual(9, target.OrigineRangée); // déplacement vers le bas
            Assert.AreEqual(9, target.OrigineColonne);  // pas de mouvement
            Assert.AreEqual(8, target.PointAt(0).Rangée); /// déplacement vers le bas
            Assert.AreEqual(8, target.PointAt(0).Colonne); // pas de mouvement
            Assert.AreEqual(10, target.PointAt(1).Rangée); // déplacement vers le bas
            Assert.AreEqual(10, target.PointAt(1).Colonne); // pas de mouvement
            m_totalScore++;

            target.Déplacer(-1, 0); // on va déplacer la pièce vers le haut
            Assert.AreEqual(8, target.OrigineRangée); // déplacement vers le haut
            Assert.AreEqual(9, target.OrigineColonne);  // pas de mouvement
            Assert.AreEqual(7, target.PointAt(0).Rangée); /// déplacement vers le haut
            Assert.AreEqual(8, target.PointAt(0).Colonne); // pas de mouvement
            Assert.AreEqual(9, target.PointAt(1).Rangée); // déplacement vers le haut
            Assert.AreEqual(10, target.PointAt(1).Colonne); // pas de mouvement
            m_totalScore++;

        }

#endif

#if B4_PieceRotation
        /// <summary>
        ///Test pour la rotation d'une piece
        ///</summary>
        [TestMethod()]
        public void B4_PieceRotation()
        {
            m_maxScore += 6;
            Piece target;

            // pièce de 3 X 2 rotation à droite
            target = new Piece(new Size(3, 2), 9, 8, 0);
            target.AjouterPoint(-1, 0); // position réelle (8,8)
            target.AjouterPoint(0, -1); // position réelle (9,7)

            target.RotationADroite();
            Assert.AreEqual(9, target.OrigineRangée);
            Assert.AreEqual(8, target.OrigineColonne);
            Assert.AreEqual(9, target.PointAt(0).Rangée);
            Assert.AreEqual(9, target.PointAt(0).Colonne);
            Assert.AreEqual(8, target.PointAt(1).Rangée);
            Assert.AreEqual(8, target.PointAt(1).Colonne);
            m_totalScore++;

            // pièce de 3 X 2 rotation à gauche
            target = new Piece(new Size(3, 2), 9, 8, 0);
            target.AjouterPoint(-1, 0); // position réelle (8,8)
            target.AjouterPoint(0, -1); // position réelle (9,7)

            target.RotationAGauche();
            Assert.AreEqual(9, target.OrigineRangée);
            Assert.AreEqual(8, target.OrigineColonne);
            Assert.AreEqual(9, target.PointAt(0).Rangée);
            Assert.AreEqual(8, target.PointAt(0).Colonne);
            Assert.AreEqual(10, target.PointAt(1).Rangée);
            Assert.AreEqual(9, target.PointAt(1).Colonne);
            m_totalScore++;

            // pièce de 2 X 2 aucun mouvement
            target = new Piece(new Size(2, 2), 9, 8, 0);
            target.AjouterPoint(-1, 0); // position réelle (8,8)

            target.RotationADroite();
            Assert.AreEqual(9, target.OrigineRangée);
            Assert.AreEqual(8, target.OrigineColonne);
            Assert.AreEqual(8, target.PointAt(0).Rangée);
            Assert.AreEqual(8, target.PointAt(0).Colonne);

            m_totalScore++;

            // pièce de 2 X 2 aucun mouvement
            target = new Piece(new Size(2, 2), 9, 8, 0);
            target.AjouterPoint(-1, 0); // position réelle (8,8)

            target.RotationAGauche();
            Assert.AreEqual(9, target.OrigineRangée);
            Assert.AreEqual(8, target.OrigineColonne);
            Assert.AreEqual(8, target.PointAt(0).Rangée);
            Assert.AreEqual(8, target.PointAt(0).Colonne);
            m_totalScore++;

            // pièce de 4 X 1 rotation à droite
            target = new Piece(new Size(4, 1), 9, 8, 0);
            target.AjouterPoint(0, -1);
            target.AjouterPoint(0, 2);

            target.RotationADroite();
            Assert.AreEqual(9, target.OrigineRangée);
            Assert.AreEqual(8, target.OrigineColonne);
            Assert.AreEqual(8, target.PointAt(0).Rangée);
            Assert.AreEqual(8, target.PointAt(0).Colonne);
            Assert.AreEqual(11, target.PointAt(1).Rangée);
            Assert.AreEqual(8, target.PointAt(1).Colonne);
            m_totalScore++;

            // pièce de 4 X 1 rotation à gauche
            target = new Piece(new Size(4, 1), 9, 8, 0);
            target.AjouterPoint(0, -1);
            target.AjouterPoint(0, 2);

            target.RotationAGauche();
            Assert.AreEqual(9, target.OrigineRangée);
            Assert.AreEqual(8, target.OrigineColonne);
            Assert.AreEqual(8, target.PointAt(0).Rangée);
            Assert.AreEqual(8, target.PointAt(0).Colonne);
            Assert.AreEqual(11, target.PointAt(1).Rangée);
            Assert.AreEqual(8, target.PointAt(1).Colonne);

            m_totalScore++;

        }
#endif
#if B5_PiecePointExiste
        /// <summary>
        ///Test pour PointExiste
        ///</summary>
        [TestMethod()]
        public void B5_PointExiste()
        {
            m_maxScore += 2;
            Piece target;

            // pièce de 3 X 2
            target = new Piece(new Size(3, 2), 9, 8, 0);
            target.AjouterPoint(-1, 0); // position réelle (8,8)
            Assert.IsTrue(target.PointExiste(new AppJeuTetris.Point(8, 8)));

            target.AjouterPoint(0, -1); // position réelle (9,7)
            Assert.IsTrue(target.PointExiste(new AppJeuTetris.Point(9, 7)));

            Assert.IsFalse(target.PointExiste(new AppJeuTetris.Point(9, 8)));
            m_totalScore += 2;
        }
#endif

        #endregion

        #region TESTS C1 à C4 DE LA CLASSE GrilleJeu avec forme Triangle

#if C1_FabriquerPiècesTriangle
        /// <summary>
        ///Test pour la classe GrilleJeu méthode: FabriquerPiece
        ///</summary>
        [TestMethod()]
        public void C1_GrilleJeuFabriquerPiècesTriangle()
        {
            m_maxScore += 1;
            IPiece target;

            GrilleTétris_Accessor grille = new GrilleTétris_Accessor();
            //------------------------------------------------------------------------
            // on va tester la pièce : enuFormePièce.Triangle
            target = grille.FabriquerPiece(5, 10, enuFormePièce.Triangle);

            Assert.AreEqual(3, target.Taille.Width);
            Assert.AreEqual(2, target.Taille.Height);
            Assert.AreEqual(4, target.NbPoints);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(10, target.OrigineColonne);
            Assert.AreEqual((int)enuFormePièce.Triangle + 1, target.ImageIndex);

            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 11));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 10));
            m_totalScore++;
        }
#endif

#if C2_DessinerPièceTriangle
        /// <summary>
        ///Test pour la classe GrilleJeu méthode: DessinerPiece forme triangle
        ///</summary>
        [TestMethod()]
        public void C2_GrilleJeuDessinerPièceTriangle()
        {
            m_maxScore += 1;
            
            GrilleTétris_Accessor target = new GrilleTétris_Accessor();
            GrilleTétris grille = (GrilleTétris)target.Target;

            target.m_objPieceCourante = target.FabriquerPiece(5, 5, enuFormePièce.Triangle);
            target.DessinerPieceCourante();

            for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
                if (grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] != target.m_objPieceCourante.ImageIndex)
                    Assert.Fail();

            m_totalScore += 1;
        }
#endif

#if C3_EffacerPièceTriangle
        /// <summary>
        ///Test pour la classe GrilleJeu méthode: EffacerPiece
        ///</summary>
        [TestMethod()]
        public void C3_GrilleJeuEffacerPièceTriangle()
        {
            m_maxScore += 1;

            GrilleTétris_Accessor target = new GrilleTétris_Accessor();
            GrilleTétris grille = (GrilleTétris)target.Target;

            target.m_objPieceCourante = target.FabriquerPiece(5, 5, enuFormePièce.Triangle);
            grille[5, 5] = 1; // pour ne pas que le test passe si dessinerpiece ne fonctionne pas
            target.DessinerPieceCourante();
            target.EffacerPieceCourante();
            for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
                if (grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] != 0)
                    Assert.Fail();

            m_totalScore += 1;
        }
#endif

#if C4_EstEnCollisionTriangle
        /// <summary>
        ///Test pour la classe GrilleJeu méthode: EstEnCollision forme Triangle
        ///</summary>
        [TestMethod()]
        public void C4_GrilleJeuEstEnCollisionTriangle()
        {
            m_maxScore += 1;

            GrilleTétris_Accessor target = new GrilleTétris_Accessor();
            GrilleTétris grille = (GrilleTétris)target.Target;
 
            // ne devrait pas être en collision
            target.m_objPieceCourante = target.FabriquerPiece(1, 1, enuFormePièce.Triangle);
            Assert.IsFalse(target.EstEnCollision());

            // vérification de la limite de la grille en haut
            target.m_objPieceCourante = target.FabriquerPiece(0, 1, enuFormePièce.Triangle);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille à gauche
            target.m_objPieceCourante = target.FabriquerPiece(1, 0, enuFormePièce.Triangle);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille à droite
            target.m_objPieceCourante = target.FabriquerPiece(1, grille.ColumnCount - 1, enuFormePièce.Triangle);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille en bas
            target.m_objPieceCourante = target.FabriquerPiece(grille.RowCount, 1, enuFormePièce.Triangle);
            Assert.IsTrue(target.EstEnCollision());

            // vérification d'une collision avec le contenu de la grille
            target.m_objPieceCourante = target.FabriquerPiece(1, 1, enuFormePièce.Triangle);
            for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
            {
                grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = index % 7 + 50;// H16
                Assert.IsTrue(target.EstEnCollision());
                grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = 0;
            }
            m_totalScore += 1;
        }
#endif
        #endregion

        #region TESTS D1 à D4 DE LA CLASSE GrilleJeu avec les autres formes
        #if D1_FabriquerPiècesAutres
        /// <summary>
        ///Test pour Piece FabriquerPiece(origineLigne, origineColonne, enuFormePièce.Triangle);
        ///</summary>
        [TestMethod()]
        public void D1_GrilleJeuFabriquerPiècesAutres()
        {
            m_maxScore += 6;
            IPiece target;

            GrilleTétris_Accessor grille = new GrilleTétris_Accessor();
            //------------------------------------------------------------------------
            // on va tester la pièce : enuFormePièce.Barre
            target = grille.FabriquerPiece(5, 10, enuFormePièce.Barre);

            Assert.AreEqual(4, target.Taille.Width);
            Assert.AreEqual(1, target.Taille.Height);
            Assert.AreEqual(4, target.NbPoints);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(10, target.OrigineColonne);
            Assert.AreEqual((int)enuFormePièce.Barre + 1, target.ImageIndex);

            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 11));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 12));
            m_totalScore++;

            //------------------------------------------------------------------------
            // on va tester la pièce : enuFormePièce.Carre
            target = grille.FabriquerPiece(5, 10, enuFormePièce.Carre);

            Assert.AreEqual(2, target.Taille.Width);
            Assert.AreEqual(2, target.Taille.Height);
            Assert.AreEqual(4, target.NbPoints);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(10, target.OrigineColonne);
            Assert.AreEqual((int)enuFormePièce.Carre + 1, target.ImageIndex);

            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 10));
            m_totalScore++;

            //------------------------------------------------------------------------
            // on va tester la pièce : enuFormePièce.Escalier_D
            target = grille.FabriquerPiece(5, 10, enuFormePièce.Escalier_D);

            Assert.AreEqual(3, target.Taille.Width);
            Assert.AreEqual(2, target.Taille.Height);
            Assert.AreEqual(4, target.NbPoints);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(10, target.OrigineColonne);
            Assert.AreEqual((int)enuFormePièce.Escalier_D + 1, target.ImageIndex);

            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 11));
            m_totalScore++;

            //------------------------------------------------------------------------
            // on va tester la pièce : enuFormePièce.Escalier_G
            target = grille.FabriquerPiece(5, 10, enuFormePièce.Escalier_G);

            Assert.AreEqual(3, target.Taille.Width);
            Assert.AreEqual(2, target.Taille.Height);
            Assert.AreEqual(4, target.NbPoints);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(10, target.OrigineColonne);
            Assert.AreEqual((int)enuFormePièce.Escalier_G + 1, target.ImageIndex);

            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 11));
            m_totalScore++;

            //------------------------------------------------------------------------
            // on va tester la pièce : enuFormePièce.L_Normal
            target = grille.FabriquerPiece(5, 10, enuFormePièce.L_Normal);

            Assert.AreEqual(3, target.Taille.Width);
            Assert.AreEqual(2, target.Taille.Height);
            Assert.AreEqual(4, target.NbPoints);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(10, target.OrigineColonne);
            Assert.AreEqual((int)enuFormePièce.L_Normal + 1, target.ImageIndex);

            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 11));
            m_totalScore++;

            //------------------------------------------------------------------------
            // on va tester la pièce : enuFormePièce.L_Inverse
            target = grille.FabriquerPiece(5, 10, enuFormePièce.L_Inverse);

            Assert.AreEqual(3, target.Taille.Width);
            Assert.AreEqual(2, target.Taille.Height);
            Assert.AreEqual(4, target.NbPoints);
            Assert.AreEqual(5, target.OrigineRangée);
            Assert.AreEqual(10, target.OrigineColonne);
            Assert.AreEqual((int)enuFormePièce.L_Inverse + 1, target.ImageIndex);

            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 9));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 10));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 4, 11));
            Assert.IsTrue(CoordonnéesValidesDuPoint(target, 5, 11));
            m_totalScore++;
        }
        #endif

        #if D2_DessinerPièceAutres
        /// <summary>
        ///Test pour la classe GrilleJeu méthode: DessinerPiece toutes les formes
        ///</summary>
        [TestMethod()]
        public void D2_GrilleJeuDessinerPièceAutres()
        {
            m_maxScore += 2;

            GrilleTétris_Accessor target = new GrilleTétris_Accessor();
            GrilleTétris grille = (GrilleTétris)target.Target;

            for(enuFormePièce forme = enuFormePièce.Escalier_G; forme <= enuFormePièce.Barre; forme++)
            {
                target.m_objPieceCourante = target.FabriquerPiece(5, 5, forme);
                target.DessinerPieceCourante();

                for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
                    if (grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] != target.m_objPieceCourante.ImageIndex)
                        Assert.Fail();
            }
            m_totalScore += 2;
        }
#endif


#if D3_EffacerPièceAutres
        /// <summary>
        ///Test pour la classe GrilleJeu méthode: EffacerPiece toutes les formes
        ///</summary>
        [TestMethod()]
        public void D3_GrilleJeuEffacerPièceAutres()
        {
            m_maxScore += 2;

            GrilleTétris_Accessor target = new GrilleTétris_Accessor();
            GrilleTétris grille = (GrilleTétris)target.Target; 
            
            for (enuFormePièce forme = enuFormePièce.Escalier_G; forme <= enuFormePièce.Barre; forme++)
            {
                target.m_objPieceCourante = target.FabriquerPiece(5, 5, forme);
                grille[5, 5] = 1; // pour ne pas que le test passe si dessinerpiece ne fonctionne pas
                target.DessinerPieceCourante();
                target.EffacerPieceCourante();
                for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
                    if (grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] != 0)
                        Assert.Fail();
            }
            m_totalScore += 2;
        }
#endif


#if D4_EstEnCollisionAutres
        /// <summary>
        ///Test pour la classe GrilleJeu méthode: EstEnCollision forme Triangle
        ///</summary>
        [TestMethod()]
        public void D4_GrilleJeuEstEnCollisionAutres()
        {
            m_maxScore += 6;

            GrilleTétris_Accessor target = new GrilleTétris_Accessor();
            GrilleTétris grille = (GrilleTétris)target.Target;

            //Pour les 5 premières formes on a la même logique de tests
            for (enuFormePièce forme = enuFormePièce.Escalier_G; forme <= enuFormePièce.L_Inverse; forme++)
            {
                // ne devrait pas être en collision
                target.m_objPieceCourante = target.FabriquerPiece(1, 1, forme);
                Assert.IsFalse(target.EstEnCollision());

                // vérification de la limite de la grille en haut
                target.m_objPieceCourante = target.FabriquerPiece(0, 1, forme);
                Assert.IsTrue(target.EstEnCollision());

                // vérification de la limite de la grille à gauche
                target.m_objPieceCourante = target.FabriquerPiece(1, 0, forme);
                Assert.IsTrue(target.EstEnCollision());

                // vérification de la limite de la grille à droite
                target.m_objPieceCourante = target.FabriquerPiece(1, grille.ColumnCount - 1, forme);
                Assert.IsTrue(target.EstEnCollision());

                // vérification de la limite de la grille en bas
                target.m_objPieceCourante = target.FabriquerPiece(grille.RowCount, 1, forme);
                Assert.IsTrue(target.EstEnCollision());
                

                // vérification d'une collision avec le contenu de la grille
                target.m_objPieceCourante = target.FabriquerPiece(1, 1, forme);
                for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
                {
                    grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = index % 7 + 50;// H16;
                    Assert.IsTrue(target.EstEnCollision());
                    grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = 0;
                }
                m_totalScore++;
            }

            //Forme enuFormePièce.Carre
            // ne devrait pas être en collision
            target.m_objPieceCourante = target.FabriquerPiece(1, 1, enuFormePièce.Carre);
            Assert.IsFalse(target.EstEnCollision());

            // vérification de la limite de la grille en haut
            target.m_objPieceCourante = target.FabriquerPiece(0, 1, enuFormePièce.Carre);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille à gauche
            target.m_objPieceCourante = target.FabriquerPiece(1, 0, enuFormePièce.Carre);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille à droite
            target.m_objPieceCourante = target.FabriquerPiece(1, grille.ColumnCount, enuFormePièce.Carre);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille en bas
            target.m_objPieceCourante = target.FabriquerPiece(grille.RowCount, 1, enuFormePièce.Carre);
            Assert.IsTrue(target.EstEnCollision());


            // vérification d'une collision avec le contenu de la grille
            target.m_objPieceCourante = target.FabriquerPiece(1, 1, enuFormePièce.Carre);
            for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
            {
                grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = 1;
                Assert.IsTrue(target.EstEnCollision());
                grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = 0;
            }
            m_totalScore++;

            //Forme enuFormePièce.Barre
            // ne devrait pas être en collision
            target.m_objPieceCourante = target.FabriquerPiece(0, 1, enuFormePièce.Barre);
            Assert.IsFalse(target.EstEnCollision());

            // vérification de la limite de la grille en haut
            target.m_objPieceCourante = target.FabriquerPiece(-1, 1, enuFormePièce.Barre);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille à gauche
            target.m_objPieceCourante = target.FabriquerPiece(1, 0, enuFormePièce.Barre);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille à droite
            target.m_objPieceCourante = target.FabriquerPiece(1, grille.ColumnCount - 2, enuFormePièce.Barre);
            Assert.IsTrue(target.EstEnCollision());

            // vérification de la limite de la grille en bas
            target.m_objPieceCourante = target.FabriquerPiece(grille.RowCount, 1, enuFormePièce.Barre);
            Assert.IsTrue(target.EstEnCollision());


            // vérification d'une collision avec le contenu de la grille
            target.m_objPieceCourante = target.FabriquerPiece(1, 1, enuFormePièce.Barre);
            for (int index = 0; index < target.m_objPieceCourante.NbPoints; index++)
            {
                grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = 1;
                Assert.IsTrue(target.EstEnCollision());
                grille[target.m_objPieceCourante.PointAt(index).Rangée, target.m_objPieceCourante.PointAt(index).Colonne] = 0;
            }
            m_totalScore++;
        }
#endif
        #endregion

        #endregion

        #region TESTS GrilleTétris : DescendrePièceCourante

#if E1_DescendrePièceCourante
        /// <summary>
        ///Test pour la classe GrilleTétris
        ///</summary>
        [TestMethod()]
        public void E1_DescendrePièceCourante()
        {
            m_maxScore += 4;

            GrilleTétris_Accessor target = new GrilleTétris_Accessor();
            GrilleTétris grille = (GrilleTétris)target.Target;

            // lance autant de triangle que possible...
            for (int cptPiece = 1; cptPiece < grille.RowCount / 2; cptPiece++)
            {
                target.m_objPieceCourante = target.FabriquerPiece(1, 1, enuFormePièce.Triangle);
                target.DessinerPieceCourante();

                for (int cpt = 0; cpt < grille.RowCount - target.m_objPieceCourante.Taille.Height * cptPiece; cpt++)
                {
                    Assert.IsTrue(target.DescendrePièceCourante());
                }
                Assert.IsFalse(target.DescendrePièceCourante());
            }
            m_totalScore += 4;
        }
#endif
#endregion

        #region TESTS GrilleTétris : SupprimerLaLigne et SupprimerLignesPleines
#if F1_SupprimerLaLigne
        /// <summary>
        ///Test pour supprimer une ligne complète dans la grille
        ///</summary>
        [TestMethod()]
        public void F1_SupprimerLaLigne()
        {
            m_maxScore += 6;

            GrilleTétris target;

            //----------------------------------------------------------------------   
            // LE CODE CI-DESSOUS VA VÉRIFIER LA SUPPRESSION DE LA DERNIÈRE LIGNE        
            target = new GrilleTétris();
            // on va placer des nombres dans une diagonale
            for (int index = 0; index < target.RowCount; index++)
                target[index,index] = index + 1;

            // on va supprimer la dernière ligne
            target.SupprimerLaLigne(target.RowCount - 1);

            // on va vérifier les nombres de la diagonales
            Assert.IsTrue(target[0, 0] == 0);
            for (int index = 0; index < target.RowCount - 1; index++)
                Assert.IsTrue(target[index + 1, index] == index + 1);

            m_totalScore += 3;
            //---------------------------------------------------------------------- 
            // LE CODE CI-DESSOUS VA VÉRIFIER LA SUPPRESSION DE LA LIGNE DU MILIEU
            target = new GrilleTétris();
            // on va placer des nombres dans une diagonale
            for (int index = 0; index < target.RowCount; index++)
                target[index, index] = index + 1;

            // on va supprimer la ligne du mileu
            target.SupprimerLaLigne(target.RowCount / 2);

            // on va vérifier les nombres de la diagonales
            Assert.IsTrue(target[0, 0] == 0);
            for (int index = 0; index < target.RowCount / 2; index++)
                Assert.IsTrue(target[index + 1, index] == index + 1);

            for (int index = target.RowCount / 2 + 1; index < target.RowCount; index++)
                Assert.IsTrue(target[index, index] == index + 1);

            
            m_totalScore += 3;
            //----------------------------------------------------------------------            
        }
#endif
#if F2_SupprimerLignesPleines

        //----------------------------------------------------------------------   
        private void Placer3LignesPleines(GrilleTétris pGrille)
        {
            // maintenant on va supprimer les trois dernières lignes qui seront pleines
            int colMilieu = pGrille.ColumnCount / 2;
            for (int row = 0; row < pGrille.RowCount; row++)
            {
                if (row >= pGrille.RowCount - 3)
                {
                    for (int col = 0; col < pGrille.ColumnCount; col++)
                        pGrille[row, col] = row;
                }
                else
                    pGrille[row, colMilieu] = row;
            }
        }

        /// <summary>
        ///Test pour supprimer toutes les lignes pleines
        ///</summary>
        [TestMethod()]
        public void F2_SupprimerLignesPleines()
        {
            m_maxScore += 10;

            GrilleTétris target;
            //----------------------------------------------------------------------   
            // LE CODE CI-DESSOUS VA VÉRIFIER LA SUPPRESSION DES LIGNES       
            target = new GrilleTétris();

            int colMilieu = target.ColumnCount / 2;
            for (int row = 0; row < target.RowCount; row++)
            {
                if (row % 2 != 0) // rangée impaire, incomplète
                    target[row, colMilieu] = row;
                else // rangée paire alors elle sera pleine
                {
                    for (int col = 0; col < target.ColumnCount; col++)
                        target[row, col] = row;
                }
            }
            target.SupprimerLignesPleines();

            // on va vérifier que les lignes pleines ont étés supprimées
            for (int row = 0; row < target.RowCount; row++)
            {
                if (target[row, colMilieu] != 0 && target[row, colMilieu]  % 2 == 0)
                    Assert.Fail();
            }
            m_totalScore += 5;

            //-------------------------------------------------------------------------------
            Placer3LignesPleines(target);
            target.SupprimerLignesPleines();
            // on va vérifier que les trois dernières lignes ont été supprimées
            for (int row = 0; row < target.RowCount; row++)
            {
                if (row < 3)
                {
                    if (target[row, colMilieu] != 0)
                        Assert.Fail();
                }
                else if (target[row, colMilieu] != row - 3)
                    Assert.Fail();
            }

            m_totalScore += 5;

        }
#endif

        #endregion

    }
}
