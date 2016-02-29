namespace GVSU.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVolunteer
    {
        int Id { get; set; }
        
        IUser User { get; set; }

    }
}
