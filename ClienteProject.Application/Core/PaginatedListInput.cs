
using ClienteProject.Domain.SeedOfWork.Repository.Core;

namespace ClienteProject.Application.Core;
public abstract class PaginatedListInput
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string Search { get; set; }
    public string Sort { get; set; }
    public QueryOrder Dir { get; set; }
    public PaginatedListInput(
        int page= 1,
        int perPage= 15,
        string search= "",
        string sort= "",
        QueryOrder dir = QueryOrder.Asc)
    {
        Page = page;
        PerPage = perPage;
        Search = search;
        Sort = sort;
        Dir = dir;
    }

    public QueryInput ToSearchInput()
        => new(Page, PerPage, Search, Sort, Dir);
}


