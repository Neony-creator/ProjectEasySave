﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text.Json;
using System.Configuration;
using System.Xml.Serialization;

namespace appWPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        public abstract Task ExecuteAsync(object parameter);
        public static long TotalsizeJson = 0;
        public static long TotalsizeXml = 0;
        Mutex mutex1 = new Mutex();
        Mutex mutex2 = new Mutex();
        Mutex mutexDailyJson = new Mutex();        
        Mutex mutexDailyXml = new Mutex();
        Mutex mutexStateXml = new Mutex();
        Mutex mutexStateJson = new Mutex();

        public override async void Execute(object parameter)
        {
            try
            {
                
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
            
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
                    Directory.CreateDirectory(destinationUpdate);
                    completeFile(Dir, destinationUpdate, name);
                    completeDirectory(Dir, destinationUpdate, name);

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
                    timeTransfert = sw.Elapsed.Milliseconds;

                    if (mutex1.WaitOne())
                    {
                        try
                        {
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
                                        ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                                        Console.WriteLine("c'est un succes");
                                    }
                                    else
                                    {
                                        ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, (timeTransfert) * -1);

                                        Console.WriteLine("error de copy");
                                    }
                                }
                            }
                        }
                        finally
                        {
                            mutex1.ReleaseMutex();

                        }


                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(dirNotFound.Message);
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


                        if (mutex2.WaitOne())
                        {
                            try
                            {
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
                                            Console.WriteLine("c'est un succes");
                                        }
                                        else
                                        {

                                            sw.Start();
                                            File.Copy(sourcePathFile, destinationPathFile, true);
                                            sw.Stop();
                                            timeTransfert = sw.Elapsed.Milliseconds;
                                            ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                                            Console.WriteLine("Le fichier ne correspond pas");

                                        }
                                    }

                                }
                            }
                            finally
                            {
                                mutex2.ReleaseMutex();

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
                        ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                        Console.WriteLine(dirNotFound.Message);
                        Console.WriteLine("Le fichier n'existe pas");
                    }
                }



            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                MessageBox.Show(dirNotFound.Message);
            }


        }


        public void ApplicatechoiceLog(string name, string sourceFile, string destinationFile, long size, double timeTransfert)
        {
            CreateJsonDaily(name, sourceFile, destinationFile, size, timeTransfert);
            CreateJsonState(name, sourceFile, destinationFile, size);          

            CreateXmlDaily(name, sourceFile, destinationFile, size, timeTransfert);

            CreateXmlState(name, sourceFile, destinationFile, size);

            /*switch (ConfigurationManager.AppSettings["logFormat"])
             {
                case "Json":
                    CreateJsonState(name, sourceFile, destinationFile, size);
                    CreateJsonDaily(name, sourceFile, destinationFile, size, timeTransfert);
                    break;

                case "Xml":

                    CreateXmlState(name, sourceFile, destinationFile, size);
                    CreateXmlDaily(name, sourceFile, destinationFile, size, timeTransfert);
                    break;

                case "JsonXml":
                    CreateJsonState(name, sourceFile, destinationFile, size);
                    CreateXmlState(name, sourceFile, destinationFile, size);
                    CreateJsonDaily(name, sourceFile, destinationFile, size, timeTransfert);
                    CreateXmlDaily(name, sourceFile, destinationFile, size, timeTransfert);
                    break;

                default:
                    CreateJsonState(name, sourceFile, destinationFile, size);
                    CreateXmlState(name, sourceFile, destinationFile, size);
                    CreateJsonDaily(name, sourceFile, destinationFile, size, timeTransfert);
                    CreateXmlDaily(name, sourceFile, destinationFile, size, timeTransfert);

                    break;
            }*/

        }

        public void countNbTotalFile(string name, string source)
        {
            try
            {

                int nbFile = 0;
                nbFile = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories).Length;
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("nbTotalFileXml" + name);
                config.AppSettings.Settings.Remove("newLog" + name);
                config.AppSettings.Settings.Remove("nbTotalFileJson" + name);
                config.AppSettings.Settings.Remove("nbTotalFilePerma" + name);
                config.AppSettings.Settings.Add("nbTotalFileJson" + name, nbFile.ToString());
                config.AppSettings.Settings.Add("newLog" + name, "true");
                config.AppSettings.Settings.Add("nbTotalFileXml" + name, nbFile.ToString());
                config.AppSettings.Settings.Add("nbTotalFilePerma" + name, nbFile.ToString());
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void CreateJsonDaily(string name, string sourceFile, string destinationFile, long size, double timeTransfert)
        {

            try
            {
                timeTransfert = timeTransfert * 0.001;
                List<dailyLog> listJsonDaily = new List<dailyLog>();
                if (mutexDailyJson.WaitOne())
                    try
                    {
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

                    finally
                    {
                        mutexDailyJson.ReleaseMutex();
                    }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Console.ReadLine();
            }

        }

        public void CreateJsonState(string name, string sourceFile, string destinationFile, long size)
        {
            string temp = ConfigurationManager.AppSettings["nbTotalFileJson" + name];
            string newLog = ConfigurationManager.AppSettings["newLog" + name];

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


            
            try
            {
                stateLog stateO = new stateLog();
                if (mutexStateJson.WaitOne())
                    try
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings.Remove("nbTotalFileJson" + name);
                        config.AppSettings.Settings.Add("nbTotalFileJson" + name, nbTotalFile.ToString());
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        List<stateLog> listJsonState = new List<stateLog>();
                        if (File.Exists("StateLog.json"))
                        {

                            var FileJsonRead = File.ReadAllText(@"StateLog.json");

                            var objectState = JsonSerializer.Deserialize<List<stateLog>>(FileJsonRead);


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
                                for (int i = 0; i < nb - 1; i++)
                                {
                                    listJsonState.Add(objectState[i]);
                                }


                            }
                        }



                        stateO.backUpName = name;
                        stateO.sourcePath = sourceFile;
                        stateO.destinationPath = destinationFile;
                        stateO.totalNumberOfFile = ConfigurationManager.AppSettings["nbTotalFilePerma" + name];
                        stateO.totalSize = TotalsizeJson;
                        if (nbTotalFile == 0)
                        {
                            state = "END";
                            TotalsizeJson = 0;
                        }
                        stateO.state = state;
                        stateO.totalNumberOfFileRemaining = nbTotalFile;
                        stateO.sizeRemaining = nbTotalFile;
                        stateO.timeStamp = DateTime.Now.ToString();


                        listJsonState.Add(stateO);


                        var json = JsonSerializer.Serialize(listJsonState, options: new() { WriteIndented = true });
                        File.WriteAllText(@"StateLog.json", json);
                        Console.WriteLine(json);
                        Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config2.AppSettings.Settings.Remove("newLog" + name);
                        config2.AppSettings.Settings.Add("newLog" + name, "false");
                        config2.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }

                    finally
                    {
                        mutexStateJson.ReleaseMutex();
                    }
                

            }
            catch (Exception e)
            {
              Console.WriteLine(e.ToString());
            }
        }



        public void CreateXmlDaily(string name, string sourceFile, string destinationFile, long size, double timeTransfert)
        {
            try
            {
                timeTransfert = timeTransfert * 0.001;
                List<dailyLog> listXmlDaily = new List<dailyLog>();
                XmlSerializer DeOrserializer = new XmlSerializer(typeof(List<dailyLog>));
                if (mutexDailyXml.WaitOne())
                    try
                    {
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
                    finally
                    {
                        mutexDailyXml.ReleaseMutex();
                    }
                    
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString()+"dailyxml");
                Console.ReadLine();
            }

        }


        public void CreateXmlState(string name, string sourceFile, string destinationFile, long size)
        {
            string temp = ConfigurationManager.AppSettings["nbTotalFileXml" + name];
            string newLog = ConfigurationManager.AppSettings["newLog" + name];
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
            if(mutexStateXml.WaitOne())
            {
                try
                {
                    nbTotalFile = nbTotalFile - 1;
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Remove("nbTotalFileXml" + name);
                    config.AppSettings.Settings.Add("nbTotalFileXml" + name, nbTotalFile.ToString());
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    List<stateLog> listXmlState = new List<stateLog>();
                    XmlSerializer DeOrserializer = new XmlSerializer(typeof(List<stateLog>));
                    
                        stateLog stateO = new stateLog();
                        if (File.Exists("stateLog.xml"))
                        {

                            using (var str = new FileStream("stateLog.xml", FileMode.Open))
                            {

                                var objectStatei = (List<stateLog>)DeOrserializer.Deserialize(str);
                                int nb = objectStatei.Count;

                                if (newLog == "false")
                                {
                                    stateO = objectStatei[nb - 1];

                                }
                                else
                                {
                                    nb = nb + 1;
                                }
                                if (nb != 0)
                                {
                                    for (int i = 0; i < nb - 1; i++)
                                    {
                                        listXmlState.Add(objectStatei[i]);
                                    }

                                }
                            }


                        }

                        stateO.backUpName = name;
                        stateO.sourcePath = sourceFile;
                        stateO.destinationPath = destinationFile;
                        stateO.totalNumberOfFile = ConfigurationManager.AppSettings["nbTotalFilePerma" + name];
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
                        config2.AppSettings.Settings.Remove("newLog" + name);
                        config2.AppSettings.Settings.Add("newLog" + name, "false");
                        config2.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

                finally
                {
                    mutexStateXml.ReleaseMutex();
                }
                
            }
            
        }

    }
}
