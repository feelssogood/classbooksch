using System.Collections.Generic;

namespace classbook.models.DTO
{
    public class Currentgrades
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public List<Student> Student { get; set; }
    }
}