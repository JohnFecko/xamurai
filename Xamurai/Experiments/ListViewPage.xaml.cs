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

        public ListViewPage ()
		{
			BindingContext = new SampleViewModel();
			InitializeComponent ();
		}

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IStatusBar>().ShowStatusBar();
        }
    }
}