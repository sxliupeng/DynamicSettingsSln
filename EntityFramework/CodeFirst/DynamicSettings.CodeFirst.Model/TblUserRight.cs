using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblUserRights")]
    public class TblUserRight : BaseModel
    {
		[NotMapped]
	    public virtual Guid ID { set; get; }

	    [NotMapped]
	    public virtual string Name { set; get; }

		[Key]
        [Column(Order = 0)]
		[ForeignKey("TblUser")]
		public Guid UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("TblRight")]
		public Guid RightID { get; set; }

        public virtual TblRight TblRight { get; set; }

        public virtual TblUser TblUser { get; set; }
    }
}