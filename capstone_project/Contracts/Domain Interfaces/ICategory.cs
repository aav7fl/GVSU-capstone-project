﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVSU.Contracts
{
    public interface ICategory
    {
        int Id { get; }

        string Description { get; }
    }
}
