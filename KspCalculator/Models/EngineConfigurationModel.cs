namespace KspCalculator.Models
{
    using System.ComponentModel;
    using KspMath;

    public class EngineConfigurationModel : INotifyPropertyChanged
    {
        readonly EngineConfiguration m_value;

        public EngineConfigurationModel()
        {
            m_value = new EngineConfiguration();
        }

        internal EngineConfiguration UnderlyingValue
        {
            get
            {
                return m_value;
            }
        }

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

        public double EngineTrust
        {
            get
            {
                return m_value.EngineTrust;
            }
            set
            {
                m_value.EngineTrust = value;

                OnPropertyChanged(nameof(EngineTrust));
                OnPropertyChanged(nameof(TotalTrust));
            }
        }

        public int EngineCount
        {
            get
            {
                return m_value.EngineCount;
            }
            set
            {
                m_value.EngineCount = value;

                OnPropertyChanged(nameof(EngineCount));
                OnPropertyChanged(nameof(TotalTrust));
            }
        }

        public double EngineAngle
        {
            get
            {
                return m_value.EngineAngle;
            }
            set
            {
                m_value.EngineAngle = value;

                OnPropertyChanged(nameof(EngineAngle));
                OnPropertyChanged(nameof(TotalTrust));
            }
        }

        public double EngineSpecificImpulse
        {
            get
            {
                return m_value.EngineSpecificImpulse;
            }
            set
            {
                m_value.EngineSpecificImpulse = value;

                OnPropertyChanged(nameof(EngineSpecificImpulse));
            }
        }

        public double TotalTrust
        {
            get
            {
                return m_value.ComputeTotalTrust();
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
