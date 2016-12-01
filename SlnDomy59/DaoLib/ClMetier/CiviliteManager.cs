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
    public class CiviliteManager : IDisposable
    {
        ConnexionSqlServer connexionSqlServer = null;
        SqlConnection sqlConnexion = null;
        //*****************************************************************************************************************
    
        public CiviliteManager()
        {
            connexionSqlServer = new ConnexionSqlServer();
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public CiviliteManager(ConnexionSqlServer connexionSqlServer)
        {
            this.connexionSqlServer = connexionSqlServer;
            sqlConnexion = connexionSqlServer.Connexion;
        }
        public ConnexionSqlServer getConnexion()
        {
            return connexionSqlServer;
        }
        //*****************************************************************************************************************   
      
        public List<Civilite> getListeCivilite()
        {
            // pour une commande "select * " on utilise pas de procédure stockée
            List<Civilite> listCivilites = new List<Civilite>();

            // Initialisation de la commande associée à la connexion en cours
            SqlCommand sqlCmd = new SqlCommand("select * from civilite", sqlConnexion);

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
                    // On rempli chque attribut de une civilité
                    listCivilites.Add(new Civilite()
                    {
                        IdCivilite = (int)dataReader["idCivilite"],
                        Titre = (String)dataReader["titre"],
                        Abreviation = (String)dataReader["abreviation"]
                    });
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Erreur lors de la récupération liste des civilités");
            }
            return listCivilites;
        }

        //*****************************************************************************************************************
        public void Dispose()
        {
            if (connexionSqlServer != null)
                connexionSqlServer.closeConnexion();
        }
    }  
}
