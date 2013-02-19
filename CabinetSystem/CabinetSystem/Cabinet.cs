using CabinetSystemTest;

namespace CabinetSystem
{
    public class Cabinet
    {
        private Bag _bag;
        public bool HasEmptyBox()
        {
            return true;
        }

        public Ticket Store(Bag bag)
        {
            _bag = bag;
            return new Ticket();
        }

        public Bag PickBag(Ticket ticket)
        {
            return _bag;
        }
    }
}