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
        private List<Technicien> listTechnicien = null;
        Materiel materielSelectionne = null;
        Technicien technicienSelectionne = null;
        public AffecterMaterielFormulaire()
        {
            InitializeComponent();
            InitialiserDGVListTechniciens();
            InitialiserDGVListMateriels();
        }

        //**************************************************************************************************
        private bool InitialiserDGVListTechniciens()
        {

           bool bRequete = false; // vrai si des techniciens ont été récupérés
           try
           {
               using (TechnicienManager technicienManager = new TechnicienManager())
               {
                   listTechnicien = technicienManager.getListeTechnicien();
               }

                foreach (Technicien technicien in listTechnicien)
                {
                    dgvListeTechniciens.Rows.Add(
                        technicien.LoginT,
                        technicien.Prenom,
                        technicien.Nom);
                }
                dgvListeTechniciens.Sort(dgvListeTechniciens.Columns[0], ListSortDirection.Ascending);
                bRequete = true;
           }
           catch
           {
           }
            return bRequete;
        }

        private bool InitialiserDGVListMateriels()
        {
            bool bRequete = false; // vrai si des techniciens ont été récupérés
            try
            {
                using (MaterielManager materielManager = new MaterielManager())
                {
                    listMateriel = materielManager.getListeMateriel();
                }

                foreach (Materiel materiel in listMateriel)
                {
                    dgvListeMateriel.Rows.Add(
                        materiel.TypeMateriel,
                        materiel.NumeroSerie);
                }
                dgvListeMateriel.Sort(dgvListeMateriel.Columns[0], ListSortDirection.Ascending);
                bRequete = true;
            }
            catch
            {
            }
            return bRequete;
        }
        //{
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
        //}
        //**************************************************************************************************
        private void listBoxSelectionMateriels_Click(object sender, EventArgs e)
        {

                
            
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
                int indiceDansListTechnicien = listTechnicien.FindIndex(s => s.LoginT == logingT);
                // recupère le technicien sélectionnée
                technicienSelectionne = listTechnicien[indiceDansListTechnicien];
            }
            if ((materielSelectionne != null) && (technicienSelectionne != null))
            {
                this.btnAttribuerMateriel.Enabled = true;
            }
        }
        //**************************************************************************************************
        private void btnAttribuerMateriel_Click(object sender, EventArgs e)
        {
            if ((materielSelectionne != null) && (technicienSelectionne != null))
            {
                using (MaterielManager materielManager = new MaterielManager())
                {
                    materielSelectionne.EtatMateriel = "enService";
                    materielManager.affectationMaterielTechnicien(ref materielSelectionne, ref technicienSelectionne);
                }
                MessageBox.Show("Materiel affecté au technicien");
            }
            else
            {
                MessageBox.Show("Sélectionner un technicien et un matériel");
            }

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

        private void dgvListeMateriel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdxLigneActuelle = e.RowIndex; // indice de la ligne sélectionnée

            if (IdxLigneActuelle >= 0)
            {
                String NumSerie = (String)dgvListeMateriel.Rows[IdxLigneActuelle].Cells[1].Value;
                int indiceDansListMateriel = listMateriel.FindIndex(leMaterielCherché => leMaterielCherché.NumeroSerie == NumSerie);
                materielSelectionne = listMateriel[indiceDansListMateriel];

            }
            if ((materielSelectionne != null) && (technicienSelectionne != null))
            {
                this.btnAttribuerMateriel.Enabled = true;
            }
        }


    }
}
