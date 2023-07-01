using System;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("RegisterElement")]
    public struct PackageRegisterElementData
    {
        [XmlElement("RegisterID")]
        public int registerID;

        [XmlElement("Name")]
        public string name;

        [XmlElement("PackageType")]
        public string packageType;

        [XmlElement("Note")]
        public string note;

        [XmlElement("Date")]
        public DateTime date;

        [XmlElement("Path")]
        public string path;

        [XmlElement("HeadCounterNumber")]
        public string headCounterNumber;

        [XmlElement("CountersCount")]
        public int countersCount;
    }
}