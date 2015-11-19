namespace KspCalculator.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using KspMath;
    using KspMath.ISP;

    public class IspComputationModel : INotifyPropertyChanged
    {
        public IspComputationModel()
        {
            EngineConfig = new ObservableCollection<EngineConfigurationModel>();
            EngineConfig.CollectionChanged += EngineConfig_CollectionChanged;
        }

        public ObservableCollection<EngineConfigurationModel> EngineConfig { get; set; }

        public double CombinedIsp
        {
            get
            {
                var ispParams = new IspParameters()
                {
                    EngineConfiguration = new List<EngineConfiguration>(this.EngineConfig.Select(x => x.UnderlyingValue))
                };
                return IspComputation.ComputeCombinedIsp(ispParams);
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

            OnPropertyChanged(nameof(CombinedIsp));
        }

        void EngineConfigurationModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CombinedIsp));
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
