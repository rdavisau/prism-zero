using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismZero.ViewModels;
using Xamarin.Forms;

namespace PrismZero.Views
{
    public partial class MainPage : BasePage
    {
        public MainPageViewModel ViewModel => (MainPageViewModel) BindingContext;

        public MainPage()
        {
            InitializeComponent();

            MyLabel.GestureRecognizers.Add(
                new TapGestureRecognizer(_ 
                    => ViewModel.GoSomewhere()));
        }
    }
}