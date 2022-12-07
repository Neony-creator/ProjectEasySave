using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Configuration;


namespace WPF.Models
{
    class modelMain
    {

        public int ScearchNbBackUp() //On crée une fonction qui permet de connaître le nombre de backup déjà créé
        {
            ConfigurationManager.RefreshSection("appSettings"); //on actualise notre fichier config, afin d'être sûr qu'il soit à jour
            string nbBackUp = ConfigurationManager.AppSettings["nbbackup"]; //On récupére la valeur correspondant à l'ID "nbbackup"
            int result = 0;
            try
            {
                result = int.Parse(nbBackUp);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }


    }
}
