using api.DTOs.Dctr;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Apnt
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string PatientContactInfo { get; set; }

        public DateTime AppointmentDateAndTime { get; set; }

        public int DoctorId { get; set; }
        
    }
}

