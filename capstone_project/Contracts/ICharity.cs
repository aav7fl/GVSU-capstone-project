using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ICharity
    {
        long Id { get; }

        string Name { get; }

        string ShortDescription { get; }

        string WebsiteURL { get; }

        DateTime CreatedAt { get; }

        DateTime CreatedBy { get; }

        IContactInfo ContactInfo { get; }

        ILocation Locations { get; }
        
        bool Claimed { get; }

        bool Verified { get; }
    }
}
