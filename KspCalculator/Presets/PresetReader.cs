namespace KspCalculator.Presets
{
    using System.IO;
    using System.Xml.Serialization;

    public static class PresetReader
    {
        public static PresetConfiguration GetPresets()
        {
            var presetDeserializer = new XmlSerializer(typeof(PresetConfiguration));
            using (var fs = File.Open("presets.xml", FileMode.Open))
            {
                var presets = (PresetConfiguration)presetDeserializer.Deserialize(fs);
                return presets;
            }
        }
    }
}
