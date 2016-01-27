using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ISkill
    {
        int Id { get; set; }

        string Description { get; set; }

    }
}
