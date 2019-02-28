using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblUserRoles")]
    public class TblUserRole : BaseModel
    {
		[NotMapped]
	    //private virtual Guid ID { set; get; }
	    private Guid ID { set; get; }

	    [NotMapped]
	    public virtual string Name { set; get; }

		//[Key,Column(Order = 1)]
		//[ForeignKey("TblUser")]
		//public Guid UserID { get; set; }

		//[Key,Column(Order = 2)]
		//[ForeignKey("TblRole")]
		//public Guid RoleID { get; set; }

		//-->此种方式无法创建联合组件,必须使用fluent API

		[Column(Order = 1)]
		[ForeignKey("TblUser")]
		public Guid UserID { get; set; }

		[Column(Order = 2)]
		[ForeignKey("TblRole")]
		public Guid RoleID { get; set; }

		public virtual TblRole TblRole { get; set; }

        public virtual TblUser TblUser { get; set; }
    }
}