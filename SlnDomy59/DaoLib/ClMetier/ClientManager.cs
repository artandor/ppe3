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
    public class ClientManager : IDisposable
    {
        ConnexionSqlServer connexionSqlServer = null;
        SqlConnection sqlConnexion = null;
        //*****************************************************************************************************************
        public ClientManager()
        {
            connexionSqlServer = new ConnexionSqlServer();
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public ClientManager(ConnexionSqlServer connexionSqlServer)
        {
            this.connexionSqlServer = connexionSqlServer;
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public ConnexionSqlServer getConnexion()
        {
            return connexionSqlServer;
        }
        //*****************************************************************************************************************
        public List<EtatClient> getListeEtatClient()
        { 
            List<EtatClient> listEtatClient = new List<EtatClient>();

            // Initialisation de la commande associée à la connexion en cours
            // pour une commande "select * " on utilise pas de procédure stockée
            SqlCommand sqlCmd = new SqlCommand("select * from etatClient", sqlConnexion);

            try
            {
                // Ouverture de la connexion
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                // Lecture de tous les enregistrements contenus dans le DataRead
                while (dataReader.Read())
                {
                    // On rempli chque attribut de l'objet etatClient
                    listEtatClient.Add(new EtatClient()
                    {
                        IdEtatClient = (int)dataReader["idEtatClient"],
                        Etat = (String)dataReader["etat"]
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la récupération liste des etats client");
            }
            return listEtatClient;
        }

        //*****************************************************************************************************************
        public Client getClient(Client prmClient)
        {
            Client client = new Client();
            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spGetClient";

            // paramètres passées à la procédure stockée
            sqlCmd.Parameters.Add("@pIdClient", SqlDbType.Int).Value = prmClient.IdClient;
            sqlCmd.Parameters.Add("@pPrenom", SqlDbType.NVarChar, 20).Value = prmClient.Prenom;
            sqlCmd.Parameters.Add("@pNom", SqlDbType.NVarChar, 30).Value = prmClient.Nom;
            try
            {
                // On se connecte
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();
                // Lecture d'un enregistrements contenus dans le DataRead
                if (dataReader.Read() == true) // un Client trouvée
                {
                    client.IdClient = (int)dataReader["IdClient"];
                    client.Entreprise = (String)dataReader["entreprise"];
                    client.FkIdCivilite = (int)dataReader["fkIdCivilite"];
                    client.Prenom = (String)dataReader["prenom"];
                    client.Nom = (String)dataReader["nom"];
                    client.Adresse = (String)dataReader["adresse"];
                    client.CompAdresse = (String)dataReader["compAdresse"];
                    client.CodePostal = (String)dataReader["codepostal"];
                    client.Ville = (String)dataReader["ville"];
                    client.NumeroTel = (String)dataReader["numerotel"];
                    client.Email = (String)dataReader["email"];
                    client.Photoent = (dataReader["photoent"]) == DBNull.Value ? new Byte[0] : (Byte[])(dataReader["photoent"]);
                    client.Latitude = (String)dataReader["latitude"].ToString(); 
                    client.Longitude = (String)dataReader["longitude"].ToString();
                    client.DateCreation = (DateTime)dataReader["dateCreation"];
                    client.DateModification = (dataReader["dateModification"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["dateModification"]));
                    client.FkIdEtatClient = (int)dataReader["fkIdEtatClient"];
                    client.FkLoginE = (String)dataReader["fkLoginE"];
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                Dispose();
                throw new Exception("Erreur recherche Client \n");
            }
            return client;
        }

        //*****************************************************************************************************************
       
        public bool insUpdateClient(Client prmClient)
        {
            bool retour = false;

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spInsUpdateClient";

            // paramètres passés à la procédure stockée
            sqlCmd.Parameters.Add("@pIdClient", SqlDbType.Int).Value = prmClient.IdClient;
            sqlCmd.Parameters.Add("@pEntreprise", SqlDbType.NVarChar, 75).Value = prmClient.Entreprise;
            sqlCmd.Parameters.Add("@pFkIdCivilite", SqlDbType.Int).Value = prmClient.FkIdCivilite;
            sqlCmd.Parameters.Add("@pPrenom", SqlDbType.NVarChar, 20).Value = prmClient.Prenom;
            sqlCmd.Parameters.Add("@pNom", SqlDbType.NVarChar, 30).Value = prmClient.Nom;
            sqlCmd.Parameters.Add("@pAdresse", SqlDbType.NVarChar, 75).Value = prmClient.Adresse;
            sqlCmd.Parameters.Add("@pCompAdresse", SqlDbType.NVarChar, 75).Value = prmClient.CompAdresse;
            sqlCmd.Parameters.Add("@pCodePostal", SqlDbType.VarChar, 10).Value = prmClient.CodePostal;
            sqlCmd.Parameters.Add("@pVille", SqlDbType.NVarChar, 30).Value = prmClient.Ville;
            sqlCmd.Parameters.Add("@pNumeroTel", SqlDbType.VarChar, 12).Value = prmClient.NumeroTel;
            sqlCmd.Parameters.Add("@pEmail", SqlDbType.VarChar, 30).Value = prmClient.Email;
            sqlCmd.Parameters.Add("@pPhotoent", SqlDbType.VarBinary).Value = prmClient.Photoent;
            sqlCmd.Parameters.Add("@pLatitude", SqlDbType.NVarChar, 20).Value = prmClient.Latitude;
            sqlCmd.Parameters.Add("@pLongitude", SqlDbType.NVarChar, 20).Value = prmClient.Longitude;
            sqlCmd.Parameters.Add("@pFkIdEtatClient", SqlDbType.Int).Value = prmClient.FkIdEtatClient;
            sqlCmd.Parameters.Add("@pLoginE", SqlDbType.NVarChar, 25).Value = prmClient.FkLoginE;

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
                throw new Exception("Erreur lors de l'ajout ou modification client");
            }
            return retour;
        }


        //*****************************************************************************************************************
        // On passe en paramètre un utilisateur qui se voit supprimer
        // on retourne True si tout s'est bien passé
        public bool supprimerClient(Client prmClient)
        {
            Client client = new Client();
            client=getClient(prmClient);
            bool retour = false;

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            // Type de commande de commande et nom de la procédure appelée
            sqlCmd.CommandType = CommandType.StoredProcedure;
            
            if (client.IdClient != 0)
            {
                sqlCmd.CommandText = @"spClientDelete";
                // paramètres passées à la procédure stockée
                sqlCmd.Parameters.Add("@pIdClient", SqlDbType.Int).Value = client.IdClient;
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
                    throw new Exception("Erreur lors de la suppression d'un client " + ex.Message);
                }
            }
            return retour;
        }

        //*****************************************************************************************************************
      
        public List<Client> getListeClient()
        {
            // pour une commande "select * " on utilise pas de procédure stockée
            List<Client> listClients = new List<Client>();

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand("select * from client", sqlConnexion);

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
                    // On rempli chque attribut de un client
                    listClients.Add(new Client()
                    {
                    IdClient = (int)dataReader["idClient"],
                    Entreprise= (String)dataReader["entreprise"],
                    FkIdCivilite = (int)dataReader["fkIdCivilite"],
                    Prenom = (String)dataReader["prenom"],
                    Nom = (String)dataReader["nom"],
                    Adresse = (String)dataReader["adresse"],
                    CompAdresse = (String)dataReader["compAdresse"],
                    CodePostal = (String)dataReader["codepostal"],
                    Ville = (String)dataReader["ville"],
                    NumeroTel = (String)dataReader["numerotel"],
                    Email = (String)dataReader["email"],
                    Photoent = (dataReader["photoent"]) == DBNull.Value ? new Byte[0] : (Byte[])(dataReader["photoent"]),
                    Latitude = (String)dataReader["latitude"].ToString(),
                    Longitude = (String)dataReader["longitude"].ToString(),
                    DateCreation = (DateTime)dataReader["dateCreation"],
                    DateModification = (dataReader["dateModification"] == DBNull.Value ? new DateTime(0) : (DateTime)(dataReader["dateModification"])),
                    FkIdEtatClient = (int)dataReader["fkIdEtatClient"],
                    FkLoginE = (String)dataReader["fkLoginE"]
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la récupération liste des clients");
            }
            return listClients;
        }


        //*****************************************************************************************************************
        public void Dispose()
        {
            if (connexionSqlServer != null)
                connexionSqlServer.closeConnexion();
        }
    }
}
