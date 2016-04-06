using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ICharityService : IDisposable
    {
        ICharity GetCharityById(int id);

        IEnumerable<ICharity> GetAllCharities();

        int CreateCharity(ICharity volunteer);

        void UpdateCharity(ICharity volunteer);

        void DeleteCharityById(int id);
    }
}
