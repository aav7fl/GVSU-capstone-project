using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface IUser
    {
        Guid Id { get; }

        string FirstName { get; }

        string LastName { get; }

        bool IsFirstLogin { get; }

        DateTime CreatedAt { get; }
    }
}
