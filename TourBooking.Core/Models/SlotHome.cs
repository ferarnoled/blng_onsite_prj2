using System;
using System.Collections.Generic;
using System.Text;

namespace TourBooking.Core.Models
{
    public class SlotHome : BaseEntity
    {
        public string BussinesId { get; set; }
        public DateTime SlotDate { get; set; }
        public string Slot { get; set; }
    }
}
