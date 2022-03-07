using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGenerator
{
    internal class CarInvoiceException:Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        ExceptionType Type;
        public CarInvoiceException(ExceptionType type,string message) : base(message)
        {
            this.Type = type;
        }

    }
}
