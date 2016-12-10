using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dispatcher.refWsValidEmail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;


namespace Dispatcher
{
    public class ValidEmail
    {
        WebServiceVerificationEmail proxy = null;

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
            return true;
        }
        public ValidEmail(String emailATester, ref String reponseWsValidEmail)
        {
            try
            {
                // On vérifie les caractéristiques du certificat renvoyé par le serveur pour eviter 
                // l'attaque 'middle man"  
                // la méthode "demandeDeValidationDuCertificat" est appelé en retour du constructeur de 
                // l'objet RemoteCertificateValidationCallback
                ServicePointManager.ServerCertificateValidationCallback =
                    new RemoteCertificateValidationCallback(demandeDeValidationDuCertificat);
                // Création du proxy (objet chargé de la liaison avec le WebService distant)
                proxy = new WebServiceVerificationEmail();

                // On prépare un objet pour réaliser une authentification basique (login, mot de passe)
                // transmis via l'entete soap
                AuthentificationEnteteSoap authentification = new AuthentificationEnteteSoap();
                // Création et peuplement de l'objet utilisateur
                Utilisateur utilisateur = new Utilisateur();
                utilisateur.Login = "lbettini";
                utilisateur.Password = "lbe1739";
                // L'objet autentification n'a qu'un attribut "user" qui est un objet utilisateur
                authentification.user = utilisateur;
                // on transmet l'authentification via l'entete Soap au Webservice
                proxy.AuthentificationEnteteSoapValue = authentification; // on transmet l'authentification
                // Appel de la méthode distante et affichage du message de retour du serveur
                String retourWS = proxy.VerifieEmail(emailATester); // adresse email a vérifier

                if (retourWS != "4")
                {
                    if (retourWS == "0")
                    {
                        reponseWsValidEmail = "Email valide";
                    }
                    else
                    {
                        reponseWsValidEmail = "Email erroné";
                    }
                }
                else
                {
                    reponseWsValidEmail = "Pas de service vérification email disponible";
                }
            }
            catch(Exception)
            {
                reponseWsValidEmail = "Pas de service vérification email disponible";
            }
        }
        
    }
}
