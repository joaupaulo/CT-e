﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Shared.Exceptions
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException(string message) : base(message) { }
    }
}
