using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Core.Domain;
using TourBooking.Core.Models;
using TourBooking.Core.Services.Interfaces;

namespace TourBooking.Core.Services
{
    public class SlotService : ISlotService
    {
        private readonly IRepository<SlotHome> repository;
        private readonly HomeService homeService;

        public SlotService(IRepository<SlotHome> repository, HomeService homeService)
        {
            this.repository = repository;
            this.homeService = homeService;
        }

        public async Task<IEnumerable<Slot>> GetSlots(string homeId)
        {
            if (!await this.homeService.IsSelfTourAllowed(homeId))
                throw new Exception("SelfTour not Alled");

            var slotsForHome = await this.repository.FilterBy(x => x.BussinesId == homeId);

            var rvalue = new List<Slot>();

            if (DateTime.Now.Hour > 9)
            {
                var s = new Slot()
                {
                    Date = DateTime.Now.AddDays(2).Date,
                    Slots = GetSlots()

                };
                rvalue.Add(s);
            }
            else
            {
                var s = new Slot()
                {
                    Date = DateTime.Now.Date,
                    Slots = GetSlots()

                };
                rvalue.Add(s);

                var s1 = new Slot()
                {
                    Date = DateTime.Now.AddDays(1).Date,
                    Slots = GetSlots()

                };
                rvalue.Add(s1);

                var s2 = new Slot()
                {
                    Date = DateTime.Now.AddDays(2).Date,
                    Slots = GetSlots()

                };

                rvalue.Add(s2);
            }

            return rvalue;
        }

        private List<string> GetSlots()
        {
           return Enumerable
             .Range(0, (int)(new TimeSpan(24, 0, 0).TotalMinutes / 30))
             .Select(i => DateTime.Today
                .AddMinutes(i * (double)30)
                .ToString("HH:mm"))
             .ToList();
        }
    }
}
