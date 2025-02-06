using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string PatientName { get; set; }

        [Required]
        [Phone]
        public string PatientContactInfo { get; set; }

        [Required]
        public DateTime AppointmentDateAndTime { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor DoctorAppointed { get; set; }

    }
}
