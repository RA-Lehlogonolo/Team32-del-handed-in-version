using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class CollectionReminder
    {
        public int CollectionReminderId { get; set; }
        public int OrderId { get; set; }
        public string CollectionReminderDescription { get; set; }

        public virtual Order Order { get; set; }
    }
}
