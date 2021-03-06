﻿namespace KspCalculator
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
    /// Interaction logic for PresetPartWindow.xaml
    /// </summary>
    public partial class PresetPartWindow : Window
    {
        PresetSelectionModel<PresetPart> m_dataContext;

        public PresetPartWindow()
        {
            InitializeComponent();
            InitializeDataContext();
        }

        public PresetPart SelectedPart { get; private set; }

        void InitializeDataContext()
        {
            var presetConfig = PresetReader.GetPresets();

            m_dataContext = new PresetSelectionModel<PresetPart>(presetConfig.Parts.OrderBy(x => x.Name));
            DataContext = m_dataContext;
        }

        void AcceptPart(PresetPart presetPart)
        {
            if (presetPart != null)
            {
                SelectedPart = presetPart;
                DialogResult = true;
                Close();
            }
        }

        void gridPresetPart_RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var presetPart = row?.Item as PresetPart;
            AcceptPart(presetPart);
        }

        void SearchboxEnterCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var view = m_dataContext.ItemView as ListCollectionView;
            if (view.Count == 1)
            {
                var presetPart = ((IEnumerable)view).Cast<PresetPart>().First();
                AcceptPart(presetPart);
            }
        }

        void SearchboxEnterCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !String.IsNullOrWhiteSpace(txtFilter.Text);
        }
    }
}
