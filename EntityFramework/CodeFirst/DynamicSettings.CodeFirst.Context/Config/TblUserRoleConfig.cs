using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DynamicSettings.EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicSettings.CodeFirst.Context.Config
{
    public class TblUserRoleConfig : IEntityTypeConfiguration<TblUserRole>
	{
		public void Configure(EntityTypeBuilder<TblUserRole> builder)
		{
			//builder.HasKey(q => q.ID);
			//builder.Property(q => q.Name).HasMaxLength(100).IsRequired();
			//builder.Property(q => q.Password).HasMaxLength(100).IsRequired();
			//builder.Property(q => q.TimeCreated).IsRequired();

			////使用HasOne和WithOne两个扩展方法对User表和Address表进行1-1关系配置
			//builder.HasOne(q => q.Address).WithOne(q => q.User).HasForeignKey<Address>(q => q.UserID);

			//builder.HasKey(q => q.ID);
			//builder.Property(q => q.Area).HasMaxLength(100).IsRequired();
			//builder.Property(q => q.City).HasMaxLength(100).IsRequired();
			//builder.Property(q => q.Country).HasMaxLength(100).IsRequired();
			//builder.Property(q => q.Province).HasMaxLength(100).IsRequired();
			//builder.Property(q => q.Street).HasMaxLength(200).IsRequired();
			//builder.Property(q => q.TimeCreated).IsRequired();
			//builder.Property(q => q.UserID).IsRequired();


			//builder.HasKey(q => q.ID);
			//builder.Property(q => q.Name).HasMaxLength(100).IsRequired();
			//builder.Property(q => q.PublicNo).HasMaxLength(100).IsRequired();

			//builder.HasOne(q => q.User).WithMany(q => q.Books).HasForeignKey(q => q.UserID).IsRequired(false);


			//builder.HasKey(q => new
			//{
			//	q.AuthorID,
			//	q.BookID
			//});

			//builder.HasOne(q => q.Author).WithMany(q => q.AuthorsInBooks).HasForeignKey(q => q.AuthorID);
			//builder.HasOne(q => q.Book).WithMany(q => q.AuthorsInBooks).HasForeignKey(q => q.BookID);





			//throw new NotImplementedException();
		}
	}
}