using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblRoleRights")]
    public class TblRoleRight:BaseModel
    {
		[NotMapped]
	    public virtual Guid ID { set; get; }

	    [NotMapped]
	    public virtual string Name { set; get; }

		[Key]
        [Column(Order = 0)]
		[ForeignKey("TblRole")]
		public Guid RoleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("TblRight")]
		public Guid RightID { get; set; }

        public virtual TblRight TblRight { get; set; }

        public virtual TblRole TblRole { get; set; }
    }
}