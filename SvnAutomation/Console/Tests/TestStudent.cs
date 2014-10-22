#if DEBUG
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SvnAutomation.Tests
{
    [TestFixture]
    class TestStudent
    {
        [Test]
        public void StudentLogin()
        {
            Student student = new Student("10055100");
            Assert.AreEqual("10055100", student.Login);
            // Can't test the Sid because it depends on the domain.
        }
    }
}
#endif