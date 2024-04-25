using System.Collections;

namespace Domain.Entities;

public class Patient : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Registration> Registrations  { get; set; }
 
}