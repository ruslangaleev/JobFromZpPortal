using Job.Data.Models;
using Job.Data.Repositories.Interfaces;
using Job.Services.Clients.Interfaces;
using Job.Services.ResourceModels;
using Job.Services.Services.Logic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            var vacancyRepoMock = new Mock<IVacancyRepository>();
            var versionRepoMock = new Mock<IVersionRepository>();
            versionRepoMock.Setup(t => t.Add(It.IsAny<VersionInfo>())).Callback((VersionInfo versionInfo) =>
            {
                versionInfo.VersionInfoId = Guid.NewGuid();
            }).Returns(Task.FromResult(1));
            //versionRepoMock.Setup(t => t.GetLast(It.IsAny<DataType>())).ReturnsAsync(new VersionInfo());

            var zpClientMock = new Mock<IZpClient>();
            zpClientMock.Setup(t => t.GetVacancies(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new VacancyInfo
            {
                Count = 300,
                Vacancies = new List<Vacancy>
                {
                    new Vacancy(),
                    new Vacancy()
                }
            });

            var vacancyManager = new VacancyManager(vacancyRepoMock.Object, versionRepoMock.Object, zpClientMock.Object);
            await vacancyManager.UpdateVacancies();
        }
    }
}
