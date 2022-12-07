using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Configuration;
using System.Xml.Serialization;

namespace ProjetEasySaveCLI
{
    class modelLogs : modelMain //Herite de modelMain
    {
        public static long  TotalsizeJson=0;
        public static long  TotalsizeXml=0;
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
                if (File.Exists("DailyLog.json"))
                {
                    var FileJsonRead = File.ReadAllText("DailyLog.json");
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
                File.WriteAllText("DailyLog.json", json);
                Console.WriteLine(json);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }

        public void CreateJsonState(string name, string sourceFile, string destinationFile, long size)
        {
            string temp = ConfigurationManager.AppSettings["nbTotalFileJson"];
            string newLog = ConfigurationManager.AppSettings["newLog"];

            TotalsizeJson = size + TotalsizeJson;
            string state = "Actif";
            int nbTotalFile = 0;
            try
            {
                nbTotalFile = int.Parse(temp);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            nbTotalFile = nbTotalFile - 1;
            

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("nbTotalFileJson");
            config.AppSettings.Settings.Add("nbTotalFileJson", nbTotalFile.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            List<stateLog> listJsonState = new List<stateLog>();
            try
            {
                stateLog stateO = new stateLog();
                if (File.Exists("StateLog.json"))
                {
              
                    var FileJsonRead = File.ReadAllText(@"StateLog.json");
                
                    var objectState = JsonSerializer.Deserialize<List<stateLog>>(FileJsonRead);


                    int nb = objectState.Count;
                    if(newLog=="false")
                    {
                        stateO = objectState[nb - 1];
                        
                    }
                    else
                    {
                        nb = nb + 1;
                    }
                    if(nb!=0)
                        {
                            for (int i = 0; i < nb - 1; i++)
                            {
                                listJsonState.Add(objectState[i]);
                            }

                            
                        }                    
                }              
            

            
            stateO.backUpName = name;
            stateO.sourcePath = sourceFile;
            stateO.destinationPath = destinationFile;            
            stateO.totalNumberOfFile = ConfigurationManager.AppSettings["nbTotalFilePerma"];
            stateO.totalSize = TotalsizeJson ;
                if (nbTotalFile == 0)
                {
                    state = "END";
                    TotalsizeJson = 0;
                }
            stateO.state = state;
            stateO.totalNumberOfFileRemaining = nbTotalFile ; 
            stateO.sizeRemaining = nbTotalFile;
            stateO.timeStamp = DateTime.Now.ToString();
            

            listJsonState.Add(stateO);


            var json = JsonSerializer.Serialize(listJsonState, options: new() { WriteIndented = true });
            File.WriteAllText(@"StateLog.json", json);
            Console.WriteLine(json);
            Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config2.AppSettings.Settings.Remove("newLog");
            config2.AppSettings.Settings.Add("newLog", "false");
            config2.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
                
            }
                catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

       

        public void CreateXmlDaily(string name, string sourceFile, string destinationFile, long size, double timeTransfert)
        {
            try
            {
                timeTransfert = timeTransfert * 0.001;
                List<dailyLog> listXmlDaily = new List<dailyLog>();
                XmlSerializer DeOrserializer = new XmlSerializer(typeof(List<dailyLog>));
                if (File.Exists("DailyLog.xml"))
                {
                    
                    using (var str = new FileStream("dailyLog.xml", FileMode.Open))
                    {
                        listXmlDaily = (List<dailyLog>)DeOrserializer.Deserialize(str);
                    }
                }
                dailyLog daily = new dailyLog();
                daily.backUpName = name;
                daily.sourcePathFile = sourceFile;
                daily.destinationPathFile = destinationFile;
                daily.size = size;
                daily.timetransfert = timeTransfert;
                daily.timestamp = DateTime.Now.ToString();

                listXmlDaily.Add(daily);

                using (var str = new FileStream("dailyLog.xml", FileMode.Create))
                {
                    DeOrserializer.Serialize(str, listXmlDaily);
                }

                ;
                Console.WriteLine(listXmlDaily);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }


        public void CreateXmlState(string name, string sourceFile, string destinationFile, long size)
        {
            string temp = ConfigurationManager.AppSettings["nbTotalFileXml"];
            string newLog = ConfigurationManager.AppSettings["newLog"];
            TotalsizeXml = size + TotalsizeXml;
            string state = "Actif";
            int nbTotalFile = 0;
            try
            {
                nbTotalFile = int.Parse(temp);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            nbTotalFile = nbTotalFile - 1;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("nbTotalFileXml");
            config.AppSettings.Settings.Add("nbTotalFileXml", nbTotalFile.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            List<stateLog> listXmlState = new List<stateLog>();
            XmlSerializer DeOrserializer = new XmlSerializer(typeof(List<stateLog>));
            try
            {
                stateLog stateO = new stateLog();
                if (File.Exists("stateLog.xml"))
                {

                    using (var str = new FileStream("stateLog.xml", FileMode.Open))
                    {

                        var objectState = (List<stateLog>)DeOrserializer.Deserialize(str);
                        int nb = objectState.Count;

                        if (newLog == "false")
                        {
                            stateO = objectState[nb - 1];

                        }
                        else
                        {
                            nb = nb + 1;
                        }
                        if (nb != 0)
                        {
                            for (int i = 0; i < nb -1; i++)
                            {
                                listXmlState.Add(objectState[i]);
                            }

                        }
                    }
                    

                }

                stateO.backUpName = name;
                stateO.sourcePath = sourceFile;
                stateO.destinationPath = destinationFile;
                stateO.totalNumberOfFile = ConfigurationManager.AppSettings["nbTotalFilePerma"];
                stateO.totalSize = TotalsizeXml;
                if (nbTotalFile == 0)
                {
                    state = "END";
                    TotalsizeXml = 0;
                }
                stateO.state = state;
                stateO.totalNumberOfFileRemaining = nbTotalFile;
                stateO.sizeRemaining = nbTotalFile;
                stateO.timeStamp = DateTime.Now.ToString();


                listXmlState.Add(stateO);
                     
                using (var str = new FileStream("stateLog.xml", FileMode.Create))
                {
                    DeOrserializer.Serialize(str, listXmlState);
                }
                

                Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config2.AppSettings.Settings.Remove("newLog");
                config2.AppSettings.Settings.Add("newLog", "false");
                config2.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
