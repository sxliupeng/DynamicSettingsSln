using DynamicSettings.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DynamicSettings.CodeFirst.IDataAccess
{
    public interface IDataAccess<T> where T:BaseModel,new()
    {
        bool Add(T obj);

        bool Delete(T obj);

        bool Delete(Expression<Func<T, bool>> predicate);

        bool Delete(Guid id);

        bool Update(T obj, bool addIfNotExists=false);

        bool Update(T obj, bool addIfNotExists = false, Guid id=default(Guid));

        T Query(Guid id);

	    //List<T> QueryAll(Func<T, bool> predicate);

		//分页、排序
		IQueryable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
