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

        public string testLanguage()
        {
            string result = "";
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
