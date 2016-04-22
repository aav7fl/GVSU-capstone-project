using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GVSU.BusinessLogic;
using GVSU.Contracts;
using GVSU.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GVSU.Tests
{
    [TestClass]
    public class AssemblyInitializers
    {
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            Factory.Register<IVolunteerService>(() => new VolunteerServiceSimulator());
        }
    }
}
