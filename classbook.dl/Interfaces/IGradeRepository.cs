using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.dl.Interfaces
{
    public interface IGradeRepository
    {
        Currentgrades Create(Currentgrades Currentgrades);

        Currentgrades Update(Currentgrades Currentgrades);

        Currentgrades Delete(int id);

        IEnumerable<Currentgrades> GetAll();
        Currentgrades GetById(int id);
    }
}