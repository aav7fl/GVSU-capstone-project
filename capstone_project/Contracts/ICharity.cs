using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ICharity
    {
        long Id { get; set; }

        string Name { get; set; }

        string ShortDescription { get; set; }

        string WebsiteURL { get; set; }

        bool Claimed { get; set; }

        bool Verified { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime CreatedBy { get; set; }

        IContactInfo ContactInfo { get; set; }

        ILocation Locations { get; set; }
    }
}
