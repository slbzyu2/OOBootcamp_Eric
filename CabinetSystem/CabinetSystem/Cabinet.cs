using CabinetSystemTest;

namespace CabinetSystem
{
    public class Cabinet
    {
        public bool HasEmptyBox()
        {
            return true;
        }

        public Ticket Store(Bag bag)
        {
            return new Ticket();
        }
    }
}