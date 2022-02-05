using classbook.dl.Interfaces;
using Microsoft.AspNetCore.Mvc;
using classbook.dl.Services;
using classbook.models.Response;
using classbook.models.Requests;
using classbook.models.DTO;
using AutoMapper;

namespace classbook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Studentcontroller : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public Studentcontroller(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _studentService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();
            var result = _studentService.GetById(id);
            if (result == null) return NotFound(id);
            var response = _mapper.Map<StudentResponse>(result);
            return Ok(response);

        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] StudentRequest studentRequest)
        {
            if (studentRequest == null) return BadRequest();
            var student = _mapper.Map<Student>(studentRequest);
            var result = _studentService.Create(student);
            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            var searchStudent = _studentService.GetById(student.Id);
            if (searchStudent == null) return NotFound(student.Id);
            searchStudent.Name = student.Name;
            searchStudent.year = student.year;


            var result = _studentService.Update(searchStudent);
            return Ok(result);
        }     
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _studentService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }
    }

}