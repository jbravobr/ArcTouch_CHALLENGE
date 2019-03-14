using System;
using System.Threading.Tasks;
using arcthouchapply.Helpers;
using arcthouchapply.Views;
using arctouchapply.Services.Contracts;
using arctouchapply.Services.Implementations;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace arcthouchapply
{
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Clean Ctor for preview
        /// </summary>
        public App() => InitializeComponent();

        /// <summary>
        /// Prism ctor
        /// </summary>
        /// <param name="platformInitializer"></param>
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) => InitializeComponent();

        /// <summary>
        /// Prism App Entry point
        /// </summary>
        protected override async void OnInitialized()
        {
            try
            {
                InitializeComponent();

                this.AppSetup();
                await this.LoadFirstPage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Load the first App page
        /// </summary>
        private async Task LoadFirstPage() => await NavigationService.NavigateAsync("NavPage/UpcomingMoviePage");

        /// <summary>
        /// Register Syncfusion license
        /// </summary>
        private void AppSetup()
        {
            On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Secrets.SyncfusionLicensingKey);
        }

        /// <summary>
        /// Prism register types
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages
            containerRegistry.RegisterForNavigation<UpcomingMoviePage>();
            containerRegistry.RegisterForNavigation<MovieSelectionPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>("NavPage");

            //Services
            containerRegistry.Register<IMovieService, MovieService>();

            //Instances
            containerRegistry.RegisterInstance(Acr.UserDialogs.UserDialogs.Instance);
        }

        /// <summary>
        /// Handle when the App Starts
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// Handle when the App Sleeps
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// Handle when the App resumes
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
