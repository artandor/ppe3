using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibDao;
using System.Globalization;

namespace Dispatcher
{
    public partial class DispatcherForm : Form
    {
        const bool VIA_ACTIVE_DIRECTORY = false; // true si application fonctionne sur AD,ATTENTION modification non automatique de la connexion à la BDD
        String VersionProg = "2.2";
        String VersionSql = "1.2";

        bool connexionBddValide = false; // pour tester si on a détecté une connexion bdd au lancement de l'application
        List<Client> listClients = null;
        Client clientSelectionne = null;
        //**************************************************************************************************
        // Constructeur
        public DispatcherForm()
        {
            InitializeComponent();
            menuStripDispatcher.Enabled = true;
            this.Text = this.Text + "  " + "Version Prog : " + VersionProg + "  Version SQL : " + VersionSql;
            //--------------------------------------------------------------------------------------------
        }
        //**************************************************************************************************
        // vérifie si la base de donnée répond
         void testValideConnexionBdd()
        {
            // test connection BDD
            try
            {
                ConnexionSqlServer connexionSqlServer = new ConnexionSqlServer();
                if (connexionSqlServer.Connexion != null)
                {
                    connexionBddValide = true;
                }
            }
            catch
            {
                connexionBddValide = false;
            }
        }

        //**************************************************************************************************
        // GESTION DES MENUS 
        //**************************************************************************************************

        //**************************************************************************************************
        // Actions Menu Item Client
        //**************************************************************************************************
        private void ajouterClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterClientForm formulaireAjouterClient = new AjouterClientForm();
            //formulaire modal
            formulaireAjouterClient.ShowDialog();
        }
        //**************************************************************************************************
        private void modifierClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierSupprimerClientForm formulaireModifierSupprimerClient = new ModifierSupprimerClientForm();
            formulaireModifierSupprimerClient.ShowDialog();
        }

        //**************************************************************************************************
        // Actions Menu Item Technicien
        //**************************************************************************************************
       
        private void mAjoutTechnicienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterTechnicienForm formulaireAjouterTechnicien = new AjouterTechnicienForm();
            formulaireAjouterTechnicien.ShowDialog();
        }
        //**************************************************************************************************
        private void modifierTechnicienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierSupprimerTechnicienForm formulaireModifierSupprimerTechnicien = new ModifierSupprimerTechnicienForm();
            formulaireModifierSupprimerTechnicien.ShowDialog();
        }
       
        //**************************************************************************************************
        // Actions Menu Item SMS
        //**************************************************************************************************
       
        private void envoiSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnvoiSMSForm formulaireEnvoiSms = new EnvoiSMSForm();
            formulaireEnvoiSms.ShowDialog();
        }

        //**************************************************************************************************
        //**************************************************************************************************
        // Actions Menu Item Matériel
        //**************************************************************************************************
        //**************************************************************************************************
        private void ajouterMaterielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjouterMaterielForm formulaireAjouterMateriel = new AjouterMaterielForm();
            formulaireAjouterMateriel.ShowDialog();
        }
        //**************************************************************************************************
        private void modifierMatérielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierSupprimerMaterielForm formulaireModifierSupprimerMateriel = new ModifierSupprimerMaterielForm();
            formulaireModifierSupprimerMateriel.ShowDialog();
        }
        //**************************************************************************************************
        private void affecterMaterielAUnTechnicienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AffecterMaterielFormulaire affecterMaterielFormulaire = new AffecterMaterielFormulaire();
            affecterMaterielFormulaire.ShowDialog();
        }
        //**************************************************************************************************
        //**************************************************************************************************
        // Actions Menu Item Intervention
        //**************************************************************************************************
        //**************************************************************************************************
        private void ajouterToolStripMenuItemIntervention_Click(object sender, EventArgs e)
        {
            AjouterPlanningForm formulaireAjouterPlanning = new AjouterPlanningForm();
            formulaireAjouterPlanning.ShowDialog();
        }
        //**************************************************************************************************
        private void supprimerToolStripMenuItemIntervention_Click(object sender, EventArgs e)
        {
            SupprimerInterventionForm formulaireSupprimerPlanning = new SupprimerInterventionForm();
            formulaireSupprimerPlanning.ShowDialog();
        }
        //**************************************************************************************************
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierInterventionForm modifierInterventionForm = new ModifierInterventionForm();
            modifierInterventionForm.ShowDialog();
        }
        //**************************************************************************************************
    }
}
