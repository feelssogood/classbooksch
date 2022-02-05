using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.dl.InMemoryDB
{
    public class TeacherInMemoryCollection
    {
        public static List<Teacher> TeacherDB = new List<Teacher>()
        {
            new Teacher()
            {
                Id = 1,
                Name = "Ivana",
            },
            new Teacher()
            {
                Id = 2,
                Name = "Dimitar",
            },
            new Teacher()
            {
                Id = 3,
                Name = "Stoyan",
            }
        };
    }
}