using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.models.Response
{
    public class GradesResponse
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public List<Student> Student { get; set; }
    }
}