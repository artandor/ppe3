using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace LibDao
{
    public class InterventionManager : IDisposable
    {
        ConnexionSqlServer connexionSqlServer = null;
        SqlConnection sqlConnexion = null;
        //*****************************************************************************************************************
        public InterventionManager()
        {
            connexionSqlServer = new ConnexionSqlServer();
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public InterventionManager(ConnexionSqlServer connexionSqlServer)
        {
            this.connexionSqlServer = connexionSqlServer;
            sqlConnexion = connexionSqlServer.Connexion;
        }
        public ConnexionSqlServer getConnexion()
        {
            return connexionSqlServer;
        }
        //*****************************************************************************************************************
        public Intervention getIntervention(Intervention prmIntervention)
        {
            Intervention intervention = new Intervention();
            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et CompteRendu de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spGetInterventionByTechnicienByDate";
            // paramètres passées à la procédure stockée
            sqlCmd.Parameters.Add("@pIdIntervention", SqlDbType.Int).Value = prmIntervention.IdIntervention;
            sqlCmd.Parameters.Add("@pFkLoginT", SqlDbType.NVarChar, 25).Value = prmIntervention.FkLoginT;
            sqlCmd.Parameters.Add("@pDebutIntervention", SqlDbType.DateTime).Value = prmIntervention.DebutIntervention;
            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                // Lecture d'un enregistrements contenus dans le DataRead
                if (dataReader.Read() == true) // une EntityIntervention trouvée
                {
                    intervention.IdIntervention = (int)dataReader["idIntervention"];
                    intervention.CompteRendu = (String)dataReader["compteRendu"].ToString();
                    intervention.DebutIntervention = (dataReader["debutIntervention"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["debutIntervention"]));
                    intervention.FinIntervention = (dataReader["finIntervention"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["finIntervention"]));
                    intervention.ObjectifVisite = (String)dataReader["objectifVisite"];
                    intervention.PhotoLieu = (dataReader["photoLieu"]) == DBNull.Value ? new Byte[0] : (Byte[])dataReader["photoLieu"];
                    intervention.NomContact = (String)dataReader["nomContact"].ToString();
                    intervention.PrenomContact = (String)dataReader["prenomContact"].ToString();
                    intervention.TelContact = (String)dataReader["telContact"].ToString();
                    intervention.EtatVisite = (String)dataReader["etatVisite"];
                    intervention.FkLoginE = (String)dataReader["fkLoginE"];
                    intervention.FkIdClient = (int)dataReader["fkIdClient"];
                    intervention.FkLoginT = (String)dataReader["fkLoginT"];
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                Dispose();
                throw new Exception("Erreur recherche Intervention");
            }
            return intervention;
        }

        //*****************************************************************************************************************
        public bool ajouterIntervention(Intervention intervention)
        {
            bool retour = false;

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et CompteRendu de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spInsertIntervention";

            // paramètres passés à la procédure stockée
            sqlCmd.Parameters.Add("@pCompteRendu", SqlDbType.Text).Value = intervention.CompteRendu;
            sqlCmd.Parameters.Add("@pDebutIntervention", SqlDbType.DateTime).Value = intervention.DebutIntervention;
            sqlCmd.Parameters.Add("@pFinIntervention", SqlDbType.DateTime).Value = intervention.FinIntervention;
            sqlCmd.Parameters.Add("@pObjectifVisite", SqlDbType.Text).Value = intervention.ObjectifVisite;
            sqlCmd.Parameters.Add("@pPhotoLieu", SqlDbType.VarBinary).Value = intervention.PhotoLieu;
            sqlCmd.Parameters.Add("@pNomContact", SqlDbType.NVarChar, 30).Value = intervention.NomContact;
            sqlCmd.Parameters.Add("@pPrenomContact", SqlDbType.NVarChar, 20).Value = intervention.PrenomContact;
            sqlCmd.Parameters.Add("@pTelContact", SqlDbType.NVarChar, 12).Value = intervention.TelContact;
            sqlCmd.Parameters.Add("@pEtatVisite", SqlDbType.NVarChar, 25).Value = intervention.EtatVisite;
            sqlCmd.Parameters.Add("@pFkLoginE", SqlDbType.NVarChar, 25).Value = intervention.FkLoginE;
            sqlCmd.Parameters.Add("@pFkIdClient", SqlDbType.Int).Value = intervention.FkIdClient;
            sqlCmd.Parameters.Add("@pFkLoginT", SqlDbType.NVarChar, 25).Value = intervention.FkLoginT;

            // On persiste les data
            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                // On appelle la procédure stockée
                if ((int)sqlCmd.ExecuteNonQuery() == -1)
                {
                    retour = true; // Une ligne a été modifiée dans la BDD tvb
                }
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de l'ajout d'une Intervention ");
            }
            return retour;
        }

        //*****************************************************************************************************************
        // On passe en paramètre une intervention que l'on veut supprimer
        // on retourne True si tout s'est bien passé
        public bool supprimerIntervention(Intervention intervention)
        {
            bool retour = false;

            //Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;
            //Type de commande de commande et CompteRendu de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.CommandText = @"spDeleteInterventionByTechnicienByDate";
            //paramètres passées à la procédure stockée
            sqlCmd.Parameters.Add("@pFkLoginT", SqlDbType.NVarChar, 25).Value = intervention.FkLoginT;
            sqlCmd.Parameters.Add("@pDebutIntervention", SqlDbType.DateTime).Value = intervention.DebutIntervention;
            try
            {
                //On ouvre la connexion
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                //On appelle la procédure stockée
                if ((int)sqlCmd.ExecuteNonQuery() == -1)
                {
                    retour = true;
                }
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la suppression d'une Intervention");
            }
            return retour;
        }

        //*****************************************************************************************************************
        // L'intervention est connue par son Id
        public bool updateIntervention(Intervention intervention)
        {
            bool retour = false;

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et CompteRendu de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spUpdateInterventionById";

            // paramètres passés à la procédure stockée
            sqlCmd.Parameters.Add("@pIdIntervention", SqlDbType.Int).Value = intervention.IdIntervention;
            sqlCmd.Parameters.Add("@pCompteRendu", SqlDbType.Text).Value = intervention.CompteRendu;
            sqlCmd.Parameters.Add("@pDebutIntervention", SqlDbType.DateTime).Value = intervention.DebutIntervention;
            sqlCmd.Parameters.Add("@pFinIntervention", SqlDbType.DateTime).Value = intervention.FinIntervention;
            sqlCmd.Parameters.Add("@pObjectifVisite", SqlDbType.Text).Value = intervention.ObjectifVisite;
            sqlCmd.Parameters.Add("@pPhotoLieu", SqlDbType.VarBinary).Value = intervention.PhotoLieu;
            sqlCmd.Parameters.Add("@pNomContact", SqlDbType.NVarChar, 30).Value = intervention.NomContact;
            sqlCmd.Parameters.Add("@pPrenomContact", SqlDbType.NVarChar, 20).Value = intervention.PrenomContact;
            sqlCmd.Parameters.Add("@pTelContact", SqlDbType.NVarChar, 12).Value = intervention.TelContact;
            sqlCmd.Parameters.Add("@pEtatVisite", SqlDbType.NVarChar, 25).Value = intervention.EtatVisite;
            sqlCmd.Parameters.Add("@pFkLoginE", SqlDbType.NVarChar, 25).Value = intervention.FkLoginE;
            sqlCmd.Parameters.Add("@pFkIdClient", SqlDbType.Int).Value = intervention.FkIdClient;
            sqlCmd.Parameters.Add("@pFkLoginT", SqlDbType.NVarChar, 25).Value = intervention.FkLoginT;

            // On persiste les data
            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                // On appelle la procédure stockée
                if ((int)sqlCmd.ExecuteNonQuery() == -1)
                {
                    retour = true; // Une ligne a été modifiée dans la BDD tvb
                }
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la modification d'une intervention");
            }
            return retour;
        }

        //*****************************************************************************************************************
        public List<Intervention> listeInterventions()
        {
            // pour une commande "select * " on utilise pas de procédure stockée
            List<Intervention> listInterventions = new List<Intervention>();

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand("select * from Intervention", sqlConnexion);

            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                // Lecture de tous les enregistrements contenus dans le DataRead
                while (dataReader.Read())
                {
                    listInterventions.Add(new Intervention()
                    {
                        IdIntervention = (int)dataReader["idIntervention"],
                        CompteRendu = (String)dataReader["compteRendu"].ToString(),
                        DebutIntervention = (dataReader["debutIntervention"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["debutIntervention"])),
                        FinIntervention = (dataReader["finIntervention"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["finIntervention"])),
                        ObjectifVisite = (String)dataReader["objectifVisite"],
                        PhotoLieu = (dataReader["photoLieu"]) == DBNull.Value ? new Byte[0] : (Byte[])dataReader["photoLieu"],
                        NomContact = (String)dataReader["nomContact"].ToString(),
                        PrenomContact = (String)dataReader["prenomContact"].ToString(),
                        TelContact = (String)dataReader["telContact"].ToString(),
                        EtatVisite = (String)dataReader["etatVisite"],
                        FkLoginE = (String)dataReader["fkLoginE"],
                        FkIdClient = (int)dataReader["fkIdClient"],
                        FkLoginT = (String)dataReader["fkLoginT"]
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la récupération liste des Interventions");
            }
            return listInterventions;
        }
        //*****************************************************************************************************************
        public List<Intervention> listeInterventionsTechnicien(Intervention prmIntervention)
        {
            // pour une commande "select * " on utilise pas de procédure stockée
            List<Intervention> listInterventions = new List<Intervention>();

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spGetlistInterventionsByTechnicienByDate";

            sqlCmd.Parameters.Add("@pFkLoginT", SqlDbType.NVarChar, 25).Value = prmIntervention.FkLoginT;
            sqlCmd.Parameters.Add("@pDateJour", SqlDbType.DateTime).Value = prmIntervention.DebutIntervention;
            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                // Lecture de tous les enregistrements contenus dans le DataRead
                while (dataReader.Read())
                {
                    listInterventions.Add(new Intervention()
                    {
                        IdIntervention = (int)dataReader["idIntervention"],
                        CompteRendu = (String)dataReader["compteRendu"].ToString(),
                        DebutIntervention = (dataReader["debutIntervention"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["debutIntervention"])),
                        FinIntervention = (dataReader["finIntervention"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["finIntervention"])),
                        ObjectifVisite = (String)dataReader["objectifVisite"],
                        PhotoLieu = (dataReader["photoLieu"]) == DBNull.Value ? new Byte[0] : (Byte[])dataReader["photoLieu"],
                        NomContact = (String)dataReader["nomContact"].ToString(),
                        PrenomContact = (String)dataReader["prenomContact"].ToString(),
                        TelContact = (String)dataReader["telContact"].ToString(),
                        EtatVisite = (String)dataReader["etatVisite"],
                        FkLoginE = (String)dataReader["fkLoginE"],
                        FkIdClient = (int)dataReader["fkIdClient"],
                        FkLoginT = (String)dataReader["fkLoginT"]
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la récupération liste des Interventions");
            }
            return listInterventions;
        }

        //*****************************************************************************************************************
        public void Dispose()
        {
            if (connexionSqlServer != null)
                connexionSqlServer.closeConnexion();
        }
    }
}