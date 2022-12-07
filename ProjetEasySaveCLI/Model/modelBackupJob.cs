using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using System.Configuration;

namespace ProjetEasySaveCLI
{
    
    class modelBackupJob : modelMain //Herite de modelMain
    {
        modelLogs log = new modelLogs();

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

        public string Backup()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string BACKUP = $"{langue.Backup}";
            return BACKUP;
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
            string MENU_MODIFF = $"{langue.MenuModif2}";
            return MENU_MODIFF;
        }
        public string MenuModif1()
        {
            languageDeserialization langue = JsonSerializer.Deserialize<languageDeserialization>(testLanguage());
            string MENU_MODIF1 = $"{langue.MenuModif1}";
            return MENU_MODIF1;
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


        public void countNbTotalFile(string source)
        {
            try
            {
                 
                int nbFile = 0;            
                nbFile = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories).Length;
                Console.WriteLine(nbFile);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("nbTotalFileXml");
                config.AppSettings.Settings.Remove("newLog");
                config.AppSettings.Settings.Remove("nbTotalFileJson");
                config.AppSettings.Settings.Remove("nbTotalFilePerma");
                config.AppSettings.Settings.Add("nbTotalFileJson", nbFile.ToString());
                config.AppSettings.Settings.Add("newLog", "true");
                config.AppSettings.Settings.Add("nbTotalFileXml", nbFile.ToString());
                config.AppSettings.Settings.Add("nbTotalFilePerma", nbFile.ToString());
                Console.ReadLine();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            } 
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
       


        
     

        public void completeDirectory(string source, string destination, string name)
        {
            try
            {
                string[] DirectoryList = Directory.GetDirectories(source);



                foreach (string Dir in DirectoryList)
                {
                   
                    string DName = Dir;
                    string DdestName = Dir.Substring(source.Length);
                    string destinationUpdate = destination + DdestName;
                    Console.WriteLine(Dir);
                    Console.WriteLine(DdestName);
                    Console.WriteLine(destinationUpdate);
                    Directory.CreateDirectory(destinationUpdate);
                    completeFile(Dir, destinationUpdate,name);
                    completeDirectory(Dir, destinationUpdate,name);                 

                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }

        }

        public void completeFile(string source, string destination, string name)
        {
            try
            {
                
                Directory.CreateDirectory(destination);
                string[] FileList = Directory.GetFiles(source);

                double timeTransfert;
                long size;
                
                foreach (string file in FileList)
                {
                    FileInfo infofi = new FileInfo(file);
                    size = infofi.Length;
                    string fName = file.Substring(source.Length + 1);
                    int file1byte;
                    int file2byte;
                    string sourcePathFile = Path.Combine(source, fName);
                    string destinationPathFile = Path.Combine(destination, fName);

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    File.Copy(sourcePathFile, destinationPathFile, true);
                    sw.Stop();
                    timeTransfert= sw.Elapsed.Milliseconds;    
                    
                    using (FileStream FileS = new FileStream(sourcePathFile, FileMode.Open))
                    {
                        using (FileStream FileD = new FileStream(destinationPathFile, FileMode.Open))
                        {
                            do
                            {
                                file1byte = FileS.ReadByte();
                                file2byte = FileD.ReadByte();
                            }
                            while ((file1byte == file2byte) && (file1byte != -1));
                            FileS.Close();
                            FileD.Close();
                            if ((file1byte - file2byte) == 0)
                            {
                                log.CreateJsonState(name, sourcePathFile, destinationPathFile, size);
                                log.CreateXmlState(name, sourcePathFile, destinationPathFile, size);
                                log.CreateJsonDaily(name, sourcePathFile, destinationPathFile, size,timeTransfert);
                                log.CreateXmlDaily(name, sourcePathFile, destinationPathFile, size,timeTransfert);
                                Console.WriteLine("c'est un succes");
                            }
                            else
                            {
                                log.CreateJsonDaily(name, sourcePathFile, destinationPathFile, size, (timeTransfert)*-1);
                                log.CreateXmlDaily(name, sourcePathFile, destinationPathFile, size, (timeTransfert)*-1);
                                log.CreateJsonState(name, sourcePathFile, destinationPathFile, size);
                                log.CreateXmlState(name, sourcePathFile, destinationPathFile, size);
                                Console.WriteLine("error de copy");
                            }
                        }
                    }
                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }



        }

        public void differentialDirectory(string source, string destination, string name)
        {
            try
            {
                string[] DirectoryList = Directory.GetDirectories(source);                
                foreach (string Dir in DirectoryList)
                {
                    
                    string DName = Dir;
                    string DdestName = Dir.Substring(source.Length);
                    string destinationUpdate = destination + DdestName;
                    Console.WriteLine(Dir);
                    Console.WriteLine(DdestName);
                    Console.WriteLine(destinationUpdate);
                    Directory.CreateDirectory(destinationUpdate);
                    differentialFile(Dir, destinationUpdate, name);
                    differentialDirectory(Dir, destinationUpdate, name);

                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }


        }

        public void differentialFile(string source, string destination, string name)
        {
            try
            {
                Directory.CreateDirectory(destination);
                string[] FileList = Directory.GetFiles(source);

                double timeTransfert;
                long size;
                Stopwatch sw = new Stopwatch();

                foreach (string file in FileList)
                {
                    try
                    {
                        FileInfo infofi = new FileInfo(file);
                        size = infofi.Length;
                        string fName = file.Substring(source.Length + 1);
                        int file1byte;
                        int file2byte;

                        string sourcePathFile = Path.Combine(source, fName);
                        string destinationPathFile = Path.Combine(destination, fName);


                        using (FileStream FileS = new FileStream(sourcePathFile , FileMode.Open))
                        {
                            using (FileStream FileD = new FileStream(destinationPathFile , FileMode.Open))
                            {
                                do
                                {
                                    file1byte = FileS.ReadByte();
                                    file2byte = FileD.ReadByte();
                                }
                                while ((file1byte == file2byte) && (file1byte != -1));
                                FileS.Close();
                                FileD.Close();
                                if ((file1byte - file2byte) == 0)
                                {
                                    Console.WriteLine("c'est un succes");
                                }
                                else
                                {
                                    
                                    sw.Start();
                                    File.Copy(sourcePathFile, destinationPathFile, true);
                                    sw.Stop();
                                    timeTransfert = sw.Elapsed.Milliseconds;                                    
                                    log.CreateJsonDaily(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                                    log.CreateJsonState(name, sourcePathFile, destinationPathFile, size);
                                    log.CreateXmlDaily(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                                    log.CreateXmlState(name, sourcePathFile, destinationPathFile, size);
                                    Console.WriteLine("Le fichier ne correspond pas");

                                }
                            }

                        }

                    }

                    catch (FileNotFoundException dirNotFound)
                    {
                        string fName = file.Substring(source.Length + 1);
                        string sourcePathFile = Path.Combine(source, fName);
                        string destinationPathFile = Path.Combine(destination, fName);
                        FileInfo infofi = new FileInfo(file);
                        size = infofi.Length;                        
                        sw.Start();
                        File.Copy(sourcePathFile, destinationPathFile, true);
                        sw.Stop();
                        timeTransfert = sw.Elapsed.Milliseconds;                        
                        log.CreateJsonDaily(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                        log.CreateXmlDaily(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                        log.CreateJsonState(name, sourcePathFile, destinationPathFile, size);
                        log.CreateXmlState(name, sourcePathFile, destinationPathFile, size);
                        Console.WriteLine(dirNotFound.Message);
                        Console.WriteLine("Le fichier n'existe pas");
                    }
                }



            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }


        }

        public void affiche()
        {
            Console.Clear();
            for (int i = 1; i <= ScearchNbBackUp(); i++)
            {
                Console.WriteLine(i+Backup()+i+" :");

                Console.WriteLine(ConfigurationManager.AppSettings["Name" + i]);
                Console.WriteLine(ConfigurationManager.AppSettings["Source" + i]);
                Console.WriteLine(ConfigurationManager.AppSettings["Destination" + i]);
                Console.WriteLine(ConfigurationManager.AppSettings["TypeOfBackUp" + i]);


            }
        }

    }
}