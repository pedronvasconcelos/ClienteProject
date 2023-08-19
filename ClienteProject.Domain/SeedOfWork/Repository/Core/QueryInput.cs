namespace ClienteProject.Domain.SeedOfWork.Repository.Core;

public class QueryInput
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string Search { get; set; }
    public string OrderBy { get; set; }
    public QueryOrder Order { get; set; }

    public QueryInput(
        int page,
        int perPage,
        string search,
        string orderBy,
        QueryOrder order)
    {
        Page = page;
        PerPage = perPage;
        Search = search;
        OrderBy = orderBy;
        Order = order;
        if(Page == 0 && PerPage == 0)
        {
            Page = 1;
            PerPage = 15;
        }
    }
}
