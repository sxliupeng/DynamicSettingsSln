using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicSettings.EF.Model
{
    [Table("TblGroups")]
    public class TblGroup:BaseModel
    {
        public TblGroup()
        {
            TblGroupRights = new HashSet<TblGroupRight>();
            TblGroupRoles = new HashSet<TblGroupRole>();
            TblUserGroups = new HashSet<TblUserGroup>();
        }
        public virtual ICollection<TblGroupRight> TblGroupRights { get; set; }

        public virtual ICollection<TblGroupRole> TblGroupRoles { get; set; }

        public virtual ICollection<TblUserGroup> TblUserGroups { get; set; }
    }
}