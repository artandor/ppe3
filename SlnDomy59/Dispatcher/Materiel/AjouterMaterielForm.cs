using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using LibDao;

namespace Dispatcher
{
    public partial class AjouterMaterielForm : Form
    {
        public AjouterMaterielForm()
        {
            InitializeComponent();
            //TODO
        }
        //**************************************************************************************************
        private void btnViderChamps_Click(object sender, EventArgs e)
        {
            // vide les champs
            textBoxNumSerie.ResetText();
            textBoxTypeMateriel.ResetText();
            mTxtBoxNumtel.ResetText();
            textBoxCodeIMEI.ResetText();
            textBoxIdGoogle.ResetText();
        }
        //**************************************************************************************************
        private void btnAjouterMateriel_Click(object sender, EventArgs e)
        {
            Materiel materiel = new Materiel();

            materiel.Prenom = txtBoxPrenomClient.Text.Trim();
            materiel.Nom = txtBoxNomClient.Text.Trim();
            materiel.Adresse = txtBoxAdresse.Text.Trim();
            materiel.CompAdresse = txtBoxAdresseSuite.Text.Trim();
            materiel.Ville = txtBoxVille.Text.Trim();
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
