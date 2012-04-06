namespace Molibar.Caching.PostSharp
{
    public enum CacheOptions
    {
        None,

        /// <summary>
        /// Forces repopulation of the cached object.
        /// </summary>
        Refresh
    }
}