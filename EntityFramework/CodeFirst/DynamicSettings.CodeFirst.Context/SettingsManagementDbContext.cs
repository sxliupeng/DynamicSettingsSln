using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DynamicSettings.EF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DynamicSettings.CodeFirst.Context
{
    public class SettingsManagementDbContext:DbContext
    {
		public SettingsManagementDbContext() : base()
		{

		}

		public SettingsManagementDbContext(DbContextOptions<SettingsManagementDbContext> options):base(options)
	    {
		    
	    }

        public DbSet<TblUser> Users { get; set; }
        public DbSet<TblRole> Roles { get; set; }
        public DbSet<TblRight> Rights { get; set; }
        public DbSet<TblGroup> Groups { get; set; }
		public DbSet<TblUserRole> UserRoles { get; set; }
		public DbSet<TblUserGroup> UserGroups { get; set; }
		public DbSet<TblUserRight> UserRights { get; set; }
		public DbSet<TblGroupRole> GroupRoles { get; set; }
		public DbSet<TblRoleRight> RoleRights { get; set; }
		public DbSet<TblGroupRight> GroupRights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<TblGroupRight>().HasKey(t => new { t.GroupID, t.RightID });
			modelBuilder.Entity<TblRoleRight>().HasKey(t => new { t.RightID, t.RoleID });
			modelBuilder.Entity<TblGroupRole>().HasKey(t => new { t.GroupID, t.RoleID });
			modelBuilder.Entity<TblUserRight>().HasKey(t => new { t.UserID, t.RightID });
			modelBuilder.Entity<TblUserGroup>().HasKey(t => new { t.UserID, t.GroupID });
			modelBuilder.Entity<TblUserRole>().HasKey(t => new { t.UserID, t.RoleID });

			//var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
			//       .Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

			//      foreach (var type in typesToRegister)
			//      {

			//       dynamic configurationInstance = Activator.CreateInstance(type);
			//       modelBuilder.ApplyConfiguration(configurationInstance);
			//      }

			base.OnModelCreating(modelBuilder);
        }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    var builder = new ConfigurationBuilder()
			    .SetBasePath(System.IO.Directory.GetCurrentDirectory()) //需要添加Microsoft.Extensions.Configuration.FileExtensions引用
			    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);//需要添加Microsoft.Extensions.Configuration.Json引用
				//.AddJsonFile($"appsettings.json", optional: true);
		    var _config = builder.Build();
		    var connectiongString = _config.GetConnectionString("SqlServer");

			//optionsBuilder.UseSqlServer(config.GetConnectionString("SqlServerConnection"));
		    //string str = "server=.;user id=sa;database=test;password=P@ssw0rd;";

			//optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=netcore;User Id=sa;Password=P@ssw0rd;");

			base.OnConfiguring(optionsBuilder);
	    }
	}
}
