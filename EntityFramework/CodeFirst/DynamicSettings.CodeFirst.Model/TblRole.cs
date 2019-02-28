using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblRoles")]
    public class TblRole:BaseModel
    {
		public TblRole()
		{
			TblGroupRoles = new HashSet<TblGroupRole>();
			TblRoleRights = new HashSet<TblRoleRight>();
			TblUserRoles = new HashSet<TblUserRole>();
		}
		public virtual ICollection<TblGroupRole> TblGroupRoles { get; set; }

		public virtual ICollection<TblRoleRight> TblRoleRights { get; set; }

		public virtual ICollection<TblUserRole> TblUserRoles { get; set; }
	}
}