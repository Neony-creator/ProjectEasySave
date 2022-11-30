using System;
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
            string MENU_NAME = $"{langue.Name}";
            return MENU_NAME;
        }
        
        public string GetSource()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_SOURCE = $"{langue.Source}";
            return MENU_SOURCE;
        }

        public string GetDestination()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_DESTINATION = $"{langue.Destination}";
            return MENU_DESTINATION;
        }

        public string GetTypeBackUp()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_TYPE_BACKUP = $"{langue.Type_Backup}";
            return MENU_TYPE_BACKUP;
        }
        
        public string GetConfirmation()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_CONFIRMATION = $"{langue.Confirmation}";
            return MENU_CONFIRMATION;
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

        public string Backup1()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string BACKUP1 = $"{langue.Backup1}";
            return BACKUP1;
        }

        public string Backup2()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string BACKUP2 = $"{langue.Backup2}";
            return BACKUP2;
        }

        public string Backup3()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string BACKUP3 = $"{langue.Backup3}";
            return BACKUP3;
        }

        public string Backup4()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string BACKUP4 = $"{langue.Backup4}";
            return BACKUP4;
        }

        public string Backup5()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string BACKUP5 = $"{langue.Backup5}";
            return BACKUP5;
        }


        public string Return()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string BACK = $"{langue.Return}";
            return BACK;
        }





        public string MenuModiff()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_MODIFF = $"{langue.MenuModiff}";
            return MENU_MODIFF;
        }

        public string MenuDelete()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_SUPPR = $"{langue.MenuSuppr}";
            return MENU_SUPPR;
        }

        public string ValidateCreate()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string VALIDATION = $"{langue.ValidCreateBackup}";
            return VALIDATION;
        }

        public string ErrorCreate()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string ERROR_CREATE = $"{langue.ErrorCreateBackup}";
            return ERROR_CREATE;
        }


    }
}