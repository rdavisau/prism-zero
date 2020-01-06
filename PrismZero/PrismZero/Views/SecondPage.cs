using Xamarin.Forms;

namespace PrismZero.Views
{
    public class SecondPage : BasePage
    {
        public SecondPage()
        {
            Content = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Green
            };
        }
    }
}