using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Core.Models;

namespace TourBooking.Core.Services.Interfaces
{
    public interface ISlotService
    {
        Task<IEnumerable<Slot>> GetSlots(string homeId);
    }
}
