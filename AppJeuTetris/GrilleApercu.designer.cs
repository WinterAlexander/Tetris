namespace AppJeuTetris
{
    partial class GrilleApercu
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
            this.SuspendLayout();
            // 
            // GrilleApercu
            // 
            this.CellMargin = 1;
            this.CellSize = new System.Drawing.Size(34, 34);
            this.ColumnCount = 4;
            this.GridAppearance.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "GrilleApercu";
            this.RowCount = 2;
            this.RowHeader.ForeColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(153, 79);
            this.SpecialValue = 0;
            this.View = VisualArrays.enuIntView.ImageList;
            this.ResumeLayout(false);

        }

        
    }
}
