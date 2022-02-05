using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.dl.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student);

        Student Update(Student student);

        Student Delete(int id);

        Student GetById(int id);

        Student GetbyName(string name);

        IEnumerable<Student> GetAll();
    }
}