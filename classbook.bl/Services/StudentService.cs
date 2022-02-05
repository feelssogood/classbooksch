using classbook.dl.Interfaces;
using classbook.models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace classbook.dl.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger _logger;

        public StudentService(IStudentRepository studentRepository, ILogger logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public Student Create(Student student)
        {
            try
            {
                var index = _studentRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
                student.Id = (int)(index != null ? index + 1 : 1);
                return _studentRepository.Create(student);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            _logger.Information("Grade Created()");
            return _studentRepository.Create(student);
        }

        public Student Delete(int id)
        {
            _logger.Information("Student Deleted()");
            return _studentRepository.Delete(id);
        }

        public IEnumerable<Student> GetAll()
        {
            _logger.Information("Student GetAll()");
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            _logger.Information("Student GetById()");

            return _studentRepository.GetById(id);
        }

        public Student GetbyName(string name)
        {
            _logger.Information("Student GetByName()");

            return _studentRepository.GetbyName(name);
        }

        public Student Update(Student student)
        {
            _logger.Information("Student Updated()");
            return _studentRepository.Update(student);
        }
    }
}