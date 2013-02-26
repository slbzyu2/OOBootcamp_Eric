using System.Collections;
using System.Collections.Generic;
using CabinetSystemTest;

namespace CabinetSystem
{
    public class Cabinet
    {
        private readonly IDictionary<Ticket, Bag> _dictionary;
        public Cabinet()
        {
            _dictionary = new Dictionary<Ticket, Bag>();
        }

        public bool HasEmptyBox()
        {
            return true;
        }

        public Ticket Store(Bag bag)
        {
            var ticket=new Ticket();
            _dictionary.Add(ticket, bag);

            return ticket;
        }

        public Bag PickBag(Ticket ticket)
        {
            if (ticket == null)
                throw new NonTicketException("Invalid Ticket");

            if (_dictionary.ContainsKey(ticket))
            {
                var bag = _dictionary[ticket];
                _dictionary.Remove(ticket);
                return bag;
            }

            return null;
        }
    }
}