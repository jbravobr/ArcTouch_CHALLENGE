using System.Collections.Generic;
using arctouchapply.Services.Helpers;
using Flurl;

namespace arctouchapply.Services.Implementations
{
    /// <summary>
    /// Base services.
    /// </summary>
    public abstract class BaseServices
    {
        /// <summary>
        /// The URL.
        /// </summary>
        public virtual Url _url { get; private set; }

        /// <summary>
        /// Create the HTTP client using Flurl
        /// </summary>
        /// <param name="pathSegments"></param>
        /// <param name="queryParams"></param>
        public virtual void CreateHttpCallForApi(object[] pathSegments, object queryParams)
        {
            this._url = new Url(Secrets.IMDBApiURL);

            if (pathSegments != null)
                this._url.AppendPathSegments(pathSegments);

            if (queryParams != null)
                _url.SetQueryParams(queryParams, NullValueHandling.Remove);
        }

        /// <summary>
        /// Create the HTTP client using Flurl
        /// </summary>
        /// <param name="pathSegments"></param>
        /// <param name="queryParams"></param>
        public virtual void CreateHttpCallForApi(object[] pathSegments, Dictionary<string, string> queryParams)
        {
            this._url = new Url(Secrets.IMDBApiURL);

            if (pathSegments != null)
                this._url.AppendPathSegments(pathSegments);

            if (queryParams != null)
            {
                foreach (var item in queryParams)
                {
                    _url.SetQueryParam(item.Key, item.Value, true, NullValueHandling.Remove);
                }
            }
        }
    }
}