namespace WorldAround.Domain.Models.Paging;

public class PagingModel
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public int Length { get; set; }

    public bool IsFirstPage => PageIndex == 1;

    public bool HasNextPage => PageIndex < TotalPages;
}
