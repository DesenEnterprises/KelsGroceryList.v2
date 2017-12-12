using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KelsGroceryList.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace KelsGroceryList
{
    public class groceryRepository
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public groceryRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);

            //conn.DropTableAsync<groceryList>(); // try this to clear the DB if testing

            conn.CreateTableAsync<groceryList>().Wait();
        }

        public Task<List<groceryList>> GetAllgroceryAsync(string category)
        {
            return conn.Table<groceryList>().Where(c => c.Category == category).ToListAsync();
        }

        public Task<List<groceryList>> GetAllgroceryAsync()
        {
            return conn.Table<groceryList>().ToListAsync();
        }

        //public async IEnumerable<ViewModel> GetModel()
        //{
        //    List<groceryList> tempG = await GetAllCategories();

        //    IEnumerable<ViewModel> cList;


        //}

        public Task<List<groceryList>> GetAllCategoriesAsync()
        {
            return conn.Table<groceryList>().Where(c => c.CategoryHead == true).ToListAsync();
        }

        public void clearAllData()
        {
            conn.DropTableAsync<groceryList>().Wait(); // clear the DB

            conn.CreateTableAsync<groceryList>().Wait();
        }

        public async Task clearSingleGroceryItemsAsync(string catIN, string itemIN, string countIN)
        {
            //StatusMessage += itemIN + catIN + countIN;
            try
            {
                ObservableCollection<groceryList> items =
                new ObservableCollection<groceryList>(
                    await App.GroceryRepo.GetAllgroceryAsync());

                foreach (groceryList item in items)
                {
                    if (item.CategoryHead == false)
                    {
                        if (item.groceryItem == itemIN && item.Category == catIN && item.Count == countIN)
                        {
                            await conn.DeleteAsync(item);
                            //StatusMessage += itemIN + item.groceryItem + catIN + item.Category + countIN + item.Count;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete items - Error: {0}", ex.ToString());
            }
        }

        public async Task clearSingleCategoryAsync(string category)
        {            
            try
            {
                ObservableCollection<groceryList> items =
                new ObservableCollection<groceryList>(
                    await App.GroceryRepo.GetAllgroceryAsync(category));

                foreach (groceryList item in items)
                {
                    await conn.DeleteAsync(item);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete category items - Error: {0}", ex.ToString());
            }
            App.Global.isNewCat = true;
        }

        public async Task clearGroceryItemsAsync()
        {
            try
            {
                ObservableCollection<groceryList> items =
                new ObservableCollection<groceryList>(
                    await App.GroceryRepo.GetAllgroceryAsync());

                foreach (groceryList item in items)
                {
                    if (item.CategoryHead == false)
                        await conn.DeleteAsync(item);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete items - Error: {0}", ex.ToString());
            }
            App.Global.isNewCat = true;
        }

        public async Task AddNewgroceryAsync(string category, bool categoryHead, string groceryitem, string count, bool incart)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(category))
                    throw new Exception("Valid category required");

                //insert a new grocery into the grocery table
                var result = await conn.InsertAsync(new groceryList {
                    Category = category,
                    CategoryHead = categoryHead,
                    groceryItem = groceryitem,
                    Count = count,
                    inCart = incart
                }).ConfigureAwait(continueOnCapturedContext: false);

                if (categoryHead)
                    StatusMessage = string.Format("{0} Category added {1}", result, category);
                else
                    StatusMessage = string.Format("{0} Item added {1} - {2}", result, groceryitem, count);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", category + " - " + groceryitem, ex.ToString());
            }
        }

        public async Task updategroceryAsync(string category, bool categoryHead, string groceryitem, string count, bool incart)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(category))
                    throw new Exception("Valid category required");

                var updateFlagLog = await conn.FindAsync<groceryList>(u => u.Category == category && u.CategoryHead == false && u.groceryItem == groceryitem && u.Count == count);
                if (updateFlagLog != null)
                {
                    if (updateFlagLog.inCart)
                        updateFlagLog.inCart = false;
                    else
                        updateFlagLog.inCart = true;

                    var result = await conn.UpdateAsync(updateFlagLog);

                    StatusMessage = string.Format("{0} Item updated {1} - {2}", result, groceryitem, count);
                    //StatusMessage = updateFlagLog.Category + " " + groceryitem + " " + count;
                }
                else
                {
                    StatusMessage = "updateFlagLog is null";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", groceryitem, ex.ToString());
            }
        }
    }
}
