namespace Dispatcher
{
    partial class AffecterMaterielFormulaire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblChoisirMateriel = new System.Windows.Forms.Label();
            this.mTxtBoxNumtel = new System.Windows.Forms.MaskedTextBox();
            this.lblNumeroTel = new System.Windows.Forms.Label();
            this.lblChoixTechnicien = new System.Windows.Forms.Label();
            this.dgvListeTechniciens = new System.Windows.Forms.DataGridView();
            this.ColLoginT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrenomTech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNomTech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAttribuerMateriel = new System.Windows.Forms.Button();
            this.dgvListeMateriel = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeTechniciens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeMateriel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChoisirMateriel
            // 
            this.lblChoisirMateriel.AutoSize = true;
            this.lblChoisirMateriel.Location = new System.Drawing.Point(12, 9);
            this.lblChoisirMateriel.Name = "lblChoisirMateriel";
            this.lblChoisirMateriel.Size = new System.Drawing.Size(144, 13);
            this.lblChoisirMateriel.TabIndex = 0;
            this.lblChoisirMateriel.Text = "Choisir le matériel à attribuer :\r\n";
            // 
            // mTxtBoxNumtel
            // 
            this.mTxtBoxNumtel.BeepOnError = true;
            this.mTxtBoxNumtel.Location = new System.Drawing.Point(15, 283);
            this.mTxtBoxNumtel.Mask = "0000000000";
            this.mTxtBoxNumtel.Name = "mTxtBoxNumtel";
            this.mTxtBoxNumtel.PromptChar = ' ';
            this.mTxtBoxNumtel.Size = new System.Drawing.Size(70, 20);
            this.mTxtBoxNumtel.TabIndex = 77;
            this.mTxtBoxNumtel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mTxtBoxNumtel_MouseClick);
            // 
            // lblNumeroTel
            // 
            this.lblNumeroTel.AutoSize = true;
            this.lblNumeroTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroTel.Location = new System.Drawing.Point(12, 264);
            this.lblNumeroTel.Name = "lblNumeroTel";
            this.lblNumeroTel.Size = new System.Drawing.Size(144, 16);
            this.lblNumeroTel.TabIndex = 76;
            this.lblNumeroTel.Text = "Numéro de téléphone :";
            // 
            // lblChoixTechnicien
            // 
            this.lblChoixTechnicien.AutoSize = true;
            this.lblChoixTechnicien.Location = new System.Drawing.Point(282, 9);
            this.lblChoixTechnicien.Name = "lblChoixTechnicien";
            this.lblChoixTechnicien.Size = new System.Drawing.Size(209, 13);
            this.lblChoixTechnicien.TabIndex = 78;
            this.lblChoixTechnicien.Text = "Choisir le technicien dépourvu de matériel :\r\n";
            // 
            // dgvListeTechniciens
            // 
            this.dgvListeTechniciens.AllowUserToAddRows = false;
            this.dgvListeTechniciens.AllowUserToDeleteRows = false;
            this.dgvListeTechniciens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListeTechniciens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListeTechniciens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLoginT,
            this.ColPrenomTech,
            this.ColNomTech});
            this.dgvListeTechniciens.Location = new System.Drawing.Point(285, 37);
            this.dgvListeTechniciens.MultiSelect = false;
            this.dgvListeTechniciens.Name = "dgvListeTechniciens";
            this.dgvListeTechniciens.ReadOnly = true;
            this.dgvListeTechniciens.RowHeadersVisible = false;
            this.dgvListeTechniciens.Size = new System.Drawing.Size(240, 121);
            this.dgvListeTechniciens.TabIndex = 79;
            this.dgvListeTechniciens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListeTechniciens_CellClick);
            // 
            // ColLoginT
            // 
            this.ColLoginT.HeaderText = "LoginT";
            this.ColLoginT.Name = "ColLoginT";
            this.ColLoginT.ReadOnly = true;
            this.ColLoginT.Visible = false;
            // 
            // ColPrenomTech
            // 
            this.ColPrenomTech.HeaderText = "Prénom";
            this.ColPrenomTech.MinimumWidth = 100;
            this.ColPrenomTech.Name = "ColPrenomTech";
            this.ColPrenomTech.ReadOnly = true;
            // 
            // ColNomTech
            // 
            this.ColNomTech.HeaderText = "Nom";
            this.ColNomTech.MinimumWidth = 100;
            this.ColNomTech.Name = "ColNomTech";
            this.ColNomTech.ReadOnly = true;
            // 
            // btnAttribuerMateriel
            // 
            this.btnAttribuerMateriel.Location = new System.Drawing.Point(327, 222);
            this.btnAttribuerMateriel.Name = "btnAttribuerMateriel";
            this.btnAttribuerMateriel.Size = new System.Drawing.Size(164, 52);
            this.btnAttribuerMateriel.TabIndex = 80;
            this.btnAttribuerMateriel.Text = "Assigner matériel";
            this.btnAttribuerMateriel.UseVisualStyleBackColor = true;
            this.btnAttribuerMateriel.Click += new System.EventHandler(this.btnAttribuerMateriel_Click);
            // 
            // dgvListeMateriel
            // 
            this.dgvListeMateriel.AllowUserToAddRows = false;
            this.dgvListeMateriel.AllowUserToDeleteRows = false;
            this.dgvListeMateriel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListeMateriel.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvListeMateriel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListeMateriel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.NumSerie});
            this.dgvListeMateriel.Location = new System.Drawing.Point(15, 37);
            this.dgvListeMateriel.Name = "dgvListeMateriel";
            this.dgvListeMateriel.ReadOnly = true;
            this.dgvListeMateriel.RowHeadersVisible = false;
            this.dgvListeMateriel.RowHeadersWidth = 40;
            this.dgvListeMateriel.Size = new System.Drawing.Size(240, 121);
            this.dgvListeMateriel.TabIndex = 81;
            this.dgvListeMateriel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListeMateriel_CellClick);
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // NumSerie
            // 
            this.NumSerie.HeaderText = "N° Série";
            this.NumSerie.Name = "NumSerie";
            this.NumSerie.ReadOnly = true;
            // 
            // AffecterMaterielFormulaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 314);
            this.Controls.Add(this.dgvListeMateriel);
            this.Controls.Add(this.btnAttribuerMateriel);
            this.Controls.Add(this.dgvListeTechniciens);
            this.Controls.Add(this.lblChoixTechnicien);
            this.Controls.Add(this.mTxtBoxNumtel);
            this.Controls.Add(this.lblNumeroTel);
            this.Controls.Add(this.lblChoisirMateriel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(581, 353);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(581, 353);
            this.Name = "AffecterMaterielFormulaire";
            this.Text = "Attribuer materiel à un technicien";
            this.Load += new System.EventHandler(this.AffecterMaterielFormulaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeTechniciens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeMateriel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoisirMateriel;
        private System.Windows.Forms.MaskedTextBox mTxtBoxNumtel;
        private System.Windows.Forms.Label lblNumeroTel;
        private System.Windows.Forms.Label lblChoixTechnicien;
        private System.Windows.Forms.DataGridView dgvListeTechniciens;
        private System.Windows.Forms.Button btnAttribuerMateriel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoginT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrenomTech;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNomTech;
        private System.Windows.Forms.DataGridView dgvListeMateriel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumSerie;
    }
}