using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.ObjectModel;
using Prism.Commands;

namespace Xamurai
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
    {
        private SampleViewModel viewModel;
        private bool SwipeEnabled = true;
        public ICommand LongPressCommand { get; }


        public ListViewPage ()
		{
            viewModel = new SampleViewModel();
            BindingContext = viewModel;
            LongPressCommand = new Command((object sender) => LongPress(sender, EventArgs.Empty));

            InitializeComponent ();
		}

        protected void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IStatusBar>().ShowStatusBar();
        }

        protected async void DeleteItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var menuItem = ((MenuItem)sender);
            Car car = (Car)menuItem.CommandParameter;
            await DeleteCar(car);
        }

        protected async void LongPress(System.Object sender, System.EventArgs e)
        {
            if(SwipeEnabled) { return; }
            Car car = (Car)sender;
            await DeleteCar(car);
        }

        protected async Task DeleteCar(Car car)
        {
            bool answer = await DisplayAlert("Delete " + car.Name + "?", "This will permanently delete " + car.Name, "Delete", "Cancel");
            if (answer)
            {
                viewModel.Cars.Remove(car);
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            collectionView.ItemsLayout = LinearItemsLayout.Vertical;
            SwipeEnabled = true;
            if (width > height)
            {
                collectionView.ItemsLayout = LinearItemsLayout.Horizontal;
                SwipeEnabled = false;
            }

            base.OnSizeAllocated(width, height);
            
        }

        void SwipeView_SwipeStarted(System.Object sender, Xamarin.Forms.SwipeStartedEventArgs e)
        {
            SwipeView view = (SwipeView)sender;
            if (!SwipeEnabled)
            {
                view.Close();
            }
        }
    }
}