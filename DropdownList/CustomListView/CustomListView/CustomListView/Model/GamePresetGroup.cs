using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CustomListView.Model
{
    public class GamePresetGroup : ObservableCollection<GamePreset>
    {
        public event EventHandler ValueChanged;
        public string Name { get; set; }
        public new void Add(GamePreset preset)
        {
            preset.PropertyChanged += OnChildObjectChanged;
            base.Add(preset);
        }
        public new void Insert(int index, GamePreset preset)
        {
            preset.PropertyChanged += OnChildObjectChanged;
            base.Insert(index, preset);
        }

        public new void Remove(GamePreset preset)
        {
            preset.PropertyChanged -= OnChildObjectChanged;
            base.Remove(preset);
        }

        private void OnChildObjectChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(sender, e);
            }
        }
    }
}