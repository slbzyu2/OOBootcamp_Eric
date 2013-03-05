using System.Collections.Generic;
using System.Linq;
using CabinetSystem;

namespace CabinetSystem
{
    public class Robot
    {
        private readonly List<Cabinet> _lsCabinet;
        public Robot()
        {
            _lsCabinet = new List<Cabinet>();
        }

        
        public void Add(Cabinet cabinet)
        {
            _lsCabinet.Add(cabinet);
        }

        public bool HasEmptyBox()
        {
            return _lsCabinet.Any(cabin => cabin.HasEmptyBox());
        }
    }
}