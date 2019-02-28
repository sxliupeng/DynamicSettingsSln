using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DynamicSettings.EF.Model
{
    public abstract class BaseModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

	    [Required]
		public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}
