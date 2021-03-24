using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourBooking.Core.Models
{
    public class Home : BaseEntity
    {
        public string BussinesId { get; set; }
        public string FrendlyName { get; set; }
        public string address { get; set; }
    }
}
