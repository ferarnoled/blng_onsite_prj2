using System;
using System.Collections.Generic;
using System.Text;

namespace TourBooking.Core.Models
{
    public class Slot
    {
        public DateTime Date { get; set; }
        public List<string> Slots { get; set; }
    }
}
