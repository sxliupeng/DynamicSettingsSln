using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblUserGroups")]
    public class TblUserGroup:BaseModel
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
        [ForeignKey("TblGroup")]
		public Guid GroupID { get; set; }

        public virtual TblGroup TblGroup { get; set; }

        public virtual TblUser TblUser { get; set; }
    }
}