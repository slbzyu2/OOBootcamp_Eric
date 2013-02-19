using System.Collections;
using CabinetSystemTest;

namespace CabinetSystem
{
    public class Cabinet
    {
        private Bag _bag;
        private Hashtable htBags;
        public Cabinet()
        {
            htBags = new Hashtable();
        }
        public bool HasEmptyBox()
        {
            return true;
        }

        public Ticket Store(Bag bag)
        {
            _bag = bag;
            var ticket=new Ticket();
            htBags.Add(ticket, bag);

            return ticket;
        }

        public Bag PickBag(Ticket ticket)
        {
            return htBags[ticket] as Bag;
        }
    }
}