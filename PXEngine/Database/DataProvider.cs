using DXProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXProject.Database
{
    public interface IDataProvider
    {
        IEnumerable<T> GetAll<T>();
    }

    public class DataProvider : IDataProvider
    {
        public DataProvider(IPXDbContext context)
        {
            this.context = context;
        }

        IPXDbContext context;

        public IEnumerable<T> GetAll<T>()
        {
            if (typeof(T).Equals(typeof(Word)))
            {
                return context.Words as IEnumerable<T>;
            }
            if (typeof(T).Equals(typeof(Translation)))
            {
                return context.Translations as IEnumerable<T>;
            }
            throw new Exception("Unsupported Type");
        }
    }
}
