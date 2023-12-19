using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CountersAnalysis
{
    [Serializable]
    [XmlRoot("ResultPackage")]
    public struct ResultPackageData 
    {
        [XmlAttribute("Name")]
        public string name;

        [XmlAttribute("Date")]
        public DateTime date;

        [XmlElement("Package")]
        public List<RegistrableData> packages;
    }
}