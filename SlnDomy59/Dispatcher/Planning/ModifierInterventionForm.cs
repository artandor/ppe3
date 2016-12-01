using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Calendar;
using LibDao;
using System.IO;

namespace Dispatcher
{
    public partial class ModifierInterventionForm : Form
    {
        List<Appointment> listRdv = null; // liste des rendez-vous utilisés pour l'affichage calendar
        List<Intervention> listIntervention = null;
        Intervention interventionRdvSelectionne = null, interventionRdvSelectionnePrecedente = null;
        private List<Technicien> listTechniciens = null;
        Technicien technicienSelectionne = null;
        Utils utils = null;
        DateTime debutRdv, debutRdvPre, finRdv, finRdvPre;

        bool selectionRdvPremiereFois = true; //  un rdv a été sélectionné pour la première fois
        //**************************************************************************************************
        public ModifierInterventionForm()
        {
            InitializeComponent();
            utils = new Utils();
            // paramétrage du calendar
            dayView.Renderer = new Office12Renderer();
            dayView.HalfHourHeight = 17;
            dayView.StartHour = 8;
            dayView.WorkingHourEnd = 18;
            dayView.AllowScroll = false;
            // initialisation des dates du calendar (date d'aujourd'hui et des debut ef fin rdv pour détecter une
            // absence de sélection d'un rendez-vous
            dayView.StartDate = DateTime.Now.Date;
            debutRdv = debutRdvPre = dayView.StartDate; finRdv = finRdvPre = dayView.StartDate;
            // initialisation des datagridView
            InitialiserDGV();
            // Initialisation des listes
            listIntervention = new List<Intervention>();
            // liste des rendez-vous construite par lecture de la liste des interventions d'un technicien
            listRdv = new List<Appointment>();
            // Pour sauvegarder l'intervention avant modification des caractéristiques horaires
            interventionRdvSelectionnePrecedente = new Intervention();
            interventionRdvSelectionnePrecedente.FkIdClient = 0;
        }

        //**************************************************************************************************
        // Event déclenché lorsque la liste de rendez-vous a été modifiée
        // Cette méthode construit l'affichage des rendes-vous compris entre StartDate et EndDate 
        // à partir de la "listRdv" fournie. Le résultat est transmis à l'attribut "Appointments" de l'objet 
        // args transmis en paramètre (paramètre transmis par l'évènement)
        private void dayView_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> malistRdv = new List<Appointment>();
            foreach (Appointment rdv in listRdv)
                if ((rdv.StartDate >= args.StartDate) &&
                    (rdv.StartDate <= args.EndDate))
                    malistRdv.Add(rdv);
            args.Appointments = malistRdv;
        }
        //**************************************************************************************************
        private void InitialiserDGV()
        {
          // TODO
        }
        //**************************************************************************************************
        void clearTextBox()
        {
            // clear des textBox
            txtBoxPrenomContact.ResetText();
            txtBoxNomContact.ResetText();
            mTxtBoxTelephone.ResetText();
            txtBoxObjetVisite.ResetText();
            txtBoxNomEntreprise.ResetText();
            txtBoxPrenomClient.ResetText();
            txtBoxNomClient.ResetText();
            maskedTextBoxTelClient.ResetText();
            cboxEtatIntervention.ResetText();
            pictureBoxImageIntervention.Image = null;
            lblValDebInter.ResetText();
            lblValFinInterv.ResetText();
            lblValDureeInterv.ResetText();
        }

