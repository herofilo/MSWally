using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MSWally.Utils
{
    public static class Utils
    {

        private static string _versionString = null;

        private static string _executableDirectory = null;


        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets a string containing the version of the executable (major + minor + build)
        /// </summary>
        /// <returns>Version string of the executable</returns>
        public static string GetExecutableVersion()
        {
            if (_versionString != null)
                return _versionString;

            Version version =
                Assembly.GetEntryAssembly()?.GetName().Version;

            string revision = (version.Revision > 0) ? $".{version.Revision}" : "";


            return (_versionString = (version == null) ? "?" : $"{version.Major}.{version.Minor}.{version.Build}{revision}");
        }


        /// <summary>
        /// Gets the executable home folder
        /// </summary>
        /// <returns>Path to the executable home folder</returns>
        public static string GetExecutableDirectory()
        {
            return _executableDirectory ?? (_executableDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
        }

        /// <summary>
        /// Gets the executable full path
        /// </summary>
        /// <returns>Path to the executable file</returns>
        public static string GetExecutableFullPath()
        {
            return System.Reflection.Assembly.GetEntryAssembly().Location;
        }


        // -------------------------------------------------------------------------------------------------------

        public static string GetMoviestormMoviesFolder()
        {
            string userDataPath = null;
            string temptativePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Moviestorm");
            if (Directory.Exists(temptativePath) && File.Exists(temptativePath + @"\machinimascope.properties"))
                userDataPath = temptativePath;

            if (userDataPath == null)
            {
                temptativePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Moviestorm");
                if (Directory.Exists(temptativePath) && File.Exists(temptativePath + @"\machinimascope.properties"))
                    userDataPath = temptativePath;
                else
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                }
            }

            string moviesPath = Path.Combine(userDataPath, "Movies");
            return
                Directory.Exists(moviesPath)
                    ? moviesPath
                    : userDataPath;
        }



        // -------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Extension method for Tooltips 
        /// </summary>
        /// <param name="pToolTip">tooltip</param>
        public static void SetDefaults(this ToolTip pToolTip)
        {
            // Set up the delays for the ToolTip.
            pToolTip.AutoPopDelay = 5000;
            pToolTip.InitialDelay = 1000;
            pToolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            pToolTip.ShowAlways = true;
        }


    }
}
