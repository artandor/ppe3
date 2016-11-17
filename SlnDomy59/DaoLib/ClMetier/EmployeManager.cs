using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace LibDao
{
    public class EmployeManager : IDisposable
    {
        ConnexionSqlServer connexionSqlServer = null;
        SqlConnection sqlConnexion = null;
        //*****************************************************************************************************************
        public EmployeManager()
        {
            connexionSqlServer = new ConnexionSqlServer();
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public EmployeManager(ConnexionSqlServer connexionSqlServer)
        {
            this.connexionSqlServer = connexionSqlServer;
            sqlConnexion = connexionSqlServer.Connexion;
        }
        public ConnexionSqlServer getConnexion()
        {
            return connexionSqlServer;
        }
        //*****************************************************************************************************************
        public Employe getEmploye(ref Employe prmEmploye)
        {
            Employe employe = new Employe();
            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spGetEmploye";

            // paramètres passées à la procédure stockée
            sqlCmd.Parameters.Add("@pLoginE", SqlDbType.NVarChar, 25).Value = prmEmploye.LoginE;
            sqlCmd.Parameters.Add("@pPrenom", SqlDbType.NVarChar, 20).Value = prmEmploye.Prenom;
            sqlCmd.Parameters.Add("@pNom", SqlDbType.NVarChar, 30).Value = prmEmploye.Nom;
            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                // Lecture d'un enregistrements contenus dans le DataRead
                if (dataReader.Read() == true) // un Employe trouvé
                {
                    employe.Nom = (String)dataReader["nom"];
                    employe.Prenom = (String)dataReader["prenom"];
                    employe.Groupe = (String)dataReader["groupe"];
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                Dispose();
                throw new Exception("Erreur recherche Employe");
            }
            return employe;
        }

        //*****************************************************************************************************************
        public bool ajoutModifEmploye(ref Employe employe)
        {
            bool retour = false;

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spInsUpdateEmploye";

            // paramètres passés à la procédure stockée
            sqlCmd.Parameters.Add("@pLoginE", SqlDbType.NVarChar, 25).Value = employe.LoginE;
            sqlCmd.Parameters.Add("@pPrenom", SqlDbType.NVarChar, 20).Value = employe.Prenom;
            sqlCmd.Parameters.Add("@pNom", SqlDbType.NVarChar, 30).Value = employe.Nom;
            sqlCmd.Parameters.Add("@pGroupe", SqlDbType.NVarChar, 25).Value = employe.Groupe;

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
                throw new Exception("Erreur lors de l'ajout d'un employé");
            }
            return retour;
        }

        //*****************************************************************************************************************
        // On passe en paramètre un utilisateur qui se voit supprimer
        // on retourne True si tout s'est bien passé
        public bool supprimerEmploye(Employe employe)
        {
            employe = getEmploye(ref employe); // On récupère un objet complet
            bool retour = false;

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;

            if (employe.LoginE != "") // il y a une EntityEmploye à supprimer
            {
                sqlCmd.CommandText = @"spEmployeDelete";
                // paramètres passées à la procédure stockée
                sqlCmd.Parameters.Add("@pLoginE", SqlDbType.NVarChar, 25).Value = employe.LoginE;

                try
                {
                    // On ouvre la connexion
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
                    throw new Exception("Erreur lors de la suppression d'un employé");
                }
            }
            return retour;
        }
       

        //*****************************************************************************************************************
        public List<Employe> getListeEmploye()
        {
            // pour une commande "select * " on utilise pas de procédure stockée
            List<Employe> listEmployes = new List<Employe>();

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand("select * from Employe", sqlConnexion);

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
                    listEmployes.Add(new Employe()
                    {
                        LoginE=(String)dataReader["loginE"],
                        Nom = (String)dataReader["nom"],
                        Prenom = (String)dataReader["prenom"],
                        Groupe=(String)dataReader["groupe"]
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la récupération liste des Employes");
            }
            return listEmployes;
        }


        //*****************************************************************************************************************
        public void Dispose()
        {
            if (connexionSqlServer != null)
                connexionSqlServer.closeConnexion();
        }
    }
}
