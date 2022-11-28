using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;


namespace ProjetEasySaveCLI
{
    class modelLogs : modelMain
    {
        public string GetFirstMenuData()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_LOGS = $"{langue.MenuLogs}";
            return MENU_LOGS;
        }

    }
}
