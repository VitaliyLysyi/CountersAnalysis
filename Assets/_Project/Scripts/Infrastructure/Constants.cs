using UnityEngine;

namespace CountersAnalysis
{
    public static class Constants
    {
        public static readonly string DEFAULT_DATA_PATH = Application.persistentDataPath;

        public static readonly string DEFAULT_REGISTER_FILE_PATH = DEFAULT_DATA_PATH + "/RegisterData.xml";

        public static readonly Color DEFAULT_OUTLINE_COLOR = new Color(0.1568628f, 0.1568628f, 0.1568628f, 1f);

        public static readonly Color SHOW_OUTLINE_COLOR = new Color(1f, 0.8352942f, 0.372549f, 1f);
    }

    public enum RegistredDataType
    {
        CountersPackage,
        CalculationPattern,
        ConsumptionPackage,
        ResultPackage
    }
}