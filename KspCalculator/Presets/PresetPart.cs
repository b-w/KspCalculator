namespace KspCalculator.Presets
{
    using System.Xml.Serialization;

    public class PresetPart
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("MassTotal")]
        public double MassTotal { get; set; }

        [XmlAttribute("MassDry")]
        public double MassDry { get; set; }
    }
}
