namespace KspCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using KspCalculator.Presets;

    /// <summary>
    /// Interaction logic for PresetPartWindow.xaml
    /// </summary>
    public partial class PresetPartWindow : Window
    {
        public PresetPartWindow()
        {
            InitializeComponent();
            InitializeDataContexts();
        }

        public PresetPart SelectedPart { get; private set; }

        void InitializeDataContexts()
        {
            var presetConfig = PresetReader.GetPresets();
            gridPresetPart.DataContext = presetConfig.Parts;
            gridPresetPart.ItemsSource = presetConfig.Parts;
        }

        void gridPresetPart_RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var presetPart = row?.Item as PresetPart;
            if (presetPart != null)
            {
                SelectedPart = presetPart;
                DialogResult = true;
                Close();
            }
        }
    }
}
