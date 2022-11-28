using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace ProjetEasySaveCLI
{
    class modelMain
    {
        private string configLanguage = "en";
        public string ConfigLanguage
        {
            get { return configLanguage; }
            set { configLanguage = value; }
        }


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
