using System;

namespace CabinetSystem
{
    public static class CabinetUtil
    {
        public static double EmptyRate(this IStorable storeable)
        {
            return (double)storeable.GetEmptyBoxCount() / storeable.GetCapacity();
        }
    }
}
