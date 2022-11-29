﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace ProjetEasySaveCLI
{
    class modelBackupJob : modelMain
    {


        public string GetFirstMenuData()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string FIRST_MENU = $"{langue.MenuSave}";
            return FIRST_MENU;
        }
        
        public string GetName()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string NAME = $"{langue.Name}";
            return NAME;
        }
        
        public string GetSource()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string SOURCE = $"{langue.Source}";
            return SOURCE;
        }

        public string GetDestination()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string DESTINATION = $"{langue.Destination}";
            return DESTINATION;
        }

        public string GetTypeBackUp()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string TYPE_BACKUP = $"{langue.Type_Backup}";
            return TYPE_BACKUP;
        }
        
        public string GetConfirmation()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string CONFIRMATION = $"{langue.Confirmation}";
            return CONFIRMATION;
        }

        public string GetErrorNB()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string ERROR_NB_BACK_UP = $"{langue.ErrorNB}";
            return ERROR_NB_BACK_UP;
        }

        public string MenuExecute()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_EXECUTE = $"{langue.MenuExecute}";
            return MENU_EXECUTE;
        }

        public string MenuModiff()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_MODIFF = $"{langue.MenuModiff}";
            return MENU_MODIFF;
        }

        public string MenuSuppr()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_SUPPR = $"{langue.MenuSuppr}";
            return MENU_SUPPR;
        }


    }
}
