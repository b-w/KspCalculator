namespace KspCalculator
{
    using System;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;
    using System.Reflection;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        const string RSRC_ASSEMBLY_TEMPLATE = "KspCalculator.Libraries.{0}.dll.bin";
        readonly string[] RSRC_ASSEMBLIES = { "KspMath" };

        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            base.OnStartup(e);
        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            if (RSRC_ASSEMBLIES.Contains(assemblyName.Name))
            {
                return LoadAssemblyFromInternalResource(String.Format(RSRC_ASSEMBLY_TEMPLATE, assemblyName.Name));
            }
            return null;
        }

        Assembly LoadAssemblyFromInternalResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var rs = assembly.GetManifestResourceStream(resourceName))
            using (var gz = new GZipStream(rs, CompressionMode.Decompress))
            using (var ms = new MemoryStream())
            {
                gz.CopyTo(ms);
                return Assembly.Load(ms.ToArray());
            }
        }
    }
}
