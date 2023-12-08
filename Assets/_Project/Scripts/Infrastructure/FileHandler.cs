using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

namespace CountersAnalysis
{
    public static class FileHandler
    {
        //C:/Users/VITALIY/AppData/LocalLow/DefaultCompany/CountersAnalysis/
        private static readonly string _dataPath = Application.persistentDataPath + "/";

        public static void writeXML<T>(T data, string filePath) where T : struct
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamWriter streamWriter = new StreamWriter(filePath);

            try
            {
                serializer.Serialize(streamWriter, data);
            }
            catch (System.Exception exception)
            {
                Debug.Log("Saving error: " + exception.Message);
            }

            streamWriter.Close();
        }

        public static T readXML<T>(string filePath) where T : struct
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader streamReader = new StreamReader(filePath);

                T data = (T)serializer.Deserialize(streamReader);
                streamReader.Close();
                return data;
            }

            Debug.LogWarning("File Handler: Loading error - file not found!");
            return default;
        }

        public static List<string> readTextFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).ToList();
            }
            return null;
        }

        public static void deleteFile(string path)
        {
            if (File.Exists (path))
            {
                File.Delete(path);
                return;
            }

            Debug.Log("File Handler: " + "File not deleted - file not found!");
        }

        public static void saveCSV(string filePath, List<string> stringList)
        {
            TextWriter writer = new StreamWriter(filePath);
            foreach (string str in stringList)
            {
                writer.WriteLine(str);
            }
            writer.Close();
        }
    }
}