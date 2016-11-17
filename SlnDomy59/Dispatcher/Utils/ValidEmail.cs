using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dispatcher.refValidEmail;


//WebService proposé :  emailvalidation3
//http://trial.serviceobjects.com/ev3/api.svc?singleWsdl   Lien pour obtenir les metadonnées afin de construire le proxy
//https://www.serviceobjects.com/products/email/email-verification-service
//https://docs.serviceobjects.com/display/devguide/DOTS+Email+Validation+3

namespace Dispatcher
{
    public class ValidEmail
    {
        //La licence obligatoire pour utiliser le webservice
        static String licence = "WS73-SHR5-OJL1";
        EV3Library eV3Library=null;

        public ValidEmail(String emailATester, ref String reponseWsValidEmail)
        {
            try
            {
                eV3Library = new EV3Library();
                // Appel synchrone
                ValidateEmailResponse reponse = eV3Library.ValidateEmailFull(emailATester, licence);
                if (reponse.Error == null)
                {
                    if ((reponse.ValidateEmailInfo.IsDeliverable == "true") ||
                        ((reponse.ValidateEmailInfo.IsDeliverable == "unknown") && (reponse.ValidateEmailInfo.Score < 3))
                        )
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
