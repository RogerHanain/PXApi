using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DXProject.Testing
{
    public class BaseUnitTesting
    {
        [SetUp]
        protected virtual void Setup()
        {
            All.Clear();

            descendants.Clear();

            SetFactories();
        }

        protected virtual void SetFactories()
        {
            descendants = new Dictionary<object, List<object>>();
        }


        private List<object> All;

        public BaseUnitTesting()
        {
            All = new List<object>();

            SetFactories();
        }

        /// <summary>
        /// Returns the single instance of the Mock (creates if called for the first time else return all the time the same object)
        /// </summary>
        public Mock<T> GetMock<T>() where T : class
        {
            var r = All.FirstOrDefault(e => e is Mock<T>);

            if (r is Mock<T>) return r as Mock<T>;

            else
            {
                var newMock = new Mock<T>() { DefaultValue = DefaultValue.Mock };

                All.Add(newMock);

                return newMock;
            }
        }

        public Mock<T> GetUnregisteredMock<T>() where T : class
        {
            return new Mock<T>() { DefaultValue = DefaultValue.Mock };
        }

        public List<T> GetList<T>() where T : class
        {
            return GetList<T>(1);
        }

        public List<T> GetList<T>(int count) where T : class
        {
            var l = new List<T>() { GetObject<T>() };

            if (count == 1) return l;

            for (int i = 1; i < count; i++)
            {
                l.Add(new Mock<T>().Object);
            }
            return l;
        }

        public Mock<T> GetMock<T>(T objet) where T : class
        {
            foreach (var item in All)
            {
                var m = item as Mock<T>;
                if (m == null) continue;

                if (m.Object == objet) return m;
            }

            foreach (var item in GetChild<T>())
            {
                if (item.Object == objet) return item;
            }

            return null;
        }

        public T GetObject<T>() where T : class
        {
            return GetMock<T>().Object;
        }

        public Mock<Tout> GetFirstChild<Tout>() where Tout : class
        {
            return GetChild<Tout>().First();
        }

        public IReadOnlyList<Mock<Tout>> GetChild<Tout>() where Tout : class
        {
            int c = 0;
            var l = new List<Mock<Tout>>();
            foreach (var item in descendants)
            {
                if (item.Value.Count == 0) continue;

                if (item.Value.First() is Mock<Tout>)
                {
                    c++;

                    foreach (var i in item.Value)
                    {
                        l.Add(i as Mock<Tout>);
                    }
                }
            }
            if (c == 0) throw new Exception($"Could not find descendants for the type {typeof(Tout)}");

            if (c > 1) throw new Exception($"The are several factories producing {typeof(Tout)}");

            return l;
        }

        public IReadOnlyList<Mock<Tout>> GetFactoryDescendants<Tin, Tout>() where Tin : class where Tout : class
        {
            foreach (var item in descendants)
            {
                if ((Type)item.Key == typeof(Tin))
                {
                    var l = new List<Mock<Tout>>();

                    foreach (var i in item.Value)
                    {
                        l.Add(i as Mock<Tout>);
                    }
                    return l;
                }
            }
            throw new Exception($"Could not find descendants for the type {typeof(Tin)}");
        }

        private Dictionary<object, List<object>> descendants;


        protected Type GetReturnType<MyType>() where MyType : class
        {
            MethodInfo methodInfo = typeof(MyType).GetMethod("Create");

            return methodInfo.ReturnType;
        }

        protected Type GetReturnTypeString<MyType>() where MyType : class
        {
            var typeName = typeof(MyType).FullName;

            if (!typeName.EndsWith("Factory")) return null;

            else
            {
                var newType = typeName.Substring(0, typeName.Length - "Factory".Length);

                var r = Type.GetType("Tests.UnitTests.KrPcTest.Suite_CapillaryPressureCalculator");

                return r;
            }
        }


        public T SetChild<Tfactory, T>() where T : class where Tfactory : class
        {
            var childMock = new Mock<T>() { DefaultValue = DefaultValue.Mock };

            if (!descendants.ContainsKey(typeof(Tfactory))) descendants[typeof(Tfactory)] = new List<object>();

            descendants[typeof(Tfactory)].Add(childMock);

            return childMock.Object;
        }

        protected T GetAny<T>()
        {
            return It.IsAny<T>();
        }
    }
}
