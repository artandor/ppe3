using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using LibDao;

namespace Dispatcher
{
    public partial class AjouterTechnicienForm : Form
    {
        public AjouterTechnicienForm()
        {
            InitializeComponent();
        }

        //**************************************************************************************************
        private void btnAjouterTechnicien_Click(object sender, EventArgs e)
        {
            //TODO
            Technicien technicien = new Technicien();
            using (TechnicienManager technicienManager = new TechnicienManager())
            {
                technicien.Nom = textBoxNom.Text.Trim();
                technicien.Prenom = textBoxPrenom.Text.Trim();
                technicien.LoginT = textBoxLoginT.Text.Trim();
                technicien.PasswdT = txtBoxMdp.Text.Trim();

                //A modifier le jour où la fonction ajouterMateriel est disponible
                //technicien.FkIdMateriel = ;

                try
                {
                    if (technicienManager.insUpdateTechnicien(technicien))
                    {
                        MessageBox.Show("Technicien ajouté avec succès");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //**************************************************************************************************
        private void btnViderChamps_Click(object sender, EventArgs e)
        {
            //TODO
            textBoxNom.ResetText();
            textBoxPrenom.ResetText();
            textBoxLoginT.ResetText();
            txtBoxMdp.ResetText();
        }
        //**************************************************************************************************
    }
}
