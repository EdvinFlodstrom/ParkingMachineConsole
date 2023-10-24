using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ParkingMachineConsoleTicket
{
    public class Ticket
    {
        private DateTime purchaseTime;
        private readonly int costPerHour;
        private readonly int price;

        /// <summary>
        /// A ticket. Cannot be changed once created.
        /// </summary>
        /// <param name="price">The amount of money payed for the ticket. A hole number.</param>
        /// <param name="costPerHour">The cost per hour to park. A hole number.</param>
        public Ticket(int price, int costPerHour)
        {
            // Your code here
            this.costPerHour = costPerHour;
            this.price = price;            
        }
        /// <summary>
        /// Property to read cost per hour.
        /// </summary>
        public int CostPerHour
        {
            get
            {
                return CostPerHour;
            }
        }

        /// <summary>
        /// Property to read the amout payed for the ticket.
        /// </summary>
        public int Price
        {
            get
            {
                return price;
            }
        }

        /// <summary>
        /// Returns the amount of time the ticket is valid for. 
        /// </summary>
        /// <returns>TimeSpan object with days, hours and minutes. 
        /// The number of seconds is set to zero.</returns>

        /// <summary>
        /// Returns the date and time the ticket is valid to.
        /// </summary>
        /// <returns>A DateTime object for the validity date.</returns>

        public TimeSpan GetValidTimeSpan()
        {
            int days = (int)MathF.Round(price / (costPerHour * 24));
            int hours = (price % (costPerHour * 24)) / costPerHour;
            int minutes = ((price % (costPerHour * 24)) % costPerHour) * (60 / costPerHour);

            return new TimeSpan(days, hours, minutes, 0);
        }
        public DateTime GetValidTo()
        {
            return DateTime.Now.Add(GetValidTimeSpan());
        }
        public override string ToString()
        {
            TimeSpan timeSpan = GetValidTimeSpan();
            DateTime validToTime = GetValidTo();

            return "Parking ticket valid for:" + Environment.NewLine +
                timeSpan.Days + " days" + Environment.NewLine +
                timeSpan.Hours + " hours" + Environment.NewLine +
                timeSpan.Minutes + " minutes" + Environment.NewLine +
                Environment.NewLine +
                "Valid to: " + validToTime.ToString();
        }
    }
}