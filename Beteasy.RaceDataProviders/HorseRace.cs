using System;
using System.Collections.Generic;
using System.Text;

namespace Beteasy.RaceDataProviders
{
    public class HorseRace
    {
        internal List<Horse> _horses;

        // As per Agile process, we only implement what is required now and we don't guess what might be required in the future.
        // Therefore, currently we only implement the Name and Price properties, but more could be added later as required.
        public string RaceName { get; internal set; }
        public IEnumerable<Horse> Horses => _horses;
    }
}
