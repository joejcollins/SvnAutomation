using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace SvnAutomation
{
    /// <summary>
    /// Just a data container
    /// </summary>
    class Team
    {
        private string name;
        private string module;
        private List<Student> students = new List<Student>();

        public Team(string module, string name, XElement xml)
        {
            Program.traceSource.TraceEvent(TraceEventType.Information, 0, "Team=" + name);
            this.name = name;
            this.module = module;
            GetStudentsList(xml);
        }

        /// <summary>
        /// The name of the team as set by Greg in Moodle,
        /// with the name of the module, for example E4007_Team_1
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// The name of the module the team is enrolled on.
        /// </summary>
        public string Module
        {
            get
            {
                return this.module;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        internal void GetStudentsList(XElement xml)
        {
            IEnumerable<XElement> teamXml = from elements in xml.Descendants("member") select elements;
            foreach (XElement memberXml in teamXml)
            {
                string memberName = (string)memberXml.Attribute("name");
                Student student = new Student(memberName);
                this.students.Add(student);
            }
        }

        /// <summary>
        /// List of the students within the team.
        /// </summary>
        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }
    }
}
