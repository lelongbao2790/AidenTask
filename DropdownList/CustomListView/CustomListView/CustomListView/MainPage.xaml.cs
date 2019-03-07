using CustomListView.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.GamePresetViewModel;
            DownArrow.Source = Utilities.PlatformImageResource("DownArrow");
            DownLine.Source = Utilities.PlatformImageResource("DownLine");
        }
    }
}
