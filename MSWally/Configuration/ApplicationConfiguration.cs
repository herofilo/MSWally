using System;
using System.IO;
using System.Xml.Serialization;
using MSWally.Domain;
using MSWally.UI;

namespace MSWally.Configuration
{
    public class ApplicationConfiguration : ConfigurationFileBase
    {
        public int Tolerance { get; set; } = WorldGraph.ToleranceDefault;

        public int WallPenWidth { get; set; } = WorldGraph.WallPenWidthDefault;

        public decimal HeightMinimum { get; set; } = Wall.HeightMinimumDefault;

        public decimal HeightMaximum { get; set; } = Wall.HeightMaximumDefault;

        public decimal ThicknessMinimum { get; set; } = Wall.ThicknessMinimumDefault;

        public decimal ThicknessMaximum { get; set; } = Wall.ThicknessMaximumDefault;

        public decimal ZOffsetMaximum { get; set; } = Wall.ZOffsetMaximumDefault;

        public static string ConfigurationFilePath => Path.Combine(Utils.Utils.GetExecutableDirectory(), "MSWally.cfg");


        // ----------------------------------------------------------------------------

        public ApplicationConfiguration()
        {

        }


        // ----------------------------------------------------------------------------

        /// <summary>
        /// Loads configuration from file
        /// </summary>
        /// <param name="pErrorText">Text of error, if any</param>
        /// <returns>Application configuration loaded (or null, if failed)</returns>
        public static ApplicationConfiguration Load(out string pErrorText)
        {
            pErrorText = null;

            string configurationFilename = ConfigurationFilePath;

            if (!File.Exists(configurationFilename))
            {
                return null;
            }

            ApplicationConfiguration configurationInfo = new ApplicationConfiguration();

            try
            {
                XmlSerializer serializer = new XmlSerializer(configurationInfo.GetType());
                using (StreamReader reader = new StreamReader(configurationFilename))
                {
                    configurationInfo = (ApplicationConfiguration)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                pErrorText = $"EXCEPTION: {exception.Message}";
                configurationInfo = null;
            }
            return configurationInfo;
        }

    }
}
