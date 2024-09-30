namespace AppointmentManagementUserApi.Models
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime DateTime { get; set; }
        public string Duration { get; set; }
        public string DescriptionName { get; set; }

        public int UserId { get; set; }
    }
}
