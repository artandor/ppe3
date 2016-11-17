﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LibDao;
using System.IO;

namespace Dispatcher
{
    public partial class ModifierSupprimerClientForm : Form
    {
        private List<Client> listClient = null;
        Client clientSelectionne = null;
        Utils utils = null;
        public ModifierSupprimerClientForm()
        {
            InitializeComponent();
            utils = new Utils();
            this.dgvClient.Columns["ColCivilité"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (InitialiserDGV())
            {
                btnModifierClient.Enabled = true;
                if (UtilisateurConnecte.Groupe == "Administration")
                {
                    btnSupprimerClient.Enabled = true; // seul un administrateur peut supprimer un client
                }
                else
                {
                    btnSupprimerClient.Enabled = false;
                } 
            }
        }
        //**************************************************************************************************
        //
        private bool InitialiserDGV()
        {
            bool bRequete = false; // vrai si des clients ont été récupérés
            try
            {
                using (ClientManager clientManager = new ClientManager())
                {
                    // créer un liste de clients et récupère les clients de la BDD
                    listClient = clientManager.listeClient();
                }
                foreach (Client chaqueClient in listClient)
                {
                    dgvClient.Rows.Add(
                        chaqueClient.IdClient,
                        chaqueClient.Entreprise,
                        chaqueClient.Civilite,
                        chaqueClient.Prenom,
                        chaqueClient.Nom);
                }

                // Trie par ordre alphabétique des noms
                dgvClient.Sort(dgvClient.Columns[4], ListSortDirection.Ascending);
                bRequete = true;
            }
            catch
            {
               
            }
           
            return bRequete;
        }
        //**************************************************************************************************
        private void viderChamps()
        {
            // vide les champs
            txtBoxNomEntreprise.ResetText();
            txtBoxPrenomClient.ResetText(); txtBoxNomClient.ResetText();
            txtBoxAdresse.ResetText(); txtBoxAdresse2.ResetText();
            mTxtBoxCodePostal.ResetText(); txtBoxVille.ResetText();
            mTxtBoxTelephone.ResetText(); txtBoxEmail.ResetText();
            pictureBoxImageClient.Image = null;
            dgvClient.Rows.Clear();
            mTxtBoxLatitude.ResetText(); mTxtBoxLongitude.ResetText();
        }
        //**************************************************************************************************
        private void rafraichirIHM()
        {
            viderChamps();
            InitialiserDGV();
        }
        //**************************************************************************************************
        private void btnRechargerListeClients_Click(object sender, EventArgs e)
        {
            rafraichirIHM();
        }
        //**************************************************************************************************
        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            if ((clientSelectionne != null) && (txtBoxNomClient.Text.Trim() != ""))
            {
                try
                {
                    // On récupère Tous les attributs du client pour les persister en BDD
                    using (ClientManager clientManager = new ClientManager()) // appel automatique de la methode dispose qui ferme la connexion
                    {
                        clientSelectionne.Entreprise = txtBoxNomEntreprise.Text.Trim();
                        clientSelectionne.Civilite = rdBtnMr.Checked ? "Mr" : "Mme";
                        clientSelectionne.Prenom = txtBoxPrenomClient.Text.Trim();
                        clientSelectionne.Nom = txtBoxNomClient.Text.Trim();
                        clientSelectionne.Adresse = txtBoxAdresse.Text.Trim();
                        clientSelectionne.CompAdresse = txtBoxAdresse2.Text.Trim();
                        clientSelectionne.Ville = txtBoxVille.Text.Trim();
                        clientSelectionne.CodePostal = mTxtBoxCodePostal.Text;
                        clientSelectionne.NumeroTel = mTxtBoxTelephone.Text;
                        // Test validation Email
                        String reponseWsValidEmail = "";
                        String email = txtBoxEmail.Text.Trim();
                        if (email != string.Empty)
                        {
                            ValidEmail ValidEmail = new ValidEmail(txtBoxEmail.Text.Trim(), ref reponseWsValidEmail);
                            MessageBox.Show(reponseWsValidEmail); // uniquement une indication, Le dispatcher peut modifier l'émail plus tard
                        }
                        clientSelectionne.Email = email;
                        clientSelectionne.Latitude = mTxtBoxLatitude.Text;
                        clientSelectionne.Latitude = clientSelectionne.Latitude.Replace(",", ".");
                        clientSelectionne.Longitude = mTxtBoxLongitude.Text;
                        clientSelectionne.Longitude = clientSelectionne.Longitude.Replace(",", ".");
                        // récupération image
                        if (pictureBoxImageClient.Image == null)
                            clientSelectionne.Photoent = new Byte[0];  // null
                        else
                            clientSelectionne.Photoent = utils.imageToByteArray(pictureBoxImageClient.Image);
                        clientSelectionne.EtatClient = comboBoxEtatClient.SelectedItem.ToString();
                        clientSelectionne.FkLoginE = UtilisateurConnecte.Login;
                        // On persiste les modifications
                        clientManager.insUpdateClient(clientSelectionne);                        
                        rafraichirIHM();
                        MessageBox.Show("Les modifications sont enregistrées");
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //**************************************************************************************************
        private void btnSupprimerClient_Click(object sender, EventArgs e)
        {
            if ((clientSelectionne != null) && (txtBoxNomClient.Text.Trim() != ""))
            {
                try
                {
                    using (ClientManager clientManager = new ClientManager()) // appel automatique de la methode dispose qui ferme la connexion
                    {
                        clientManager.supprimerClient(clientSelectionne);
                        MessageBox.Show("Client supprimmé avec succès");
                        rafraichirIHM();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //**************************************************************************************************
        private void btnSupprimerImage_Click(object sender, EventArgs e)
        {
            pictureBoxImageClient.Image = null;
        }
        //**************************************************************************************************
        // Appelé à deux enfroits ... En faire une méthode de classe util ?
        private void btnModifierImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                string CombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\PhotosClients");
                dlg.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath);
                dlg.Title = "Choisir le ficher image du client";
                dlg.Filter = "Fichers images| *.bmp; *.jpg; *.jpeg; *.gif; *.png"
                           + "|Fichiers bmp| *.bmp"
                           + "|Fichiers jpg/jpeg| *.jpg;*.jpeg"
                           + "|Fichiers gif| *.gif"
                           + "|Fichiers png| *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                    pictureBoxImageClient.ImageLocation = dlg.FileName;
            }
        }
        //**************************************************************************************************
        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdxLigneActuelle = e.RowIndex;

            if (IdxLigneActuelle >= 0)
            {
                int idClient = (int)dgvClient.Rows[IdxLigneActuelle].Cells[0].Value;
                int indiceDansListClient = listClient.FindIndex(s => s.IdClient == idClient);
                clientSelectionne = listClient[indiceDansListClient];
                // recupère les données du client
                txtBoxNomEntreprise.Text = clientSelectionne.Entreprise;
                txtBoxNomClient.Text = clientSelectionne.Nom;
                txtBoxPrenomClient.Text = clientSelectionne.Prenom;
                txtBoxAdresse.Text = clientSelectionne.Adresse;
                txtBoxAdresse2.Text = clientSelectionne.CompAdresse;
                mTxtBoxCodePostal.Text = clientSelectionne.CodePostal;
                txtBoxVille.Text = clientSelectionne.Ville;
                mTxtBoxTelephone.Text = clientSelectionne.NumeroTel;
                txtBoxEmail.Text = clientSelectionne.Email;

                mTxtBoxLatitude.Text = clientSelectionne.Latitude;
                mTxtBoxLongitude.Text = utils.formatageLongitude(clientSelectionne.Longitude, '.');

                String civilite = dgvClient.Rows[IdxLigneActuelle].Cells[2].Value.ToString();
                if (civilite == "Mr")
                { rdBtnMr.Checked = true; }
                else
                {
                    rdBtnMme.Checked = true;
                }

                Byte[] image = clientSelectionne.Photoent;
                if (image == null || image.Length == 0)
                {
                    pictureBoxImageClient.Image = null;
                }
                else
                {
                    pictureBoxImageClient.Image = utils.byteArrayToImage(image);
                }

                comboBoxEtatClient.SelectedItem = clientSelectionne.EtatClient;

                lblDateEnregistrementClient.Text = clientSelectionne.DateCreation.ToString("dd/MM/yyyy");
            }
        }
        //**************************************************************************************************
        // Au chargement de la page on déselectionne la première cellule du dataGridView
        // Un try catch permet d'éviter attrape une exception rarissime si la table client est vide (Row null)
        private void ModifierSupprimerClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvClient.Rows[0].Selected = false;
            }
            catch { }
        }
        //**************************************************************************************************
        // permet de placer le curseur de saisie a gauche de la maskTextBox
        private void mTxtBoxTelephone_MouseClick(object sender, MouseEventArgs e)
        {
            mTxtBoxTelephone.SelectionStart = 0;
        }

        private void mTxtBoxCodePostal_MouseClick(object sender, MouseEventArgs e)
        {
            mTxtBoxCodePostal.SelectionStart = 0;
        }
        //**************************************************************************************************
    }
}
