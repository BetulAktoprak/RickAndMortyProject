using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyBusiness.Abstract
{
	public interface IGenericService<T>
	{
		void TAdd(T t);
		void TDelete(T t);
		void TUpdate(T t);
		List<T> GetList();
		T TGetById(int id);
		T Get(Expression<Func<T, bool>> filter);
		List<T> GetAll(Expression<Func<T, bool>> filter = null);

	}
}
