namespace CabinetSystem
{
    public class SmartRobot : Robot
    {
        public override Ticket Store(Bag bag)
        {
            var cabinet = GetCabinetWithMaxEmptybox();
            if (cabinet == null)
                throw new NoAvailableBoxException();

            var ticket = cabinet.Store(bag, true);
            return ticket;
        }

        private IStorable GetCabinetWithMaxEmptybox()
        {
            var boxcount = 0;
            var iCabinetWithMaxEmptybox = -1;
            for (var iCabinet = 0; iCabinet < _lsCabinet.Count; iCabinet++)
            {
                if (boxcount < _lsCabinet[iCabinet].GetEmptyBoxCount())
                {
                    boxcount = _lsCabinet[iCabinet].GetEmptyBoxCount();
                    iCabinetWithMaxEmptybox = iCabinet;
                }
            }

            return iCabinetWithMaxEmptybox == -1 ? null : _lsCabinet[iCabinetWithMaxEmptybox];
        }
    }
}