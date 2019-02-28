using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblGroupRights")]
    public class TblGroupRight:BaseModel
    {
        [NotMapped]
        public virtual Guid ID { set; get; }

		[NotMapped]
		public virtual string Name { set; get; }

		//[Key,Column(Order = 1)]
		[ForeignKey("TblGroup")]
        public Guid GroupID { get; set; }

	    [ForeignKey("TblRight")]
		//[Key,Column(Order = 2)]
		public Guid RightID { get; set; }

        public virtual TblGroup TblGroup { get; set; }

        public virtual TblRight TblRight { get; set; }
    }
}