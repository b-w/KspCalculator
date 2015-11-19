namespace KspCalculator.Presets
{
    using System.Xml.Serialization;

    public abstract class PresetItem
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
