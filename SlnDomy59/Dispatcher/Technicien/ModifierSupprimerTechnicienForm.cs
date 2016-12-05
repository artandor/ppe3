using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibDao;
using System.IO;
using LibDao.Entites;

namespace Dispatcher
{
    public partial class ModifierSupprimerTechnicienForm : Form
    {
        private List<Technicien> listTechnicien = null;
        Technicien technicienSelectionne = null;
        Utils utils = null;

        public ModifierSupprimerTechnicienForm()
        {
            InitializeComponent();
            utils = new Utils();

            if (InitialiserDGV())
            {
                btnModifierTechnicien.Enabled = true;
                if (UtilisateurConnecte.Groupe == "Administration")
                {
                    btnSupprimerTechnicien.Enabled = true; // seul un administrateur peut supprimer un client
                }
                else
                {
                    btnSupprimerTechnicien.Enabled = false;
                }
            }

        }
        //**************************************************************************************************

        private bool InitialiserDGV()
        {
           bool bRequete = false; // vrai si des techniciens ont été récupérés
           try
           {
               using (TechnicienManager technicienManager = new TechnicienManager())
               {
                   listTechnicien = technicienManager.getListeTechnicien();
               }
                foreach (Technicien chaqueTechnicien in listTechnicien)
                {
                    dgvTechnicien.Rows.Add(
                        chaqueTechnicien.Nom,
                        chaqueTechnicien.Prenom,
                        chaqueTechnicien.LoginT
                        );
                }
                dgvTechnicien.Sort(dgvTechnicien.Columns[4], ListSortDirection.Ascending);
                bRequete = true;
           }
           catch
           {

           }
            return bRequete;
        }

        //**************************************************************************************************
        private void btnModifierTechnicien_Click(object sender, EventArgs e)
        {
            // TODO
        }
        //**************************************************************************************************
        private void btnSupprimerTechnicien_Click(object sender, EventArgs e)
        {
            // TODO
        }
        //**************************************************************************************************
        private void viderChamps()
        {
            textBoxLoginT.ResetText();
            textBoxNom.ResetText();
            textBoxPrenom.ResetText();
            txtBoxMdp.ResetText();
        }
        //**************************************************************************************************
        private void RafraichirIHM()
        {
            viderChamps();
            InitialiserDGV();
        }
        //**************************************************************************************************
        private void btnResetSelectionTechniciens_Click(object sender, EventArgs e)
        {
            RafraichirIHM();
        }

        //**************************************************************************************************        
        private void dgvTechnicien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdxLigneActuelle = e.RowIndex;

            if(IdxLigneActuelle >=0 )
            {
                String nom = (String)dgvTechnicien.Rows[IdxLigneActuelle].Cells[0].Value;
                int indiceDansListTechnicien = listTechnicien.FindIndex(leTechnicienCherché => leTechnicienCherché.Nom == nom);
                technicienSelectionne = listTechnicien[indiceDansListTechnicien];

                textBoxLoginT.Text = technicienSelectionne.LoginT;
                txtBoxMdp.Text = technicienSelectionne.PasswdT;
                textBoxNom.Text = technicienSelectionne.Nom;
                textBoxPrenom.Text = technicienSelectionne.Prenom;

            }

        }
        //**************************************************************************************************        
        private void ModifierSupprimerTechnicienForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvTechnicien.Rows[0].Selected = false;
            }
            catch { } 
        }
        //**************************************************************************************************        
    }
}
