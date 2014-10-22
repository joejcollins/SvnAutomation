What is it for?
===
Setting up individual and team Subversion repositories for first and 
second year engineering students.  And keeping the security up to date.

What does it do?
===
A subversion repository is set up for each of the teams created in the 
first and second year engineering modules (in Moodle).  Once created a
repository is not removed in case in contains valuable information.
However, every time SvnAutomation is run the security on the repositories
is updated so that students can be moved between teams at the correct
permissions are set.  

Incidentally, if a student is not in a team they are ignored, so no
repository is set up for them.

How do you use it?
===
Configure using the xml file "SvnAutomation.exe.config" then run from 
the command line.
