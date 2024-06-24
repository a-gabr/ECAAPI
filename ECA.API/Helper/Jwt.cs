namespace ECA.API.Helper
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int DurationInDays { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
