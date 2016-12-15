using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibDao;

namespace Dispatcher
{
    public partial class ModifierSupprimerMaterielForm : Form
    {
        private List<Materiel> listMateriel = null;
        Materiel materielSelectionne = null;
        public ModifierSupprimerMaterielForm()
        {
            InitializeComponent();
            if (InitialiserSelectBox())
            {
                listBoxSelectionMateriels.Enabled = true;
                btnModifierMateriel.Enabled = false;
                btnSupprimerMateriel.Enabled = false;
            }
        }
        //**************************************************************************************************
        private bool InitialiserSelectBox()
        {
            bool bRequete = false; // vrai si des matériels ont été récupérés
           // TODO Remplir la listBox
            return bRequete;
        }
        //**************************************************************************************************
        private void viderChamps()
        {
            // vide les champs
            textBoxNumSerie.ResetText();
            textBoxTypeMateriel.ResetText();
            mTxtBoxNumtel.ResetText();
            textBoxCodeIMEI.ResetText();
            textBoxIdGoogle.ResetText();
            txtBoxAffectationMat.ResetText();
            comBoxEtatMatériel.SelectedItem = "";
        }
        //**************************************************************************************************
        private void RafraichirIHM()
        {
            viderChamps();
            InitialiserSelectBox();
        }
        //**************************************************************************************************
        private void btnModifierMateriel_Click(object sender, EventArgs e)
        {
          // TODO
        }
        //**************************************************************************************************
        private void btnSupprimerMateriel_Click(object sender, EventArgs e)
        {
            // TODO
        }
        //**************************************************************************************************
        private void btnResetSelectionMateriel_Click(object sender, EventArgs e)
        {
            RafraichirIHM();
        }
        //**************************************************************************************************
        private void listBoxSelectionMateriel_Click(object sender, EventArgs e)
        {
           // TODO
        }
        //**************************************************************************************************
        // permet de placer le curseur de saisie à gauche de la maskTextBox
        private void mTxtBoxNumtel_MouseClick(object sender, MouseEventArgs e)
        {
            mTxtBoxNumtel.SelectionStart = 0;
        }
    }
}
