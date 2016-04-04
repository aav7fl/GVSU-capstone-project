using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts.Decorators
{
    public class CharityServiceDecorator : ICharityService, IDisposable
    {
        private readonly ICharityService _service;

        protected CharityServiceDecorator(ICharityService service)
        {
            _service = service;
        }

        public virtual int CreateCharity(ICharity charity)
        {
            return _service.CreateCharity(charity);
        }

        public virtual void DeleteCharityById(int id)
        {
            _service.DeleteCharityById(id);
        }

        public virtual IEnumerable<ICharity> GetAllCharities()
        {
            return _service.GetAllCharities();
        }

        public virtual ICharity GetCharityById(int id)
        {
            return _service.GetCharityById(id);
        }

        public virtual void UpdateCharity(ICharity charity)
        {
            _service.UpdateCharity(charity);
        }

        public void Dispose()
        {
        }
    }
}
