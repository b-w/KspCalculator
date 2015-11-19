namespace KspCalculator.Models
{
    using Presets;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Data;

    public class PresetSelectionModel<T> : INotifyPropertyChanged where T : PresetItem
    {
        readonly ObservableCollection<T> m_items;

        public PresetSelectionModel(IEnumerable<T> items)
        {
            m_items = new ObservableCollection<T>(items);
            ItemView = CollectionViewSource.GetDefaultView(m_items);
        }

        string m_filter;
        public string Filter
        {
            get
            {
                return m_filter;
            }
            set
            {
                m_filter = value;

                if (String.IsNullOrWhiteSpace(m_filter))
                {
                    ItemView.Filter = null;
                }
                else
                {
                    ItemView.Filter = x => ((T)x).Name.IndexOf(m_filter, StringComparison.OrdinalIgnoreCase) > -1;
                }
                ItemView.Refresh();

                OnPropertyChanged(nameof(Filter));
            }
        }

        public ICollectionView ItemView { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
