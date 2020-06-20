namespace ServerApp.Models
{
    public class UserQueryParams
    {
        public int UserId { get; set; }
        public bool Followers { get; set; }
        public bool Followings { get; set; }
        public string Gender { get; set; }
        public int minAge { get; set; } = 18;
        public int maxAge { get; set; } = 100;
        public string City { get; set; }
        public string Country { get; set; }
        public string OrderBy { get; set; }
    }
}