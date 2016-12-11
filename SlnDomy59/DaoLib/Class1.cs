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
    class MaterielManager : IDisposable
    {
        ConnexionSqlServer connexionSqlServer = null;
        SqlConnection sqlConnexion = null;

        public MaterielManager()
        {
            connexionSqlServer = new ConnexionSqlServer();
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public MaterielManager(ConnexionSqlServer connexionSqlServer)
        {
            this.connexionSqlServer = connexionSqlServer;
            sqlConnexion = connexionSqlServer.Connexion;
        }

        public ConnexionSqlServer getConnexion()
        {
            return connexionSqlServer;
        }

        public List<Materiel> getListeMateriel()
        {
            List<Materiel> listMateriel = new List<Materiel>();

            SqlCommand sqlCmd = new SqlCommand("select * from materiel", sqlConnexion);

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
                    listMateriel.Add(new Materiel()
                    {
                        IdGoogle = (String)dataReader["idGoogle"],
                        IdMateriel = (int)dataReader["idMateriel"],
                        Imei = (String)dataReader["imei"],
                        NumeroSerie = (String)dataReader["numeroSerie"],
                        TypeMateriel = (String)dataReader["typeMateriel"],
                        NumeroTel = (String)dataReader["numeroTel"],
                        DateAffectation = (DateTime)dataReader["dateAffectation"],
                        DateEnregistrement = (DateTime)dataReader["dateEnregistrement"],
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
            return listMateriel;
        }

        public Materiel saveMateriel(Materiel prmMateriel)
        {
            Materiel Materiel = new Materiel();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConnexion;

            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = @"spEnregistrerMateriel";

            sqlCmd.Parameters.Add("@pImei", SqlDbType.NVarChar, 17).Value = prmMateriel.Imei;
            sqlCmd.Parameters.Add("@pTypeMateriel", SqlDbType.NVarChar, 100).Value = prmMateriel.TypeMateriel;
            sqlCmd.Parameters.Add("@pIdMateriel", SqlDbType.NVarChar, 20).Value = prmMateriel.IdMateriel;
            sqlCmd.Parameters.Add("@pImei", SqlDbType.NVarChar).Value = prmMateriel.Imei;
            sqlCmd.Parameters.Add("@pEtatMateriel", SqlDbType.NVarChar, 15).Value = prmMateriel.EtatMateriel;
            sqlCmd.Parameters.Add("@pNumeroTel", SqlDbType.NVarChar, 20).Value = prmMateriel.NumeroTel;
            sqlCmd.Parameters.Add("@pNumerieSerie", SqlDbType.NVarChar, 50).Value = prmMateriel.NumeroSerie;

            try
            {
                if (sqlConnexion.State != ConnectionState.Open)
                {
                    sqlConnexion.Open();
                }
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                
            }
            return retour;
        }

        public bool supprimerMateriel(Materiel prmMateriel)
        {
            Materiel materiel = new Materiel();
            materiel = getMateriel;
            return retour;
        }

        public void Dispose()
        {
            if (connexionSqlServer != null)
                connexionSqlServer.closeConnexion();
        }

            
    }
}
