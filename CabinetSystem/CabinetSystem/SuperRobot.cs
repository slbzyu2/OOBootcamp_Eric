using System.Collections.Generic;
using System.Linq;

namespace CabinetSystem
{
    public class SuperRobot : Robot
    {
        public virtual Ticket Store(Bag bag)
        {
            var cabinet = _lsCabinet.OrderByDescending(x=> x.EmptyRate()).FirstOrDefault();
            if (cabinet != null && cabinet.HasEmptyBox())
                return cabinet.Store(bag,true);

            throw new NoAvailableBoxException();
        }
    }
}