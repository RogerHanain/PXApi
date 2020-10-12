using DXProject.Models;
using System.ComponentModel;

namespace AXAdminApplication
{
    public class TranslationUI : INotifyPropertyChanged
    {
        public string Word => translation.Word;
        public string Example => translation.Example;
        public string FrenchTranslation => translation.FrenchTranslations;


        private readonly Translation translation;

        public TranslationUI(Translation t)
        {
            translation = t;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
