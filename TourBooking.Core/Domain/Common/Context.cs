using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourBooking.Core.Domain
{
    public class Context<T>
    {
        private readonly IMongoDatabase _database = null;

        public Context(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<T> Collection
        {
            get
            {
                return _database.GetCollection<T>(typeof(T).Name);
            }
        }

        public IMongoCollection<T> GetCollection()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }
    }
}
