namespace WebAPI.Models.DTO.User
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string KeycloakId { get; set; }
    }
}
