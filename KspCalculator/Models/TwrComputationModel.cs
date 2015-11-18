namespace KspCalculator.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using KspMath;
    using KspMath.TWR;

    public class TwrComputationModel : INotifyPropertyChanged
    {
        public TwrComputationModel()
        {
            m_gravity = 9.81;
            EngineConfig = new ObservableCollection<EngineConfigurationModel>();
            EngineConfig.CollectionChanged += EngineConfig_CollectionChanged;
        }

        public ObservableCollection<EngineConfigurationModel> EngineConfig { get; set; }

        double m_rocketMass;
        public double RocketMass
        {
            get
            {
                return m_rocketMass;
            }
            set
            {
                m_rocketMass = value;

                OnPropertyChanged(nameof(RocketMass));
                OnPropertyChanged(nameof(TrustToWeightRatio));
            }
        }

        double m_gravity;
        public double Gravity
        {
            get
            {
                return m_gravity;
            }
            set
            {
                m_gravity = value;

                OnPropertyChanged(nameof(Gravity));
                OnPropertyChanged(nameof(TrustToWeightRatio));
            }
        }

        public double TrustToWeightRatio
        {
            get
            {
                var twrParams = new TwrParameters()
                {
                    Gravity = this.Gravity,
                    RocketMass = this.RocketMass,
                    EngineConfiguration = new List<EngineConfiguration>(this.EngineConfig.Select(x => x.UnderlyingValue))
                };
                return TwrComputation.ComputeTwr(twrParams);
            }
        }

        void EngineConfig_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (EngineConfigurationModel item in e.NewItems)
                {
                    item.PropertyChanged += EngineConfigurationModel_PropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (EngineConfigurationModel item in e.OldItems)
                {
                    item.PropertyChanged -= EngineConfigurationModel_PropertyChanged;
                }
            }

            OnPropertyChanged(nameof(TrustToWeightRatio));
        }

        void EngineConfigurationModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TrustToWeightRatio));
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
