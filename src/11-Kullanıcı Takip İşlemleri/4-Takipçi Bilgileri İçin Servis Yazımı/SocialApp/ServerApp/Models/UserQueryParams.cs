namespace ServerApp.Models
{
    public class UserQueryParams
    {
        public int UserId { get; set; }
        public bool Followers { get; set; }=false;
        public bool Followings { get; set; }=false;
    }
}