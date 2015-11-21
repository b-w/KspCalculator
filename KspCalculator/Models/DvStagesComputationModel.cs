namespace KspCalculator.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using KspMath;
    using KspMath.DVStages;

    public class DvStagesComputationModel : INotifyPropertyChanged
    {
        public DvStagesComputationModel()
        {
            StageConfig = new ObservableCollection<StageConfigurationModel>();
            StageConfig.CollectionChanged += StageConfig_CollectionChanged;

            Gravity = 9.81;
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
                ComputeStageDeltaVs();
            }
        }

        double m_totalDeltaV;
        public double TotalDeltaV
        {
            get
            {
                return m_totalDeltaV;
            }
            set
            {
                m_totalDeltaV = value;

                OnPropertyChanged(nameof(TotalDeltaV));
            }
        }

        public ObservableCollection<StageConfigurationModel> StageConfig { get; set; }

        void StageConfig_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (StageConfigurationModel item in e.NewItems)
                {
                    item.RecomputeRequired += StageConfigurationModel_RecomputeRequired; ;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (StageConfigurationModel item in e.OldItems)
                {
                    item.RecomputeRequired -= StageConfigurationModel_RecomputeRequired;
                }
            }

            ComputeStageDeltaVs();
        }

        void StageConfigurationModel_RecomputeRequired(StageConfigurationModel source)
        {
            ComputeStageDeltaVs();
        }

        void ComputeStageDeltaVs()
        {
            var currentTotalDv = 0d;
            var stages = new List<StageConfiguration>();
            foreach (var stage in StageConfig)
            {
                var singleStageParam = new DvStagesParameters()
                {
                    Gravity = this.Gravity,
                    StageConfiguration = new List<StageConfiguration> { stage.UnderlyingValue }
                };
                stage.StageDeltaV = DvStagesComputation.ComputeTotalDeltaV(singleStageParam);

                stages.Add(stage.UnderlyingValue);

                var stagesParam = new DvStagesParameters()
                {
                    Gravity = this.Gravity,
                    StageConfiguration = stages
                };
                stage.EffectiveDeltaV = DvStagesComputation.ComputeTotalDeltaV(stagesParam) - currentTotalDv;

                currentTotalDv += stage.EffectiveDeltaV;
            }
            TotalDeltaV = currentTotalDv;
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
