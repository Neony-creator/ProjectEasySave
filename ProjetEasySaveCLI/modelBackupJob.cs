using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Configuration;

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

        public void completeDirectory(string source, string destination)
        {
            try
            {
                string[] DirectoryList = Directory.GetDirectories(source);


                // Copy picture files.
                foreach (string Dir in DirectoryList)
                {
                    // Remove path from the file name.
                    string DName = Dir;
                    string DdestName = Dir.Substring(source.Length);
                    string destinationUpdate = destination + DdestName;
                    Console.WriteLine(Dir);
                    Console.WriteLine(DdestName);
                    Console.WriteLine(destinationUpdate);
                    Directory.CreateDirectory(destinationUpdate);
                    completeFile(Dir, destinationUpdate);
                    completeDirectory(Dir, destinationUpdate);

                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.

                }


            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }


        }

        public void completeFile(string source, string destination)
        {
            try
            {
                Directory.CreateDirectory(destination);
                string[] FileList = Directory.GetFiles(source);



                // Copy picture files.
                foreach (string file in FileList)
                {
                    // Remove path from the file name.
                    string fName = file.Substring(source.Length + 1);
                    int file1byte;
                    int file2byte;


                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.

                    File.Copy(Path.Combine(source, fName), Path.Combine(destination, fName), true);

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
                                Console.WriteLine("errorrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr");
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

        public void differentialDirectory(string source, string destination)
        {
            try
            {
                string[] DirectoryList = Directory.GetDirectories(source);


                // Copy picture files.
                foreach (string Dir in DirectoryList)
                {
                    // Remove path from the file name.
                    string DName = Dir;
                    string DdestName = Dir.Substring(source.Length);
                    string destinationUpdate = destination + DdestName;
                    Console.WriteLine(Dir);
                    Console.WriteLine(DdestName);
                    Console.WriteLine(destinationUpdate);
                    Directory.CreateDirectory(destinationUpdate);
                    differentialFile(Dir, destinationUpdate);
                    differentialDirectory(Dir, destinationUpdate);

                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.

                }


            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }


        }

        public void differentialFile(string source, string destination)
        {
            try
            {
                Directory.CreateDirectory(destination);
                string[] FileList = Directory.GetFiles(source);




                // Copy picture files.
                foreach (string file in FileList)
                {
                    try
                    {
                        // Remove path from the file name.
                        string fName = file.Substring(source.Length + 1);
                        int file1byte;
                        int file2byte;


                        // Use the Path.Combine method to safely append the file name to the path.
                        // Will overwrite if the destination file already exists.


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
                                    File.Copy(Path.Combine(source, fName), Path.Combine(destination, fName), true);
                                    Console.WriteLine("Le fichier ne correspond pas");
                                }
                            }

                        }

                    }

                    catch (FileNotFoundException dirNotFound)
                    {
                        string fName = file.Substring(source.Length + 1);
                        File.Copy(Path.Combine(source, fName), Path.Combine(destination, fName), true);
                        Console.WriteLine(dirNotFound.Message);
                        Console.WriteLine("Lefichier n'existe pas");
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
            for (int i = 0; i <= ScearchNbBackUp(); i++)
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