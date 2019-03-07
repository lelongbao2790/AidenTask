using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CustomListView.Model
{
    public class GamePreset : INotifyPropertyChanged
    {
        string name = string.Empty;
        bool isEditting = false;
        public Command FinishAddNewPreset { get; }
        public GamePreset()
        {
            Name = "";
            Bands = new List<float> { 0, 0, 0, 0, 0 };
            Type = 2;
            isEditting = false;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsNotEditting
        {
            get
            {
                return !IsEditting;
            }
        }
        public bool IsEditting
        {
            get
            {
                return isEditting;
            }
            set
            {
                if (isEditting != value)
                {
                    if (isEditting)
                    {
                    }
                    isEditting = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotEditting));

                }
            }
        }
        public List<float> Bands { get; set; }
        public int Type { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}