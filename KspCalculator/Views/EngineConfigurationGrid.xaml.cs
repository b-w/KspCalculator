namespace KspCalculator.Views
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using KspCalculator.Models;

    /// <summary>
    /// Interaction logic for EngineConfigurationGrid.xaml
    /// </summary>
    public partial class EngineConfigurationGrid : UserControl
    {
        public EngineConfigurationGrid()
        {
            InitializeComponent();
        }

        void PresetLink_Click(object sender, RoutedEventArgs e)
        {
            var engine = ((Hyperlink)sender).CommandParameter;
            var presetWindow = new PresetEngineWindow()
            {
                Owner = Window.GetWindow(this)
            };
            presetWindow.ShowDialog();
            if (presetWindow.DialogResult == true && presetWindow.SelectedEngine != null)
            {
                var optionWindow = new PresetEngineOptionWindow()
                {
                    Owner = Window.GetWindow(this)
                };
                optionWindow.ShowDialog();

                double isp, trust;
                switch (optionWindow.SelectedOption)
                {
                    case PresetEngineOptionWindow.EngineOption.Atm:
                        isp = presetWindow.SelectedEngine.IspAtm;
                        trust = presetWindow.SelectedEngine.TrustAtm;
                        break;
                    case PresetEngineOptionWindow.EngineOption.Vac:
                        isp = presetWindow.SelectedEngine.IspVac;
                        trust = presetWindow.SelectedEngine.TrustVac;
                        break;
                    default:
                        return;
                }

                if (engine is EngineConfigurationModel)
                {
                    var engineModel = (EngineConfigurationModel)engine;
                    engineModel.Name = presetWindow.SelectedEngine.Name;
                    engineModel.EngineSpecificImpulse = isp;
                    engineModel.EngineTrust = trust;
                }
                else
                {
                    var dataContext = (ObservableCollection<EngineConfigurationModel>)DataContext;
                    dataContext.Add(new EngineConfigurationModel()
                    {
                        Name = presetWindow.SelectedEngine.Name,
                        EngineCount = 1,
                        EngineSpecificImpulse = isp,
                        EngineTrust = trust
                    });
                }
            }
        }
    }
}
