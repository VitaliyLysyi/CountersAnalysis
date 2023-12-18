using System;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("RegisterElement")]
    public struct RegistrableData
    {
        [XmlElement("RegisterID")]
        public int registerID;

        [XmlElement("Name")]
        public string name;

        [XmlElement("Path")]
        public string path;

        [XmlElement("Date")]
        public DateTime date;

        [XmlElement("ElementType")]
        public string elementType;

        [XmlElement("Note")]
        public string note;
    }
}