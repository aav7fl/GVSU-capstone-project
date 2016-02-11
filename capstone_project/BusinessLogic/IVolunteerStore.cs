namespace GVSU.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GVSU.Contracts;

    public interface IVolunteerStore<T> : IRepository<T>
        where T : IVolunteer
    {
       //more specific volunteer stuff
    }
}
