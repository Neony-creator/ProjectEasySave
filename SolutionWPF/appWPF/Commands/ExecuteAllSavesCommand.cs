using appWPF.Stores;
using SaveDomain.Models;
using SaveDomain.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace appWPF.Commands
{
    public class ExecuteAllSavesCommand : AsyncCommandBase
    {
        private readonly SavesStore _saveStore;

        Mutex mutex1 = new Mutex();
        Mutex mutex2 = new Mutex();

        public ExecuteAllSavesCommand(SavesStore savesStore)
        {
            _saveStore = savesStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {

            List<Task> tasks = new List<Task>();



            foreach (Save save in _saveStore.Saves)
            {
                string name = save.SaveName;
                string source = save.SourceDisplay;
                string destination = save.DestinationDisplay;
                string typeOfBackUp = save.TypeDisplay;


                if (typeOfBackUp == "complete")
                {
                    tasks.Add(Task.Run(() => completeFile(source, destination, name)));
                    tasks.Add(Task.Run(() => completeDirectory(source, destination, name)));

                }
                else if (typeOfBackUp == "differential")
                {
                    tasks.Add(Task.Run(() => differentialFile(source, destination, name)));
                    tasks.Add(Task.Run(() => differentialDirectory(source, destination, name)));

                }

            }

            await Task.WhenAll(tasks);
        }


        ////////////////////////////////////////////////////////////


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

                    Stopwatch sw = new Stopwatch();
                    sw.Start();                    
                    File.Copy(Path.Combine(source, fName), Path.Combine(destination, fName), true);                    
                    sw.Stop();
                    timeTransfert = sw.Elapsed.Milliseconds;

                    if (mutex1.WaitOne())
                    {
                        try
                        {
                            using (FileStream FileS = new FileStream(Path.Combine(source, fName), FileMode.Open))
                            {
                                using (FileStream FileD = new FileStream(Path.Combine(destination, fName), FileMode.Open))
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
                                        /*log.CreateJsonState(name, source, destination, size);
                                        log.CreateJsonDaily(name, source, destination, size, timeTransfert);*/
                                        Console.WriteLine("c'est un succes");
                                    }
                                    else
                                    {
                                        /*log.CreateJsonDaily(name, source, destination, size, (timeTransfert) * -1);
                                        log.CreateJsonState(name, source, destination, size);*/
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


                        if (mutex2.WaitOne())
                        {
                            try
                            {
                                using (FileStream FileS = new FileStream(Path.Combine(source, fName), FileMode.Open))
                                {
                                    using (FileStream FileD = new FileStream(Path.Combine(destination, fName), FileMode.Open))
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
                                            File.Copy(Path.Combine(source, fName), Path.Combine(destination, fName), true);
                                            sw.Stop();
                                            timeTransfert = sw.Elapsed.Milliseconds;
                                            /*log.CreateJsonDaily(name, source, destination, size, timeTransfert);
                                            log.CreateJsonState(name, source, destination, size);*/
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
                        FileInfo infofi = new FileInfo(file);
                        size = infofi.Length;
                        sw.Start();
                        File.Copy(Path.Combine(source, fName), Path.Combine(destination, fName), true);
                        sw.Stop();
                        timeTransfert = sw.Elapsed.Milliseconds;
                        /*log.CreateJsonDaily(name, source, destination, size, timeTransfert);
                        log.CreateJsonState(name, source, destination, size);*/
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


        ////////////////////////////////////////////////////////////
    }
}