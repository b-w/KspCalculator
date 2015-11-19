namespace KspCalculator
{
    using System.Windows;
    using KspCalculator.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataContexts();
        }

        void InitializeDataContexts()
        {
            viewTwrComputation.DataContext = new TwrComputationModel();
            viewIspComputation.DataContext = new IspComputationModel();
            viewDvComputation.DataContext = new DvComputationModel();
        }
    }
}
