#if DEBUG
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SvnAutomation.Tests
{
    [TestFixture]
    class TestTeam
    {
        [Test]
        public void TeamWithThreeMembers()
        {
            Team team = new Team("Second_Year", "Test_Team", XElement.Parse("<team name=\"Team_1\"><member name=\"10045300\" />"
                + "<member name=\"10093600\" /><member name=\"10055100\" /></team>"));
            Assert.AreEqual("Test_Team", team.Name);
            Assert.AreEqual(3, team.Students.Count);
        }

    }
}
#endif
