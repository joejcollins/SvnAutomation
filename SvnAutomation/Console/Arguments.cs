using System;
using CommandLine;

namespace SvnAutomation
{
    /// <summary>
    /// 
    /// </summary>
    internal class Arguments
    {
        [Argument(ArgumentType.AtMostOnce, DefaultValue = true, HelpText = "Update the respositories from the Moodle teams.")]
        public Boolean update = true;

        [Argument(ArgumentType.AtMostOnce, DefaultValue = false, HelpText = "Provides information about the teams and students.")]
        public Boolean info = true;
    }
}
