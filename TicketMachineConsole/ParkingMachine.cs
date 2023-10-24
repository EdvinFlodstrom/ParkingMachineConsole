using ParkingMachineConsoleTicket;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingMachineConsole
{
    /// <summary>
    /// An object of the class ParkingMachine represents a parking machine.
    /// 
    /// Insert money first. 
    /// 
    /// Then buy a ticket or select cancel to refund.
    /// </summary>
    public class ParkingMachine
    {
        // There is two places to save money.
        // Total in the machine, from all finnished purchases.
        private int total;

        // Total for the current customer.
        private int currentTotal;

        // Cost to park.
        private int costPerHour;

        public ParkingMachine(int costPerHour)
        {
            total = 0;
            currentTotal = 0;
            this.costPerHour = costPerHour;            
        }

        public int CostPerHour
        {
            get
            {
                return costPerHour;
            }
        }
        public int CurrentTotal
        {
            get
            {
                return currentTotal;
            }
        }

        public int Total
        {
            get
            {
                return total;
            }
        }

        public Ticket BuyTicket()
        {
            total += currentTotal;

            Ticket ticket = new Ticket(currentTotal, CostPerHour);
            
            currentTotal = 0;

            return ticket;
        }

        public int Cancel()
        {
            int currentRefund = currentTotal;
            currentTotal = 0;
            return currentRefund;
        }
        public DateTime GetValidTo()
        {
            Ticket ticket = new Ticket(currentTotal, CostPerHour);

            return ticket.GetValidTo();
        }
        public TimeSpan GetParkingTimeSpan()
        {
            Ticket ticket = new Ticket(currentTotal, costPerHour);
          
            return ticket.GetValidTimeSpan();
        }
        public void InsertMoney(int v)
        {
            if (v > 0)
            {
                currentTotal += v;
            }            
        }
    }
}
