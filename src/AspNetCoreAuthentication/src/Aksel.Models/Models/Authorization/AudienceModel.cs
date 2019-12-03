namespace Aksel.Models.Models.Authorization
{
    public class AudienceModel
    {
        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Aud { get; set; }
    }
}