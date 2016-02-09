using System.Collections.Generic;

namespace TestApplication.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<TeacherSubjects> TeacherSubjectList { get; set; }
    }
}
