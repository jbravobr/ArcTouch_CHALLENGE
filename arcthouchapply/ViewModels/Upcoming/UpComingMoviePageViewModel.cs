using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using arcthouchapply.Events;
using arcthouchapply.Helpers;
using arcthouchapply.Models;
using arctouchapply.Services.Contracts;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;

namespace arcthouchapply.ViewModels
{
    public class UpcomingMoviePageViewModel : BaseViewModel
    {
        /// <summary>
        /// Page Loading control
        /// </summary>
        private bool IsPageLoading { get; set; }

        /// <summary>
        /// Current Page from the Movie List
        /// </summary>
        private static long CurrentPage { get; set; }

        /// <summary>
        /// Last Total Pages from the Movie List
        /// </summary>
        private static long LastTotalPage { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:arcthouchapply.ViewModels.UpcomingMoviePageViewModel"/> is loading.
        /// </summary>
        /// <value><c>true</c> if is loading; otherwise, <c>false</c>.</value>
        public bool IsLoading { get; private set; }

        /// <summary>
        /// The search text
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is loading more
        /// </summary>
        public bool IsLoadingMore { get; private set; }

        /// <summary>
        /// Movie Service
        /// </summary>
        protected IMovieService _movieService { get; }

        /// <summary>
        /// Gets the event aggregator.
        /// </summary>
        /// <value>The event aggregator.</value>
        protected IEventAggregator _eventAggregator { get; }

        /// <summary>
        /// IMG URL
        /// </summary>
        private string IMGURL { get; set; }

        /// <summary>
        /// Gets the selected movie command.
        /// </summary>
        /// <value>The selected movie command.</value>
        public DelegateCommand<Syncfusion.ListView.XForms.ItemTappedEventArgs> SelectedMovieCommand { get; private set; }

        /// <summary>
        /// Gets the search Command
        /// </summary>
        public DelegateCommand<string> SearchCommand { get; private set; }

        /// <summary>
        /// List of Genres
        /// </summary>
        /// <value>The genres.</value>
        private List<Genres> Genres { get; set; }

        /// <summary>
        /// List of Movies
        /// </summary>
        public ObservableCollection<Results> Movies { get; set; }

        public UpcomingMoviePageViewModel(INavigationService navigationService,
                                          IPageDialogService pageDialogService,
                                          IMovieService movieService,
                                          IEventAggregator eventAggregator) : base(navigationService, pageDialogService)
        {
            this._eventAggregator = eventAggregator;
            this._movieService = movieService;
            this.PageTitle = "MOVIE LIST";
            this.SelectedMovieCommand = new DelegateCommand<Syncfusion.ListView.XForms.ItemTappedEventArgs>(this.SelectedMovie);
            this.SearchCommand = new DelegateCommand<string>(Search);

            this.RegisterEvents();
        }

        /// <summary>
        /// Registers the events.
        /// </summary>
        private void RegisterEvents() => this._eventAggregator.GetEvent<LoadMoreItensEvent>().Subscribe(LoadMore);

        /// <summary>
        /// Uns the register events.
        /// </summary>
        private void UnRegisterEvents() => this._eventAggregator.GetEvent<LoadMoreItensEvent>().Unsubscribe(LoadMore);

        /// <summary>
        /// Load More movie for the list
        /// </summary>
        private async void LoadMore()
        {
            try
            {
                if (this.IsLoadingMore || this.Movies == null || this.Movies.Count == 0)
                    return;

                this.IsLoadingMore = true;
                string result = string.Empty;

                if (!this.IsPageLoading && LastTotalPage == 0 || !this.IsPageLoading && LastTotalPage >= CurrentPage + 1)
                {
                    if (string.IsNullOrEmpty(this.SearchText))
                    {
                        result = await this._movieService.GetMovieListPagedAsync(CurrentPage + 1);
                        if (!string.IsNullOrEmpty(result))
                        {
                            var root = this.DeserializePayloadFromServices<Root>(result);
                            if (root != null)
                            {
                                CurrentPage = CurrentPage + 1;
                                LastTotalPage = root.TotalPages;
                                await this.GetConfiguration().ContinueWith(async (Task task) =>
                                {
                                    await AssociateGenresWithMovies(root.Results).ContinueWith((Task<List<Results>> arg) =>
                                    {
                                        this.AddMoreMoviesToTheList(this.AddImageLinkAndRemoveRepeated(arg.Result).ToList());
                                    });

                                });
                            }
                        }
                    }
                    else
                        this.Search(this.SearchText);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.IsLoadingMore = false;
            }
        }

        /// <summary>
        /// Add more itens to the Movie List
        /// </summary>
        /// <param name="movies"></param>
        private void AddMoreMoviesToTheList(List<Results> movies)
        {
            movies.ForEach((Results movie) =>
            {
                this.Movies.Add(movie);
            });
        }

        /// <summary>
        /// Selecteds the movie.
        /// </summary>
        /// <param name="selectedMovie">Selected movie.</param>
        private async void SelectedMovie(Syncfusion.ListView.XForms.ItemTappedEventArgs selectedMovie)
        {
            if (selectedMovie == null)
                return;

            this.AddNavigationParameters(new Dictionary<string, object> { { "MOVIE", selectedMovie.ItemData as Results } });
            await this.NavigateRelative(Pages.MovieSelectionPage);
        }

        /// <summary>
        /// Load Data for the page
        /// </summary>
        private async Task LoadData()
        {
            var result = await this._movieService.GetMovieListAsync();
            if (!string.IsNullOrEmpty(result))
            {
                var movies = this.DeserializePayloadFromServices<Root>(result);
                if (movies != null)
                {
                    await this.GetConfiguration().ContinueWith(async (Task task) =>
                    {
                        await AssociateGenresWithMovies(movies.Results).ContinueWith((Task<List<Results>> arg) =>
                        {
                            this.Movies = new ObservableCollection<Results>(this.AddImageLinkAndRemoveRepeated(arg.Result));
                        });

                    });
                }
            }

            this.IsPageLoading = false;
            await Task.CompletedTask;
        }

        /// <summary>
        /// Search for a movie using the passed term
        /// </summary>
        public async void Search(string term)
        {
            try
            {
                if (string.IsNullOrEmpty(term))
                {
                    this.IsLoading = true;
                    await this.LoadData();
                }
                else
                {
                    this.IsLoading = true;
                    var searchResult = await this._movieService.SearchMovieAsync(term, CurrentPage + 1);
                    if (!string.IsNullOrEmpty(searchResult))
                    {
                        var root = this.DeserializePayloadFromServices<Root>(searchResult);
                        if (root != null && root.Results.Count > 0)
                        {
                            await AssociateGenresWithMovies(root.Results).ContinueWith((Task<List<Results>> arg) =>
                            {
                                this.Movies = new ObservableCollection<Results>(this.AddImageLinkAndRemoveRepeated(arg.Result));
                            });
                        }
                        else
                        {
                            await this.ShowAlertAsync(string.Empty, "No results found");
                            this.IsLoading = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Image URL
        /// </summary>
        private async Task GetConfiguration()
        {
            var result = await this._movieService.GetConfigurationAsync();
            if (!string.IsNullOrEmpty(result))
            {
                var config = this.DeserializePayloadFromServices<Root>(result);
                if (config != null && config.Images != null && !string.IsNullOrEmpty(config.Images.BaseUrl))
                {
                    this.IMGURL = config.Images.BaseUrl;
                }
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Adds the image link and remove repeated.
        /// </summary>
        /// <returns>The image link and remove repeated.</returns>
        /// <param name="movies">Movies.</param>
        private IEnumerable<Results> AddImageLinkAndRemoveRepeated(IEnumerable<Results> movies)
        {
            using (var currentMovie = movies.GetEnumerator())
            {
                try
                {
                    while (currentMovie.MoveNext())
                    {
                        if (string.IsNullOrEmpty(currentMovie.Current.FullImagePath) &&
                            !string.IsNullOrEmpty(currentMovie.Current.PosterPath))
                        {
                            currentMovie.Current.FullImagePath = $"{this.IMGURL}w154{currentMovie.Current.PosterPath}";
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    this.IsLoading = false;
                }
            }

            return movies;
        }

        /// <summary>
        /// Take care of the initialization when navigating in
        /// </summary>
        public async override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            this.IsPageLoading = true;
            this.IsLoading = true;
            await this.LoadData();
        }

        ///<summary>
        /// Associates the genres with movies.
        /// </summary>
        /// <param name="movies">Movies.</param>
        public async Task<List<Results>> AssociateGenresWithMovies(List<Results> movies)
        {
            try
            {
                var genresResult = await this._movieService.GetGenresAsync();
                if (!string.IsNullOrEmpty(genresResult))
                {
                    var root = this.DeserializePayloadFromServices<Root>(genresResult);
                    this.Genres = root.Genres;
                }

                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Genres == null || movies[i].Genres.Count == 0)
                        movies[i].Genres = new List<Genres>();

                    for (int j = 0; j < movies[i].GenresIds.Count; j++)
                    {
                        if (movies[i].GenresIds[j] <= 0)
                            continue;

                        var genre = this.Genres.FirstOrDefault(g => g.Id == movies[i].GenresIds[j]);
                        if (genre == null)
                            movies[i].Genres.Add(new Genres { Id = 999, Name = "Undefined" });
                        else
                            movies[i].Genres.Add(genre);
                    }
                }

                return await Task.FromResult(movies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Destroy this instance.
        /// </summary>
        public override void Destroy()
        {
            base.Destroy();
            this.UnRegisterEvents();
        }
    }
}