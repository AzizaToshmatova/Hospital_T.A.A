namespace Domain.Entities;

public class Doctor : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Experience { get; set; }
    public string Specialty { get; set; }
    public virtual ICollection<Registration> Registrations { get; set; }

}