namespace WebAPI.Models.DTO.User
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string KeycloakId { get; set; }
    }
}
