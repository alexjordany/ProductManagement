namespace ProductManagement.Domain.Shared;

public class AuditableEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public bool Active { get; set; }
}