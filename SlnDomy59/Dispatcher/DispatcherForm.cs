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
        String VersionProg = "2.0";
        String VersionSql = "1.0";

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
    }
}
