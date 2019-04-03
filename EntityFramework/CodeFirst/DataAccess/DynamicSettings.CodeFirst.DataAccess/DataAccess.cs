using Microsoft.EntityFrameworkCore;
using DynamicSettings.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DynamicSettings.CodeFirst.IDataAccess;

namespace DynamicSettings.CodeFirst.DataAccess
{
    public class DataAccess<T> : IDataAccess<T> where T : BaseModel, new()
    {
        private DbContext ctx;
        public DataAccess(DbContext context)
        {
			//string connectionString=Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(this.Configuration,"")
	        //var connectionString=new ConfigurationBuilder().Build().GetSection("ConnectionStrings");
	        //var a1=new ConfigurationBuilder().Build().GetSection("appSettings");

			ctx = context;
        }
        public bool Add(T obj)
        {
            bool result = false;

            try
            {
                if (null == obj)
                    return result;
                ctx.Set<T>().Add(obj);
                ctx.Entry(obj).State = EntityState.Added;
                result = ctx.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }

        public bool Delete(T obj)
        {
            bool result = false;

            try
            {
                if (null == obj)
                    return result;
                ctx.Set<T>().Add(obj);
                ctx.Entry(obj).State = EntityState.Deleted;
                result = ctx.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            bool result = false;

            try
            {
                if (null == predicate)
                    return result;
                IQueryable<T> objs = Query(predicate);

                if (objs == null || objs.Any())
                    return result;

                ctx.Set<T>().AddRange(objs);
                ctx.Entry(objs).State = EntityState.Deleted;
                result = ctx.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            bool result = false;

            try
            {
                if (default(Guid) == id)
                    return result;
                T obj = Query(id);

                if (obj == null)
                    return result;

                ctx.Set<T>().Add(obj);
                ctx.Entry(obj).State = EntityState.Deleted;
                result = ctx.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }

        public T Query(Guid id)
        {
            T result = null;

            try
            {
                if (default(Guid) == id)
                    return result;

                result=ctx.Set<T>().FirstOrDefault(t=>t.ID==id);
            }
            catch (Exception ex)
            {

                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }
	    //public List<T> QueryAll(Func<T, bool> predicate = null)


		public IQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T,bool>> keySelector, int? pageSize = null, int? pageIndex = null)
        {
            IQueryable<T> result = null;

            try
            {
                if (null == predicate)
                    return result;

                result = ctx.Set<T>().Where(predicate).OrderBy(keySelector).Skip((pageIndex.Value-1)*pageSize.Value).Take(pageSize.Value);
            }
            catch (Exception ex)
            {

                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> result = null;

            try
            {
                if (null == predicate)
                    return result;

                result = ctx.Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {

                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }

        public bool Update(T obj, bool addIfNotExists = false)
        {
            bool result = false;

            try
            {
                if (obj == null)
                    return result;

                var model = Query(obj.ID);
                if (model == null)
                {
                    if (addIfNotExists)
                        result = Add(obj);
                    else
                        return result;
                }
                else
                {
                    ctx.Set<T>().Add(obj);
                    ctx.Entry(obj).State = EntityState.Modified;
                    //ctx.Entry(obj).State = EntityState.Detached;
                    result = ctx.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
            }

            return result;
            //throw new NotImplementedException();
        }

        public bool Update(T obj, bool addIfNotExists = false, Guid id = default(Guid))
        {
            bool result = false;

			try
			{
				if (obj == null || (id == null || (obj != null && obj.ID == Guid.Empty)))
					return result;

				var model = Query(id==Guid.Empty? obj.ID:id);
                if (obj == null)
                {
                    if (addIfNotExists)
                        result = Add(obj);
                    else
                        return result;
                }
                else
                {
                    ctx.Set<T>().Add(obj);
                    ctx.Entry(obj).State = EntityState.Modified;
                    result = ctx.SaveChanges() > 0 ? true : false;
                }
			}
			catch (Exception e)
			{
				//Console.WriteLine(e);
				//throw;
			}

			return result;
            //throw new NotImplementedException();
        }
    }
}
