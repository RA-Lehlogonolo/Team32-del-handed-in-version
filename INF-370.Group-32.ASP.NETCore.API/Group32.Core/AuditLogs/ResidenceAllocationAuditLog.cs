
using Group32.Core.ResidenceManagement;
using Group32.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AuditLogs
{
    public class ResidenceAllocationAuditLog
    {
        public int Id { get; set; }
        public string Initiator { get; set; }

        /// <summary>
        /// This can either be Add or Remove
        /// </summary>
        public string OperationType { get; set; }
        public DateTime DateTimeStamp { get; set; }

        public virtual Residence Residence { get; set; }
        public int ResidenceId { get; set; }

        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
