using System;
using System.Collections.Generic;
using System.Diagnostics;
using CommandLine;

namespace SvnAutomation
{
    public  class Program
    {
        public static TraceSource traceSource = new TraceSource("Tracing");

        /// <summary>
        /// Parse the arguments and act accordingly.
        /// </summary>
        /// <param name="arguments"></param>
        static void Main(string[] arguments)
        {
            Arguments parsedArguments = new Arguments();
            if (Parser.ParseArgumentsWithUsage(arguments, parsedArguments))
            {
                if (parsedArguments.update == true)
                {
                    Update();
                }
                if (parsedArguments.info == true)
                {
                    Info();
                }
            }
            else
            {
                // parse error, do nothing
            }
            #if DEBUG
            // Wait for user to end, just for convenience when launching from within Visual Studio.
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            #endif
        }

        /// <summary>
        /// Update the repositories, one for each team and one for each student, provided
        /// the student is in a team.  
        /// </summary>
        private static void Update()
        {
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Update Start at " + DateTime.Now.ToString());
            Moodle moodle = moodle = new Moodle(Settings.MoodleUrl);
           // moodle.Save(Settings.CacheFile);
            foreach (Team team in moodle.Teams)
            {
                // Create shared repository for the team
                Repository teamRepository = new Repository(team.Module + "_" + team.Name, team.Students);
                teamRepository.Create();
                foreach (Student student in team.Students)
                {
                    // Create personal repository for each student
                    List<Student> students = new List<Student>();
                    students.Add(student);
                    Repository studentRepository = new Repository(team.Module + "_" + student.Login, students);
                    studentRepository.Create();
                }
            }
        }

        /// <summary>
        /// Provide some information about the teams etc....
        /// </summary>
        private static void Info()
        {
            Console.WriteLine("Not implemented yet");
        }
    }
}
