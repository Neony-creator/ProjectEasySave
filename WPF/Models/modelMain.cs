using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    class modelMain
    {
        

        public string GetinterfaceData() //On crée une fonction qui récupére l'interface principale de notre fichier JSON
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage()); //On déserrialise notre fichier JSON contenant les différentes informations à afficher sur la console, afin d'en obtenir un objet C# exploitable
            string MAIN_MENU = $"{langue.MainMenu}"; //On récupére les informations correspondantes à l'ID souhaité parmis ce que l'on a récupéré suite à la déserialisation de notre fichier JSON
            return MAIN_MENU; //On retourne les infomations que l'on a extraite
        }

        public string GetError()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string ERROR = $"{langue.Error}";
            return ERROR;
        }

        public int ScearchNbBackUp() //On crée une fonction qui permet de connaître le nombre de backup déjà créé
        {
            ConfigurationManager.RefreshSection("appSettings"); //on actualise notre fichier config, afin d'être sûr qu'il soit à jour
            string nbBackUp = ConfigurationManager.AppSettings["nbbackup"]; //On récupére la valeur correspondant à l'ID "nbbackup"
            int result = 0;
            try
            {
                result = int.Parse(nbBackUp);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }

        public string configLanguage = ConfigurationManager.AppSettings["language"]; //On récupére la valeur correspondant à l'ID "language" de notre fichier config, qui sera dans notre "fr" ou "en" en fonction de la langue choisie par l'utilisateur
        public string testLanguage() //Fonction qui ragarde la langue actuellement appliquée, et utilise donc le fichier contenant le texte affiché, de la langue correpondante
        {
            string result = File.ReadAllText(@"./text_en.json"); //On met dans une variable toutes les informations de notre fichier JSON contenant le texte qui sera affiché dans la console (le fichier JSON correspondant à la langue selectionnée)
            switch (configLanguage)
            {
                case "fr":
                    result = File.ReadAllText(@"./text_fr.json");
                    break;
                case "en":
                    result = File.ReadAllText(@"./text_en.json");
                    break;
            }
            return (result);
        }





    }

}
