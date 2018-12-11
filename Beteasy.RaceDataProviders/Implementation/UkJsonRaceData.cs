using System;
using System.Collections.Generic;
using System.Text;

namespace Beteasy.RaceDataProviders.Implementation
{
    /// <summary>
    /// A model that represents the way the source data is serialised in JSON.
    /// We don't have any docs for the API, so we infer the schema from the provided JSON file.
    /// No guarantees that this is fully correct without consulting API docs.
    /// </summary>
    internal class UkJsonRaceData
    {
        public RawDataEnvelope RawData { get; set; }

        public class RawDataEnvelope
        {
            public string FixtureName { get; set; }
            public List<Market> Markets { get; set; }
        }

        public class Market
        {
            public List<Selection> Selections { get; set; }
        }

        public class Selection
        {
            public decimal Price { get; set; }
            public Dictionary<string,string> Tags { get; set; }
        }
    }
}
