using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace MSWally.Domain
{
    public class MovieDescriptor
    {
        public string MovieName { get; private set; }

        public string FilePath { get; private set; }

        public List<Scene> Scenes { get; private set; }

        public string OriginalXmlText { get; private set; }

        public XmlDocument XmlDocument { get; private set; }

        public bool BackupMade { get; private set; }

        public string ErrorText { get; private set; }

        // -------------------------------------------------------------------------------------------------------------------------



        public static MovieDescriptor Load(string pFile, out string pErrorText)
        {
            pErrorText = null;
            if (string.IsNullOrEmpty(pFile = pFile.Trim()))
            {
                pErrorText = "Invalid file name";
                return null;
            }

            System.Xml.XmlDocument xml = null;
            if (!File.Exists(pFile))
            {
                pErrorText = "File not found";
                return null;
            }

            string fileText;
            try
            {
                fileText = File.ReadAllText(pFile);

                xml = new XmlDocument();
                xml.LoadXml(fileText);
            }
            catch (Exception exception)
            {
                pErrorText = exception.Message;
                return null;
            }

            MovieDescriptor descriptor = new MovieDescriptor();
            descriptor.FilePath = pFile;
            descriptor.OriginalXmlText = fileText;
            descriptor.XmlDocument = xml;
            descriptor.BackupMade = false;

            if (!descriptor.ReadXmlDocument())
            {
                pErrorText = descriptor.ErrorText;
                return null;
            }

            return descriptor;
        }




        private bool ReadXmlDocument()
        {
            ErrorText = null;

            XmlNode titleNode = XmlDocument.SelectSingleNode("/movie/title");
            if (titleNode == null)
            {
                ErrorText = "No Movie Title node found";
                return false;
            }
            MovieName = titleNode.InnerText;

            Scenes = new List<Scene>();
            foreach (XmlNode sceneNode in XmlDocument.SelectNodes("/movie/scenes/scene"))
            {
                Scene scene = new Scene(sceneNode);
                string errorText;
                if (!scene.ReadXmlDocument())
                {
                    ErrorText = scene.ErrorText;
                    return false;
                }

                Scenes.Add(scene);
            }

            return true;
        }

        // ---------------------------------------------------------------------------------------------------

        public bool Save(string pFile, out string pErrorText)
        {
            pErrorText = null;

            bool saveOk = false;
            try
            {
                string text;
                // text = XmlDocument.OuterXml;
                
                using (StringWriter stringWriter = new StringWriter())
                {
                    using (XmlWriter xmlTextWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings() { Indent = true }))
                    {

                        XmlDocument.WriteTo(xmlTextWriter);
                        xmlTextWriter.Flush();
                        text = stringWriter.GetStringBuilder().ToString();
                    }
                }

                // <? xml version = "1.0" encoding = "utf-16" ?>
                if (text.StartsWith("<?"))
                {
                    int startIndex = text.IndexOf("\n");
                    if (startIndex > 0)
                        text = text.Substring(startIndex + 1);
                }
                

                File.WriteAllText(pFile, text);

                SetClean();
                saveOk = true;
            }
            catch (Exception exception)
            {
                pErrorText = exception.Message;
            }

            return saveOk;
        }


        public void SetClean()
        {
            if (Scenes == null)
                return;

            foreach (Scene scene in Scenes)
                scene.SetClean();
        }


        // -----------------------------------------------------------------------------------------------------------

        public bool BackupOriginal(out string pBackupFilename, out string pResultText)
        {
            pBackupFilename = null;
            pResultText = null;
            if (BackupMade)
            {
                pResultText = "Already backed up";
                return true;
            }

            pBackupFilename = GetBackupFilename();
            try
            {
                File.WriteAllText(pBackupFilename, OriginalXmlText);
            }
            catch (Exception exception)
            {
                pResultText = exception.Message;
                return false;
            }

            return true;
        }


        public string GetBackupFilename()
        {
            string folder = Path.GetDirectoryName(FilePath);
            string fileName = Path.GetFileNameWithoutExtension(FilePath);
            string extension = Path.GetExtension(FilePath);

            string backupFileName = $"{fileName}-WallyBackup{extension}";
            return Path.Combine(folder, backupFileName);
        }



        public bool RestoreOriginal(out string pErrorText)
        {
            pErrorText = null;

            string backupFilename = GetBackupFilename();
            if (!File.Exists(backupFilename))
            {
                pErrorText = "Backup file not found";
                return false;
            }

            

            throw new NotImplementedException();
        }
    }
}
