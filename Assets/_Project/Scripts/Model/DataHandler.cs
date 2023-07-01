using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

namespace CountersAnalysis
{
    public static class DataHandler
    {
        private const string XML_FORMAT = ".xml";
        private static readonly string _dataPath = Application.persistentDataPath + "/";

        public static void save<T>(T data, string dataName) where T : class
        {
            string json = JsonUtility.ToJson(data, true);
            string filePath = _dataPath + dataName;

            try
            {
                File.WriteAllText(filePath, json);
            }
            catch (System.Exception exception)
            {
                Debug.Log("Saving error: " + exception.Message);
            }
        }

        public static T load<T>(string dataName) where T : class
        {
            string filePath = _dataPath + dataName;
            //Debug.Log("Data Handler: " + filePath);

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonUtility.FromJson<T>(json);
            }

            return null;
        }

        public static void saveXML<T>(T data, string filePath) where T : struct
        {
            Debug.Log("Data Handler: " + filePath);

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

        public static T loadXML<T>(string filePath) where T : struct
        {
            Debug.Log("Data Handler: " + filePath);
            //C:/Users/VITALIY/AppData/LocalLow/DefaultCompany/CountersAnalysis/

            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader streamReader = new StreamReader(filePath);

                T data = (T)serializer.Deserialize(streamReader);
                streamReader.Close();
                return data;
            }

            Debug.Log("Data Handler: " + "Loading error - file not found!");
            return default;
        }

        public static List<string> readTExtFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).ToList();
            }
            return null;
        }
    }
}