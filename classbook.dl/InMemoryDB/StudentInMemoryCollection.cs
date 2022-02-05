using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.dl.InMemoryDB
{
    public class StudentInMemoryCollection
    {
        public static List<Student> StudentDB = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Alex",
                year = 2,
            },
             new Student()
            {
                Id = 2,
                Name = "Sasho",
                year = 3,
             },
             new Student()
            {
                Id = 3,
                Name = "Petko",
                year = 4,
             }
        };
    }
}