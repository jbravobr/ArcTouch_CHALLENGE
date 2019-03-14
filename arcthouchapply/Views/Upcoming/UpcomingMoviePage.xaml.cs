
using System.Collections;
using arcthouchapply.Events;
using Prism.Events;

namespace arcthouchapply.Views
{
    /// <summary>
    /// Upcoming movie page.
    /// </summary>
    public partial class UpcomingMoviePage : BaseContentPage
    {
        /// <summary>
        /// Gets the event aggregate.
        /// </summary>
        /// <value>The event aggregate.</value>
        protected IEventAggregator _eventAggregator { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:arcthouchapply.Views.UpcomingMoviePage"/> class.
        /// </summary>
        public UpcomingMoviePage(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;

            InitializeComponent();
        }

        /// <summary>
        /// Handles the item appearing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void Handle_ItemAppearing(object sender, Syncfusion.ListView.XForms.ItemAppearingEventArgs e)
        {
            if (listViewMovies.ItemsSource is IList items && e.ItemData == items[items.Count - 1])
            {
                this._eventAggregator.GetEvent<LoadMoreItensEvent>().Publish();
            }
        }
    }
}