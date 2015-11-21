namespace KspCalculator.Presets
{
    using System.Xml.Serialization;

    public class PresetEngine : PresetItem
    {
        [XmlAttribute("TrustVac")]
        public double TrustVac { get; set; }

        [XmlAttribute("TrustAtm")]
        public double TrustAtm { get; set; }

        [XmlAttribute("IspVac")]
        public double IspVac { get; set; }

        [XmlAttribute("IspAtm")]
        public double IspAtm { get; set; }
    }
}
