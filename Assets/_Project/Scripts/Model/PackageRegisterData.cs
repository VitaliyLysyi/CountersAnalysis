using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("PackageRegister")]
    public struct PackageRegisterData
    {
        [XmlAttribute("lastID")]
        public int lastID;

        [XmlElement("RegisterElement")]
        public List<PackageRegisterElementData> registerData;
    }
}