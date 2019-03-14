using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace arcthouchapply.ViewModels
{
    // <summary>
    /// Base view model.
    /// </summary>
    public class BaseViewModel : BindableBase, INavigationAware, IApplicationStore, IDestructible
    {
        /// <summary>
        /// Title of the page
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public IDictionary<string, object> Properties => Xamarin.Forms.Application.Current.Properties;

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>The navigation service.</value>
        private INavigationService _navigationService { get; set; }

        /// <summary>
        /// Gets the page dialog service.
        /// </summary>
        /// <value>The page dialog service.</value>
        private IPageDialogService _pageDialogService { get; set; }

        /// <summary>
        /// Gets the navigation parameters.
        /// </summary>
        /// <value>The navigation parameters.</value>
        protected NavigationParameters NavigationParameters { get; private set; }

        /// <summary>
        /// Gets the back to previous page command.
        /// </summary>
        /// <value>The back to previous page command.</value>
        public DelegateCommand BackToPreviousPageCommand { get; private set; }

        /// <summary>
        /// Gets the back to root command.
        /// </summary>
        /// <value>The back to root command.</value>
        public DelegateCommand BackToRootCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TrainingApp.ViewModels.BaseViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            this._navigationService = navigationService;
            this._pageDialogService = pageDialogService;

            this.BackToPreviousPageCommand = new DelegateCommand(BackToPreviousPage);
            this.BackToRootCommand = new DelegateCommand(BackToRootPage);
        }

        /// <summary>
        /// Backs to previous page.
        /// </summary>
        /// <returns>The to previous page.</returns>
        public async void BackToPreviousPage() => await this._navigationService.GoBackAsync();

        /// <summary>
        /// Backs to root page.
        /// </summary>
        /// <returns>The to root page.</returns>
        private async void BackToRootPage() => await this._navigationService.GoBackToRootAsync();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TrainingApp.ViewModels.BaseViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public BaseViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        /// <summary>
        /// Shows the alert async.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="cancelButtonText">Cancel button text.</param>
        public virtual async Task ShowAlertAsync(string title, string message, string cancelButtonText = "OK") => await this._pageDialogService?.DisplayAlertAsync(title, message, cancelButtonText);

        /// <summary>
        /// Ons the navigated from.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public async virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public async virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigating to.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public async virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Adds the navigation parameters.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public void AddNavigationParameters(Dictionary<string, object> @parameters)
        {
            if (@parameters.Any())
            {
                this.NavigationParameters = new NavigationParameters();

                foreach (var item in @parameters)
                {
                    this.NavigationParameters.Add(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// Navigates the relative.
        /// </summary>
        /// <returns>The relative.</returns>
        /// <param name="page">Page.</param>
        protected async Task NavigateAbsolute(string page) => await this._navigationService.NavigateAsync(new Uri($"http://demoapp.com/{page}", UriKind.Absolute), this.NavigationParameters, true);

        /// <summary>
        /// Navigates the relative.
        /// </summary>
        /// <returns>The relative.</returns>
        /// <param name="page">Page.</param>
        protected async Task NavigateRelative(string page) => await this._navigationService.NavigateAsync(page, this.NavigationParameters, false);

        /// <summary>
        /// Saves the properties async.
        /// </summary>
        /// <returns>The properties async.</returns>
        public virtual async Task SavePropertiesAsync()
        {
        }

        /// <summary>
        /// Destroy this instance.
        /// </summary>
        public virtual void Destroy()
        {

        }

        /// <summary>
        /// Serializes the payload to services.
        /// </summary>
        /// <returns>The payload to services.</returns>
        /// <param name="data">Data.</param>
        public string SerializePayloadToServices(object data) => JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        /// <summary>
        /// Deserializes the payload from services.
        /// </summary>
        /// <returns>The payload from services.</returns>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T DeserializePayloadFromServices<T>(string data) where T : class => JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        /// <summary>
        /// Ises the internet connected.
        /// </summary>
        /// <returns>The internet connected.</returns>
        public bool IsInternetConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
