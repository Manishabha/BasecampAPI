using DAL;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly ApplicationDbContext _context;
	private readonly DbSet<T> _dbSet;

	public Repository(ApplicationDbContext context)
	{
		_context = context;
		_dbSet = context.Set<T>();
	}

	public T GetById(int id)
	{
		return _dbSet.Find(id);
	}

	public IEnumerable<T> GetAll()
	{
		return _dbSet.ToList();
	}

	public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
	{
		return _dbSet.Where(predicate).ToList();
	}

	public void Add(T entity)
	{
		_dbSet.Add(entity);
	}

	public void Update(T entity)
	{
		_context.Entry(entity).State = EntityState.Modified;
	}

	public void Delete(T entity)
	{
		_dbSet.Remove(entity);
	}
}