using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ICharityService
    {
        IVolunteer GetCharityById(int id);

        IEnumerable<IVolunteer> GetAllCharities();

        string CreateCharity(IVolunteer volunteer);

        string UpdateCharity(IVolunteer volunteer);

        string DeleteCharityById(int id);
    }
}
