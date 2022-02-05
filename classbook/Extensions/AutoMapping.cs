using AutoMapper;
using classbook.models.DTO;
using classbook.models.Requests;
using classbook.models.Response;

namespace classbook.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Teacher, TeacherResponse>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Currentgrades, GradesResponse>().ReverseMap();
            CreateMap<TeacherRequest, Teacher>().ReverseMap();
            CreateMap<StudentRequest, Student>().ReverseMap();
            CreateMap<GradesRequest, Currentgrades>().ReverseMap();
        }
    }
}