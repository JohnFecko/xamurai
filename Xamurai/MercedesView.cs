using System;
using System.Linq;
using Xamarin.Forms;

namespace Xamurai
{
    public class MercedesView : CarView
    {
        public MercedesView()
        {

            Style labelStyle = new Style(typeof(Label))
            {
                Setters = {
                    new Setter
                    {
                        Property = Label.FontFamilyProperty,
                        Value =  "OpenSans"
                    }
                }
            };
            Resources["DescriptionStyle"] = labelStyle;

            GradientStop top = new GradientStop(Color.White, .1f);
            GradientStop bottom = new GradientStop(Color.LightBlue, 1f);

            GradientStopCollection gradientStops = new GradientStopCollection();
            gradientStops.Add(top);
            gradientStops.Add(bottom);

            LinearGradientBrush brush = new LinearGradientBrush(gradientStops, new Point(0,0), new Point(0,1));

            Style frameStyle = new Style(typeof(Frame))
            {
                Setters =
                {
                    new Setter
                    {
                        Property=VisualElement.BackgroundProperty,
                        Value = brush
                    }
                }
            };
            Resources["FrameStyle"] = frameStyle;

        }
    }
}


