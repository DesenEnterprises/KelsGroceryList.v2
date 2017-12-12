using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SQLite;
using KelsGroceryList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KelsGroceryList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addItemPage : ContentPage
    {
        public addItemPage(string cat)
        {
            InitializeComponent();

            categoryEntry.Text = cat;

            topLevelLayout.BackgroundColor = App.Global.bgColor;
            catLabel.TextColor = App.Global.textColor;
            countLabel.TextColor = App.Global.textColor;
            itemLabel.TextColor = App.Global.textColor;
            statusMessage.TextColor = App.Global.textColor;

            if (Device.RuntimePlatform != Device.iOS)
            {
                countEntry.TextColor = App.Global.textColor;
                groceryEntry.TextColor = App.Global.textColor;
                categoryEntry.TextColor = App.Global.textColor;
            }
            else
            {
                countEntry.TextColor = Color.Black;
                groceryEntry.TextColor = Color.Black;
                categoryEntry.TextColor = Color.Black;
            }
            //statusMessage.Text = Device.RuntimePlatform.ToString();           
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //topLevelLayout = null;
            //catLabel = null;
            //countLabel = null;
            //itemLabel = null;
            //statusMessage = null;

            GC.Collect();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //App.Current.Resources["text_size"] = (App.Global.myTextSize == "Large" ? App.Current.Resources["IOStext_size_large"] : (App.Global.myTextSize == "Small" ? App.Current.Resources["IOStext_size_small"] : App.Current.Resources["IOStext_size_medium"]));

            if (App.Global.isFirstRun)
            {
                bool answer = await DisplayAlert("Getting Started!", "Edit the Category text to add a new category." +
                        "\n\nThen add a New Item and how many you need.\n\nTo add more Items, click Enter/Save and then ADD ITEMS again." +
                         "\n\nWhen a category is selected from the previous screen, it will automatically be placed here so you can easily add items to a category.", "Turn Tutorial OFF", "Ok");

                if (answer)
                    App.Global.isFirstRun = false;
            }
        }

        public async void onCategoryTextChanged(object sender, EventArgs e)
        {
            ObservableCollection<groceryList> items =
                new ObservableCollection<groceryList>(
                    await App.GroceryRepo.GetAllgroceryAsync());

            bool gotCat = false;

            foreach (groceryList item in items)
            {
                if (item.CategoryHead)
                {
                    if (item.Category.ToString() == categoryEntry.Text)
                    {
                        gotCat = true;
                        App.Global.myCategory = item.Category.ToString();
                    }
                }
            }

            if (!gotCat)
            {
                await App.GroceryRepo.AddNewgroceryAsync(categoryEntry.Text, true, null, null, false);
                App.Global.isNewCat = true;
                statusMessage.Text = App.GroceryRepo.StatusMessage;
                App.Global.myCategory = categoryEntry.Text;
            }

            //if (App.Global.isFirstRun)
            //    await DisplayAlert("Getting Started!", "Now add an Item and the number you need.\n\nTo add more Items, click Enter/Save and then ADD ITEMS again.", "Ok");

            items = null;
        }

        public async void onEnterNewButtonClicked(object sender, EventArgs e)
        {
            if (categoryEntry.Text != null && groceryEntry.Text != null && countEntry.Text != null)
            {
                await App.GroceryRepo.AddNewgroceryAsync(categoryEntry.Text, false, groceryEntry.Text, countEntry.Text, false);
                statusMessage.Text = App.GroceryRepo.StatusMessage;
                //App.Global.isNewCat = true;

                bool answer = false;
                if (App.Global.isFirstRun)
                    answer = await DisplayAlert("Getting Started!", "Click a Category to see the Items added to that Category", "Turn Tutorial OFF", "Ok");
                if (answer)
                    App.Global.isFirstRun = false;

                await Application.Current.MainPage.Navigation.PopModalAsync(); //Remove the page currently on top.
            }
            else
            {
                //statusMessage.Text = "Please complete all fields";
                await DisplayAlert("Incomplete item!", "Please complete all fields.", "Ok");
            }
        }

        public async void onCancelButtonClicked(object sender, EventArgs e)
        {            
            await Application.Current.MainPage.Navigation.PopModalAsync(); //Remove the page currently on top.
        }
    }
}