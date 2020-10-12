using DXProject.Models;
using System.Collections.ObjectModel;

namespace AXAdminApplication
{
    public class Translations : ObservableCollection<TranslationUI>
    {
        public Translations()
        {
            Add(new TranslationUI(new Translation() { Word = "blabla" }));
        }
    }
}
