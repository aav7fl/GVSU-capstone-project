using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.BusinessLogic
{
    public static class Factory
    {
        private static readonly IDictionary<Type, Lazy<Object>> _factories;

        static Factory()
        {
            _factories = new Dictionary<Type, Lazy<Object>>();
        }

        public static void Register<T>(Func<T> factoryMethod)
        {
            _factories[typeof(T)] = new Lazy<Object>(() => factoryMethod());
        }

        public static T GetService<T>()
        {
            return (T)_factories[typeof(T)].Value;
        }
    }
}
