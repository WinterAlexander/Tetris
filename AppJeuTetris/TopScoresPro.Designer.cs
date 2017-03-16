namespace AppJeuTetris
{
	partial class TopScoresPro
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.shapeSprite1 = new VisualArrays.ShapeSprite();
			this.SuspendLayout();
			// 
			// shapeSprite1
			// 
			this.shapeSprite1.Name = null;
			this.shapeSprite1.Visible = false;
			// 
			// TopScoresPro
			// 
			this.AddressView = VisualArrays.enuAddressView.Mode1D;
			this.BackColor = System.Drawing.Color.Black;
			this.EnabledAppearance.BackgroundColor = System.Drawing.Color.Maroon;
			this.CellSize = new System.Drawing.Size(267, 26);
			this.ColumnCount = 1;
			this.Enabled = false;
			this.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GridAppearance.LineSize = 0;
			this.Name = "TopScoresPro";
			this.SelectionAppearance.Color = System.Drawing.Color.Lime;
			this.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.SelectionAppearance.Padding = new System.Windows.Forms.Padding(2);
			this.SelectionAppearance.PenWidth = 5;
			this.Sprites.AddRange(new VisualArrays.Sprite[] {
			this.shapeSprite1});
			this.ResumeLayout(false);

		}

		

		private VisualArrays.ShapeSprite shapeSprite1;
	}
}
