using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using KelsGroceryList.Models;
using KelsGroceryList.ViewModels;
using System.Collections.ObjectModel;
using PCLStorage;
using Telerik.XamarinForms.DataControls.ListView;
using Telerik.XamarinForms.DataControls;

namespace KelsGroceryList
{
    public partial class MainPage : ContentPage
    {
        bool iCameFromSettings = false;

        public MainPage()
        {            
            InitializeComponent();

            //OnGetgrocery(App.Global.myCategory != null ? App.Global.myCategory : "nothing");

            string settingspExits = FileSystem.Current.LocalStorage.CheckExistsAsync("settingsp.txt").Result.ToString();
            if (settingspExits == "NotFound")
            {
                readWriteSettingsFile(false);
            }
            else if (settingspExits == "FileExists")
            {
                readWriteSettingsFile(true);
            }

            
        }

        public async void readWriteSettingsFile(bool isFound)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;

            if (!isFound)
            {
                try
                {
                    IFile myFile = await rootFolder.CreateFileAsync("settingsp.txt", CreationCollisionOption.FailIfExists);
                    await myFile.WriteAllTextAsync("dbVersion1.dbColornull.txtColornull.tutorTRUE.txtSizeMedium");

                    statusLabel.Text = "wrote new settings file";
                    App.Global.isFirstRun = true;
                    await DisplayAlert("Getting Started!", "Click the ADD ITEMS button to get started", "Ok");
                }
                catch (Exception)
                {
                    statusLabel.Text = "Could not write personal settings";
                }
            }
            else
            {
                try
                {
                    IFile myFile = await rootFolder.GetFileAsync("settingsp.txt");

                    string fileText = await myFile.ReadAllTextAsync();

                    if (!fileText.Contains(".tutor") || !fileText.Contains(".txtSize"))
                    {
                        await myFile.WriteAllTextAsync("dbVersion1.dbColornull.txtColornull.tutorFALSE.txtSizeMedium");
                        await DisplayAlert("Getting Started!", "Click the ADD ITEMS button to get started", "Ok");
                        App.Global.isFirstRun = true;
                    }
                    else
                    {
                        string dbVersion = fileText.Substring(fileText.IndexOf("dbVersion") + 9);
                        dbVersion = dbVersion.Substring(0, dbVersion.IndexOf("."));
                        string fileText2 = fileText.Substring(fileText.IndexOf(".") + 1);
                        string dbColor = fileText2.Substring(fileText2.IndexOf("dbColor") + 7);
                        dbColor = dbColor.Substring(0, dbColor.IndexOf("."));
                        string fileText3 = fileText2.Substring(fileText2.IndexOf(".") + 1);
                        string textColor = fileText3.Substring(fileText3.IndexOf("txtColor") + 8);
                        textColor = textColor.Substring(0, textColor.IndexOf("."));
                        string fileText4 = fileText3.Substring(fileText3.IndexOf(".") + 1);
                        string tutorON = fileText4.Substring(fileText4.IndexOf("tutor") + 5);
                        tutorON = tutorON.Substring(0, tutorON.IndexOf("."));
                        string fileText5 = fileText4.Substring(fileText4.IndexOf(".") + 1);
                        string txtSize = fileText5.Substring(fileText5.IndexOf("txtSize") + 7);

                        //App.Global.myTextSize = txtSize;

                        //if (App.Global.myTextSize == null || App.Global.myTextSize.Trim() == "")
                        //    App.Global.myTextSize = "Medium";

                        App.Current.Resources["text_size"] = (txtSize == "Large" ? App.Current.Resources["IOStext_size_large"] : (txtSize == "Small" ? App.Current.Resources["IOStext_size_small"] : App.Current.Resources["IOStext_size_medium"]));

                        if (tutorON == "TRUE" && App.Global.isFirstRun != false)
                        {
                            await DisplayAlert("Getting Started!", "Click the ADD ITEMS button to get started", "Ok");
                            App.Global.isFirstRun = true;
                        }
                        else
                        {
                            App.Global.isFirstRun = false;
                            try
                            {
                                await myFile.WriteAllTextAsync(fileText.Replace("TRUE", "FALSE"));
                            }
                            catch (Exception ex)
                            {
                                await DisplayAlert("Error writing personal data", ex.ToString(), "Ok");
                            }
                        }

                        var converter = new ColorTypeConverter();

                        App.Global.dbVersion = dbVersion;

                        if (dbColor != "null")
                        {
                            App.Global.bgColor = (Color)converter.ConvertFromInvariantString(dbColor);
                            App.Global.textColor = (Color)converter.ConvertFromInvariantString(textColor);
                        }
                        else
                        {
                            App.Global.bgColor = Color.Pink;
                            App.Global.textColor = Color.DarkBlue;
                        }

                        topLevelLayout.BackgroundColor = App.Global.bgColor;
                        categoriesLabel.TextColor = App.Global.textColor;
                        groceryListLabel.TextColor = App.Global.textColor;
                        statusLabel.TextColor = App.Global.textColor;

                        //statusLabel.Text = fileText + " " + dbVersion + " " + dbColor + " " + textColor + " " + txtSize;
                    }
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "Could not read personal settings: " + ex.ToString();
                }
            }
            rootFolder = null;
        }

