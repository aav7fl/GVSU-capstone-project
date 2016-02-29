using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ICharity
    {
        int Id { get; }

        string Name { get; }

        string ShortDescription { get; }

        string Email { get; }

        string PhoneNumber { get; }

        string WebsiteURL { get; }

        DateTime CreatedAt { get; }

        IUser CreatedBy { get; }

        ILocation Locations { get; }

        bool Claimed { get; }

        bool Verified { get; }
    }
}
