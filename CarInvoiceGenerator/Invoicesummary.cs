using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGenerator
{
    public class Invoicesummary
    {
        private int numberOfRides;
        private double TotalFair;
        private double AverageFair;
        public Invoicesummary(int RideLength,double totalfair)
        {
            this.numberOfRides=RideLength;
            this.TotalFair=totalfair;
            this.AverageFair = totalfair / RideLength;
        }

        public override  bool Equals(object obj)
        {
            if (obj == null) return false;
            if(!(obj is Invoicesummary)) return false;
            Invoicesummary inputobj=(Invoicesummary)obj;
            return this.numberOfRides == inputobj.numberOfRides && this.TotalFair == inputobj.TotalFair && this.AverageFair==inputobj.AverageFair;
        }
        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode()^this.TotalFair.GetHashCode()^this.AverageFair.GetHashCode();
        }

    }
}
