namespace KspCalculator.Views
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using KspCalculator.Models;

    /// <summary>
    /// Interaction logic for PartConfigurationGrid.xaml
    /// </summary>
    public partial class PartConfigurationGrid : UserControl
    {
        public PartConfigurationGrid()
        {
            InitializeComponent();
        }

        void PresetLink_Click(object sender, RoutedEventArgs e)
        {
            var part = ((Hyperlink)sender).CommandParameter;
            var presetWindow = new PresetPartWindow()
            {
                Owner = Window.GetWindow(this)
            };
            presetWindow.ShowDialog();
            if (presetWindow.DialogResult == true && presetWindow.SelectedPart != null)
            {
                if (part is PartConfigurationModel)
                {
                    var partModel = (PartConfigurationModel)part;
                    partModel.Name = presetWindow.SelectedPart.Name;
                    partModel.MassTotal = presetWindow.SelectedPart.MassTotal;
                    partModel.MassDry = presetWindow.SelectedPart.MassDry;
                }
                else
                {
                    var dataContext = (ObservableCollection<PartConfigurationModel>)DataContext;
                    dataContext.Add(new PartConfigurationModel()
                    {
                        Name = presetWindow.SelectedPart.Name,
                        MassTotal = presetWindow.SelectedPart.MassTotal,
                        MassDry = presetWindow.SelectedPart.MassDry
                    });
                }
            }
        }
    }
}
