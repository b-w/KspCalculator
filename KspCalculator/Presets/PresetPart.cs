namespace KspCalculator.Presets
{
    using System.Xml.Serialization;

    public class PresetPart : PresetItem
    {
        [XmlAttribute("MassTotal")]
        public double MassTotal { get; set; }

        [XmlAttribute("MassDry")]
        public double MassDry { get; set; }
    }
}
