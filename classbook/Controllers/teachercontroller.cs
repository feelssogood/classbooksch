using AutoMapper;
using classbook.dl.Interfaces;
using Microsoft.AspNetCore.Mvc;
using classbook.dl.Services;
using classbook.models.Response;
using classbook.models.Requests;
using classbook.models.DTO;

namespace classbook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Teachercontroller : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public Teachercontroller(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _teacherService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();
            var result = _teacherService.GetById(id);
            if (result == null) return NotFound(id);
            var response = _mapper.Map<TeacherResponse>(result);
            return Ok(response);

        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] TeacherRequest teacherRequest)
        {
            if (teacherRequest == null) return BadRequest();
            var teacher = _mapper.Map<Teacher>(teacherRequest);
            var result = _teacherService.Create(teacher);
            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody] Teacher teacher)
        {
            if (teacher == null) return BadRequest();
            var searchTeacher = _teacherService.GetById(teacher.Id);
            if (searchTeacher == null) return NotFound(teacher.Id);
            searchTeacher.Name = teacher.Name;

            var result = _teacherService.Update(searchTeacher);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _teacherService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }
    }
 
}