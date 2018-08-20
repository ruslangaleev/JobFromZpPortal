using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Job.Services.Clients.Interfaces;
using Job.Services.Services.Logic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job.Tests
{
    [TestFixture]
    public class JobManagerTests
    {
        // Удалит старые рубрики и добавит новые
        [Test]
        public async Task ReturnsNewRubrics()
        {
            // Подготовка
            var expectedRubrics = new List<Rubric>
            {
                new Rubric(),
                new Rubric()
            };
            var actualRubrics = new List<Rubric>
            {
                new Rubric(),
                new Rubric()
            };

            var rubricRepoMock = new Mock<IRubricRepository>();
            rubricRepoMock.Setup(t => t.AddRange(It.IsAny<IEnumerable<Rubric>>())).Callback((IEnumerable<Rubric> param) =>
            {
                actualRubrics.AddRange(param.ToList());
            }).Returns(Task.FromResult(1));

            rubricRepoMock.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<Rubric>>())).Callback((IEnumerable<Rubric> param) =>
            {
                actualRubrics.RemoveRange(0, param.Count());
            }).Returns(Task.FromResult(1));

            rubricRepoMock.Setup(t => t.Get()).ReturnsAsync(actualRubrics);

            var zpClientMock = new Mock<IZpClient>();
            zpClientMock.Setup(t => t.GetRubrics()).ReturnsAsync(expectedRubrics);
            var jobManager = new JobManager(rubricRepoMock.Object, zpClientMock.Object);

            // Действие
            await jobManager.UpdateRubrics();

            // Проверка
            Assert.AreEqual(expectedRubrics.Count, actualRubrics.Count);
        }

        public async Task ReturnsNewVacancies()
        {
        }
    }
}
