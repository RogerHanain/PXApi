using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXProject.Splitting
{
    /// <summary>
    /// Splits the content of a string into words
    /// </summary>
    public class WordSplitter
    {
        public static char[] SPLIT_CARACTERS = { ' ', '\n', '\r' };
        //public static char[] TRIM_CARACTERS = { ',', '.', ' ', '"', '“', '”', '$', '%', ']', '[', '(', ')', '’', '‘' };
        public static string[] REMOVE_CARACTERS = {"♪", "!", "?", "<i>", "</i>", "/", "-", ">", ":", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ",", ".", "\"", @"“", @"”", @"$", "%", "]", "[", "(", ")", "’", "‘" };


        private string content;
        public WordSplitter(string content)
        {
            this.content = content;
        }

        public List<string> Split()
        {
            var l = new List<string>();

            foreach (var word in content.Split(SPLIT_CARACTERS))
            {
                string w = word;
                foreach (var item in REMOVE_CARACTERS)
                {
                    w = w.Replace(item, "");
                }
                w = w.Trim();
                if (w != "") l.Add(w);
            }
            return l;
        }
    }
}
