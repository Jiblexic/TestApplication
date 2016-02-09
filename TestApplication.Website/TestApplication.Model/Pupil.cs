using System.Collections.Generic;

namespace TestApplication.Model
{
    public class Pupil
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Attending> AttendingList { get; set; }
    }
}
