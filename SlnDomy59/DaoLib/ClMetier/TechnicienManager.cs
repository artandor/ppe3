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
                throw new Exception("Erreur lors de l'ajout ou modification client");
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
