using CustomListView.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CustomListView
{
    public partial class App : Application
    {
        public static GamePresetViewModel GamePresetViewModel { get; private set; }
        public App()
        {
            InitializeComponent();
            GamePresetViewModel = new GamePresetViewModel();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
