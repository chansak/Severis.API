using Severis.DataAccess.Models.Context;
using System.Linq.Expressions;
namespace Severis.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T GetById(Guid id);
        T GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IQueryable<T> AsQueryable { get; }
    }
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly BS_OE_BudgetContext _context;

        public GenericRepository(BS_OE_BudgetContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public virtual T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }
        public virtual T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public IQueryable<T> AsQueryable
        {
            get {
                return _context.Set<T>().AsQueryable();
            }
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
