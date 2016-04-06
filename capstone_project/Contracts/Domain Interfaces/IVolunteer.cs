namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVolunteer
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }

        string Description { get; }

        string Email { get; }

        int? ZipCode { get; }

        bool IsActive { get; }
    }
}
