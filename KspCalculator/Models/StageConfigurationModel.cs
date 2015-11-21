namespace KspCalculator.Models
{
    using System.ComponentModel;
    using KspMath;

    public class StageConfigurationModel : INotifyPropertyChanged
    {
        readonly StageConfiguration m_value;

        public StageConfigurationModel()
        {
            m_value = new StageConfiguration();
        }

        internal StageConfiguration UnderlyingValue
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

        public double Mass
        {
            get
            {
                return m_value.Mass;
            }
            set
            {
                m_value.Mass = value;

                OnPropertyChanged(nameof(Mass));
                OnRecomputeRequired();
            }
        }

        public double MassDry
        {
            get
            {
                return m_value.MassDry;
            }
            set
            {
                m_value.MassDry = value;

                OnPropertyChanged(nameof(MassDry));
                OnRecomputeRequired();
            }
        }

        public double Isp
        {
            get
            {
                return m_value.Isp;
            }
            set
            {
                m_value.Isp = value;

                OnPropertyChanged(nameof(Isp));
                OnRecomputeRequired();
            }
        }

        double m_dvStage;
        public double StageDeltaV
        {
            get
            {
                return m_dvStage;
            }
            set
            {
                m_dvStage = value;

                OnPropertyChanged(nameof(StageDeltaV));
            }
        }

        double m_dvEffective;
        public double EffectiveDeltaV
        {
            get
            {
                return m_dvEffective;
            }
            set
            {
                m_dvEffective = value;

                OnPropertyChanged(nameof(EffectiveDeltaV));
            }
        }

        public delegate void RecomputeHandler(StageConfigurationModel source);

        public event RecomputeHandler RecomputeRequired;

        void OnRecomputeRequired()
        {
            RecomputeRequired?.Invoke(this);
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
