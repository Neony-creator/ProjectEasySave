using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;


namespace ProjetEasySaveCLI
{
    class modelLogs : modelMain //Herite de modelMain
    {
        public string GetFirstMenuData()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_LOGS = $"{langue.MenuLogs}";
            return MENU_LOGS;
           
        }
        public void CreateJsonDaily(string name, string sourceFile, string destinationFile, long size, double timeTransfert)
        {
            try
            {
                timeTransfert = timeTransfert * 0.001;
                List<dailyLog> listJsonDaily = new List<dailyLog>();
                if (File.Exists("JsonDailyLog.json"))
                {
                    var FileJsonRead = File.ReadAllText("JsonDailyLog.json");
                    var objectDaily = JsonSerializer.Deserialize<List<dailyLog>>(FileJsonRead);
                    foreach (var Jso in objectDaily)
                    {
                        listJsonDaily.Add(Jso);
                    }
                }
                dailyLog daily = new dailyLog();
                daily.backUpName = name;
                daily.sourcePathFile = sourceFile;
                daily.destinationPathFile = destinationFile;
                daily.size = size;
                daily.timetransfert = timeTransfert;
                daily.timestamp = DateTime.Now.ToString();

                listJsonDaily.Add(daily);


                var json = JsonSerializer.Serialize(listJsonDaily, options: new() { WriteIndented = true });
                File.AppendAllText("DailyLog.json", json);
                Console.WriteLine(json);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }

        public void CreateJsonState(string name, string sourceFile, string destinationFile, string state, int totalFileToCopy, long TotalFileSize, int NbFileLeftToDo , long SizeFileLeftToDo)
        {
            List<stateLog> listJsonState = new List<stateLog>();
            if (File.Exists("StateLog.json"))
            {
                var FileJsonRead = File.ReadAllText(@"StateLog.json");
                var objectState = JsonSerializer.Deserialize<List<stateLog>>(FileJsonRead);
                int nb = objectState.Count;
                ;
                foreach (var Jss in objectState)
                {
                    listJsonState.Add(Jss);
                }
            }
            stateLog stateO = new stateLog();
            stateO.backUpName = name;
            stateO.sourcePath = sourceFile;
            stateO.destinationPath = destinationFile;
            stateO.state = state;
            stateO.totalNumberOfFile = totalFileToCopy;
            stateO.totalSize = TotalFileSize;
            stateO.totalNumberOfFileRemaining = NbFileLeftToDo;
            stateO.sizeRemaining =SizeFileLeftToDo;
            

            listJsonState.Add(stateO);


            var json = JsonSerializer.Serialize(listJsonState, options: new() { WriteIndented = true });
            File.AppendAllText(@"StateLog.json", json);
            Console.WriteLine(json);

        }

    }
}
