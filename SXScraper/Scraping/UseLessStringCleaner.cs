using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SXScraper.Scraping
{
    public interface IUseLessStringCleaner
    {
        string Clean(string s);
    }

    public class UseLessStringCleaner : IUseLessStringCleaner
    {
        private List<string> uselessStrings;
        public UseLessStringCleaner()
        {
            uselessStrings = new List<string>();
            PopulateUseLessStrings();
        }

        private void PopulateUseLessStrings()
        {
            uselessStrings.Add(" nnoun: Refers to person, place, thing, quality, etc.");
            uselessStrings.Add(" adjadjective: Describes a noun or pronoun--for example, \"a tall girl,\" \"an interesting book,\" \"a big house.\"");
            uselessStrings.Add(" advadverb: Describes a verb, adjective, adverb, or clause--for example, \"come quickly,\" \"very rare,\"  \"happening now,\" \"fall down.\"");
            uselessStrings.Add("⇒ vtrverbe transitif: verbe qui s'utilise avec un complément d'objet direct (COD). Ex : \"J'écris une lettre\". \"Elle a retrouvé son chat\".");

            uselessStrings.Add(" nmnom masculin: s'utilise avec les articles \"le\", \"l'\" (devant une voyelle ou un h muet), \"un\". Ex : garçon - nm > On dira \"le garçon\" ou \"un garçon\". ");
            uselessStrings.Add(" nmnom masculin: s'utilise avec les articles \"le\", \"l'\" (devant une voyelle ou un h muet), \"un\". Ex : garçon - nm &gt; On dira \"le garçon\" ou \"un garçon\". ");
            uselessStrings.Add(" nfnom féminin: s'utilise avec les articles \"la\", \"l'\" (devant une voyelle ou un h muet), \"une\". Ex : fille - nf > On dira \"la fille\" ou \"une fille\". Avec un nom féminin, l'adjectif s'accorde. En général, on ajoute un \"e\" à l'adjectif. Par exemple, on dira \"une petite fille\".");
            uselessStrings.Add(" nfnom féminin: s'utilise avec les articles \"la\", \"l'\" (devant une voyelle ou un h muet), \"une\". Ex : fille - nf &gt; On dira \"la fille\" ou \"une fille\". Avec un nom féminin, l'adjectif s'accorde. En général, on ajoute un \"e\" à l'adjectif. Par exemple, on dira \"une petite fille\".");
        }

        public string Clean(string s)
        {
            var result = s;
            foreach (var item in uselessStrings)
            {
                if (!s.Contains(item)) continue;
                result = result.Replace(item, "");
            }
            return result;
        }
    }
}
