using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.dl.Interfaces
{
    public interface IGradeService
    {
        Currentgrades Create(Currentgrades currentgrades);

        Currentgrades Update(Currentgrades currentgrades);

        Currentgrades Delete(int id);

        Currentgrades GetById(int id); 
        IEnumerable<Currentgrades> GetAll();
    }
}