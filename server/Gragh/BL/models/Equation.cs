﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.models
{
    class Equation
    {
        public int Class { get; set; }
        public int Count { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
