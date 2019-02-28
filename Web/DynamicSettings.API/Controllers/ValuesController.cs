using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicSettings.API.Model;
using DynamicSettings.CodeFirst.Context;
using Microsoft.AspNetCore.Mvc;
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

		public ValuesController(SettingsManagementDbContext context
			, Microsoft.Extensions.Options.IOptions<SmtpConfig> smtpConfig
			, IConfiguration config)
		{
			_context = context;
			SmtpConfig = smtpConfig.Value;
			Config = config;
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
