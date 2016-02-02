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
