using System.Collections;
using System.Collections.Generic;
using CabinetSystemTest;

namespace CabinetSystem
{
    public class Cabinet
    {
        private const int DEFAULT_CAPACITY = 5;
        private readonly int _capacity;
        private readonly IDictionary<Ticket, Bag> _dictionary;
        public Cabinet()
        {
            _dictionary = new Dictionary<Ticket, Bag>(DEFAULT_CAPACITY);
            _capacity = DEFAULT_CAPACITY;
        }

        public Cabinet(int capacity)
        {
            _capacity = capacity;
            _dictionary = new Dictionary<Ticket, Bag>(capacity);
        }

        public bool HasEmptyBox()
        {
            return _dictionary.Count < _capacity;
        }

        public Ticket Store(Bag bag, bool isFromRobot)
        {
            var ticket = Store(bag);
            ticket.IsFromRobat = isFromRobot;
            return ticket;
        }

        public Ticket Store(Bag bag)
        {
            if (_dictionary.Count >= _capacity)
                throw new NoAvailableBoxException();

            var ticket = new Ticket();
            _dictionary.Add(ticket, bag);

            return ticket;
        }

        public Bag PickBag(Ticket ticket, bool isFromRobot)
        {
            return Pick(ticket, isFromRobot);
        }

        //public Bag PickBag(Ticket ticket)
        //{
        //    return PickBag(ticket, false);
        //}

        public Bag Pick(Ticket ticket, bool isFromRobot)
        {
            if (ticket == null)
                throw new NonTicketException("Invalid Ticket");

           
            if (!_dictionary.ContainsKey(ticket))
                return null;

            if (ticket.IsFromRobat != isFromRobot)
                return null;

            var bag = _dictionary[ticket];
            _dictionary.Remove(ticket);
            return bag;
        }
    }
}