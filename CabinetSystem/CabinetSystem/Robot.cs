using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
namespace CabinetSystem
{
    public class Robot : IStorable
    {
        protected readonly List<IStorable> _lsCabinet;
        public Robot()
        {
            _lsCabinet = new List<IStorable>();
        }

        
        public void Add(IStorable storable)
        {
            _lsCabinet.Add(storable);
        }

        public int GetCapacity()
        {
            return _lsCabinet.Sum(cabinet => cabinet.GetCapacity());
        }

        public bool HasEmptyBox()
        {
            return _lsCabinet.Any(cabin => cabin.HasEmptyBox());
        }

        public Ticket Store(Bag bag, bool isFromRobot)
        {
            return this.Store(bag);
        }

        public virtual Ticket Store(Bag bag)
        {
            foreach (var cabinet in _lsCabinet)
            {
                if (!cabinet.HasEmptyBox())
                    continue;

                var ticket = cabinet.Store(bag, true);
                return ticket;
            }

            throw new NoAvailableBoxException();
        }

        public Bag PickBag(Ticket ticket, bool isFromRobot)
        {
            return PickBag(ticket);
        }

        public int GetEmptyBoxCount()
        {
            return _lsCabinet.Sum(cabinet => cabinet.GetEmptyBoxCount());
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