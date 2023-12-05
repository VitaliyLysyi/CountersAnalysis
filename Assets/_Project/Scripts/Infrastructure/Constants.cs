using UnityEngine;

namespace CountersAnalysis
{
    public static class Constants
    {
        public static readonly string DEFAULT_DATA_PATH = Application.persistentDataPath;
        public static readonly string DEFAULT_REGISTER_FILE_PATH = DEFAULT_DATA_PATH + "/RegisterData.xml";
        public static readonly string REGISTRED_PACKAGES_DIRECTORY = DEFAULT_DATA_PATH /*+ "/CountersPackages"*/;
    }
}