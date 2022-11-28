using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace ProjetEasySaveCLI
{
    class modelExecuteBackupJob : modelMain
    {
        public string GetFirstMenuData()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string FIRST_MENU = $"{langue.MenuExecuteBackupJob}";
            return FIRST_MENU;
        }
    }
}
