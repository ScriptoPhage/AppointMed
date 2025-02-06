using api.DTOs.Apnt;
using api.Models;

namespace api.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDTO ToAppointmentDTO(this Appointment appointmentModel)
        {
            return new AppointmentDTO
            {
                Id = appointmentModel.AppointmentId,
                PatientName = appointmentModel.PatientName,
                PatientContactInfo = appointmentModel.PatientContactInfo,
                AppointmentDateAndTime = appointmentModel.AppointmentDateAndTime,
                DoctorId = appointmentModel.DoctorId
            };
        }
        public static Appointment ToAppointmentFromCreateDTO(this CreateAppointmentDTO appointmentDTO)
        {
            return new Appointment
            {
                PatientName = appointmentDTO.PatientName,
                PatientContactInfo = appointmentDTO.PatientContactInfo,
                AppointmentDateAndTime = appointmentDTO.AppointmentDateAndTime,
                DoctorId = appointmentDTO.DoctorId
            };
        }

    }
}
