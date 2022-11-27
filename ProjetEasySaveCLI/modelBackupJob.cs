using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjetEasySaveCLI
{
    class modelBackupJob : modelMain
    {
        private const string FIRST_MENU_FR = "Que voulez-vous faire ?\n" +
            "Choisissez une des options (1,2,3,4,5):\n" +
            "1-Exécuter travaux de sauvegarde existant\n" +
            "2-Créer\n" +
            "3-Modifier\n"+
            "4-Supprimer\n"+
            "5-Retour\n";

        private const string NAME_FR = "Veulliez Saisir le nom de la sauvegarde\n" +
            "Nom :";
        private const string SOURCE_FR = "Veulliez Saisir le chemin d'acces des ressource à sauvegarder\n" +
            "Source :";
        private const string DESTINATION_FR = "Veulliez Saisir le chemin d'acces de l'emplacement de la sauvegarde\n" +
            "Destination :";
        private const string TYPE_BACKUP_FR = "Veulliez choisir le type de sauvegarde\n" +
            "1-Complet\n" +
            "2-Differentiel\n";
        private const string CONFIRMATION = "Vous confirmé les informations saisi ?";


        public string GetFirstMenuData()
        {
            return FIRST_MENU_FR;
        }
        
        public string GetName()
        {
            return NAME_FR;
        }
        
        public string GetSource()
        {
            return SOURCE_FR;
        }

        public string GetDestination()
        {
            return DESTINATION_FR;
        }

        public string GetTypeBackUp()
        {
            return TYPE_BACKUP_FR;
        }
        
        public string GetConfirmation()
        {
            return CONFIRMATION;
        }



    }
}
