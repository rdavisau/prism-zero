using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismZero.Services.Hello;

namespace PrismZero.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IHelloService _helloService;

        public MainPageViewModel(INavigationService navigationService, IHelloService helloService)
            : base(navigationService)
        {
            _helloService = helloService;

            Title = "Main Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _helloService.SayHello();
        }

        public Task GoSomewhere()
        {
            return NavigationService.NavigateAsync("SecondPage", ("number", new Random().Next(1, 101)));
        }
    }
}
