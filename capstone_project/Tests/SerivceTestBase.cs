using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.BusinessLogic;

namespace GVSU.Tests
{
    public class SerivceTestBase<T>
    {
        protected T Service { get; }

        protected SerivceTestBase()
        {
            Service = Factory.GetService<T>();
        }
    }
}
