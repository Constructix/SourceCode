using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using StrayaGaming.Data;
using StrayaGaming.Contracts;

namespace StrayaGaming.Ban.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void PlayerNameIsNotNullNoExceptionExpected()
        {
            string expectedName = "CheesyMantis72";
            IPlayer player = new Player { Name =  "CheesyMantis72" };
            Assert.That(player.Name.Equals(expectedName));
        }

        [Test]
        public void PlayerGuidNotNullExpectedNoException()
        {
            Guid expectedPlayerGuid = new Guid("42e1fde490cfbf33e1038c30762c45db");
            IPlayer player = new Player {Id = new Guid("42e1fde490cfbf33e1038c30762c45db") };
            Assert.That(player.Id.Equals(expectedPlayerGuid));
        }

        [Test]
        public void PlayerCreatedNotNull()
        {
            DateTime expectedCreatedDateTime = DateTime.Today;
            IPlayer player = new Player {Created = DateTime.Now};
            Assert.That(player.Created.Date.Equals(expectedCreatedDateTime));
        }

        [Test]
        public void PlayerIPIsNotNull()
        {
            string expectedIpAddress = "219.74.244.56";
            IPlayer player = new Player {IpAddress = "219.74.244.56"};
            Assert.That(player.IpAddress.Equals(expectedIpAddress));
        }

        [Test]
        public void PlayerStatusIsBanned()
        {
            IPlayer player = new Player {Status = PlayerStatus.Banned};
            Assert.That(player.Status.Equals(PlayerStatus.Banned));
        }

        [Test]
        public void PlayerStatusIsPlaying()
        {

            PlayerStatus expectedStatus  = PlayerStatus.Playing;
            IPlayer player = new Player { Status = PlayerStatus.Playing };
            Assert.That(player.Status.Equals(expectedStatus));
        }

        [Test]
        public void PlayerBansNotNull()
        {
            List<IBan> bans = new List<IBan>();
            bans.Add(new Data.Ban());

            Mock<IPlayer> playerMock = new Mock<IPlayer>();
            playerMock.Setup(x => x.Bans).Returns(bans);
            Assert.That(playerMock.Object.Bans.Any());
        }
    }
}