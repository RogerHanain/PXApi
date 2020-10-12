using System;
using System.Collections.Generic;
using System.Linq;

namespace DXProject.Splitting
{
    public interface IContentFilter
    {
        List<string> Filter(List<string> l);
    }

    public class ContentFilter : IContentFilter
    {
        public List<string> Filter(List<string> l)
        {
            var lowered = new List<string>();
            var result = new List<string>();

            foreach (var word in l)
            {
                if (lowered.Contains(word.ToLower())) continue;

                lowered.Add(word.ToLower());

                result.Add(word);
            }
            return result;
        }
    }
}
