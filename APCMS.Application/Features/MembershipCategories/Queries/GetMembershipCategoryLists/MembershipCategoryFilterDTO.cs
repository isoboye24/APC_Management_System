namespace APCMS.Application.Features.MembershipCategories.Queries.GetMembershipCategoryLists
{
    public class MembershipCategoryFilterDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string? Name { get; set; }
    }
}
