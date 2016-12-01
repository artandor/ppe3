using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LibDao;
//using Dispatcher.refWsSms;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Configuration;

namespace Dispatcher
{
    public partial class EnvoiSMSForm : Form
    {
       
        // A Compléter
       
        String clePublicDuCerticatChiffrement = ""; // cle sera lue dans le fichier de configuration de l'application
        String passwordEnvoiSMS = ""; // mot de passe commun à tous et lu dans le fichier de configuration
        //**************************************************************************************************
        // le constructeur
        public EnvoiSMSForm()
        {
            InitializeComponent();

        }
        //**************************************************************************************************
        private void InitialiserDGV()
        {
            
        }
        //***********************************************************************************************
        private void viderChamps()
        {
            // vide les champs
            textBoxNom.ResetText();
            textBoxPrenom.ResetText();
            mTxtBoxNumtel.ResetText();
            btnEnvoyerMessage.Enabled = false;
        }
        //***********************************************************************************************
       
        // Cette methode est appelée par RemoteCertificateValidationDelegate
        // pour vérifier la validité du certificat type X509
        bool demandeDeValidationDuCertificat(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            // vérification par rapport au contenu de la clé publique du certificat
            // le certificat a été installé sur le serveur web
            if (certificate.GetPublicKeyString() == clePublicDuCerticatChiffrement)
            {
                return true; // certificat valide, le site distant est bien celui voulu
            }
            else
            {
                return false; // certificat de la transaction non valide
            }
        }

        //**************************************************************************************************
        // envoi de la requête vers le web service en https https://domy59efficom.ddns.net/WebServiceSms.asmx?WSDL
        // l'utilisateur avec son login est envoyé dans l'entête
        // le corps du sms est envoyé dans le corps de la requête
        // En production le WebSeervice ne devra pas fournir ses metadonnées par sécurité
        private void btnEnvoyerMessage_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de joindre le serveur d'envoi SMS"); 
            }
        }
       
        //***********************************************************************************************
        private void dgvTechnicien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdxLigneActuelle = e.RowIndex;
            Materiel materiel = new Materiel();
            viderChamps();

            if (IdxLigneActuelle >= 0)
            {
               // récupération des informations technicien matériel affecté etc...
            }
        }
        //**************************************************************************************************
        // permet de placer le curseur de saisie à gauche de la maskTextBox
        private void mTxtBoxNumtel_MouseClick(object sender, MouseEventArgs e)
        {
            mTxtBoxNumtel.SelectionStart = 0;
        }
        //**************************************************************************************************
        // Au chargement de la page on déselectionne la première cellule du dataGridView
        // Un try catch permet d'éviter attrape une exception rarissime si la table technicien est vide (Row null)
        private void EnvoiSMSForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvTechnicien.Rows[0].Selected = false;
            }
            catch { }
        }
        //**************************************************************************************************
        // validation du bouton envoyer sms s'il y a du texte qui est entré dans le textbox
        private void richTextBoxMessage_TextChanged(object sender, EventArgs e)
        {
            if (mTxtBoxNumtel.Text != String.Empty)
            {
                btnEnvoyerMessage.Enabled = true;
            }
        }
        //**************************************************************************************************
    }
}

