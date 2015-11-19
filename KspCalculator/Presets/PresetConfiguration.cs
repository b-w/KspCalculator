namespace KspCalculator.Presets
{
    using System.Xml.Serialization;

    [XmlRoot("Presets")]
    public class PresetConfiguration
    {
        [XmlArray("Parts")]
        [XmlArrayItem("Part")]
        public PresetPart[] Parts { get; set; }

        [XmlArray("Engines")]
        [XmlArrayItem("Engine")]
        public PresetEngine[] Engines { get; set; }
    }
}
