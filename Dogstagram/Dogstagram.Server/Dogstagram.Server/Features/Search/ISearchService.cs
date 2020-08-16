using Dogstagram.Server.Features.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchServiceModel>> Profile(string query);
    }
}
