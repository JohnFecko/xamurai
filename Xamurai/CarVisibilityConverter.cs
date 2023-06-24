using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamurai
{
    
    public class CarDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CarDataTemplate { get; set; }
        public DataTemplate MercedesDataTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Car car = (Car)item;
            if(car.Make == CarMake.Mercedes)
            {
                return MercedesDataTemplate;
            }
            return CarDataTemplate;
        }
    }
}

