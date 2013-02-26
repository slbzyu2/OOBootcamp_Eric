using System;

namespace CabinetSystem
{
    public class NonTicketException : Exception
    {
        public NonTicketException(string message) : base(message)
        {
        }
    }
}