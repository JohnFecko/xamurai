using System;
using CoreFoundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamurai;
using Xamurai.iOS;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace Xamurai.iOS
{
	public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is CustomListView enhancedListView)
            {
                enhancedListView.ViewCellSizeChangedEvent += UpdateTableView;
            }
        }

        private void UpdateTableView()
        {
            DispatchQueue.MainQueue.DispatchAfter(new DispatchTime(DispatchTime.Now, TimeSpan.FromSeconds(0.2)), () =>
            { 
                if (!(Control is UITableView tv)) return;
                tv.BeginUpdates();
                tv.EndUpdates();
            });
        }
    }
}

