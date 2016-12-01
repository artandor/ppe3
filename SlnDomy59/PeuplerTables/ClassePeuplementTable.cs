using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibDao;
using System.IO;
using Dispatcher;
using LibDao.Entites;

namespace PeuplerTables
{
    class ClassePeuplementTables
    {
        //*****************************************************************************************************************
        // pour chaque employé il faut :
        // lire le fichier contenant les données à placer dans la table employé (employes.csv)
        // faire un split de chaque ligne du fichier représentant un employé
        // peupler une entité employé et la persister en BDD
        private void peuplerTableEmploye()
        {
            Employe employe = new Employe();
            using (EmployeManager employeManager = new EmployeManager())
            {
                // Lire chaque ligne du fichier. 
                // Chaque élément du tableau représente une ligne du fichier
                String[] tabLines = System.IO.File.ReadAllLines(@"..\..\..\DonneesInitialesBdd\employes.csv", Encoding.GetEncoding("iso-8859-1"));

                foreach (String line in tabLines) // pour toutes les lignes du jeux d'essais
                {
                    String[] str = line.Split(';'); // on a choisi ";" comme séparateur csv
                    employe.LoginE = str[0];
                    employe.Prenom = str[1];
                    employe.Nom = str[2];
                    employe.Groupe = str[3];
                    // On persiste l'entité en BDD
                    employeManager.ajoutModifEmploye(ref employe);
                }
            }
        }
        //*****************************************************************************************************************
        // pour chaque client il faut :
        // // lire le fichier contenant les données à placer dans la table client (clients.csv)
        // faire un split du string csv représentatnt le client et éventuellment récupérer et convertir l'image du lieu
        // peupler une entité client et la persister en BDD
      
        private void peuplerTableClient()
        {
            Client client = new Client();
            String[] tabLines = System.IO.File.ReadAllLines(@"..\..\..\DonneesInitialesBdd\Clients.csv", Encoding.GetEncoding("iso-8859-1"));

            using (ClientManager clientManager = new ClientManager())
            {
                // chargement de la list de toutes les civilités
                // On utilise la connexion préalablement établie
                List<Civilite> listCivilites = new List<Civilite>();
                using (CiviliteManager civiliteManager = new CiviliteManager(clientManager.getConnexion()))
                {
                    listCivilites = civiliteManager.getListeCivilite();

                    foreach (String line in tabLines) // pour tous les clients du jeux d'essais
                    {
                        String[] str = line.Split(';'); // on a choisi ; comme séparateur csv
                        client.Entreprise = str[0];
                        // Dans le fichier de peuplement la civilité est fournie sous forme d'abréviation
                        // Il faut donc retrouver l'id correspondante dans la liste des civilités
                        Civilite elementCivilite = listCivilites.Find(uneCivilite => uneCivilite.Abreviation == str[1]);
                        client.FkIdCivilite = elementCivilite.IdCivilite;
                        client.Prenom = str[2];
                        client.Nom = str[3];
                        client.Adresse = str[4];
                        client.CompAdresse = str[5];
                        client.Ville = str[6];
                        client.CodePostal = str[7];
                        client.NumeroTel = str[8];
                        client.Email = str[9];
                        if (str[10] != "") // y a t il une image correspondant à l'adresse fournie par le client
                        {
                            // il faut charger et convertir l'image
                            // Conversion fichier photo en tableau de byte pour enregistrement en BDD
                            FileStream fs = new FileStream(str[10], FileMode.OpenOrCreate, FileAccess.Read); // on ouvre le fichier de la photo
                            byte[] imageBytes = new byte[fs.Length]; // tableau de byte pour recevoir le contenu des octets de la photo
                            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length)); // on place le contenu des octets de la photo dans le tableau
                            client.Photoent = imageBytes; // on enregistre dans l'entité
                        }
                        else
                        {
                            client.Photoent = new Byte[0];
                        }
                        client.Latitude = str[11];
                        client.Longitude = str[12];
                        client.FkIdEtatClient = Convert.ToInt32(str[13]);
                        client.FkLoginE = str[14];
                        // On persiste l'entité en BDD
                        clientManager.insUpdateClient(client);
                    }
                }
            }
        }
        //*****************************************************************************************************************
        void listerLesClients()
        {
            try
            {
                using (ClientManager clientManager = new ClientManager())
                {
                    List<Client> listClient = clientManager.getListeClient();
                    List<EtatClient> listEtatClient = clientManager.getListeEtatClient();

                    // chargement de la list de toutes les civilités
                    // On utilise la connexion préalablement établie
                    using (CiviliteManager civiliteManager = new CiviliteManager(clientManager.getConnexion()))
                    {
                        List<Civilite> listCivilites = civiliteManager.getListeCivilite(); 
                     
                        foreach (Client chaqueClient in listClient)
                        {
                            // la civilité est fournie via son Id
                            // Il faut retrouver l'abréviation correspondante dans la liste des civilités
                            Civilite elementCivilite = listCivilites.Find(uneCivilite => uneCivilite.IdCivilite == chaqueClient.FkIdCivilite);
                            // idem pour etat client
                            EtatClient elementEtatClient = listEtatClient.Find(unEtatClient => unEtatClient.IdEtatClient == chaqueClient.FkIdEtatClient);
                            
                            Console.Write(elementCivilite.Abreviation+"   "+chaqueClient.Prenom + "  " + chaqueClient.Nom
                                + "  " + chaqueClient.DateCreation.ToString()
                                + "  " + chaqueClient.DateModification.ToString()
                                + "  " + elementEtatClient.Etat);

                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //*****************************************************************************************************************
        ClassePeuplementTables()
        {
            // APPELS DES METHODES DE CLASSE DANS LE CONSTRUCTEUR
            peuplerTableEmploye();
            peuplerTableClient();
            listerLesClients();
        }
        //*****************************************************************************************************************
        static void Main(string[] args)
        {
            new ClassePeuplementTables();
        }
    }
}
