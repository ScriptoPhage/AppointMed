using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Apnt
{
    public class UpdateAppointmentDTO
    {
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
    }
}
