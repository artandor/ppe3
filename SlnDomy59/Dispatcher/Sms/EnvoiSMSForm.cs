using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LibDao;
using Dispatcher.refWsSms;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Configuration;

namespace Dispatcher
{
    public partial class EnvoiSMSForm : Form
    {
        private List<Technicien> listTechnicien = null;
        Technicien technicienSelectionne = null;

        // le constructeur
        public EnvoiSMSForm()
        {
            InitializeComponent();
            InitialiserDGV();

        }
        //**************************************************************************************************
        private void InitialiserDGV()
        {
            bool bRequete = false; // vrai si des techniciens ont été récupérés
            try
            {
                using (TechnicienManager technicienManager = new TechnicienManager())
                {
                    listTechnicien = technicienManager.getListeTechnicien();
                }

                foreach (Technicien technicien in listTechnicien)
                {
                    dgvTechnicien.Rows.Add(
                        technicien.Nom,
                        technicien.Prenom);
                }
                dgvTechnicien.Sort(dgvTechnicien.Columns[0], ListSortDirection.Ascending);
                bRequete = true;
            }
            catch
            {
            }
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

        WebServiceSms proxy = null;
        Sms sms = null;
        //*******************************************************************************************************
        // Cette methode est appelée par le delegue RemoteCertificateValidationDelegate
        // vérification de la validité du certificat
        //*******************************************************************************************************
        bool demandeDeValidationDuCertificat(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {

            if (// Vérification de la clé publique
                (certificate.GetPublicKeyString() == @"3081890281810088DB0C93EF592B89C0177DE0B6210B447464982EBE9A734C2D7BB651B434F086776C7A79F28ECB140E7BB50F011AD0C0D264C439D662C69E723115605674B1ABB886CAE64A624FC513169A95550F954FAE5625B2C455AA306A64728273AB35E36B65A118AA5D02097B4489A9AE3CB77DF2D8E0080B8914B269BCDB58411476BB0203010001")
                // Vérification du nom du certificat
                && (certificate.GetName() == "CN=WSSMSClient")
                // Vérification du nom de l'autorité de certification
                && (certificate.Issuer == "CN=CA_SMS"))
            {
                // Pour le fun et la mise au point on affiche les caractéristiques du certificat reçu
                //Console.WriteLine(certificate.GetName());
                //Console.WriteLine(certificate.Issuer);
                //Console.WriteLine(certificate.GetPublicKeyString());
                return true;
            }
            else
            {
                return false;
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
                ServicePointManager.ServerCertificateValidationCallback =
                new RemoteCertificateValidationCallback(demandeDeValidationDuCertificat);
                // Création du proxy (objet chargé de la liaison avec le WebService distant)
                proxy = new WebServiceSms();

                // On prépare un objet pour réaliser une authentification basique (login, mot de passe)
                // transmis via l'entete soap

                AuthentificationEnteteSoap authentification = new AuthentificationEnteteSoap();
                // Création et peuplement de l'objet utilisateur
                Utilisateur utilisateur = new Utilisateur();
                utilisateur.Login = "nmylle";
                utilisateur.Password = "nmy5112"; // reçu par SMS sur votre portable
                // L'objet autentification n'a qu'un attribut "user" qui est un objet utilisateur
                authentification.user = utilisateur;
                // on transmet l'authentification via l'entete Soap au Webservice
                proxy.AuthentificationEnteteSoapValue = authentification;

                // La demande d'authentification est faite, on envoit l'objet SMS
                // Construction et envoi du SMS
                sms = new Sms();
                sms.NumDestinataire = mTxtBoxNumtel.Text; // Numero du technicien
                sms.TextMessage = "Bonjour "+ textBoxPrenom.Text + " " + textBoxNom.Text + ". \n" + richTextBoxMessage.Text; // Le message
                // Envoi et affichage du message de retour du serveur
                String retourWS = proxy.envoyerSms(sms);
                Console.WriteLine(retourWS);
                MessageBox.Show("Le SMS a été envoyé.");
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
                String nom = (String)dgvTechnicien.Rows[IdxLigneActuelle].Cells[0].Value;
                int indiceDansListTechnicien = listTechnicien.FindIndex(leTechnicienCherché => leTechnicienCherché.Nom == nom);
                technicienSelectionne = listTechnicien[indiceDansListTechnicien];

                textBoxNom.Text = technicienSelectionne.Nom;
                textBoxPrenom.Text = technicienSelectionne.Prenom;

                //TODO: Après que Materiel aura été fait, récupérer le numéro de tel du matériel lié au technicien 
                mTxtBoxNumtel.Text = "0614659508";
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

