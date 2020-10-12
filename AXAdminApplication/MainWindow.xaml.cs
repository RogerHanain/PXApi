using DXProject.Database;
using DXProject.Models;
using DXProject.Scraping;
using NUnit.Framework;
using SXDatabase;
using SXScraper;
using SXScraper.Scraping;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace AXAdminApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //FIELDS
        private DatabaseConnector dataAccesser;
        public static Translations translationsList = new Translations();
        DispatcherTimer timer = new DispatcherTimer();

        //PROPERTIES

        //CONSTRUCTOR
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            dataAccesser = new DatabaseConnector();
        }

        //METHODS
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.comingWordList.ItemsSource = translationsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var scraper = new WordReferenceScraper(new HtmlDocumentFactory(), new WordReferenceURLBuilder(), new CaretAnalyser(new UseLessStringCleaner()));
            translationsList.Clear();

            var dataProvider = new DataProvider(dataAccesser.ConnectToDB());

            var untranslatedWords = new UntranslatedWordsProvider(dataProvider).GetAll().ToList();

            var translationProvider = new TranslationProvider(scraper);

            translationsList.Add(new TranslationUI(translationProvider.GetTranslations(untranslatedWords[0]) as Translation));
         
            translationsList.Add(new TranslationUI(translationProvider.GetTranslations(untranslatedWords[1]) as Translation));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //dataAccesser.StoreAll(MissingTranslations.ToList());
        }
    }
}
