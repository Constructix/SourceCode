

using GeoLib.Contracts;
using GeoLib.Data;
using GeoLib.Services;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GeoLib.Tests
{
    [TestFixture]
    public class ManagerTests
    {
        [TestCase()]
        public void Test_zip_code_Retrieval()
        {
            Mock<IZipCodeRepository> RepositoryMoq = new Mock<IZipCodeRepository>();

            ZipCode zipCode = new ZipCode()
            {
                City = "LINCOLN PARK",
                State = new State() {Abbreviation = "NJ"},
                Zip = "0735"
            };

            RepositoryMoq.Setup(x => x.GetByZip("07035")).Returns(zipCode);

            IGeoService geoService = new GeoManager(RepositoryMoq.Object);

            var zipData = geoService.GetZipInfo("07035");

            Assert.That(zipData != null);
            Assert.That(zipData.City.Equals("LINCOLN PARK"));



        }

    }
}