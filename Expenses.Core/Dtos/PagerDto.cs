namespace Expenses.Core.Dtos
{
    public class PagerDto
    {
        public int PageCurrent { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public int TotalRecords { get; set; }
        public int CountPage
        {
            get
            {
                return (int)Math.Ceiling((double)TotalRecords / RecordsPerPage);
            }
        }

        public int TotalRecordsFiltered { get; set; }

        public Object List { get; set; }

        public string Search { get; set; }
        public string SortColumn { get; set; } = "Id";
        public string SortColumnDir { get; set; } = "DESC";
    }

    public class SearchDtoIn
    {
        public int PageCurrent { get; set; }
        public int RecordsPerPage { get; set; }
        public string Search { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
    }
}
