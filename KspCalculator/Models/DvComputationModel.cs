namespace KspCalculator.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using KspMath;
    using KspMath.DV;

    public class DvComputationModel : INotifyPropertyChanged
    {
        public DvComputationModel()
        {
            Gravity = 9.81;

            PartConfig = new ObservableCollection<PartConfigurationModel>();
            PartConfig.CollectionChanged += PartConfig_CollectionChanged;

            EngineConfig = new ObservableCollection<EngineConfigurationModel>();
            EngineConfig.CollectionChanged += EngineConfig_CollectionChanged;
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
                OnPropertyChanged(nameof(DeltaV));
            }
        }

        public ObservableCollection<PartConfigurationModel> PartConfig { get; set; }

        public ObservableCollection<EngineConfigurationModel> EngineConfig { get; set; }

        public double CombinedMassTotal
        {
            get
            {
                return PartConfig.Sum(x => x.TotalMass);
            }
        }

        public double CombinedMassDry
        {
            get
            {
                return PartConfig.Sum(x => x.TotalMassDry);
            }
        }

        public double DeltaV
        {
            get
            {
                var dvParams = new DvParameters()
                {
                    EngineConfiguration = new List<EngineConfiguration>(EngineConfig.Select(x => x.UnderlyingValue)),
                    Gravity = this.Gravity,
                    RocketMassTotal = CombinedMassTotal,
                    RocketMassDry = CombinedMassDry
                };
                return DvComputation.ComputeDeltaV(dvParams);
            }
        }

        void PartConfig_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (PartConfigurationModel item in e.NewItems)
                {
                    item.PropertyChanged += PartConfigurationModel_PropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (PartConfigurationModel item in e.OldItems)
                {
                    item.PropertyChanged -= PartConfigurationModel_PropertyChanged;
                }
            }

            OnPropertyChanged(nameof(CombinedMassTotal));
            OnPropertyChanged(nameof(CombinedMassDry));
            OnPropertyChanged(nameof(DeltaV));
        }

        void PartConfigurationModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CombinedMassTotal));
            OnPropertyChanged(nameof(CombinedMassDry));
            OnPropertyChanged(nameof(DeltaV));
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

            OnPropertyChanged(nameof(DeltaV));
        }

        void EngineConfigurationModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DeltaV));
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
