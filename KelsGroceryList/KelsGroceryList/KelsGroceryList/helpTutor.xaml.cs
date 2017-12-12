using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KelsGroceryList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class helpTutor : ContentPage
	{
		public helpTutor ()
		{
			InitializeComponent ();
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            GC.Collect();
        }

        public async void onCancelButtonClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync(); //Remove the page currently on top.
        }
    }
}