using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DynamicSettings.API.Model;
using DynamicSettings.API.Util;
using DynamicSettings.CodeFirst.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace DynamicSettings.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private SettingsManagementDbContext _context;
		private SmtpConfig SmtpConfig { get; }
		private readonly IConfiguration Config;
		private DistributedCache cache;

		public ValuesController(SettingsManagementDbContext context
			, Microsoft.Extensions.Options.IOptions<SmtpConfig> smtpConfig
			, IConfiguration config
			, IDistributedCache cache)
		{
			_context = context;
			SmtpConfig = smtpConfig.Value;
			Config = config;
			this.cache=new DistributedCache(cache);
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			//SmtpConfig
			//var connectionString = Config.GetConnectionString("SqlServer");

			//TblUser model = new TblUser()
			//{
			//	ID = Guid.NewGuid(),
			//	Name = "Young",
			//	DataCreated = DateTimeOffset.Now
			//};
			//access.DataAccess<TblUser> userDataAccess = new access.DataAccess<TblUser>(_context);
			//bool result = userDataAccess.Add(model);

			//if (result)
			//{
			//	model.Name = "Young+Lau";
			//	result = userDataAccess.Update(model);

			//	if (result)
			//	{
			//		model.Name = "Young+Lau+Hello,World";
			//		result = userDataAccess.Update(model, false, model.ID);

			//		if (result)
			//		{
			//			var m = userDataAccess.QueryByID(model.ID);

			//			if (m != null)
			//			{
			//				var lst = userDataAccess.QueryAll(t => t.ID != null);

			//				if (lst != null)
			//				{
			//					//
			//				}
			//			}
			//		}
			//	}
			//}
			//Assert.NotNull(model);
			//Assert.Equal(true, result);

			#region

			if (HttpContext.Session==null || !HttpContext.Session.IsAvailable)
			{
				HttpContext.Session.SetString("UserID","1000");//Microsoft.AspNetCore.Http
			}

			//添加
			bool booladd = cache.Add("id", "sssss");
			//验证
			bool boolExists = cache.Exists("id");
			//获取
			object obj = cache.Get("id");
			//删除
			bool boolRemove = cache.Remove("id");
			//修改
			bool boolModify = cache.Modify("id", "ssssssss");

			#endregion

			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
