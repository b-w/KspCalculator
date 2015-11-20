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

        int m_count;
        public int Count
        {
            get
            {
                return m_count;
            }
            set
            {
                m_count = value;
                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(TotalMass));
                OnPropertyChanged(nameof(TotalMassDry));
            }
        }

        double m_mass;
        public double Mass
        {
            get
            {
                return m_mass;
            }
            set
            {
                m_mass = value;
                OnPropertyChanged(nameof(Mass));
                OnPropertyChanged(nameof(TotalMass));
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
                OnPropertyChanged(nameof(TotalMassDry));
            }
        }

        public double TotalMass
        {
            get
            {
                return m_mass * m_count;
            }
        }

        public double TotalMassDry
        {
            get
            {
                return m_massDry * m_count;
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
