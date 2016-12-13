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
            comBoxEtatMateriel.ResetText();
        }
        //**************************************************************************************************
        private void btnAjouterMateriel_Click(object sender, EventArgs e)
        {
            Materiel materiel = new Materiel();
            using (MaterielManager materielManager = new MaterielManager())
            {
                materiel.NumeroSerie = textBoxNumSerie.Text.Trim();
                materiel.TypeMateriel = textBoxTypeMateriel.Text.Trim();
                materiel.NumeroTel = mTxtBoxNumtel.Text.Trim();
                materiel.Imei = textBoxCodeIMEI.Text.Trim();
                materiel.IdGoogle = textBoxIdGoogle.Text.Trim();
                materiel.EtatMateriel = comBoxEtatMateriel.Text.Trim();
                materiel.FkLoginE = "phenri";
    

                    try
                    {
                        if (materielManager.insertUpdateMateriel(ref materiel))
                        {
                            MessageBox.Show("Materiel ajouté avec succès");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            
            }
            
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
