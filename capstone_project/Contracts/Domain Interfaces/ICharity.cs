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

        string ImageUrl { get; set; }

        ICategory Category { get; }

        string Email { get; }

        string PhoneNumber { get; }

        string WebsiteUrl { get; }

        DateTime? CreatedAt { get; }

        IUser CreatedBy { get; }

        DateTime? UpdatedAt { get; }

        IUser UpdatedBy { get; }

        ICollection<ILocation> Locations { get; }

        bool Claimed { get; }

        bool Verified { get; }

        double TotalHours { get; set; }

        int FollowersCount { get; set; }

        double? AverageRating { get; set; }
    }
}
