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
    public class Gradecontroller : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;

        public Gradecontroller(IGradeService gradeService, IMapper mapper)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _gradeService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetByID")]
        public IActionResult GetById(int id)
        {
            var result = _gradeService.GetById(id);
            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] GradesRequest gradeRequest)
        {
            if (gradeRequest == null) return BadRequest();
            var grade = _mapper.Map<Currentgrades>(gradeRequest);
            var result = _gradeService.Create(grade);
            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update([FromBody] Currentgrades grade)
        {
            if (grade == null) return BadRequest();
            var searchGrade = _gradeService.GetById(grade.Id);
            if (searchGrade == null) return NotFound(grade.Id);
            searchGrade.Mark = grade.Mark;

            var result = _gradeService.Update(searchGrade);
            return Ok(result);


        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _gradeService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }
    }
}