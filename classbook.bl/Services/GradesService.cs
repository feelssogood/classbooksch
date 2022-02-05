using classbook.dl.Interfaces;
using classbook.models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace classbook.dl.Services
{
    public class GradesService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ILogger _logger;

        public GradesService(IGradeRepository gradeRepository, ILogger logger)
        {
            _gradeRepository = gradeRepository;
            _logger = logger;
        }

        public Currentgrades Create(Currentgrades currentgrades)
        {
            try
            {
                var index = _gradeRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
                currentgrades.Id = (int)(index != null ? index + 1 : 1);
                return _gradeRepository.Create(currentgrades);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            _logger.Information("Grade Created()");
            return _gradeRepository.Create(currentgrades);
        }

        public Currentgrades Delete(int id)
        {
            _logger.Information("Grade Delete()");
            return _gradeRepository.Delete(id);
        }

        public IEnumerable<Currentgrades> GetAll()
        {
            _logger.Information("Grade GetAll()");
            return _gradeRepository.GetAll();
        }
        public Currentgrades GetById(int id)
        {
            _logger.Information("Grade GetById()");
            return _gradeRepository.GetById(id);
        }

        public Currentgrades Update(Currentgrades currentgrades)
        {
            _logger.Information("Grade Updated()");
            return _gradeRepository.Update(currentgrades);
        }

    }
}