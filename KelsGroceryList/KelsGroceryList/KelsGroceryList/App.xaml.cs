using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace KelsGroceryList
{
    public partial class App : Application
    {
        public static class Global
        {
            public static bool isNewCat { get; set; }
            public static string dbVersion { get; set; }
            public static Color bgColor { get; set; }
            public static Color textColor { get; set; }
            public static bool isFirstRun { get; set; }
            public static string myCategory { get; set; }
            //public static string myTextSize { get; set; }
        }

        public static groceryRepository GroceryRepo { get; private set; }
        public App(string dbPath)
        {
            InitializeComponent();

            Global.isNewCat = false;

            Current.Resources["text_size"] = Resources["IOStext_size_medium"];

            GroceryRepo = new groceryRepository(dbPath);

            MainPage = new NavigationPage(new KelsGroceryList.MainPage())
            {
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White
            };
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
