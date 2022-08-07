namespace SpotifyApplication.Domain.Base
{
    public abstract class AuditableBase : DomainBase
    {
        public DateTime CreatedAt { get; set; }
    }
}
