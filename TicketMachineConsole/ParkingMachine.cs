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

        public string BuyTicket()
        {
            total += currentTotal;

            TimeSpan ticketTimeSpan = GetParkingTimeSpan();

            DateTime validToTime = DateTime.Now;
            validToTime = validToTime.Add(ticketTimeSpan);
            currentTotal = 0;

            return "Parking ticket valid for:" + Environment.NewLine +
                ticketTimeSpan.Days + " days" + Environment.NewLine +
                ticketTimeSpan.Hours + " hours" + Environment.NewLine +
                ticketTimeSpan.Minutes + " minutes" + Environment.NewLine +
                Environment.NewLine +
                "Valid to: " + validToTime.ToString();
        }

        public int Cancel()
        {
            int currentRefund = currentTotal;
            currentTotal = 0;
            return currentRefund;
        }
        public DateTime GetValidTo()
        {            
            return DateTime.Now.Add(GetParkingTimeSpan());
        }
        public TimeSpan GetParkingTimeSpan()
        {
            int days = (int)MathF.Round(currentTotal / (costPerHour * 24));
            int hours = (currentTotal % (costPerHour * 24)) / costPerHour;
            int minutes = ((currentTotal % (costPerHour * 24)) % costPerHour) * (60/costPerHour);

            return new TimeSpan(days, hours, minutes, 0);
        }
        public void InsertMoney(int v)
        {
            if (v > 0)
            {
                currentTotal += v;
            }            
        }
        private string TimeToTicketText(int days, int hours, int minutes)
        {
            return "Parking ticket valid for:" + Environment.NewLine +
                days + " days" + Environment.NewLine +
                hours + " hours" + Environment.NewLine +
                minutes + " minutes";
        }
    }
}
