using System.Collections;

namespace Domain.Entities;

public class Registration : BaseEntity
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public Guid DoctorId { get; set; }
    public Guid AdminId { get; set; }
    public Guid PatientId { get; set; }
    public Guid PaymentId { get; set; }

    public Doctor? Doctor { get; set; }
    public Admin? Admin { get; set; }
    public Patient? Patient { get; set; }
    public Payment? Payment { get; set; }



}