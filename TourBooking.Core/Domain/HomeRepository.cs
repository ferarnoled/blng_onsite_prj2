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
    public class HomeRepository : IRepository<Home>
    {
        private readonly Context<Home> _context;
        private readonly ILogger<HomeRepository> _logger;

        public HomeRepository(Context<Home> context, ILogger<HomeRepository> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task Add(Home item)
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

        public IQueryable<Home> CreateSet()
        {
            return _context.Collection.AsQueryable<Home>();
        }

        public async Task<IEnumerable<Home>> FilterBy(Expression<Func<Home, bool>> filterExpression)
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

        public async Task<IEnumerable<Home>> GetAll()
        {
            try
            {
                return await _context.Collection.FindSync(Builders<Home>.Filter.Empty).ToListAsync();
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

        public Task<bool> UpdateDocument(string id, string body)
        {
            throw new NotImplementedException();
        }
    }
}
