using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Core.Models;

namespace TourBooking.Core.Services.Interfaces
{
    public interface IHomeService
    {
        Task<bool> IsSelfTourAllowed(string homeId);

        Task<IEnumerable<Home>> GetAll();
    }
}
