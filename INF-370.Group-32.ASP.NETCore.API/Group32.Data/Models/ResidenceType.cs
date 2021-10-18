using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class ResidenceType
    {
        public ResidenceType()
        {
            Residences = new HashSet<Residence>();
        }

        public int ResidenceTypeId { get; set; }
        public string ResidenceTypeName { get; set; }

        public virtual ICollection<Residence> Residences { get; set; }
    }
}
