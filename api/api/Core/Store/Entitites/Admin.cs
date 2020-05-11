namespace api.Core.Store.Entities
{
    public class Admin : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
