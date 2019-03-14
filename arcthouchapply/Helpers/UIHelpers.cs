using Acr.UserDialogs;
using Xamarin.Essentials;

namespace arcthouchapply.Helpers
{
    /// <summary>
    /// UIH elpers.
    /// </summary>
    public static class UIHelpers
    {
        /// <summary>
        /// Shows the loading.
        /// </summary>
        /// <param name="text">Text.</param>
        public static void ShowLoading(string text = null)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                UserDialogs.Instance.ShowLoading(text ?? "Loading", MaskType.Black);
            });
        }

        /// <summary>
        /// Hides the loading.
        /// </summary>
        public static void HideLoading() => UserDialogs.Instance.HideLoading();
    }
}
