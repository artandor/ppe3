namespace Dispatcher
{
    partial class DispatcherForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripDispatcher = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemClient = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIntervention = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItemIntervention = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItemIntervention = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aperçuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envoiSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionMatérielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterMaterielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierMatérielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affecterMaterielAUnTechnicienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TechnicienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAjoutTechnicienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierTechnicienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDispatcher.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripDispatcher
            // 
            this.menuStripDispatcher.Enabled = false;
            this.menuStripDispatcher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClient,
            this.toolStripMenuItemIntervention,
            this.envoiSMSToolStripMenuItem,
            this.gestionMatérielToolStripMenuItem,
            this.TechnicienToolStripMenuItem});
            this.menuStripDispatcher.Location = new System.Drawing.Point(0, 0);
            this.menuStripDispatcher.Name = "menuStripDispatcher";
            this.menuStripDispatcher.Size = new System.Drawing.Size(804, 24);
            this.menuStripDispatcher.TabIndex = 0;
            this.menuStripDispatcher.Text = "menuStripDispatcher";
            // 
            // toolStripMenuItemClient
            // 
            this.toolStripMenuItemClient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterClientToolStripMenuItem,
            this.modifierClientToolStripMenuItem});
            this.toolStripMenuItemClient.Name = "toolStripMenuItemClient";
            this.toolStripMenuItemClient.Size = new System.Drawing.Size(93, 20);
            this.toolStripMenuItemClient.Text = "Gestion Client";
            // 
            // ajouterClientToolStripMenuItem
            // 
            this.ajouterClientToolStripMenuItem.Name = "ajouterClientToolStripMenuItem";
            this.ajouterClientToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ajouterClientToolStripMenuItem.Text = "Ajouter";
            this.ajouterClientToolStripMenuItem.Click += new System.EventHandler(this.ajouterClientToolStripMenuItem_Click);
            // 
            // modifierClientToolStripMenuItem
            // 
            this.modifierClientToolStripMenuItem.Name = "modifierClientToolStripMenuItem";
            this.modifierClientToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.modifierClientToolStripMenuItem.Text = "Modifier/Supprimer";
            this.modifierClientToolStripMenuItem.Click += new System.EventHandler(this.modifierClientToolStripMenuItem_Click);
            // 
            // toolStripMenuItemIntervention
            // 
            this.toolStripMenuItemIntervention.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItemIntervention,
            this.supprimerToolStripMenuItemIntervention,
            this.modifierToolStripMenuItem,
            this.aperçuToolStripMenuItem});
            this.toolStripMenuItemIntervention.Enabled = false;
            this.toolStripMenuItemIntervention.Name = "toolStripMenuItemIntervention";
            this.toolStripMenuItemIntervention.Size = new System.Drawing.Size(134, 20);
            this.toolStripMenuItemIntervention.Text = "Gestion  interventions";
            // 
            // ajouterToolStripMenuItemIntervention
            // 
            this.ajouterToolStripMenuItemIntervention.Enabled = false;
            this.ajouterToolStripMenuItemIntervention.Name = "ajouterToolStripMenuItemIntervention";
            this.ajouterToolStripMenuItemIntervention.Size = new System.Drawing.Size(129, 22);
            this.ajouterToolStripMenuItemIntervention.Text = "Ajouter";
         
            // 
            // supprimerToolStripMenuItemIntervention
            // 
            this.supprimerToolStripMenuItemIntervention.Enabled = false;
            this.supprimerToolStripMenuItemIntervention.Name = "supprimerToolStripMenuItemIntervention";
            this.supprimerToolStripMenuItemIntervention.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItemIntervention.Text = "Supprimer";
           
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Enabled = false;
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
           
            // 
            // aperçuToolStripMenuItem
            // 
            this.aperçuToolStripMenuItem.Enabled = false;
            this.aperçuToolStripMenuItem.Name = "aperçuToolStripMenuItem";
            this.aperçuToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aperçuToolStripMenuItem.Text = "Aperçu";
           
            // 
            // envoiSMSToolStripMenuItem
            // 
            this.envoiSMSToolStripMenuItem.Enabled = false;
            this.envoiSMSToolStripMenuItem.Name = "envoiSMSToolStripMenuItem";
            this.envoiSMSToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.envoiSMSToolStripMenuItem.Text = "Envoi SMS";
          
            // 
            // gestionMatérielToolStripMenuItem
            // 
            this.gestionMatérielToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterMaterielToolStripMenuItem,
            this.modifierMatérielToolStripMenuItem,
            this.affecterMaterielAUnTechnicienToolStripMenuItem});
            this.gestionMatérielToolStripMenuItem.Enabled = false;
            this.gestionMatérielToolStripMenuItem.Name = "gestionMatérielToolStripMenuItem";
            this.gestionMatérielToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.gestionMatérielToolStripMenuItem.Text = "Gestion Matériel";
            // 
            // ajouterMaterielToolStripMenuItem
            // 
            this.ajouterMaterielToolStripMenuItem.Name = "ajouterMaterielToolStripMenuItem";
            this.ajouterMaterielToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ajouterMaterielToolStripMenuItem.Text = "Ajouter";
           
            // 
            // modifierMatérielToolStripMenuItem
            // 
            this.modifierMatérielToolStripMenuItem.Name = "modifierMatérielToolStripMenuItem";
            this.modifierMatérielToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.modifierMatérielToolStripMenuItem.Text = "Modifier";
           
            // 
            // affecterMaterielAUnTechnicienToolStripMenuItem
            // 
            this.affecterMaterielAUnTechnicienToolStripMenuItem.Name = "affecterMaterielAUnTechnicienToolStripMenuItem";
            this.affecterMaterielAUnTechnicienToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.affecterMaterielAUnTechnicienToolStripMenuItem.Text = "Affecter matériel";
           
            // 
            // TechnicienToolStripMenuItem
            // 
            this.TechnicienToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAjoutTechnicienToolStripMenuItem,
            this.modifierTechnicienToolStripMenuItem});
            this.TechnicienToolStripMenuItem.Enabled = false;
            this.TechnicienToolStripMenuItem.Name = "TechnicienToolStripMenuItem";
            this.TechnicienToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.TechnicienToolStripMenuItem.Text = "Gestion techniciens";
            // 
            // mAjoutTechnicienToolStripMenuItem
            // 
            this.mAjoutTechnicienToolStripMenuItem.Name = "mAjoutTechnicienToolStripMenuItem";
            this.mAjoutTechnicienToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.mAjoutTechnicienToolStripMenuItem.Text = "Ajouter technicien";
           
            // 
            // modifierTechnicienToolStripMenuItem
            // 
            this.modifierTechnicienToolStripMenuItem.Name = "modifierTechnicienToolStripMenuItem";
            this.modifierTechnicienToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.modifierTechnicienToolStripMenuItem.Text = "Modifier";
           
            // 
            // DispatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 571);
            this.Controls.Add(this.menuStripDispatcher);
            this.MainMenuStrip = this.menuStripDispatcher;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 610);
            this.MinimumSize = new System.Drawing.Size(820, 610);
            this.Name = "DispatcherForm";
            this.Text = "Application PPE3";
            this.menuStripDispatcher.ResumeLayout(false);
            this.menuStripDispatcher.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripDispatcher;
        private System.Windows.Forms.ToolStripMenuItem TechnicienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mAjoutTechnicienToolStripMenuItem;
        //private System.Windows.Forms.StatusStrip statusStripBDD;
        private System.Windows.Forms.ToolStripMenuItem envoiSMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClient;
        private System.Windows.Forms.ToolStripMenuItem ajouterClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionMatérielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterMaterielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierMatérielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affecterMaterielAUnTechnicienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIntervention;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItemIntervention;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItemIntervention;
        private System.Windows.Forms.ToolStripMenuItem modifierTechnicienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aperçuToolStripMenuItem;
    }
}

