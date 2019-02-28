using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DynamicSettings.CodeFirst.Context;
using DynamicSettings.EF.Model;

namespace DynamicSettings.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private SettingsManagementDbContext ctx;
		public UsersController(SettingsManagementDbContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpPost("users/register")]
		[ValidateAntiForgeryToken]
		public IActionResult Post([FromBody] TblUser user)
		{
			if (ModelState.IsValid)
			{
				//_context.Users.Add(registeruser);
				//_context.SaveChanges();
				//return RedirectToAction("Index");
			}
			//return View(registeruser);
			return StatusCode((int)HttpStatusCode.OK);
		}
	}
}
