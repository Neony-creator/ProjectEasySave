using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEasySaveCLI
{
    class modelMain
    {
        private const string MAIN_MENU_FR = "Bienvenu dans l'application EasySave ! \n" +
            "Que voulez-vous faire ?\n" +
            "Choisissez une des options (1,2,3):\n" +
            "1-Travaux de sauvegarde\n" +
            "2-Voir les logs\n" +
            "3-Changer de langue\n";

        private const string ERROR_FR = "Erreur :/\n" +
            "Veulliez resaisir votre réponse\n";


        public string GetinterfaceData()
        {
            return MAIN_MENU_FR;
        }

        public string GetError()
        {
            return ERROR_FR;
        }
    }
}
