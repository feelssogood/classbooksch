using classbook.dl.InMemoryDB;
using classbook.dl.Interfaces;
using classbook.models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace classbook.dl.Repositories.InMemoryRepos
{
    public class TeacherInMemoryRepository : ITeacherRepository
    {
        public TeacherInMemoryRepository()
        {
        }

        public Teacher Create(Teacher Teacher)
        {
            TeacherInMemoryCollection.TeacherDB.Add(Teacher);
            return Teacher;
        }

        public Teacher Delete(int id)
        {
            var teacher = TeacherInMemoryCollection.TeacherDB.FirstOrDefault(teacher => teacher.Id == id);
            TeacherInMemoryCollection.TeacherDB.Remove(teacher);
            return teacher;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return TeacherInMemoryCollection.TeacherDB;
        }

        public Teacher GetById(int id)
        {
            return TeacherInMemoryCollection.TeacherDB.FirstOrDefault(teacher => teacher.Id == id);
        }

        public Teacher GetbyName(string name)
        {
            return TeacherInMemoryCollection.TeacherDB.FirstOrDefault(teacher => teacher.Name == name);
        }

        public Teacher Update(Teacher teacher)
        {
            var result = TeacherInMemoryCollection.TeacherDB.FirstOrDefault(t => t.Id == teacher.Id);
            result.Id = teacher.Id;
            result.Name = teacher.Name;

            return result;
        }
    }
}