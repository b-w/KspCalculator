namespace KspCalculator.Presets
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public static class PresetReader
    {
        const string PRESETFILE_NAME = "presets.xml";
        const string RSRC_PRESETFILE = "KspCalculator.Resources.presets.xml.bin";

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
            PresetConfiguration config;
            if (TryReadFromDisk(out config))
            {
                return config;
            }

            config = ReadFromInternalResource();

            Task.Factory.StartNew(() => TryWriteInternalResourceToDisk());

            return config;
        }

        static PresetConfiguration DeserializePresets(Stream input)
        {
            var presetDeserializer = new XmlSerializer(typeof(PresetConfiguration));
            return (PresetConfiguration)presetDeserializer.Deserialize(input);
        }

        static PresetConfiguration ReadFromInternalResource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var rs = assembly.GetManifestResourceStream(RSRC_PRESETFILE))
            using (var gz = new GZipStream(rs, CompressionMode.Decompress))
            {
                return DeserializePresets(gz);
            }
        }

        static bool TryReadFromDisk(out PresetConfiguration config)
        {
            config = null;
            try
            {
                using (var fs = File.Open(PRESETFILE_NAME, FileMode.Open))
                {
                    config = DeserializePresets(fs);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        static void TryWriteInternalResourceToDisk()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var rs = assembly.GetManifestResourceStream(RSRC_PRESETFILE))
                using (var fo = File.OpenWrite(PRESETFILE_NAME))
                using (var gz = new GZipStream(rs, CompressionMode.Decompress))
                {
                    gz.CopyTo(fo);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
