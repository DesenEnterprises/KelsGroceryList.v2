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
	public partial class testPage : ContentPage
	{
		public testPage ()
		{
			InitializeComponent ();

            Button dButton = new Button();

            dynamicStackLayout.Children.Add(new Button { Text = "testButtonSingle.Add" });

            for (int i = 0; i < 30; i++)
                dynamicStackLayout.Children.Add(new Button { Text = i.ToString() });
        }
	}
}