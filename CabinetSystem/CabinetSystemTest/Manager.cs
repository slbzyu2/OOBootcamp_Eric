using System.Collections.Generic;
using System.Linq;
using CabinetSystem;

namespace CabinetSystem
{
    public class Manager : IStorable
    {
        private IList<IStorable> _stoableList;

        public Manager()
        {
            _stoableList = new List<IStorable>();
        }
        public void Add(IStorable r1)
        {
            _stoableList.Add(r1);
        }

        public int GetCapacity()
        {
            return _stoableList.Sum(storable => storable.GetCapacity());
        }

        public bool HasEmptyBox()
        {
            if (_stoableList.Any(storable => storable.HasEmptyBox()))
                return true;

            return false;
        }

        public Ticket Store(Bag bag, bool isFromRobot)
        {
            foreach (var storable in _stoableList)
            {
                if (storable.HasEmptyBox())
                    return storable.Store(bag, isFromRobot);
            }

            return null;
        }

        public Bag PickBag(Ticket ticket, bool isFromRobot)
        {
            foreach (var storable in _stoableList)
            {
                var bag = storable.PickBag(ticket, isFromRobot);
                if (bag != null)
                    return bag;
            }
            return null;
        }

        public int GetEmptyBoxCount()
        {
            return _stoableList.Sum(storable => storable.GetEmptyBoxCount());
        }
    }
}