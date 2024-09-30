using System.ComponentModel.DataAnnotations;

namespace AppointmentManagementUserApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
