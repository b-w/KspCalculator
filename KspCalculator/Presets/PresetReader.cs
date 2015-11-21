namespace KspCalculator.Presets
{
    using System.IO;
    using System.Xml.Serialization;

    public static class PresetReader
    {
        static object m_lock = new object();
        static bool m_presetsRead;
        static PresetConfiguration m_config;

        public static PresetConfiguration GetPresets()
        {
            if (m_presetsRead)
            {
                return m_config;
            }

            lock (m_lock)
            {
                if (!m_presetsRead)
                {
                    m_config = ReadPresets();
                    m_presetsRead = true;
                }
            }
            return m_config;
        }

        static PresetConfiguration ReadPresets()
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
