using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppJeuTetris
{
	/// <summary>
	/// Classe utilisée pour sa méthode statique Main afin de lancer l'application
	/// </summary>
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
        }
    }
}