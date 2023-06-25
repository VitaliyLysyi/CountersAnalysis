using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("PackageRegister")]
    public struct PackageRegisterData
    {
        [XmlElement("RegisterElement")]
        public List<RegisterElementData> registerData;
    }
}