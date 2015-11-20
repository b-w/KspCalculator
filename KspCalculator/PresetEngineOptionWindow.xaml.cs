namespace KspCalculator
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for PresetEngineOptionWindow.xaml
    /// </summary>
    public partial class PresetEngineOptionWindow : Window
    {
        public PresetEngineOptionWindow()
        {
            InitializeComponent();
        }

        public EngineOption SelectedOption { get; private set; }

        void PressAKeyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SelectedOption = EngineOption.Atm;
            Close();
        }

        void PressVKeyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SelectedOption = EngineOption.Vac;
            Close();
        }

        public enum EngineOption
        {
            None = 0,
            Atm,
            Vac
        }
    }
}
