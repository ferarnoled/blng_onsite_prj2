using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourBooking.Core.Models
{
    public class BaseEntity
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
    }
}
