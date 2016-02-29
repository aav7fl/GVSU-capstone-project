using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.BusinessLogic;

namespace GVSU.Tests
{
    public class ServiceTestBase<T>
    {
        protected T Service { get; }

        protected ServiceTestBase()
        {
            Service = Factory.GetService<T>();
        }
    }
}
