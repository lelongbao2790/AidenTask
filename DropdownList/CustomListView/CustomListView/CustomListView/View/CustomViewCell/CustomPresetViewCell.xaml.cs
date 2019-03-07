using CustomListView.Model;
using CustomListView.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomListView.View.CustomViewCell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPresetViewCell : ViewCell
    {
        public CustomPresetViewCell()
        {
            InitializeComponent();
            Bands = new List<float>();
            this.View.BindingContextChanged += OnBindingContextChanged;
            ////Bands = preset.Bands;
            //this.ContextActions.Add(new MenuItem()
            //{
            //    Text = Bands.Count.ToString()
            //});
        }
        public List<float> Bands { get; set; }
        private void Entry_Completed(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            if (entry.Text.Equals(String.Empty))
            {
                return;
            }
            entry.IsVisible = false;
            App.GamePresetViewModel.IsEnableCreateButton = true;
            App.GamePresetViewModel.MenuIsVisible = true;
            Application.Current.MainPage.BindingContext = App.GamePresetViewModel;
        }
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();

            if (BindingContext == null)
                return;

            GamePreset preset = (GamePreset)this.BindingContext;
        }
    }
}