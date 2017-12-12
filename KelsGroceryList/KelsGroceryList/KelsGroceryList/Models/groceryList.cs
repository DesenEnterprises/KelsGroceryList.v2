using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace KelsGroceryList.Models
{
    [Table("items")]
    public class groceryList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), NotNull]
        public string Category { get; set; }

        [NotNull]
        public bool CategoryHead { get; set; }

        [MaxLength(50)]
        public string groceryItem { get; set; }

        [MaxLength(4)]
        public string Count { get; set; }

        [NotNull]
        public bool inCart { get; set; }
    }

    //public class ViewModel
    //{
    //    public string Category { get; set; }

    //    //public async IEnumerable<ViewModel> SelectAll()
    //    //{
    //    //    IEnumerable<ViewModel> modelList = await App.GroceryRepo.GetAllCategories();
    //    //    return modelList;
    //    //}
    //}

    //[Table("colorsPersonal")]
    //public class colorPersonal
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int Id { get; set; }

    //    public Xamarin.Forms.Color backGroundColorP { get; set; }

    //    [MaxLength(50)]
    //    public string textColorP { get; set; }
    //}
}
