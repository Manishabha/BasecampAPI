using System.Linq.Expressions;

namespace DAL.Repository
{
	public interface IRepository<T> where T : class
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
		T Add(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
