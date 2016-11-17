﻿using System;
using System.Windows.Forms;
using System.IO;
using LibDao;

namespace Dispatcher
{
    public partial class AjouterClientForm : Form
    {
        public AjouterClientForm()
        {
            InitializeComponent();
            comBoxCivilite.SelectedItem = "Mr";
        }
    //**************************************************************************************************
        private void btnViderChamps_Click(object sender, EventArgs e)
        {
            txtBoxNomEntreprise.ResetText();
            txtBoxNomClient.ResetText();
            txtBoxPrenomClient.ResetText();
            mTxtBoxTelephone.ResetText();
            txtBoxAdresse.ResetText();
            txtBoxVille.ResetText();
            txtBoxAdresseSuite.ResetText();
            mTxtBoxCodePostal.ResetText();
            txtBoxEmail.ResetText();
            pictureBoxImageClient.Image = null;
        }
        //**************************************************************************************************
        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            // créer un client et lui affecte les champs remplis 
            Client client = new Client();
            using (ClientManager clientManager = new ClientManager()) // appel automatique de la methode dispose qui ferme la connexion
            {
                client.Entreprise = txtBoxNomEntreprise.Text.Trim();
                client.Civilite = comBoxCivilite.SelectedItem.ToString();
                client.Prenom = txtBoxPrenomClient.Text.Trim() ;
                client.Nom = txtBoxNomClient.Text.Trim();
                client.Adresse = txtBoxAdresse.Text.Trim();
                client.CompAdresse = txtBoxAdresseSuite.Text.Trim();
                client.Ville = txtBoxVille.Text.Trim();
                client.CodePostal = mTxtBoxCodePostal.Text;
                client.NumeroTel = mTxtBoxTelephone.Text;
                // Test validation Email
                String reponseWsValidEmail = "";
                String email = txtBoxEmail.Text.Trim();
                if(email!=string.Empty)
                {
                    ValidEmail ValidEmail = new ValidEmail(txtBoxEmail.Text.Trim(), ref reponseWsValidEmail);
                    MessageBox.Show(reponseWsValidEmail); // uniquement une indication, Le dispatcher peut modifier l'émail plus tard
                }
                client.Email = email;
                Byte[] image;
                // récupération de l'image chargée
                if (pictureBoxImageClient.Image != null)
                {
                    try
                    {
                        FileStream fs = new FileStream(pictureBoxImageClient.ImageLocation, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        image = br.ReadBytes((int)fs.Length);
                        client.Photoent = (Byte[])image;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    client.Photoent = new Byte[0];  // Pas d'image du tout
                }
                client.EtatClient = "valide"; // Le client est valide à l'inscription
                client.FkLoginE = UtilisateurConnecte.Login;
                try
                {
                    if(clientManager.insUpdateClient(client))
                    {
                        MessageBox.Show("Client ajouté avec succès");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
        }
        //**************************************************************************************************
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
        // permet de placer le curseur de saisie a gauche de la maskTextBox
        private void mTxtBoxTelephone_MouseClick(object sender, MouseEventArgs e)
        {
            mTxtBoxTelephone.SelectionStart = 0;
        }

        private void mTxtBoxCodePostal_Click(object sender, EventArgs e)
        {
            mTxtBoxCodePostal.SelectionStart = 0;
        }

        //**************************************************************************************************
    }
}
