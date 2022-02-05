using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.dl.InMemoryDB
{
    public class GradesInMemoryCollection
    {
        public static List<Currentgrades> currentgradesDB = new List<Currentgrades>()
        {
            new Currentgrades()
            {
                Id = 1,
                Mark = 6,
                Student = new List<Student>()
                {
                    new Student()
                    {
                        Id = 1,
                        year = 2,
                        Name = "Alex"
                    }
                }
            },
            new Currentgrades()
            {
                Id = 2,
                Mark = 3,
                Student = new List<Student>()
                {
                    new Student()
                    {
                        Id = 2,
                        year = 3,
                        Name = "Valentin"
                    }
                }
            },
            new Currentgrades()
            {
                Id = 3,
                Mark = 5,
                Student = new List<Student>()
                {
                    new Student()
                    {
                        Id = 3,
                        year = 4,
                        Name = "Vladimir"
                    }
                }
            }

        };
    }
}