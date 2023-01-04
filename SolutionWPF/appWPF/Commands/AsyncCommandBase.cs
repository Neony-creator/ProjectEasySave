using System;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace appWPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {

        Mutex mutex1 = new Mutex();
        Mutex mutex2 = new Mutex();
        public override async void Execute(object parameter)
        {
            try
            {
                MessageBox.Show("commun await");
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
            
        }

        public void completeDirectory(string source, string destination, string name)
        {
            MessageBox.Show("test");
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
                                        //log.ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, timeTransfert);
                                        Console.WriteLine("c'est un succes");
                                    }
                                    else
                                    {
                                        //log.ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, (timeTransfert) * -1);

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
                                            //log.ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, timeTransfert);
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
                        //log.ApplicatechoiceLog(name, sourcePathFile, destinationPathFile, size, timeTransfert);
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


        public abstract Task ExecuteAsync(object parameter);
    }
}
