using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DynamicSettings.EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicSettings.CodeFirst.Context.Config
{
    public class TblUserRightConfig : IEntityTypeConfiguration<TblGroupRight>
	{
		public void Configure(EntityTypeBuilder<TblGroupRight> builder)
		{
			throw new NotImplementedException();
		}
	}
}