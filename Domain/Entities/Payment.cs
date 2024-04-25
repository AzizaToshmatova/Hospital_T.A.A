namespace Domain.Entities;

public class Payment : BaseEntity
{
    public Guid Id { get; set; }
    public float Amount { get; set; }

    public  string Date { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; }
}