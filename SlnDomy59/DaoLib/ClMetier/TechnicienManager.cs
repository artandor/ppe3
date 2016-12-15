using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Sql;
using LibDao.Entites;

namespace LibDao
{
    public class TechnicienManager : IDisposable
    {
        ConnexionSqlServer connexionSqlServer = null;
        SqlConnection sqlConnexion = null;
        //*****************************************************************************************************************
        public TechnicienManager()
        {
            connexionSqlServer = new ConnexionSqlServer();
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public TechnicienManager(ConnexionSqlServer connexionSqlServer)
        {
            this.connexionSqlServer = connexionSqlServer;
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public ConnexionSqlServer getConnexion()
        {
            return connexionSqlServer;
        }

        public Technicien getTechnicien(Technicien prmTechnicien)
        {
            Technicien Technicien = new Technicien();
            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spGetTechnicien";

            // paramètres passées à la procédure stockée
            sqlCmd.Parameters.Add("@pLoginT", SqlDbType.NVarChar).Value = prmTechnicien.LoginT;
            sqlCmd.Parameters.Add("@pPrenom", SqlDbType.NVarChar, 20).Value = prmTechnicien.Prenom;
            sqlCmd.Parameters.Add("@pNom", SqlDbType.NVarChar, 30).Value = prmTechnicien.Nom;

            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                // Lecture d'un enregistrements contenus dans le DataRead
                if (dataReader.Read() == true) // un Technicien trouvée
                {
                    Technicien.LoginT = (String)dataReader["loginT"];
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                Dispose();
                throw new Exception("Erreur recherche Technicien \n");
            }
            return Technicien;
        }

        
        public bool insUpdateTechnicien (Technicien prmTechnicien)
        {
            bool retour = false;

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spInsUpdateTechnicien";

            sqlCmd.Parameters.Add("@pLoginT", SqlDbType.NVarChar, 25).Value = prmTechnicien.LoginT;
            sqlCmd.Parameters.Add("@pPrenom", SqlDbType.NVarChar, 20).Value = prmTechnicien.Prenom;
            sqlCmd.Parameters.Add("@pNom", SqlDbType.NVarChar, 30).Value = prmTechnicien.Nom;
            sqlCmd.Parameters.Add("@pPasswdT", SqlDbType.NVarChar, 32).Value = prmTechnicien.PasswdT;
            sqlCmd.Parameters.Add("@pFkIdMateriel", SqlDbType.Int).Value = prmTechnicien.FkIdMateriel;

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
                throw new Exception("Erreur lors de l'ajout ou modification Technicien");
            }
            return retour;
        }

        public List<Technicien> getListeTechnicien()
        {
            List<Technicien> listTechnicien = new List<Technicien>();

            SqlCommand sqlCmd = new SqlCommand("select * from technicien", sqlConnexion);

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
                    // On rempli chque attribut de un Technicien
                    listTechnicien.Add(new Technicien()
                    {
                        Nom = (String)dataReader["nom"],
                        Prenom = (String)dataReader["prenom"],
                        LoginT = (String)dataReader["loginT"],
                        PasswdT = (String)dataReader["passwdT"],
                        //cette ligne ne fonctionne pas sans que je sache pourquoi. erreur renvoyée : Le cast spécifié n'est pas valide.
                        //FkIdMateriel = (int)dataReader["fkIdMateriel"],
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la récupération liste des techniciens");
            }
            return listTechnicien;
        }

        public bool supprimerTechnicien(Technicien prmTechnicien)
        {
            Technicien technicien = new Technicien();
            technicien = getTechnicien(prmTechnicien);
            bool retour = false;

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;

            if (technicien.LoginT.Trim() != "")
            {
                sqlCmd.CommandText = @"spTechnicienDelete";
                sqlCmd.Parameters.Add("@pLoginT", SqlDbType.NVarChar, 25).Value = technicien.LoginT;

                try
                {
                    if (sqlConnexion.State != ConnectionState.Open)
                    {
                        sqlConnexion.Open();
                    }
                    // On appelle la procédure stockée
                    if ((int)sqlCmd.ExecuteNonQuery() == -1)
                    {
                        retour = true;
                    }
                }
                catch (Exception ex)
                {
                    Dispose();
                    throw new Exception("Erreur lors de la suppression d'un client " + ex.Message);
                }
            }
            return retour;
        }


        public void Dispose()
        {
            if (connexionSqlServer != null)
            {
                connexionSqlServer.closeConnexion();
            }
        }
    }
}
