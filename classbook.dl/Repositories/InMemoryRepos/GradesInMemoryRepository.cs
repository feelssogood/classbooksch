using classbook.dl.InMemoryDB;
using classbook.dl.Interfaces;
using classbook.models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace classbook.dl.Repositories
{
    public class GradesInMemoryRepository : IGradeRepository
    {
        public GradesInMemoryRepository()
        {

        }

        public Currentgrades Create(Currentgrades currentgrades)
        {
            GradesInMemoryCollection.currentgradesDB.Add(currentgrades);
            return currentgrades;
        }

        public Currentgrades Delete(int id)
        {
            var grade = GradesInMemoryCollection.currentgradesDB.FirstOrDefault(grade => grade.Id == id);
            GradesInMemoryCollection.currentgradesDB.Remove(grade);
            return grade;
        }

        public IEnumerable<Currentgrades> GetAll()
        {
            return GradesInMemoryCollection.currentgradesDB;
        }

        public Currentgrades GetById(int id)
        {
            return GradesInMemoryCollection.currentgradesDB.FirstOrDefault(g => g.Id == id);
        }

        public Currentgrades Update(Currentgrades currentgrades)
        {
            var result = GradesInMemoryCollection.currentgradesDB.FirstOrDefault(g => g.Id == currentgrades.Id);

            result.Id = currentgrades.Id;
            result.Mark = currentgrades.Mark;
            result.Student = currentgrades.Student;

            return result;
        }
    }
}