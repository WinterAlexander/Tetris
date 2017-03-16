using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppJeuTetris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJeuTetris.Tests
{
	[TestClass()]
	public class GrilleTétrisTests
	{
		private int[] m_tabNbLignesParNiveau = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, int.MaxValue };
		// --- délai en ms par niveau
		private int[] m_tabDelaiParNiveau = { 500, 450, 400, 350, 300, 225, 150, 100, 75, 60, 50, 40 };

		[TestMethod()]
		public void ProgressionNiveauTest()
		{
			int niveau = 1, niveauDepart = 0, m_rangees = 4;

			float rowsDone = m_rangees, rowsTodo = m_tabNbLignesParNiveau[niveau];

			if(niveauDepart > 0 && niveau == niveauDepart)
			{
				rowsDone += m_tabNbLignesParNiveau[niveauDepart - 1];
				rowsTodo += m_tabNbLignesParNiveau[niveauDepart - 1];
			}

			if(niveau > 0)
			{
				rowsDone -= m_tabNbLignesParNiveau[niveau - 1];
				rowsTodo -= m_tabNbLignesParNiveau[niveau - 1];
			}
			
			Assert.Fail(rowsDone + " / " + rowsTodo);
		}
	}
}