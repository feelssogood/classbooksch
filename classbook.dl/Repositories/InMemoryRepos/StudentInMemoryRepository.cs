using classbook.dl.InMemoryDB;
using classbook.dl.Interfaces;
using classbook.models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace classbook.dl.Repositories.InMemoryRepos
{
    public class StudentInMemoryRepository : IStudentRepository
    {
        public StudentInMemoryRepository()
        {
        }

        public Student Create(Student student)
        {
            StudentInMemoryCollection.StudentDB.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            var student = StudentInMemoryCollection.StudentDB.FirstOrDefault(student => student.Id == id);
            StudentInMemoryCollection.StudentDB.Remove(student);
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentInMemoryCollection.StudentDB;
        }

        public Student GetById(int id)
        {
            return StudentInMemoryCollection.StudentDB.FirstOrDefault(stud => stud.Id == id);
        }

        public Student GetbyName(string name)
        {
            return StudentInMemoryCollection.StudentDB.FirstOrDefault(stud => stud.Name == name);
        }

        public Student Update(Student student)
        {
            var result = StudentInMemoryCollection.StudentDB.FirstOrDefault(stud => stud.Id == student.Id);

            result.Id = student.Id;
            result.Name = student.Name;
            return result;
        }
    }
}