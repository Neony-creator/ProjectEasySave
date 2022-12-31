
using appWPF.Stores;
using appWPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using SaveDomain.Commands;
using SaveDomain.Queries;
using SaveEntityFramework;
using SaveEntityFramework.Commands;
using SaveEntityFramework.Queries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace appWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ResourceDictionary obj;

        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SavesDbContextFactory _savesDbContextFactory;
        private readonly IGetAllSavesQuery _getAllSavesQuery;
        private readonly ICreateSaveCommand _createSaveCommand;
        private readonly IUpdateSaveCommand _updateSaveCommand;
        private readonly IDeleteSaveCommand _deleteSaveCommand;
        private readonly SavesStore _savesStore;
        private readonly SelectedSaveStore _selectedSaveStore;
        public App()
        {


            string connectionString = "Data Source=Saves.db";

            _modalNavigationStore = new ModalNavigationStore();
            _savesDbContextFactory = new SavesDbContextFactory(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            _getAllSavesQuery = new GetAllSavesQuery(_savesDbContextFactory);
            _createSaveCommand = new CreateSaveCommand(_savesDbContextFactory);
            _updateSaveCommand = new UpdateSaveCommand(_savesDbContextFactory);
            _deleteSaveCommand = new DeleteSaveCommand(_savesDbContextFactory);
            _savesStore = new SavesStore(_getAllSavesQuery, _createSaveCommand, _updateSaveCommand, _deleteSaveCommand);
            _selectedSaveStore = new SelectedSaveStore(_savesStore);
            //
            

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (SavesDbContext context = _savesDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            SavesViewModel savesViewModel = new SavesViewModel(_savesStore, _selectedSaveStore, _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, savesViewModel)
            };
            MainWindow.Show();

            foreach (ResourceDictionary item in this.Resources.MergedDictionaries)
            {
                if (item.Source != null && item.Source.OriginalString.Contains(@"Resources\"))
                {
                    obj = item;
                }
            }


            base.OnStartup(e);
        }


        public void ChangeLangage(Uri dictionnaryUri)
        {
            if (String.IsNullOrEmpty(dictionnaryUri.OriginalString) == false)
            {
                ResourceDictionary objNewLanguageDictionary = (ResourceDictionary)(LoadComponent(dictionnaryUri));

                if (objNewLanguageDictionary != null)
                {
                    this.Resources.MergedDictionaries.Remove(obj);
                    this.Resources.MergedDictionaries.Add(objNewLanguageDictionary);

                    CultureInfo culture = new CultureInfo((string)Application.Current.Resources["Culture"]);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }
        }

    }
}
