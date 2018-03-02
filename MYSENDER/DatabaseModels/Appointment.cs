using System;
using System.Collections.Generic;

namespace MYSENDER.DatabaseModels
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int? Idcontact { get; set; }

        public virtual Contact IdcontactNavigation { get; set; }
    }
}
