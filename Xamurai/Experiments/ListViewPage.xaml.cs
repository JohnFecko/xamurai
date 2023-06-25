using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamurai
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
        SampleViewModel viewModel;

        public ListViewPage ()
		{
            viewModel = new SampleViewModel();
            BindingContext = viewModel;

            InitializeComponent ();
		}

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IStatusBar>().ShowStatusBar();
        }

        async void DeleteItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var menuItem = ((MenuItem)sender);
            Car car = (Car)menuItem.CommandParameter;

            bool answer = await DisplayAlert("Delete " + car.Name + "?", "This will permanently delete " + car.Name, "Delete", "Cancel");
            if (answer)
            {
                viewModel.Cars.Remove(car);
            }
        }
    }
}