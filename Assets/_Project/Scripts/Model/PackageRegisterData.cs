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
        public List<RegistredPackageData> registerData;

        public PackageRegisterData(int lastID, List<RegistredPackageData> registerData)
        {
            this.lastID = lastID;
            this.registerData = registerData;
        }
    }
}