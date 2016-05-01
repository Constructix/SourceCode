using System;
using System.Security.Policy;
using NUnit.Framework;
using StrayaGaming.Contracts;

namespace StrayaGaming.Ban.Tests
{
    [TestFixture]
    public class BanTest
    {
        [Test]
        public void BanInstanceCreated()
        {
            IBan ban = new StrayaGaming.Data.Ban();
            Assert.That(ban != null);
            Assert.That(ban is StrayaGaming.Data.Ban);
        }

        [Test]
        public void BanAssignedToPlayer()
        {
            string expectedReason = "team killing";
            IBan ban = new StrayaGaming.Data.Ban {Reason = "team killing"};
            Assert.That(ban.Reason.Equals(expectedReason));
        }

        [Test]
        public void BanTimeOfBan()
        {
            DateTime expectedDateTimeOfBan;
            DateTime.TryParse("01/05/2016 15:30 PM", out expectedDateTimeOfBan);

            IBan ban = new StrayaGaming.Data.Ban {DateTimeOfBan = Convert.ToDateTime("01/05/2016 15:30 PM")};
            Assert.That(ban.DateTimeOfBan.Equals(expectedDateTimeOfBan));
        }

        [Test]
        public void BanDurationIsSevenDays()
        {
            const int expectedBanDuration = 7;
            IBan ban = new StrayaGaming.Data.Ban {Duration = 7};
            Assert.That(ban.Duration == expectedBanDuration);
        }

       
        [Test]
        public void BanDurationTypeIsDays()
        {
            const string expectedBanDurationType = "Days";
            IBan ban = new StrayaGaming.Data.Ban { DurationType = DurationType.Days };
            Assert.That(ban.DurationType.ToString().Equals(expectedBanDurationType));
        }
        [Test]
        public void BanDurationTypeIsHours()
        {
            const string expectedBanDurationType = "Hours";
            IBan ban = new StrayaGaming.Data.Ban { DurationType = DurationType.Hours };
            Assert.That(ban.DurationType.ToString().Equals(expectedBanDurationType));
        }
        [Test]
        public void BanDurationTypeIsPermanent()
        {
            const string expectedBanDurationType = "Permanent";
            IBan ban = new StrayaGaming.Data.Ban { DurationType = DurationType.Permanent };
            Assert.That(ban.DurationType.ToString().Equals(expectedBanDurationType));
        }

        [Test]
        public void BanEvidence()
        {
            const string evidence = "Joe Bloggs";
            IBan ban =new StrayaGaming.Data.Ban{Evidence = "Joe Bloggs"};
            Assert.That(ban.Evidence.Equals(evidence));
        }

        [Test]
        public void BanNotes()
        {
            const string expectedNotes = "This is a test";
            IBan ban = new StrayaGaming.Data.Ban() {Notes = "This is a test"};
            Assert.That(ban.Notes.Equals(expectedNotes));
        }

        [Test]
        public void BanExpiryDueDate()
        {
            DateTime expectedBanDueDate = DateTime.Today.AddDays(1);

            IBan ban = new StrayaGaming.Data.Ban();
            ban.ExpiryDueDate = DateTime.Today.AddDays(1);
            Assert.That(ban.ExpiryDueDate.Equals(expectedBanDueDate));
        }

    }
}