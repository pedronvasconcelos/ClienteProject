namespace ClienteProject.Domain.SeedOfWork.Repository.Core;

public class QueryOutput<TAggregate> where TAggregate : AggregateRoot
{
    public int CurrentPage { get; set; }
    public int PerPage { get; set; }
    public int Total { get; set; }
    public IReadOnlyList<TAggregate> Items { get; set; }
    public QueryOutput(
         IReadOnlyList<TAggregate> items,
       int currentPage,
       int perPage,
       int total)
    {
        CurrentPage = currentPage;
        PerPage = perPage;
        Total = total;
        Items = items;
    }
}
