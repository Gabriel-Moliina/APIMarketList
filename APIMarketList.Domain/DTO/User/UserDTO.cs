namespace APIMarketList.Domain.DTO.User
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool CanUpdate { get; set; }
    }
}
