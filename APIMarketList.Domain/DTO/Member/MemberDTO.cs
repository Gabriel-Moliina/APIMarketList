namespace APIMarketList.Domain.DTO.Member
{
    public class MemberDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool CanUpdate { get; set; }
    }
}
