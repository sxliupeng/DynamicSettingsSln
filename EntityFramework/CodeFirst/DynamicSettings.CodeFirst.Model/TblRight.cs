using DynamicSettings.EF.Model.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblRights")]
    public class TblRight:BaseModel
    {
		[Required]
        public Permissions Value { get; set; }

		public TblRight()
		{
			TblGroupRights = new HashSet<TblGroupRight>();
			TblRoleRights = new HashSet<TblRoleRight>();
			TblUserRights = new HashSet<TblUserRight>();
		}
		public virtual ICollection<TblGroupRight> TblGroupRights { get; set; }

		public virtual ICollection<TblRoleRight> TblRoleRights { get; set; }

		public virtual ICollection<TblUserRight> TblUserRights { get; set; }
	}
}