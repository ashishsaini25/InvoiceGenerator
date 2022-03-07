using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGenerator
{
    public class Carinvoicegenerator
    {
        private RideRepositary riderepo;
        RIDE_TYPE type;
        private readonly Double Cost_Per_Km;
        private readonly Double Cost_Per_Minute;
        private readonly Double Minimum_Fare;

        public Carinvoicegenerator(RIDE_TYPE ridetype){
            this.type = ridetype;
            try
            {
                if (ridetype.Equals(RIDE_TYPE.NORMAL))
                {
                    Cost_Per_Km = 10;
                    Minimum_Fare = 5;
                    Cost_Per_Minute = 1;
                }
                if (ridetype.Equals(RIDE_TYPE.PREMIUM))
                {
                    Cost_Per_Km = 15;
                    Cost_Per_Minute = 2;
                    Minimum_Fare = 20;
                }
            }
            catch (CarInvoiceException)
            {
                throw new CarInvoiceException(CarInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }

        }

        public Double CalculateFair(double distance,int time)
        {
            double fair = 0;
            try
            {
                fair = distance * Cost_Per_Km + time * Cost_Per_Minute;
            }
            catch (CarInvoiceException)
            {
                if (time < 0)
                {
                    throw new CarInvoiceException(CarInvoiceException.ExceptionType.INVALID_TIME, "Time cannot be negative");
                }
                if (distance <= 0)
                {
                    throw new CarInvoiceException(CarInvoiceException.ExceptionType.INVALID_DISTANCE, "Distance should be greater than Zero");
                }
                if (type.Equals(null)){
                    throw new CarInvoiceException(CarInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");

                }
            }
            return Math.Max(fair, Minimum_Fare);
        }
        public Invoicesummary FairMultipleRides(Ride[] rides)
        {
            double Totalfair = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    Totalfair += this.CalculateFair(ride.distance, ride.time);
                }
            }
            catch (CarInvoiceException)
            {
                if (rides == null)
                {
                    throw new CarInvoiceException(CarInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }

            }
            return new Invoicesummary(rides.Length, Totalfair);
        }

    }
}
