using DryIocZero;
using Prism;
using Prism.Ioc;
using PrismZero.DryIocZero;
using PrismZero.ViewModels;
using PrismZero.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismZero
{
    public partial class App
    {
        public new IZeroContainer Container;

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override IContainerExtension CreateContainerExtension()
        {
            var container = new Container();
            var extension = new DryIocZeroContainerExtension(container);

            // plug the containerextension placeholder
            container.UseInstance<IContainerExtension>(extension);

            Container = container;

            return extension;
        }

        protected override void RegisterRequiredTypes(IContainerRegistry _)
        {
            // intercept the call to base
            // since we already registered the required types at compile time
        }

        protected override void RegisterTypes(IContainerRegistry _)
        {
            // call our auto-generated page wireup method
            Container.RegisterPageTypes();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }
    }
}
