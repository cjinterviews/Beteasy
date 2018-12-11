using System;
using System.Collections.Generic;
using System.Text;

namespace Beteasy.RaceDataProviders
{
    public class RaceDataInvalidException : Exception
    {
        public RaceDataInvalidException(string message) : base(message) { }
    }
}
