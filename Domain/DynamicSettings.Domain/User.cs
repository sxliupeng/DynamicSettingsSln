using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DynamicSettings.CodeFirst.Context;
using DynamicSettings.CodeFirst.DataAccess;
using DynamicSettings.CodeFirst.IDataAccess;
using DynamicSettings.EF.Model;
using Microsoft.EntityFrameworkCore;

namespace DynamicSettings.Domain
{
	public class User
	{
		private SettingsManagementDbContext context;
		private IDataAccess<TblUser> userAccess;
		private IDataAccess<TblGroup> groupAccess;
		private IDataAccess<TblRole> roleAccess;
		private IDataAccess<TblRight> rightAccess;
		public User(SettingsManagementDbContext context)
		{
			this.context = context;
			userAccess = new DataAccess<TblUser>(this.context);
			groupAccess = new DataAccess<TblGroup>(this.context);
			roleAccess = new DataAccess<TblRole>(this.context);
			rightAccess = new DataAccess<TblRight>(this.context);
		}

		public bool Create(TblUser user)
		{
			bool result = false;

			try
			{
				if (user == null)
					return result;
				this.context.Database.AutoTransactionsEnabled = true;

				result=userAccess.Add(user);
			}
			catch (Exception e)
			{
				//Console.WriteLine(e);
				//throw;
			}

			return result;
		}

		public List<TblUser> Users(Expression<Func<TblUser,bool>> predicate)
		{
			return userAccess.Query(predicate).ToList();
			//禁用延迟加载
		}
	}
}
