namespace AppJeuTetris
{
    partial class GrilleTétris
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
            if (disposing && (components != null))
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrilleTétris));
			this.imlPièces = new System.Windows.Forms.ImageList(this.components);
			this.tmrDrop = new System.Windows.Forms.Timer(this.components);
			this.tmrKeyRepeatLeft = new System.Windows.Forms.Timer(this.components);
			this.tmrKeyRepeatRight = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// imlPièces
			// 
			this.imlPièces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlPièces.ImageStream")));
			this.imlPièces.TransparentColor = System.Drawing.Color.Transparent;
			this.imlPièces.Images.SetKeyName(0, "CellVide.bmp");
			this.imlPièces.Images.SetKeyName(1, "CellBleu.bmp");
			this.imlPièces.Images.SetKeyName(2, "CellBleuCiel.bmp");
			this.imlPièces.Images.SetKeyName(3, "CellJaune.bmp");
			this.imlPièces.Images.SetKeyName(4, "CellLime.bmp");
			this.imlPièces.Images.SetKeyName(5, "CellMauve.bmp");
			this.imlPièces.Images.SetKeyName(6, "CellOrange.bmp");
			this.imlPièces.Images.SetKeyName(7, "CellRouge.bmp");
			this.imlPièces.Images.SetKeyName(8, "CellGrise.bmp");
			// 
			// tmrDrop
			// 
			this.tmrDrop.Interval = 500;
			this.tmrDrop.Tick += new System.EventHandler(this.tmrDrop_Tick);
			// 
			// tmrKeyRepeatLeft
			// 
			this.tmrKeyRepeatLeft.Interval = 55;
			this.tmrKeyRepeatLeft.Tick += new System.EventHandler(this.tmrKeyRepeatLeft_Tick);
			// 
			// tmrKeyRepeatRight
			// 
			this.tmrKeyRepeatRight.Interval = 55;
			this.tmrKeyRepeatRight.Tick += new System.EventHandler(this.tmrKeyRepeatRight_Tick);
			// 
			// GrilleTétris
			// 
			this.CellMargin = 0;
			this.CellSize = new System.Drawing.Size(35, 35);
			this.ColumnCount = 9;
			this.EnabledAppearance.ImageList = this.imlPièces;
			this.EnabledAppearance.Style = VisualArrays.enuBkgStyle.None;
			this.Name = "GrilleTétris";
			this.RowCount = 9;
			this.RowHeader.ForeColor = System.Drawing.Color.White;
			this.Size = new System.Drawing.Size(337, 337);
			this.View = VisualArrays.enuIntView.ImageList;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrilleTétris_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GrilleTétris_KeyUp);
			this.ResumeLayout(false);

        }

        

        private System.Windows.Forms.ImageList imlPièces;
        public System.Windows.Forms.Timer tmrDrop;
        private System.Windows.Forms.Timer tmrKeyRepeatLeft;
        private System.Windows.Forms.Timer tmrKeyRepeatRight;
	}
}
