using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamurai.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBar))]
namespace Xamurai.iOS
{
    public class StatusBar : IStatusBar
    {
        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }
    }
}

