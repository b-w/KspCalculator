namespace KspCalculator.Presets
{
    using System.Xml.Serialization;

    public class PresetEngine
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("TrustVacc")]
        public double TrustVacc { get; set; }

        [XmlAttribute("TrustAtm")]
        public double TrustAtm { get; set; }

        [XmlAttribute("IspVacc")]
        public double IspVacc { get; set; }

        [XmlAttribute("IspAtm")]
        public double IspAtm { get; set; }
    }
}
