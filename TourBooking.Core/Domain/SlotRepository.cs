using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Core.Models;

namespace TourBooking.Core.Domain
{
    public class SlotRepository : IRepository<SlotHome>
    {
        private readonly Context<SlotHome> _context;
        private readonly ILogger<SlotRepository> _logger;

        public SlotRepository(Context<SlotHome> context, ILogger<SlotRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task Add(SlotHome item)
        {
            try
            {
                await _context.Collection.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public IQueryable<SlotHome> CreateSet()
        {
            return _context.Collection.AsQueryable<SlotHome>();
        }

        public async Task<IEnumerable<SlotHome>> FilterBy(Expression<Func<SlotHome, bool>> filterExpression)
        {
            try
            {
                return await _context.Collection.FindSync(filterExpression).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public Task<Home> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Home>> Get(string bodyText, DateTime updatedFrom, long headerSizeLimit)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SlotHome>> GetAll()
        {
            try
            {
                return await _context.Collection.FindSync(Builders<SlotHome>.Filter.Empty).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public IReadOnlyList<Home> List(Expression<Func<Home, bool>> condition = null, Func<Home, string> order = null)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SlotHome> List(Expression<Func<SlotHome, bool>> condition = null, Func<SlotHome, string> order = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id, string user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove()
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, Home body)
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, SlotHome body)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDocument(string id, string body)
        {
            throw new NotImplementedException();
        }

        Task<SlotHome> IRepository<SlotHome>.Get(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<SlotHome>> IRepository<SlotHome>.Get(string bodyText, DateTime updatedFrom, long headerSizeLimit)
        {
            throw new NotImplementedException();
        }
    }
}
