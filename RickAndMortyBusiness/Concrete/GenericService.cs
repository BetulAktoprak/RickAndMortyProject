using Microsoft.EntityFrameworkCore;
using RickAndMortyBusiness.Abstract;
using RickAndMortyDataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyBusiness.Concrete
{
	public class GenericService<T> : IGenericService<T> where T : class
	{
		private readonly DbContext _context;

		public GenericService(DbContext context)
		{
			_context = context;
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			return _context.Set<T>().FirstOrDefault(filter);
		}

		public List<T> GetAll(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = _context.Set<T>();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			return query.ToList();
		}

		public List<T> GetList()
		{
			return _context.Set<T>().ToList();
		}

		public void TAdd(T t)
		{
			_context.Set<T>().Add(t);
			_context.SaveChanges();
		}

		public void TDelete(T t)
		{
			_context.Set<T>().Remove(t);
			_context.SaveChanges();
		}

		public T TGetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public void TUpdate(T t)
		{
			_context.Set<T>().Update(t);
			_context.SaveChanges();
		}
	}
}
