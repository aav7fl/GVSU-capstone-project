namespace GVSU.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : IEntity
    {
        IEnumerable<T> List { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T FindById(long id);
    }
}

//irepository - applies to ALL repositories
//ivolunteerstore implements irepository - add additional functionality that is the contract for this port
//volunteerstore (concrete, not abstract) - tries to map physical connections to our idealized contract
