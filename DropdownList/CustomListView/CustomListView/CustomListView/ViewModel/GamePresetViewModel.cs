using CustomListView.Constant;
using CustomListView.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CustomListView.ViewModel
{
    public class GamePresetViewModel : ObservableCollection<GamePresetGroup>
    {
        public GamePresetViewModel()
        {
            gamePresetGroups = new ObservableCollection<GamePresetGroup>();
            LoadData();
            SelectedPresetName = defaultGamePreset.FirstOrDefault()?.Name;
            countOfCustomPreset = customGamePreset.Count;
            IsEnableCreateButton = true;
            CreateNewCustomGamePreset = new Command(NewCustomGamePreset);
            DisplayMenuCommand = new Command(ChangStateMenuVisible);
        }
        public Command CreateNewCustomGamePreset { get; }
        public Command DisplayMenuCommand { get; }
        bool isEnableCreateButton;
        public bool IsEnableCreateButton
        {
            get
            {
                return isEnableCreateButton;
            }
            set
            {
                if (isEnableCreateButton != value)
                {
                    if (value)
                    {
                        if (countOfCustomPreset > 3)
                        {
                            value = !value;
                        }
                    }
                    isEnableCreateButton = value;
                    OnPropertyChanged();
                }
            }
        }
        bool menuIsVisible;
        public bool MenuIsVisible
        {
            get
            {
                return menuIsVisible;
            }
            set
            {
                if (menuIsVisible != value)
                {
                    menuIsVisible = value;
                    OnPropertyChanged();
                }
            }
        }
        GamePreset selectedPreset;
        public GamePreset SelectedPreset
        {
            get
            {
                return selectedPreset;
            }
            set
            {
                if (selectedPreset != value)
                {
                    selectedPreset = value;
                    HandleSelectedPreset();
                }
            }
        }
        string selectedPresetName = String.Empty;
        public string SelectedPresetName
        {
            get
            {
                return selectedPresetName;
            }
            set
            {
                if (selectedPresetName != value)
                {
                    selectedPresetName = value;
                    OnPropertyChanged();
                }
            }
        }
        int countOfCustomPreset;
        public int CountOfCustomPreset
        {
            get
            {
                return countOfCustomPreset;
            }
            set
            {
                if (countOfCustomPreset != value)
                {
                    countOfCustomPreset = value;
                    if (CountOfCustomPreset >= 4)
                    {
                        isEnableCreateButton = false;
                    }
                    OnPropertyChanged();
                }
            }
        }
        private void HandleSelectedPreset()
        {
            SelectedPresetName = selectedPreset.Name;
            MenuIsVisible = false;
        }

        ObservableCollection<GamePresetGroup> gamePresetGroups;

        GamePresetGroup defaultGamePreset = new GamePresetGroup()
        {
            Name = "Default preset"
        };
        GamePresetGroup customGamePreset = new GamePresetGroup()
        {
            Name = "Custom preset"
        };
        public ObservableCollection<GamePresetGroup> GamePresetGroups
        {
            get
            {
                return gamePresetGroups;
            }
            set
            {
                if (gamePresetGroups != value)
                {
                    gamePresetGroups = value;
                }
            }
        }


        private void NewCustomGamePreset()
        {
            if (!IsEnableCreateButton)
            {
                return;
            }
            IsEnableCreateButton = false;
            customGamePreset.Insert(0, new GamePreset()
            {
                IsEditting = true
            });
            CountOfCustomPreset = customGamePreset.Count;
            OnPropertyChanged("GamePresetGroups");
        }

        private void ChangStateMenuVisible()
        {
            MenuIsVisible = !MenuIsVisible;
            OnPropertyChanged("MenuIsVisible");
        }

        protected override event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void LoadData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string dataPath = Utilities.PlatformFileResource("Data");

            using (Stream stream = assembly.GetManifestResourceStream(dataPath))
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<GamePreset>>(json);

                var defaultData = data.Where(x => x.Type == TypeOfGamePreset.DEFAULT_PRESET);
                var customData = data.Where(x => x.Type == TypeOfGamePreset.CUSTOM_PRESET);

                foreach (var item in defaultData)
                {
                    defaultGamePreset.Add(item);
                }
                foreach (var item in customData)
                {
                    customGamePreset.Add(item);
                }
                gamePresetGroups.Add(defaultGamePreset);
                gamePresetGroups.Add(customGamePreset);
            }

        }
    }
}
