namespace KspCalculator.Models
{
    using System.ComponentModel;

    public class PartConfigurationModel : INotifyPropertyChanged
    {
        string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        double m_massTotal;
        public double MassTotal
        {
            get
            {
                return m_massTotal;
            }
            set
            {
                m_massTotal = value;
                OnPropertyChanged(nameof(MassTotal));
            }
        }

        double m_massDry;
        public double MassDry
        {
            get
            {
                return m_massDry;
            }
            set
            {
                m_massDry = value;
                OnPropertyChanged(nameof(MassDry));
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
