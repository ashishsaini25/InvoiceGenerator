using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGenerator
{
    public  class RideRepositary
    {
       Dictionary<string,List<Ride>>user=null;
        public RideRepositary()
        {
            this.user=new Dictionary<string,List<Ride>>();
        }
        public void AddRide(string userid, Ride[] ride)
        {
            bool contains =this.user.ContainsKey(userid);
            try
            {
                if (contains)
                {
                   
                       List<Ride> list = new List<Ride>();
                        list.AddRange(ride);
                }
            }
            catch (CarInvoiceException)
            {
                throw new CarInvoiceException(CarInvoiceException.ExceptionType.NULL_RIDES, "Rides are NUll");
            }
        }
        public Ride[] GetRide(string userid)
        {
            try
            {
                return this.user[userid].ToArray();
            }
            catch(CarInvoiceException)
            {
                throw new CarInvoiceException(CarInvoiceException.ExceptionType.INVALID_USER_ID, "User id is invalid");

            }
        }
    }

}
