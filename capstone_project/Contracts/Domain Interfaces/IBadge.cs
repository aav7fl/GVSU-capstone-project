using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface IBadge
    {
        int Id { get; }

        string Name { get; }

        string ShortDescription { get; }

        string ImageUrl { get; }

        string IconName { get; }

        string DisplayName { get; }

        bool Active { get; }

        int MinValue { get; }

        int MaxValue { get; }

        ICharity Charity { get; }
    }
}
