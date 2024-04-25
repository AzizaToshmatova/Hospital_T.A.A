namespace Domain.Entities;

public class Admin : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Registration> Registrations { get; set; }
    }
