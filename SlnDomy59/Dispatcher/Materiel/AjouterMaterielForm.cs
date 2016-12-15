using System;
using System.Windows.Forms;
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
            // créer un matériel et lui affecte les champs remplis 
           // Ajoute le matériel en BDD       
           // TODO
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
