using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Navigation;

namespace PrismZero.ViewModels
{
    public class SecondPageViewModel : ViewModelBase, INavigatedAware
    {
        public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Console.WriteLine($"The magic number is {parameters.First().Value}!");
        }
    }
}
