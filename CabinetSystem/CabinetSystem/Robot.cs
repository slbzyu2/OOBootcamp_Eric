using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using CabinetSystemTest;

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

        public Ticket StoreBag(Bag bag)
        {
            foreach (var cabinet in _lsCabinet)
            {
                if (!cabinet.HasEmptyBox()) 
                    continue;

                var ticket = cabinet.Store(bag,true);
                return ticket;
            }

            throw new NoAvailableBoxException();
        }

        public Bag PickBag(Ticket ticket)
        {
            Bag bag = null;

            foreach (var cabinet in _lsCabinet)
            {
                bag = cabinet.PickBag(ticket,true);

                if (null != bag)
                    break;
            }

            return bag;
        }
    }
}