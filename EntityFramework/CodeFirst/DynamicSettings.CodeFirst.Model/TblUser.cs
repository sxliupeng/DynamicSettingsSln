using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DynamicSettings.EF.Model
{
    [Table("TblUsers")]
    public class TblUser:BaseModel
    {
		public TblUser()
		{
			TblUserGroups = new HashSet<TblUserGroup>();
			TblUserRights = new HashSet<TblUserRight>();
			TblUserRoles = new HashSet<TblUserRole>();
		}

		public virtual ICollection<TblUserGroup> TblUserGroups { get; set; }

		public virtual ICollection<TblUserRight> TblUserRights { get; set; }

		public virtual ICollection<TblUserRole> TblUserRoles { get; set; }
	}
}
