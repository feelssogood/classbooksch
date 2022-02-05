using classbook.models.DTO;
using System.Collections.Generic;

namespace classbook.models.Requests
{
    public class GradesRequest
    {
        public int Mark { get; set; }
        public List<Student> Student { get; set; }
    }
}