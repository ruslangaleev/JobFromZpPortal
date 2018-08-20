using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Job.Services.Clients.Interfaces;
using Job.Services.ResourceModels;
using Job.Services.Services.Logic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Tests
{
    [TestFixture]
    public class VacancyManagerTests
    {
        [Test]
        public async Task T()
        {
            int count = 3;

            var expectedVacancies = new List<Vacancy>
            {
                new Vacancy(), new Vacancy()
            };
            var actualVacancies = new List<Vacancy>();

            var vacancyRepoMock = new Mock<IVacancyRepository>();
            vacancyRepoMock.Setup(t => t.AddRange(It.IsAny<IEnumerable<Vacancy>>())).Callback((IEnumerable<Vacancy> vacancies) =>
            {
                actualVacancies.AddRange(vacancies);
            }).Returns(Task.FromResult(1));

            var versionRepoMock = new Mock<IVersionRepository>();
            versionRepoMock.Setup(t => t.Add(It.IsAny<VersionInfo>())).Callback((VersionInfo versionInfo) =>
            {
                versionInfo.VersionInfoId = Guid.NewGuid();
            }).Returns(Task.FromResult(1));

            var zpClientMock = new Mock<IZpClient>();
            zpClientMock.Setup(t => t.GetVacancies(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new VacancyInfo
            {
                Count = 100 * count,
                Vacancies = expectedVacancies
            });

            var vacancyManager = new VacancyManager(vacancyRepoMock.Object, versionRepoMock.Object, zpClientMock.Object);
            await vacancyManager.UpdateVacancies();

            Assert.AreEqual(expectedVacancies.Count() * count, actualVacancies.Count());
        }
    }
}
