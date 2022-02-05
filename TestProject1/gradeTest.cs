using AutoMapper;
using classbook.Controllers;
using classbook.dl.Interfaces;
using classbook.dl.Services;
using classbook.Extensions;
using classbook.models.DTO;
using classbook.models.Requests;
using classbook.models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Library.Test
{
    public class gradeTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGradeRepository> _gradeRepository;
        private readonly GradesService _gradeService;
        private readonly Gradecontroller _gradeController;

        private IList<Currentgrades> Currentgradess = new List<Currentgrades>()
        {
            new Currentgrades()
            {
                Id = 1,
                Mark = 6,
            },
            new Currentgrades()
            {
                Id = 2,
                Mark = 3,               
            }
        };
  

        public gradeTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _gradeRepository = new Mock<IGradeRepository>();

            var logger = new Mock<ILogger>();

            _gradeService = new GradesService(_gradeRepository.Object, logger.Object);

            _gradeController = new Gradecontroller(_gradeService, _mapper);
        }

        [Fact]
        public void Grades_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IGradeService>();

            mockedService.Setup(x => x.GetAll()).Returns(Currentgradess);

            //inject
            var controller = new Gradecontroller(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var grade = okObjectResult.Value as IEnumerable<Currentgrades>;
            Assert.NotNull(grade);
            Assert.Equal(expectedCount, Currentgradess.Count());
        }

        [Fact]
        public void Grades_GetById()
        {
            //setup
            var gradeId = 2;

            _gradeRepository.Setup(x => x.GetById(gradeId))
                .Returns(Currentgradess.FirstOrDefault(g => g.Id == gradeId));

            //Act
            var result = _gradeController.GetById(gradeId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as GradesResponse;
            var currentgrades = _mapper.Map<Currentgrades>(response);
        }

        [Fact]
        public void Grade_GetById_NotFound()
        {
            //setup
            var gradeId = 3;

            _gradeRepository.Setup(g => g.GetById(gradeId))
                .Returns(Currentgradess.FirstOrDefault(g => g.Id == gradeId));

            //Act
            var result = _gradeController.GetById(gradeId);

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Grade_Update_Mark()
        {
            var gradeId = 1;
            var expectedMark = 6;

            var grade = Currentgradess.FirstOrDefault(g => g.Id == gradeId);
            grade.Mark = expectedMark;

            _gradeRepository.Setup(g => g.GetById(gradeId))
                .Returns(Currentgradess.FirstOrDefault(g => g.Id == gradeId));
            _gradeRepository.Setup(g => g.Update(grade))
                .Returns(grade);

            //Act
            var gradeUpdateRequest = _mapper.Map<Currentgrades>(grade);
            var result = _gradeController.Update(gradeUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Currentgrades;
            Assert.NotNull(val);
            Assert.Equal(expectedMark, val.Mark);

        }
        [Fact]
        public void Grade_Delete_CurrentMark()
        {
            //Setup
            var gradeId = 1;

            var grade = Currentgradess.FirstOrDefault(g => g.Id == gradeId);

            _gradeRepository.Setup(x => x.Delete(gradeId)).Callback(() => Currentgradess.Remove(grade)).Returns(grade);

            //Act
            var result = _gradeController.Delete(gradeId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Currentgrades;
            Assert.NotNull(val);
            Assert.Equal(1, Currentgradess.Count);
            Assert.Null(Currentgradess.FirstOrDefault(g => g.Id == gradeId));
        }
        [Fact]
        public void Grade_Delete_nonExistMark()
        {
            //Setup
            var gradeId = 3;

            var grade = Currentgradess.FirstOrDefault(g => g.Id == gradeId);

            _gradeRepository.Setup(g => g.Delete(gradeId)).Callback(() => Currentgradess.Remove(grade)).Returns(grade);

            //Act
            var result = _gradeController.Delete(gradeId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(gradeId, response);
        }
        [Fact]
        public void Grade_CreateMark()
        {
            //setup
            var grade = new Currentgrades()
            {
                Id = 5,
                Mark = 3
            };

            _gradeRepository.Setup(g => g.GetAll()).Returns(Currentgradess);
                                        
            _gradeRepository.Setup(g => g.Create(It.IsAny<Currentgrades>())).Callback(() =>
            {
                Currentgradess.Add(grade);
            }).Returns(grade);

            //Act
            var result = _gradeController.Create(_mapper.Map<GradesRequest>(grade));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Currentgradess.FirstOrDefault(g => g.Id == grade.Id));
            Assert.Equal(3, Currentgradess.Count);

        }
    }
}
