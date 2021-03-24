using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Core.Domain
{
    public interface IRepository<T>
    {
        IQueryable<T> CreateSet();

        IReadOnlyList<T> List(Expression<Func<T, bool>> condition = null, Func<T, string> order = null);

        Task<IEnumerable<T>> GetAll();

        Task<T> Get(string id);

        Task<IEnumerable<T>> Get(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression);

        Task Add(T item);

        Task<bool> Remove(string id, string user);

        Task Update(string id, T body);

        Task<bool> UpdateDocument(string id, string body);

        Task<bool> Remove();
    }
}
