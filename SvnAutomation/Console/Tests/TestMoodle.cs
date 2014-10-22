#if DEBUG
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SvnAutomation.Tests
{
    [TestFixture]
    public class TestMoodle
    {
        [Test]
        public void LoadFromFile()
        {
            Moodle moodle = new Moodle("Tests/TestMoodleData.xml");
            Assert.AreEqual(9, moodle.Teams.Count);
            Assert.AreEqual("Team_2", moodle.Teams[1].Name);
            Assert.AreEqual(20, moodle.Teams[2].Students.Count);
            Assert.AreEqual("10123500", moodle.Teams[2].Students[1].Login);
            // Did the caching happen
            Assert.LessOrEqual(File.GetLastWriteTime(Moodle.MOODLE_XML_CACHE), DateTime.Now);
        }

        [Test]
        public void LoadFromUrl()
        {
            Moodle moodle = new Moodle("http://dl.dropbox.com/u/22535750/Moodle.xml");
            Assert.AreEqual(9, moodle.Teams.Count);
            Assert.AreEqual("Team_2", moodle.Teams[1].Name);
            Assert.AreEqual(20, moodle.Teams[2].Students.Count);
            Assert.AreEqual("10123500", moodle.Teams[2].Students[1].Login);
        }
    }
}
#endif
