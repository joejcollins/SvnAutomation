using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace SvnAutomation
{
    class Repository
    {
        private string repositoryName;
        private List<Student> students;

        /// <summary>
        /// All repositories have to have a name so it is include in the constructor.
        /// </summary>
        /// <param name="repositoryName">Name of the respository or team to be created.</param>
        /// <param name="students"></param>
        public Repository(string repositoryName, List<Student> students)
        {
            this.repositoryName = repositoryName;
            this.students = students;
        }
        
        /// <summary>
        /// Create a repository.  If you attempt to create a repository 
        /// which is already there then a warning message is given, but
        /// it does nothing.
        /// </summary>
        public void Create()
        {
            this.CreateRepository();
            this.UpdatePermissions();
        }

        /// <summary>
        /// Create the subversion respository
        /// </summary>
        private void CreateRepository()
        { 
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = false; // or multiple windows are opened.
                processStartInfo.RedirectStandardOutput = true; // catch the output but ignore.
                processStartInfo.RedirectStandardError = true; // catch the output but ignore.
                processStartInfo.FileName = Settings.SvnAdminPath;
                processStartInfo.Arguments = "create " + Settings.SvnRepositoriesPath + this.repositoryName;
                Process process = Process.Start(processStartInfo);
            }
            catch (Exception exception)
            {
                Program.traceSource.TraceEvent(TraceEventType.Error, 0, exception.Message);
            }
        }

        /// <summary>
        /// Set the permissions on the repository
        /// </summary>
        private void UpdatePermissions()
        {
            RepositoryPermissions repositoryPermissions = RepositoryPermissions.Instance;
            repositoryPermissions.RepositoryName = this.repositoryName;
            repositoryPermissions.Students = this.students;
            repositoryPermissions.UpdatePermissions();
        }

    }
} 
