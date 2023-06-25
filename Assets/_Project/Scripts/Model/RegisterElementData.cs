using System;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("RegisterElement")]
    public struct RegisterElementData
    {
        [XmlAttribute("Path")]
        public string path;
    }
}