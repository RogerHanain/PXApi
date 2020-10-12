using DXProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace DXProject.Database
{
    public class UntranslatedWordsProvider
    {
        private readonly IDataProvider dataProvider;

        public UntranslatedWordsProvider(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        

        public IEnumerable<string> GetAll()
        {
            var allWords = dataProvider.GetAll<Word>().Select(w => w.Name);

            var allDistinctsTranslations = dataProvider.GetAll<Translation>().Select(t => t.Word).Distinct();

            var wordsNotAlreadyPresentInTranslation = allWords.Where(w => !allDistinctsTranslations.Contains(w));

            return wordsNotAlreadyPresentInTranslation;
        }
    }
}
