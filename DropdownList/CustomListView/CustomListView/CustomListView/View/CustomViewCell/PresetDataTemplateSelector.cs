using CustomListView.Constant;
using CustomListView.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomListView.View.CustomViewCell
{
    class PresetDataTemplateSelector : DataTemplateSelector
    {
        private DataTemplate _customPresetViewCell = new DataTemplate(typeof(CustomPresetViewCell));
        private DataTemplate _defaultPresetViewCell = new DataTemplate(typeof(DefaultPresetViewCell));
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var gamePreset = item as GamePreset;
            switch (gamePreset.Type)
            {
                case TypeOfGamePreset.DEFAULT_PRESET:
                    {
                        return _defaultPresetViewCell;
                    }
                case TypeOfGamePreset.CUSTOM_PRESET:
                    {
                        return _customPresetViewCell;
                    }
                default:
                    {
                        return _defaultPresetViewCell;
                    }
            }
        }
    }
}