        //**************************************************************************************************
        // methode appelée lorsqu'on sélectionne un autre jour sur le calendrier
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            dayView.StartDate = monthCalendar.SelectionStart;
            if (technicienSelectionne != null)
            {
                affichePlanningTechnicien(technicienSelectionne);
            }
        }
        //**************************************************************************************************
        // chargement d'une intervention à partir de la BDD (heure de début, login du technicien)
        void loadIntervention()
        {
            //interventionRdvSelectionne = new Intervention();
            //interventionRdvSelectionne.DebutIntervention = debutRdv;
            //interventionRdvSelectionne.FkLoginT = technicienSelectionne.LoginT;
            //Client client = new Client();
            //using (InterventionManager interventionManager = new InterventionManager())
            //{
            //    using (ClientManager clientManager = new ClientManager(interventionManager.getConnexion()))
            //    {
            //        interventionRdvSelectionne = interventionManager.getIntervention(interventionRdvSelectionne);
            //        if (interventionRdvSelectionne.FkIdClient != 0) // as-t-on trouvé une intervention correspondant au RDV
            //        { // si oui on affiche les données
            //            txtBoxPrenomContact.Text = interventionRdvSelectionne.PrenomContact;
            //            txtBoxNomContact.Text = interventionRdvSelectionne.NomContact;
            //            mTxtBoxTelephone.Text = interventionRdvSelectionne.TelContact;
            //            txtBoxObjetVisite.Text = interventionRdvSelectionne.ObjectifVisite;
            //            cboxEtatIntervention.Text = interventionRdvSelectionne.EtatVisite;
            //            Byte[] image = interventionRdvSelectionne.PhotoLieu;
            //            if (image == null || image.Length == 0)
            //            {
            //                pictureBoxImageIntervention.Image = null;
            //            }
            //            else
            //            {
            //                pictureBoxImageIntervention.Image = utils.byteArrayToImage(image);
            //            }

            //            client.IdClient = interventionRdvSelectionne.FkIdClient;
            //            client = clientManager.getClient(client);
            //            // On affiche les données du client
            //            txtBoxNomEntreprise.Text = client.Entreprise;
            //            txtBoxPrenomClient.Text = client.Prenom;
            //            txtBoxNomClient.Text = client.Nom;
            //            maskedTextBoxTelClient.Text = client.NumeroTel;
            //        }
            //    }
            //}
        }

        //**************************************************************************************************
        // méthode appelée lorque l'on sélectionne un rendez vous 
        private void dayView_SelectionChanged(object sender, EventArgs e)
        {
            if (dayView.Selection == SelectionType.Appointment)
            {
                // on récupère les valeurs du rendez-vous sélectionné sur le control DayView
                debutRdv = dayView.SelectedAppointment.StartDate;
                finRdv = dayView.SelectedAppointment.EndDate;
                // affichage des valeurs du rendez-vous
                lblValDebInter.Text = debutRdv.ToString("HH:mm");
                lblValFinInterv.Text = finRdv.ToString("HH:mm");
                // calcul et affichage durée intervention
                TimeSpan dureeIntervention = finRdv - debutRdv;
                lblValDureeInterv.Text = dureeIntervention.ToString(@"h\:mm");
                // récupération de l'intervention correspondant au technicien et au rdv sélectionné
                loadIntervention();

                if (selectionRdvPremiereFois == true)
                {
                    // on mémorise l'intervention pour la sélection
                    interventionRdvSelectionnePrecedente = interventionRdvSelectionne;
                    selectionRdvPremiereFois = false;
                }
                else if (interventionRdvSelectionne.FkIdClient == 0) // si ==0 pas d'intervention trouvée pour cette heure
                {// si pas d'intervention trouvée il faut simplement changer les heures de rdv
                    interventionRdvSelectionne = interventionRdvSelectionnePrecedente;
                    interventionRdvSelectionne.DebutIntervention = debutRdv;
                    interventionRdvSelectionne.FinIntervention = finRdv;
                }
                else if (interventionRdvSelectionne.FkIdClient != interventionRdvSelectionnePrecedente.FkIdClient)
                {// Si jamais les fkIdClient ont changé c'est que l'utilisateur a changé de rdv
                    if (technicienSelectionne != null)
                    {
                        // On rafraichit l'affichage du planning de la journée du technicien
                        affichePlanningTechnicien(technicienSelectionne);
                        interventionRdvSelectionne = null;
                    }
                }
            }
        }
        //**************************************************************************************************
        // méthode appelée lorsque l'on change les valeurs début ou fin d'un rendez-vous
        private void dayView_AppointmentMove(object sender, AppointmentEventArgs e)
        {
            // On appelle la méthode évènementielle  "dayView_SelectionChanged" pour gérer le changement des heures du rdv
            dayView_SelectionChanged(this, e);
        }
        //**************************************************************************************************
        // Cette méthode récupère les rdv d'un technicien en BDD pour peupler la liste des rendez-vous à afficher
        private void affichePlanningTechnicien(Technicien technicien)
        {
            //selectionRdvPremiereFois = true; // après affichage du planning la sélection d'un rendez-vous sera la premiere selection
            //// Raz des listes contenant les rdv affichées et les instreventions d'un technicien récupérées en BDD
            //listRdv.Clear();
            //listIntervention.Clear();
            //// Raz de l'affichage
            //clearTextBox();
            //// On charge la liste des rendez-vous d'un technicien pour un jour donné
            //Intervention uneIntervention = new Intervention();
            //uneIntervention.DebutIntervention = dayView.StartDate.Date;
            //uneIntervention.FkLoginT = technicien.LoginT;
            //try
            //{
            //    using (InterventionManager interventionManager = new InterventionManager())
            //    {
            //        listIntervention = interventionManager.listeInterventionsTechnicien(uneIntervention);

            //        foreach (Intervention chaqueIntervention in listIntervention)
            //        {
            //            // on peuple la liste des rdv a afficher 
            //            Appointment rdv = new Appointment();
            //            rdv.StartDate = chaqueIntervention.DebutIntervention;
            //            rdv.EndDate = chaqueIntervention.FinIntervention;
            //            rdv.BorderColor = Color.Red; // la couleur de l'entourage
            //            rdv.Title = chaqueIntervention.ObjectifVisite; // le texte à l'intérieur du rdv
            //            listRdv.Add(rdv);
            //        }
            //        dayView.Invalidate(); // On force le controle à se redessiner
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);
            //}
        }
        //**************************************************************************************************
        private void dgvTechnicien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdxLigneActuelle = e.RowIndex;
            if (IdxLigneActuelle >= 0)
            {
                string loginTechnicien = (string)dgvTechnicien.Rows[IdxLigneActuelle].Cells[2].Value;
                int indiceDansListTechnicien = listTechniciens.FindIndex(item => item.LoginT == loginTechnicien);
                technicienSelectionne = listTechniciens[indiceDansListTechnicien];
                affichePlanningTechnicien(technicienSelectionne);
            }
        }
        //**************************************************************************************************
        // Choix d'une image pour l'intervention
        private void btnModifierImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                string CombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\PhotosIntervention");
                dlg.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath);
                dlg.Title = "Choisir le ficher image de l'intervention";
                dlg.Filter = "Fichers images| *.bmp; *.jpg; *.jpeg; *.gif; *.png"
                           + "|Fichiers bmp| *.bmp"
                           + "|Fichiers jpg/jpeg| *.jpg;*.jpeg"
                           + "|Fichiers gif| *.gif"
                           + "|Fichiers png| *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                    this.pictureBoxImageIntervention.ImageLocation = dlg.FileName;
            }
        }
        //**************************************************************************************************
        // Enregistrement des nouvelles données de l'intervention
        private void BtnModificationIntervention_Click(object sender, EventArgs e)
        {
            //if ((debutRdv != DateTime.Now.Date) && (technicienSelectionne != null) &&
            //    (interventionRdvSelectionne != null))
            //{
            //    interventionRdvSelectionne.EtatVisite = cboxEtatIntervention.SelectedItem.ToString();
            //    if (interventionRdvSelectionne.EtatVisite != String.Empty) // EtatVisite doit être renseigné
            //    {
            //        interventionRdvSelectionne.DebutIntervention = debutRdv;
            //        interventionRdvSelectionne.FinIntervention = finRdv;
            //        interventionRdvSelectionne.ObjectifVisite = txtBoxObjetVisite.Text;
            //        // récupération image
            //        if (pictureBoxImageIntervention.Image == null)
            //            interventionRdvSelectionne.PhotoLieu = new Byte[0];  // tableau de byte vide
            //        else
            //            interventionRdvSelectionne.PhotoLieu = utils.imageToByteArray(pictureBoxImageIntervention.Image);
            //        // les champs des textBox
            //        interventionRdvSelectionne.PrenomContact = txtBoxPrenomContact.Text.Trim();
            //        interventionRdvSelectionne.NomContact = txtBoxNomContact.Text.Trim();
            //        interventionRdvSelectionne.TelContact = mTxtBoxTelephone.Text.Trim();
            //        interventionRdvSelectionne.FkLoginE = UtilisateurConnecte.Login;
            //        using (InterventionManager interventionManager = new InterventionManager())
            //        {
            //            // On persiste l'entité en BDD
            //            interventionManager.updateIntervention(interventionRdvSelectionne);
            //        }
            //        affichePlanningTechnicien(technicienSelectionne);
            //        interventionRdvSelectionne = null;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ne pas laisser l'état visite vide");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("sélectionner un rendez-vous, un technicien");
            //}
        }
        //**************************************************************************************************
        // permet de placer le curseur de saisie a gauche de la maskTextBox
        private void mTxtBoxTelephone_MouseClick(object sender, MouseEventArgs e)
        {
            mTxtBoxTelephone.SelectionStart = 0;
        }
        //**************************************************************************************************
        // Au chargement de la page on déselectionne la première cellule du dataGridView
        // Un try catch permet d'éviter attrape une exception rarissime si la table client est vide (Row null)
        private void ModifierInterventionForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvTechnicien.Rows[0].Selected = false;
            }
            catch { }
        }
        
        //**************************************************************************************************
    }
}
