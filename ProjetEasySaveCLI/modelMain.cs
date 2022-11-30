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
        public string configLanguage = ConfigurationManager.AppSettings["language"];



        public string GetinterfaceData()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MAIN_MENU = $"{langue.MainMenu}";
            return MAIN_MENU;
        }

        public string GetError()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string ERROR = $"{langue.Error}";
            return ERROR;
        }

        public int ScearchNbBackUp()
        {
            ConfigurationManager.RefreshSection("appSettings");
            string nbBackUp = ConfigurationManager.AppSettings["nbbackup"];
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

        public string testLanguage()
        {
            string result = File.ReadAllText(@"./text_en.json"); ;
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
