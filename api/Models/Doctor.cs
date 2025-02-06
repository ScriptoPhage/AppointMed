using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
