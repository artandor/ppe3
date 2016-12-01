using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibDao;

namespace Dispatcher
{
    public partial class ModifierSupprimerTechnicienForm : Form
    {

        public ModifierSupprimerTechnicienForm()
        {
            // TODO
            InitializeComponent();
        }
        //**************************************************************************************************

        private bool InitialiserDGV()
        {
            bool bRequete = false; // vrai si des techniciens ont été récupérés
          // TODO
           
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
            // TODO
        }
        //**************************************************************************************************
        private void RafraichirIHM()
        {
            // TODO
        }
        //**************************************************************************************************
        private void btnResetSelectionTechnciens_Click(object sender, EventArgs e)
        {
            RafraichirIHM();
        }

        //**************************************************************************************************        
        private void dgvTechnicien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO
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
