using System;
using Xamarin.Forms;

namespace Xamurai
{
	public class CustomListView : ListView
    {
        public CustomListView() : base(ListViewCachingStrategy.RetainElement)
        {

        }

        public void UpdateCells()
        {
            ViewCellSizeChangedEvent?.Invoke();
        }

        public event Action ViewCellSizeChangedEvent;
    }
}

