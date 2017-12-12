using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KelsGroceryList.Models;
using Xamarin.Forms;

namespace KelsGroceryList.ViewModels
{
    public class ViewModel
    {
        public ViewModel()
        {
            // this is called in OnAppearing instead, to keep code out of the constructor
            //Task.Run(async () => { await GetCatsAsync(); });           
        }

        public ObservableCollection<groceryList> Source { get; set; } = new ObservableCollection<groceryList>();
        public ObservableCollection<groceryList> groceryItemSource { get; set; } = new ObservableCollection<groceryList>();
        public ObservableCollection<groceryList> groceryItemSourceSorted { get; set; } = new ObservableCollection<groceryList>();

        public async Task GetCatsAsync()
        {
            //this.Source = new List<SourceItem> { new SourceItem("Tom"), new SourceItem("Anna"), new SourceItem("Peter"), new SourceItem("Teodor"), new SourceItem("Lorenzo"), new SourceItem("Andrea"), new SourceItem("Martin") };

            var itemsT = await App.GroceryRepo.GetAllgroceryAsync();

            if (App.Global.isNewCat)
                this.Source.Clear();

            this.groceryItemSource.Clear();
            this.groceryItemSourceSorted.Clear();

            foreach (var groceryList in itemsT.ToList())
            {
                if (groceryList.CategoryHead)
                {
                    bool gotCat = false;

                    foreach (var sList in Source)
                    {
                        if (sList.Category.Contains(groceryList.Category))
                        {
                            gotCat = true;                                
                        }
                    }

                    if (!gotCat)
                        this.Source.Add(groceryList);
                }

                if (groceryList.Category == App.Global.myCategory && !groceryList.CategoryHead)
                {
                    if (groceryList.inCart)
                        groceryList.groceryItem = "zz InTheCart - DONE - " + groceryList.groceryItem;

                    this.groceryItemSourceSorted.Add(groceryList);
                }
            }

            //this.groceryItemSource = new ObservableCollection<groceryList>(this.groceryItemSourceSorted.OrderBy(o => o.groceryItem).ToList());
            foreach (groceryList sortMe in groceryItemSourceSorted.OrderBy(o => o.groceryItem))
            {
                this.groceryItemSource.Add(sortMe);
            }

            this.groceryItemSourceSorted.Clear();
            itemsT = null;

            GC.Collect();
        }
    }
}
