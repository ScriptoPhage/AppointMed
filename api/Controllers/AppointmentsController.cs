using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.Mappers;
using api.DTOs.Apnt;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public AppointmentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {

            var appointments = _context.Appointments.Include(e => e.DoctorAppointed).ToList().Select(s => s.ToAppointmentDTO());
            return Ok(appointments);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment([FromRoute] int id)
        {
            var appointment = await _context.Appointments.Include(e => e.DoctorAppointed)
                .FirstOrDefaultAsync(e => e.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment.ToAppointmentDTO());
        }


        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            if (appointmentDTO == null)
            {
                return BadRequest("Invalid Appointment Data");
            }

            var doctorExists = await _context.Doctors.AnyAsync(d => d.Id == appointmentDTO.DoctorId);
            if (!doctorExists)
            {
                return BadRequest($"No doctor available of ID: {appointmentDTO.DoctorId}");
            }
            if (appointmentDTO.AppointmentDateAndTime <= DateTime.Now)
            {
                return BadRequest($"Date and Time must be in the future");

            }

            var appointment = appointmentDTO.ToAppointmentFromCreateDTO();
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentId }, appointment.ToAppointmentDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] int id, [FromBody] UpdateAppointmentDTO appointmentDTO)
        {

            if (appointmentDTO == null)
            {
                return BadRequest("Provided Appointment data is null");
            }

            var doctorExists = await _context.Doctors.AnyAsync(d => d.Id == appointmentDTO.DoctorId);
            if (!doctorExists)
            {
                return BadRequest($"No doctor available of ID: {appointmentDTO.DoctorId}");
            }
            if (appointmentDTO.AppointmentDateAndTime <= DateTime.Now)
            {
                return BadRequest($"Date and Time must be in the future");

            }
            var appointment = await _context.Appointments.FirstOrDefaultAsync(d => d.AppointmentId == id);
           
            
            if (appointment == null)
            {
                return NotFound();
            }

            appointment.PatientName = appointmentDTO.PatientName;
            appointment.PatientContactInfo = appointmentDTO.PatientContactInfo;
            appointment.AppointmentDateAndTime = appointmentDTO.AppointmentDateAndTime;
            appointment.DoctorId = appointmentDTO.DoctorId;

            await _context.SaveChangesAsync();
            return Ok(appointment.ToAppointmentDTO());
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
