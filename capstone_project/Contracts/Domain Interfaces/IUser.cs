using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface IUser
    {
        string Id { get; }

        string FirstName { get; }

        string LastName { get; }
    }
}
