using System;

namespace CabinetSystem
{
    public static class CabinetUtil
    {
        public static double EmptyRate(Cabinet cabinet)
        {
            return (double)cabinet.GetEmptyBoxCount()/cabinet.Capacity;
        }
    }
}
