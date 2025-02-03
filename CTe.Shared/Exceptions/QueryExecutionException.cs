using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTe.Shared.Exceptions
{
    public class QueryExecutionException : Exception
    {
        public QueryExecutionException(string message) : base(message) { }

    }
}
