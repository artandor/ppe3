using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LibDao;

namespace Dispatcher
{
    public partial class AffecterMaterielFormulaire : Form
    {
        private List<Materiel> listMateriel = null;
        private List<Technicien> listTechniciens = null;
        Materiel materielSelectionne = null;
        Technicien technicienSelectionne = null;
        public AffecterMaterielFormulaire()
        {
            InitializeComponent();
            InitialiserDGVListBox();
        }

        //**************************************************************************************************
        private void InitialiserDGVListBox()
        {
            // Initialisation
            //TODO

            // Récupération de la liste des techniciens et des matériels
           //TODO

            // Création de la liste des Id des matériels dispo (au départ on suppose tout est disponible)
           //TODO

            // On rempli le dataGridView des Techniciens sans matériels et
            // on retire de la liste des Id des matériels dispo 
            // les id des matériels affectés à des techniciens
           // TODO

            // Trier par ordre alphabétique des noms le dataGridView
          // TODO

            // clear de la listBox et des textBox
           // TODO

            // On affiche dans la listBox que les matériels trouvé dispo
           // TODO
        }
        //**************************************************************************************************
        private void listBoxSelectionMateriels_Click(object sender, EventArgs e)
        {
           // TODO
        }
        //**************************************************************************************************
        private void dgvListeTechniciens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdxLigneActuelle = e.RowIndex; // indice de la ligne sélectionnée

            if (IdxLigneActuelle >= 0)
            {
                // loginT est caché dans la première colonne du dgv
                String logingT = (String)dgvListeTechniciens.Rows[IdxLigneActuelle].Cells[0].Value;
                // on récupère l'indice dans la liste des techniciend de celui qui est sélectionnée
                int indiceDansListTechnicien = listTechniciens.FindIndex(s => s.LoginT == logingT);
                // recupère le technicien sélectionnée
                technicienSelectionne = listTechniciens[indiceDansListTechnicien];
            }
            if ((materielSelectionne != null) && (technicienSelectionne != null))
            {
                this.btnAttribuerMateriel.Enabled = true;
            }
        }
        //**************************************************************************************************
        private void btnAttribuerMateriel_Click(object sender, EventArgs e)
        {
           // TODO  Attribuer un matériel à un technicien
        }
        //**************************************************************************************************
        // Au chargement de la page on déselectionne la première cellule du dataGridView
        private void AffecterMaterielFormulaire_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListeTechniciens.Rows[0].Selected = false;
            }
            catch { }
        }
        //**************************************************************************************************
        // permet de placer le curseur de saisie a gauche de la maskTextBox
        private void mTxtBoxNumtel_MouseClick(object sender, MouseEventArgs e)
        {
            mTxtBoxNumtel.SelectionStart = 0;
        }
        //**************************************************************************************************
    }
}
