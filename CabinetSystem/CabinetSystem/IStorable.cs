namespace CabinetSystem
{
    public interface IStorable
    {
        int GetCapacity();
        bool HasEmptyBox();
        Ticket Store(Bag bag, bool isFromRobot);
        Bag PickBag(Ticket ticket, bool isFromRobot);
        int GetEmptyBoxCount();
    }
}