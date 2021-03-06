﻿namespace Dispatcher
{
    partial class EnvoiSMSForm
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.btnEnvoyerMessage = new System.Windows.Forms.Button();
            this.dgvTechnicien = new System.Windows.Forms.DataGridView();
            this.ColNomTech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrenomTech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoginTech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumTelTechnicien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mTxtBoxNumtel = new System.Windows.Forms.MaskedTextBox();
            this.lblTechSelectionné = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicien)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(16, 249);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(164, 20);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message à envoyer :";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(313, 91);
            this.textBoxNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.ReadOnly = true;
            this.textBoxNom.Size = new System.Drawing.Size(132, 22);
            this.textBoxNom.TabIndex = 1;
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Location = new System.Drawing.Point(313, 138);
            this.textBoxPrenom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.ReadOnly = true;
            this.textBoxPrenom.Size = new System.Drawing.Size(132, 22);
            this.textBoxPrenom.TabIndex = 2;
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Location = new System.Drawing.Point(15, 272);
            this.richTextBoxMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(445, 219);
            this.richTextBoxMessage.TabIndex = 7;
            this.richTextBoxMessage.Text = "";
            this.richTextBoxMessage.TextChanged += new System.EventHandler(this.richTextBoxMessage_TextChanged);
            // 
            // btnEnvoyerMessage
            // 
            this.btnEnvoyerMessage.Enabled = false;
            this.btnEnvoyerMessage.Location = new System.Drawing.Point(135, 528);
            this.btnEnvoyerMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnvoyerMessage.Name = "btnEnvoyerMessage";
            this.btnEnvoyerMessage.Size = new System.Drawing.Size(220, 28);
            this.btnEnvoyerMessage.TabIndex = 8;
            this.btnEnvoyerMessage.Text = "Envoyer le message";
            this.btnEnvoyerMessage.UseVisualStyleBackColor = true;
            this.btnEnvoyerMessage.Click += new System.EventHandler(this.btnEnvoyerMessage_Click);
            // 
            // dgvTechnicien
            // 
            this.dgvTechnicien.AllowUserToAddRows = false;
            this.dgvTechnicien.AllowUserToDeleteRows = false;
            this.dgvTechnicien.AllowUserToOrderColumns = true;
            this.dgvTechnicien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTechnicien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNomTech,
            this.ColPrenomTech,
            this.ColLoginTech,
            this.NumTelTechnicien});
            this.dgvTechnicien.Location = new System.Drawing.Point(16, 15);
            this.dgvTechnicien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTechnicien.Name = "dgvTechnicien";
            this.dgvTechnicien.ReadOnly = true;
            this.dgvTechnicien.RowHeadersVisible = false;
            this.dgvTechnicien.Size = new System.Drawing.Size(277, 203);
            this.dgvTechnicien.TabIndex = 33;
            this.dgvTechnicien.TabStop = false;
            this.dgvTechnicien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTechnicien_CellClick);
            // 
            // ColNomTech
            // 
            this.ColNomTech.HeaderText = "Nom";
            this.ColNomTech.Name = "ColNomTech";
            this.ColNomTech.ReadOnly = true;
            // 
            // ColPrenomTech
            // 
            this.ColPrenomTech.HeaderText = "Prenom";
            this.ColPrenomTech.Name = "ColPrenomTech";
            this.ColPrenomTech.ReadOnly = true;
            // 
            // ColLoginTech
            // 
            this.ColLoginTech.HeaderText = "Login";
            this.ColLoginTech.Name = "ColLoginTech";
            this.ColLoginTech.ReadOnly = true;
            this.ColLoginTech.Visible = false;
            // 
            // NumTelTechnicien
            // 
            this.NumTelTechnicien.HeaderText = "NumTelTechnicien";
            this.NumTelTechnicien.Name = "NumTelTechnicien";
            this.NumTelTechnicien.ReadOnly = true;
            this.NumTelTechnicien.Visible = false;
            // 
            // mTxtBoxNumtel
            // 
            this.mTxtBoxNumtel.BeepOnError = true;
            this.mTxtBoxNumtel.Location = new System.Drawing.Point(313, 209);
            this.mTxtBoxNumtel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mTxtBoxNumtel.Mask = "0000000000";
            this.mTxtBoxNumtel.Name = "mTxtBoxNumtel";
            this.mTxtBoxNumtel.PromptChar = ' ';
            this.mTxtBoxNumtel.Size = new System.Drawing.Size(92, 22);
            this.mTxtBoxNumtel.TabIndex = 72;
            this.mTxtBoxNumtel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mTxtBoxNumtel_MouseClick);
            // 
            // lblTechSelectionné
            // 
            this.lblTechSelectionné.AutoSize = true;
            this.lblTechSelectionné.Location = new System.Drawing.Point(301, 52);
            this.lblTechSelectionné.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTechSelectionné.Name = "lblTechSelectionné";
            this.lblTechSelectionné.Size = new System.Drawing.Size(161, 17);
            this.lblTechSelectionné.TabIndex = 73;
            this.lblTechSelectionné.Text = "Technicien sélectionné :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 76;
            this.label1.Text = "Numéro destinataire :";
            // 
            // EnvoiSMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 560);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTechSelectionné);
            this.Controls.Add(this.mTxtBoxNumtel);
            this.Controls.Add(this.dgvTechnicien);
            this.Controls.Add(this.btnEnvoyerMessage);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.textBoxPrenom);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.lblMessage);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(493, 607);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(493, 607);
            this.Name = "EnvoiSMSForm";
            this.Text = "Envoi de SMS";
            this.Load += new System.EventHandler(this.EnvoiSMSForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Button btnEnvoyerMessage;
        private System.Windows.Forms.DataGridView dgvTechnicien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNomTech;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrenomTech;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoginTech;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumTelTechnicien;
        private System.Windows.Forms.MaskedTextBox mTxtBoxNumtel;
        private System.Windows.Forms.Label lblTechSelectionné;
        private System.Windows.Forms.Label label1;
    }
}