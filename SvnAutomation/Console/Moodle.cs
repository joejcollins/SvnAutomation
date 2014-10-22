using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace SvnAutomation
{
    class Moodle
    {
        public static string MOODLE_XML_CACHE = "Moodle_copy.xml";
        private XElement xml;
        private List<Team> teams = new List<Team>();

        /// <summary>
        /// Create a Moodle object with data from a file or from a server.
        /// For debugging purposes the data is cached, but it is not used
        /// subsequently.
        /// </summary>
        /// <param name="url"></param>
        public Moodle(string url)
        {
            this.xml = XElement.Load(url);
            this.xml.Save(MOODLE_XML_CACHE);
            GetTeamsList(this.xml);
        }

        /// <summary>
        /// And XElement containing the entire xml from the Moodle server.
        /// </summary>
        public XElement Xml
        {
            get
            {
                return this.xml;
            }
        }

        /// <summary>
        /// Create a list of the teams on the Moodle server.  The team names
        /// are unique within the modules, but may not be unique to all the modules,
        /// so the name of the module is appended to the name of the team.
        /// </summary>
        /// <param name="xelement"></param>
        private void GetTeamsList(XElement xelement)
        {
            IEnumerable<XElement> modulesXml = from elements in xelement.Descendants("team") select elements;
            foreach (XElement teamXml in modulesXml)
            {
                string moduleName = (string)teamXml.Parent.Attribute("name");
                string teamName = (string)teamXml.Attribute("name");
                Team team = new Team(moduleName, teamName, teamXml);
                this.teams.Add(team);
            }
        }

        /// <summary>
        /// List of all the teams in all the modules.
        /// </summary>
        public List<Team> Teams
        {
            get
            {
                return this.teams;
            }
        }
    }
}
