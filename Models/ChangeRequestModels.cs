namespace AspnetCoreMvcFull.Models   // เปลี่ยนตรงนี้
{
    public class ChangeRequestIndexViewModel
    {
        public SearchCriteriaModel SearchCriteria { get; set; } = new();
        public List<ChangeRequestItemModel> RequestItems { get; set; } = new();
    }

    public class SearchCriteriaModel
    {
        public string? AgencyId { get; set; }
        public string? EntrepreneurName { get; set; }
        public string? Status { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }

    public class ChangeRequestItemModel
    {
        public string Id { get; set; } = "";
        public string DocumentNo { get; set; } = "";
        public string DocumentName { get; set; } = "";
        public string EntrepreneurDetails { get; set; } = "";
        public string Subject { get; set; } = "";
        public DateTime TransactionDate { get; set; }
    }
}