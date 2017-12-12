using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KelsGroceryList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class settings : ContentPage
    {
        public settings()
        {
            InitializeComponent();

            topLevelLayout.BackgroundColor = App.Global.bgColor;
            clearAllDataLabel.TextColor = App.Global.textColor;
            clearItemsLabel.TextColor = App.Global.textColor;
            colorChangeLabel.TextColor = App.Global.textColor;
            statusLabelt.TextColor = App.Global.textColor;
            statusLabelth.TextColor = App.Global.textColor;
            textChangeLabel.TextColor = App.Global.textColor;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //topLevelLayout = null;
            //clearAllDataLabel = null;
            //clearItemsLabel = null;
            //colorChangeLabel = null;
            //statusLabelt = null;
            //statusLabelth = null;
            //textChangeLabel = null;

            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //App.Current.Resources["text_size"] = (App.Global.myTextSize == "Large" ? App.Current.Resources["IOStext_size_large"] : (App.Global.myTextSize == "Small" ? App.Current.Resources["IOStext_size_small"] : App.Current.Resources["IOStext_size_medium"]));
            
            topLevelLayout.BackgroundColor = App.Global.bgColor;
            clearAllDataLabel.TextColor = App.Global.textColor;
            clearItemsLabel.TextColor = App.Global.textColor;
            colorChangeLabel.TextColor = App.Global.textColor;
            statusLabelt.TextColor = App.Global.textColor;
            statusLabelth.TextColor = App.Global.textColor;
            textChangeLabel.TextColor = App.Global.textColor;
            statusLabelt.Text = App.Global.isFirstRun ? "Tutorial is ON" : "Tutorial is OFF";
        }

        public async void goToColorPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new colorPage());
        }

        public async void onTutorHelpButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new helpTutor());
        }

        public async void onTutorButton(object sender, EventArgs e)
        {
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;

                IFile myFile = await rootFolder.GetFileAsync("settingsp.txt");

                string fileText = await myFile.ReadAllTextAsync();

                if (App.Global.isFirstRun)
                {
                    App.Global.isFirstRun = false;
                    await myFile.WriteAllTextAsync(fileText.Replace("TRUE", "FALSE"));
                }
                else
                {
                    App.Global.isFirstRun = true;
                    await myFile.WriteAllTextAsync(fileText.Replace("FALSE", "TRUE"));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error writing personal data", ex.ToString(), "Ok");
            }

            statusLabelt.Text = (App.Global.isFirstRun ? "Tutorial is ON" : "Tutorial is OFF");
        }

        public async void onTextSizeButton(object sender, EventArgs e)
        {
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;

                IFile myFile = await rootFolder.GetFileAsync("settingsp.txt");

                string fileText = await myFile.ReadAllTextAsync();

                string textSize = "Medium";

                if (App.Current.Resources["text_size"] != null)
                {
                    if (App.Current.Resources["text_size"].ToString().Contains("12"))
                    {
                        App.Current.Resources["text_size"] = App.Current.Resources["IOStext_size_medium"];
                        textSize = "Medium";
                    }
                    else if (App.Current.Resources["text_size"].ToString().Contains("18"))
                    {
                        App.Current.Resources["text_size"] = App.Current.Resources["IOStext_size_large"];
                        textSize = "Large";
                    }
                    else if (App.Current.Resources["text_size"].ToString().Contains("24"))
                    {
                        App.Current.Resources["text_size"] = App.Current.Resources["IOStext_size_small"];
                        textSize = "Small";
                    }
                }

                //string textSize = App.Global.myTextSize;
                //if (textSize == null)
                //{
                //    textSize = "Medium";
                //    App.Global.myTextSize = textSize;
                //}

                //await DisplayAlert("text_size: " + App.Current.Resources["text_size"].ToString(), "large: " + App.Current.Resources["IOStext_size_large"].ToString() + "\n" +
                //    "medium: " + App.Current.Resources["IOStext_size_medium"].ToString() + "\n" +
                //    "small: " + App.Current.Resources["IOStext_size_small"].ToString() + "\n" +
                //    "global: " + App.Global.myTextSize.ToString() + "\n" +
                //    "textsize: " + textSize + "\n", "Ok");

                //App.Current.Resources["text_size"] = (textSize == "Large" ? App.Current.Resources["IOStext_size_large"] : (textSize == "Small" ? App.Current.Resources["IOStext_size_small"] : App.Current.Resources["IOStext_size_medium"]));

                string preText = fileText.Substring(0, fileText.IndexOf(".txtSize"));

                await myFile.WriteAllTextAsync(preText + ".txtSize" + textSize);

                App.Global.isNewCat = true;
                var vUpdatedPage = new settings();
                Navigation.InsertPageBefore(vUpdatedPage, this);
                await Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error writing personal data", ex.ToString(), "Ok");
            }            
        }

        public async void onClearItemsData(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Clear items data", "Do you really want to clear all items?", "Yes", "No");
            if (answer)
            {
                await App.GroceryRepo.clearGroceryItemsAsync();
            }
        }

        public async void onClearData(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Clear all data", "Do you really want to clear everything?", "Yes", "No");
            if (answer)
            {
                App.GroceryRepo.clearAllData();

                App.Global.isNewCat = true;
            }
        }

        public async void onCancelButtonClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
        }
    }
}