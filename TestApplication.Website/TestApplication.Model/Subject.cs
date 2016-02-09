using System.Collections.Generic;

namespace TestApplication.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TeacherSubjects> TeacherSubjectList { get; set; }
    }
}
