using classbook.dl.Interfaces;
using classbook.models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace classbook.dl.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILogger _logger;

        public TeacherService(ITeacherRepository teacherRepository, ILogger logger)

        {
            _teacherRepository = teacherRepository;
            _logger = logger;
        }

        public Teacher Create(Teacher Teacher)
        {
            try
            {
                var index = _teacherRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
                Teacher.Id = (int)(index != null ? index + 1 : 1);
                return _teacherRepository.Create(Teacher);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            _logger.Information("Teacher Created()");
            return _teacherRepository.Create(Teacher);
        }

        public Teacher Delete(int id)
        {
            _logger.Information("Teacher Deleted()");
            return _teacherRepository.Delete(id);
        }

        public IEnumerable<Teacher> GetAll()
        {
            _logger.Information("Teacher GetAll()");
            return _teacherRepository.GetAll();
        }

        public Teacher GetById(int id)
        {
            _logger.Information("Teacher GetbyID()");
            return _teacherRepository.GetById(id);
        }

        public Teacher GetbyName(string name)
        {
            _logger.Information("Teacher Get by Name()");
            return _teacherRepository.GetbyName(name);
        }

        public Teacher Update(Teacher Teacher)
        {
            _logger.Information("Teacher Update()");
            return _teacherRepository.Update(Teacher);
        }
    }
}