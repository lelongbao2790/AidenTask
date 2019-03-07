using System.Collections.ObjectModel;

namespace CustomListView.Model
{
    public class GamePresetGroup : ObservableCollection<GamePreset>
    {
        public string Name { get; set; }
    }
}