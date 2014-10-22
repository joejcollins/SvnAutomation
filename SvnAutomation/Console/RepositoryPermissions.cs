using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SvnAutomation
{
    public class RepositoryPermissions
    {
        private static RepositoryPermissions instance;
        private const Boolean DO_NOT_APPEND = false;
        private const Boolean APPEND = true;
        private StreamWriter streamWriter = new StreamWriter(Settings.SvnAuthzFile, DO_NOT_APPEND);
        private string repositoryName;
        private List<Student> students;

        /// <summary>
        /// On creation create a file with the header for 
        /// </summary>
        private RepositoryPermissions() 
        {
            using (this.streamWriter)
            {
                // Give root permissions to the lecturers, HARPER-ADAMS\gsEngineeringDepartment
                streamWriter.WriteLine("[/]");
                streamWriter.WriteLine("S-1-5-21-2751556418-30463742-747518010-60173=rw");
                streamWriter.WriteLine();
            }
        }
         
        /// <summary>
        /// 
        /// </summary>
        public static RepositoryPermissions Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositoryPermissions();
                }
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RepositoryName
        {
            set
            {
                this.repositoryName = value;
            }
        }

        /// <summary>
        /// The students that will be able to use the repository
        /// </summary>
        public List<Student> Students
        {
            set 
            {
                this.students = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdatePermissions()
        {
            // Provided RepositoryName and Students aren't null write to the file
            StreamWriter streamWriter = new StreamWriter(Settings.SvnAuthzFile, APPEND);
            using (streamWriter)
            {
                streamWriter.WriteLine("[" + repositoryName + ":/]");
                foreach (Student student in this.students)
                {
                    Program.traceSource.TraceEvent(TraceEventType.Information, 0, "Student=" + student.Login);
                    streamWriter.WriteLine(student.Sid + "=rw");
                }
                streamWriter.WriteLine();
            }
        }
    }
}

