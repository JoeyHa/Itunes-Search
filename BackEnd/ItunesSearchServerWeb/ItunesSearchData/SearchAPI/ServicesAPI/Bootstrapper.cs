using Microsoft.Extensions.DependencyInjection;

namespace ItunesSearchData
{
    public static class Bootstrapper
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<ISearchService, SearchService>();
        }
    }
}