        void openTestPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new testPage());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //topLevelLayout = null;
            //categoriesLabel = null;
            //groceryListLabel = null;
            //statusLabel = null;
            //categoriesListview = null;
            //groceriesListview = null;
            //ViewModel = null;

            GC.Collect();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //App.Current.Resources["text_size"] = (App.Global.myTextSize == "Large" ? App.Current.Resources["IOStext_size_large"] : (App.Global.myTextSize == "Small" ? App.Current.Resources["IOStext_size_small"] : App.Current.Resources["IOStext_size_medium"]));

            if (App.Global.isNewCat)
            {
                App.Global.myCategory = null;
                iCameFromSettings = true;
            }

            await ViewModel.GetCatsAsync();

            statusLabel.Text = "";            

            //OnGetgrocery(App.Global.myCategory != null ? App.Global.myCategory : "nothing");

            topLevelLayout.BackgroundColor = App.Global.bgColor;
            categoriesLabel.TextColor = App.Global.textColor;
            groceryListLabel.TextColor = App.Global.textColor;
            statusLabel.TextColor = App.Global.textColor;

            groceryListLabel.Text = "Items needed" + (App.Global.myCategory != null ? " for " + App.Global.myCategory : "");

            //statusLabel.Text = App.Global.myTextSize;

            if (App.Global.isNewCat)
            {
                App.Global.isNewCat = false;
                var vUpdatedPage = new MainPage();
                Navigation.InsertPageBefore(vUpdatedPage, this);
                await Navigation.PopAsync();
            }
        }

        public async void categoryOnItemSwipeCompleted(object sender, ItemSwipeCompletedEventArgs e)
        {
            try
            {
                var row = sender as RadListView;
                var itemE = e.Item as groceryList;
                var category = itemE.Category as string;
                row.EndItemSwipe();

                bool answer = false;
                answer = await DisplayAlert("Delete Category", "Do you want to delete the entire category and all items in it?\n\n" + "Category: " + category, "YES", "NO");
                if (answer)
                {
                    await App.GroceryRepo.clearSingleCategoryAsync(category);
                    statusLabel.Text = App.GroceryRepo.StatusMessage;
                    await ViewModel.GetCatsAsync();
                    //OnGetgrocery("nothing");
                    App.Global.isNewCat = false;
                }

                //statusLabel.Text = "item: " + item + " sender: " + row + " e: " + e + " grocery: " + grocery;
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error: " + ex.ToString();
            }            
        }

        private async void CategoryRadListView_OnItemTapped(object sender, ItemTapEventArgs e)
        {
            var item = e.Item as groceryList;
            var grocery = item.Category as string;
            
            App.Global.myCategory = grocery != null ? grocery : "nothing";

            //OnGetgrocery(App.Global.myCategory);
            groceryListLabel.Text = "Items needed" + (grocery != null ? " for " + grocery : "");

            bool answer = false;
            if (App.Global.isFirstRun)
                answer = await DisplayAlert("Getting Started!", "Click an Item in the list to mark it as DONE\n\nIt will then be moved to the bottom of the list and marked DONE", "Turn Tutorial OFF", "Ok");
            if (answer)
                App.Global.isFirstRun = false;

            await ViewModel.GetCatsAsync();
            
        }

        public async void groceryOnItemSwipeCompleted(object sender, ItemSwipeCompletedEventArgs e)
        {
            try
            {
                var row = sender as RadListView;
                var itemE = e.Item as groceryList;
                var grocery = itemE.groceryItem as string;
                var category = itemE.Category as string;
                var count = itemE.Count as string;
                row.EndItemSwipe();

                bool answer = false;
                answer = await DisplayAlert("Delete Category", "Do you want to delete this shopping Item?\n\n" + "Item: " + grocery, "YES", "NO");
                if (answer)
                {
                    // public async Task clearSingleGroceryItemsAsync(string catIN, string itemIN, string countIN)
                    await App.GroceryRepo.clearSingleGroceryItemsAsync(category, grocery, count);
                    statusLabel.Text = App.GroceryRepo.StatusMessage;
                    await ViewModel.GetCatsAsync();
                    //OnGetgrocery(category);
                }

                //statusLabel.Text = "item: " + item + " sender: " + row + " e: " + e + " grocery: " + grocery;
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error: " + ex.ToString();
            }
        }

        public async void onItemSelect(object sender, ItemTapEventArgs e)
        {
            var item = e.Item as groceryList;
            var grocery = item.groceryItem.ToString().Replace("zz InTheCart - DONE - ", "");

            bool answerD = false;
            bool allItemsInCart = true;
            bool answerDC = false;

            try
            {
                ObservableCollection<groceryList> items =
                new ObservableCollection<groceryList>(
                    await App.GroceryRepo.GetAllgroceryAsync(item.Category));

                foreach (groceryList itemT in items)
                {
                    if (itemT.CategoryHead == false)
                    {
                        if (!itemT.inCart && itemT.groceryItem != grocery)
                        {
                            allItemsInCart = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = string.Format("Failed to retrieve category items - Error: {0}", ex.ToString());
            }

            if (allItemsInCart)
            {
                answerDC = await DisplayAlert("Delete Category?", "All of the Items in " + App.Global.myCategory + " have been added to your cart!\n\n" +
                        "Do you wish to delete this Category and all Items in it?", "Yes", "No");
            }

            if (answerDC)
            {
                await App.GroceryRepo.clearSingleCategoryAsync(App.Global.myCategory);
                statusLabel.Text = App.GroceryRepo.StatusMessage;
                await ViewModel.GetCatsAsync();
                //OnGetgrocery("nothing");
                App.Global.isNewCat = false;
            }

            if (item.inCart && !answerDC)
            {
                answerD = await DisplayAlert("Delete Item?", "You've selected " + grocery + "\n\n" +
                        "Do you wish to delete this Item or Add it back to the shopping list?", "DELETE", "Add Back");
            }

            if (answerD)
            {
                // delete specific item
                try
                {
                    await App.GroceryRepo.clearSingleGroceryItemsAsync(App.Global.myCategory, grocery, item.Count);

                    statusLabel.Text = App.GroceryRepo.StatusMessage;
                }
                catch (Exception ex)
                {
                    statusLabel.Text = ex.ToString();
                }
                //OnGetgrocery(App.Global.myCategory != null ? App.Global.myCategory : "nothing");
                await ViewModel.GetCatsAsync();
            }
            else 
            {
                if (!answerDC)
                {
                    try
                    {
                        await App.GroceryRepo.updategroceryAsync(App.Global.myCategory, false, grocery, item.Count, false);

                        statusLabel.Text = App.GroceryRepo.StatusMessage;
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Text = ex.ToString();
                    }
                    //OnGetgrocery(App.Global.myCategory != null ? App.Global.myCategory : "nothing");
                    await ViewModel.GetCatsAsync();
                }
            }
            

            if (App.Global.isFirstRun)
            {
                bool answer = await DisplayAlert("End of Tutorial", "When you're done shopping, click the SETTINGS button to clear your List so you're ready for next time!\n\n" +
                    "Clicking the SETTINGS button will also allow you to change colors and turn this tutorial on / off" +
                    "\n\nDo you want me to turn the tutorial OFF now?\n\nIf you want it back ON just go to SETTINGS and turn it ON", "Yes", "No");

                if (answer)
                    App.Global.isFirstRun = false;
            }
        }

        void goToSettingsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new settings()));
        }

        void goToAddItemPage(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new addItemPage(App.Global.myCategory != null ? App.Global.myCategory : ""));
        }



        private double width = 0;
        private double height = 0;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    //topLevelLayout.Orientation = StackOrientation.Horizontal;
                    //helpStackLayout.Orientation = StackOrientation.Vertical;
                    
                    if (height > 500)
                        categoriesListview.HeightRequest = 200;
                    else if (height > 300 && height < 400)
                        categoriesListview.HeightRequest = 75;
                    else if (height < 300)
                        categoriesListview.HeightRequest = 50;
                    else
                        categoriesListview.HeightRequest = 100;
                }
                else
                {
                    //topLevelLayout.Orientation = StackOrientation.Vertical;
                    //helpStackLayout.Orientation = StackOrientation.Horizontal;

                    if (height > 500)
                        categoriesListview.HeightRequest = 200;
                    else
                        categoriesListview.HeightRequest = 100;
                }

                //if (width < 400)
                //{
                //    // set buttons and other widths to smaller footprints so they don't go off screen
                //    settingsButton.WidthRequest = 100;
                //    settingsButton.FontSize = 12;
                //    addButton.WidthRequest = 100;
                //    addButton.FontSize = 12;
                //}
                //else
                //{
                //    settingsButton.WidthRequest = 150;
                //    settingsButton.FontSize = App.Global.myTextSize == "Large" ? 24 : (App.Global.myTextSize == "Medium" ? 18 : 12);
                //    addButton.WidthRequest = 150;
                //    addButton.FontSize = App.Global.myTextSize == "Large" ? 24 : (App.Global.myTextSize == "Medium" ? 18 : 12);
                //}
            }
            //statusLabel.Text = height + " " + width;
        }

        public async void OnGetgrocery(string catIN)
        {
            //ObservableCollection<groceryList> items =
            //    new ObservableCollection<groceryList>(
            //        await App.GroceryRepo.GetAllgroceryAsync());

            //string[] myList = new string[items.Where(xr => xr.CategoryHead).Count()];
            //string[] myList2 = new string[items.Where(xr => !xr.CategoryHead && 
            //    (catIN != null ? xr.Category.ToString() == catIN : false)).Count()];
            //int i = 0;
            //int i2 = 0;

            //foreach (groceryList item in items)
            //{                
            //    if (item.CategoryHead)
            //    {                    
            //        myList[i] = item.Category.ToString();
            //        i++;
            //    }
            //    else
            //    {
            //        if (catIN != null)
            //        {
            //            if (item.Category.ToString() == catIN && item.groceryItem != null)
            //            {
            //                if (item.inCart)
            //                {
            //                    myList2[i2] = "zz InTheCart - DONE - " + item.groceryItem.ToString() + " - " + item.Count.ToString() + " each";
            //                    i2++;
            //                }
            //                else
            //                {
            //                    myList2[i2] = item.groceryItem.ToString() + " - " + item.Count.ToString() + " each";
            //                    i2++;
            //                }                            
            //            }
            //        }
            //    }
            //}
            //groceriesListview.ItemsSource = myList2;

            //if ((catIN != null && catIN != "nothing") || iCameFromSettings)
            //{
            //    groceriesListview.ItemsSource = myList2.OrderBy(o => o[0]).ToArray();
            //    iCameFromSettings = false;
            //}
        }
    }    
}
