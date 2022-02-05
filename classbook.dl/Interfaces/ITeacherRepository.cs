using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.dl.Interfaces
{
    public interface ITeacherRepository
    {
        Teacher Create(Teacher Teacher);

        Teacher Update(Teacher Teacher);

        Teacher Delete(int id);

        Teacher GetById(int id);

        Teacher GetbyName(string name);

        IEnumerable<Teacher> GetAll();
    }
}