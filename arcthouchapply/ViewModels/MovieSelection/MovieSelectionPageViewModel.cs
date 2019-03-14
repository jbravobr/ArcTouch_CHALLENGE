using Acr.UserDialogs;
using arcthouchapply.Helpers;
using arcthouchapply.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace arcthouchapply.ViewModels
{
    public class MovieSelectionPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the movie.
        /// </summary>
        /// <value>The movie.</value>
        public Results Movie { get; set; }

        /// <summary>
        /// Gets the on movie tapped.
        /// </summary>
        /// <value>The on movie tapped.</value>
        public DelegateCommand OnMovieTapped { get; private set; }

        /// <summary>
        /// Plaies the movie.
        /// </summary>
        private async void PlayMovie() => await this.ShowAlertAsync(string.Empty, "You should start playing the movie now");

        /// <summary>
        /// Initializes a new instance of the <see cref="T:arcthouchapply.ViewModels.MovieSelectionPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="pageDialogService">Page dialog service.</param>
        public MovieSelectionPageViewModel(INavigationService navigationService,
                                           IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            this.OnMovieTapped = new DelegateCommand(PlayMovie);
            this.PageTitle = "DETAIL";
        }

        /// <summary>
        /// Ons the navigating to.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            try
            {
                if (parameters.ContainsKey("MOVIE"))
                    Movie = parameters["MOVIE"] as Results;

                UIHelpers.HideLoading();
            }
            catch
            {
                this.BackToPreviousPage();
            }
        }
    }
}

