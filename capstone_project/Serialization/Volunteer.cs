namespace GVSU.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public class Volunteer : IVolunteer
    {
        public int Id { get; set; }

        public IUser User { get; set; }
    }
}
