using System;
using System.Collections.Generic;
using System.Text;

namespace Beteasy.RaceDataProviders
{
    public class Horse
    {
        // As per Agile process, we only implement what is required now and we don't guess what might be required in the future.
        // Therefore, currently we only implement the Name and Price properties, but more could be added later as required.
        public string HorseName { get; internal set; }
        public decimal Price { get; internal set; }
    }
}
