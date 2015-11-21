namespace KspCalculator
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using KspCalculator.Models;
    using KspCalculator.Presets;

    /// <summary>
    /// Interaction logic for PresetEngineWindow.xaml
    /// </summary>
    public partial class PresetEngineWindow : Window
    {
        PresetSelectionModel<PresetEngine> m_dataContext;

        public PresetEngineWindow()
        {
            InitializeComponent();
            InitializeDataContext();
        }

        public PresetEngine SelectedEngine { get; private set; }

        void InitializeDataContext()
        {
            var presetConfig = PresetReader.GetPresets();

            m_dataContext = new PresetSelectionModel<PresetEngine>(presetConfig.Engines.OrderBy(x => x.Name));
            DataContext = m_dataContext;
        }

        void AcceptPart(PresetEngine presetEngine)
        {
            if (presetEngine != null)
            {
                SelectedEngine = presetEngine;
                DialogResult = true;
                Close();
            }
        }

        void gridPresetEngine_RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var presetEngine = row?.Item as PresetEngine;
            AcceptPart(presetEngine);
        }

        void SearchboxEnterCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var view = m_dataContext.ItemView as ListCollectionView;
            if (view.Count == 1)
            {
                var presetEngine = ((IEnumerable)view).Cast<PresetEngine>().First();
                AcceptPart(presetEngine);
            }
        }

        void SearchboxEnterCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !String.IsNullOrWhiteSpace(txtFilter.Text);
        }
    }
}
