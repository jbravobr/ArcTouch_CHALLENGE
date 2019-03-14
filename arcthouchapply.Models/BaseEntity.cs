using System.ComponentModel;

namespace arcthouchapply.Models
{
    /// <summary>
    /// Base Class
    /// </summary>
    public class BaseEntity : INotifyPropertyChanged
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}