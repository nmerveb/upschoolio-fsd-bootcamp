namespace UpSchool.Domain.Entities
{
    //veri tabaniyla baglantili bilgileri entity icinde tanimlariz.
    public class Account
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Url { get; set; }
        public bool IsFavourite { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
